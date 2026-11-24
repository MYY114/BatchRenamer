using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BatchRenamer.Core;

namespace BatchRenamer
{
    public partial class MainForm : Form
    {
        private List<string> _files = new List<string>();
        private List<RenameItem> _items = new List<RenameItem>();
        private List<string[]> _lastBatch;
        private bool _loaded;

        public MainForm()
        {
            InitializeComponent();

            cmbMode.SelectedIndex = 0;
            cmbCase.SelectedIndex = 0;
            UpdateModePanels();

            _lastBatch = UndoStore.Load();
            btnUndo.Enabled = _lastBatch != null && _lastBatch.Count > 0;

            _loaded = true;
            string saved = AppSettings.GetString("rename.folder", string.Empty);
            if (saved.Length > 0 && Directory.Exists(saved)) txtFolder.Text = saved;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "选择要批量重命名的文件夹";
                if (Directory.Exists(txtFolder.Text)) dialog.SelectedPath = txtFolder.Text;
                if (dialog.ShowDialog(this) == DialogResult.OK) txtFolder.Text = dialog.SelectedPath;
            }
        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            if (!_loaded) return;
            AppSettings.Set("rename.folder", txtFolder.Text.Trim());
            RefreshFiles();
        }

        private void Rule_Changed(object sender, EventArgs e)
        {
            if (!_loaded) return;
            RefreshPreview();
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loaded) return;
            UpdateModePanels();
            RefreshPreview();
        }

        private void UpdateModePanels()
        {
            int mode = cmbMode.SelectedIndex;
            pnlReplace.Visible = mode == 0;
            pnlAffix.Visible = mode == 1;
            pnlNumber.Visible = mode == 2;
            pnlRegex.Visible = mode == 3;
            pnlCase.Visible = mode == 4;
        }

        private void RefreshFiles()
        {
            _files = new List<string>();
            string folder = txtFolder.Text.Trim();
            if (folder.Length == 0)
            {
                _items = new List<RenameItem>();
                BindPreview();
                lblStatus.Text = "选择文件夹后自动预览";
                return;
            }
            if (!Directory.Exists(folder))
            {
                _items = new List<RenameItem>();
                BindPreview();
                lblStatus.Text = "文件夹不存在";
                return;
            }

            try
            {
                string filter = txtFilter.Text.Trim();
                string[] patterns = filter.Length == 0
                    ? new[] { "*" }
                    : filter.Split(';').Select(p => p.Trim()).Where(p => p.Length > 0).ToArray();
                if (patterns.Length == 0) patterns = new[] { "*" };

                var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (string pattern in patterns)
                {
                    foreach (string file in Directory.GetFiles(folder, pattern)) set.Add(file);
                }
                _files = set.OrderBy(f => f, StringComparer.OrdinalIgnoreCase).ToList();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "读取失败：" + ex.Message;
                return;
            }
            RefreshPreview();
        }

        private RenameRule BuildRule()
        {
            return new RenameRule
            {
                Mode = (RenameMode)Math.Max(0, cmbMode.SelectedIndex),
                Find = txtFind.Text,
                ReplaceWith = txtReplace.Text,
                IgnoreCase = chkIgnoreCase.Checked,
                Prefix = txtPrefix.Text,
                Suffix = txtSuffix.Text,
                BaseName = txtBaseName.Text,
                Start = (int)numStart.Value,
                Digits = (int)numDigits.Value,
                KeepExtension = chkKeepExt.Checked,
                Pattern = txtPattern.Text,
                RegexReplace = txtRegexReplace.Text,
                CaseOption = Math.Max(0, cmbCase.SelectedIndex)
            };
        }

        private void RefreshPreview()
        {
            _items = RenameEngine.BuildPreview(_files, BuildRule());
            BindPreview();
            int ok = _items.Count(i => i.CanApply);
            lblStatus.Text = string.Format("共 {0} 个文件，可改名 {1} 个", _files.Count, ok);
        }

        private void BindPreview()
        {
            dgvPreview.SuspendLayout();
            dgvPreview.Rows.Clear();
            foreach (var item in _items)
            {
                int index = dgvPreview.Rows.Add(item.OldName, item.NewName, item.Status);
                var cell = dgvPreview.Rows[index].Cells[2];
                if (item.Status == RenameItem.StatusOk)
                    cell.Style.ForeColor = Color.FromArgb(34, 139, 34);
                else if (item.Status == "无变化")
                    cell.Style.ForeColor = Color.Gray;
                else
                    cell.Style.ForeColor = Color.Firebrick;
            }
            dgvPreview.ResumeLayout();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int ok = _items.Count(i => i.CanApply);
            if (ok == 0)
            {
                MessageBox.Show(this, "当前没有可执行的重命名项。", "批量重命名",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(this,
                    string.Format("即将重命名 {0} 个文件。\n可点击「撤销上次」恢复，确定执行吗？", ok),
                    "确认重命名", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            string error;
            var done = RenameEngine.Apply(_items, out error);
            if (done.Count > 0)
            {
                _lastBatch = done;
                UndoStore.Save(done);
                btnUndo.Enabled = true;
            }
            if (error != null)
            {
                MessageBox.Show(this, "部分操作失败，已尽力回滚：\n" + error, "批量重命名",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            lblStatus.Text = string.Format("已重命名 {0} 个文件，可撤销", done.Count);
            RefreshFiles();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (_lastBatch == null || _lastBatch.Count == 0) return;
            string error;
            if (RenameEngine.Undo(_lastBatch, out error))
            {
                int count = _lastBatch.Count;
                _lastBatch = null;
                UndoStore.Clear();
                btnUndo.Enabled = false;
                lblStatus.Text = string.Format("已撤销，{0} 个文件恢复原名", count);
                RefreshFiles();
            }
            else
            {
                MessageBox.Show(this, "撤销失败：" + error, "撤销重命名",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}