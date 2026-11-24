namespace BatchRenamer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilterHint = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.grpRule = new System.Windows.Forms.GroupBox();
            this.pnlReplace = new System.Windows.Forms.Panel();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lblReplace = new System.Windows.Forms.Label();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.pnlAffix = new System.Windows.Forms.Panel();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.lblAffixHint = new System.Windows.Forms.Label();
            this.pnlNumber = new System.Windows.Forms.Panel();
            this.lblBase = new System.Windows.Forms.Label();
            this.txtBaseName = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.lblDigits = new System.Windows.Forms.Label();
            this.numDigits = new System.Windows.Forms.NumericUpDown();
            this.chkKeepExt = new System.Windows.Forms.CheckBox();
            this.pnlRegex = new System.Windows.Forms.Panel();
            this.lblPattern = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.lblRReplace = new System.Windows.Forms.Label();
            this.txtRegexReplace = new System.Windows.Forms.TextBox();
            this.lblRegexHint = new System.Windows.Forms.Label();
            this.pnlCase = new System.Windows.Forms.Panel();
            this.lblCase = new System.Windows.Forms.Label();
            this.cmbCase = new System.Windows.Forms.ComboBox();
            this.lblCaseHint = new System.Windows.Forms.Label();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.colOld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpRule.SuspendLayout();
            this.pnlReplace.SuspendLayout();
            this.pnlAffix.SuspendLayout();
            this.pnlNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigits)).BeginInit();
            this.pnlRegex.SuspendLayout();
            this.pnlCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(12, 20);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(44, 15);
            this.lblFolder.TabIndex = 0;
            this.lblFolder.Text = "文件夹";
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(64, 16);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(676, 23);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(752, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(76, 27);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "浏览…";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(12, 54);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 15);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "筛选";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(64, 50);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(150, 23);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.TextChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblFilterHint
            // 
            this.lblFilterHint.AutoSize = true;
            this.lblFilterHint.ForeColor = System.Drawing.Color.Gray;
            this.lblFilterHint.Location = new System.Drawing.Point(222, 54);
            this.lblFilterHint.Name = "lblFilterHint";
            this.lblFilterHint.Size = new System.Drawing.Size(200, 15);
            this.lblFilterHint.TabIndex = 5;
            this.lblFilterHint.Text = "如 *.jpg;*.png（留空=全部）";
            // 
            // lblMode
            // 
            this.lblMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(642, 54);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(32, 15);
            this.lblMode.TabIndex = 6;
            this.lblMode.Text = "模式";
            // 
            // cmbMode
            // 
            this.cmbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "查找替换",
            "添加前后缀",
            "序号重命名",
            "正则替换",
            "大小写转换"});
            this.cmbMode.Location = new System.Drawing.Point(684, 50);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(144, 23);
            this.cmbMode.TabIndex = 7;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // grpRule
            // 
            this.grpRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRule.Controls.Add(this.pnlReplace);
            this.grpRule.Controls.Add(this.pnlAffix);
            this.grpRule.Controls.Add(this.pnlNumber);
            this.grpRule.Controls.Add(this.pnlRegex);
            this.grpRule.Controls.Add(this.pnlCase);
            this.grpRule.Location = new System.Drawing.Point(12, 84);
            this.grpRule.Name = "grpRule";
            this.grpRule.Size = new System.Drawing.Size(816, 106);
            this.grpRule.TabIndex = 8;
            this.grpRule.TabStop = false;
            this.grpRule.Text = "规则";
            // 
            // pnlReplace
            // 
            this.pnlReplace.Controls.Add(this.lblFind);
            this.pnlReplace.Controls.Add(this.txtFind);
            this.pnlReplace.Controls.Add(this.lblReplace);
            this.pnlReplace.Controls.Add(this.txtReplace);
            this.pnlReplace.Controls.Add(this.chkIgnoreCase);
            this.pnlReplace.Location = new System.Drawing.Point(8, 24);
            this.pnlReplace.Name = "pnlReplace";
            this.pnlReplace.Size = new System.Drawing.Size(800, 70);
            this.pnlReplace.TabIndex = 0;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(8, 16);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(32, 15);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "查找";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(52, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(230, 23);
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(300, 16);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(44, 15);
            this.lblReplace.TabIndex = 2;
            this.lblReplace.Text = "替换为";
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(356, 12);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(230, 23);
            this.txtReplace.TabIndex = 3;
            this.txtReplace.TextChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Location = new System.Drawing.Point(610, 14);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(87, 19);
            this.chkIgnoreCase.TabIndex = 4;
            this.chkIgnoreCase.Text = "忽略大小写";
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            this.chkIgnoreCase.CheckedChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // pnlAffix
            // 
            this.pnlAffix.Controls.Add(this.lblPrefix);
            this.pnlAffix.Controls.Add(this.txtPrefix);
            this.pnlAffix.Controls.Add(this.lblSuffix);
            this.pnlAffix.Controls.Add(this.txtSuffix);
            this.pnlAffix.Controls.Add(this.lblAffixHint);
            this.pnlAffix.Location = new System.Drawing.Point(8, 24);
            this.pnlAffix.Name = "pnlAffix";
            this.pnlAffix.Size = new System.Drawing.Size(800, 70);
            this.pnlAffix.TabIndex = 1;
            this.pnlAffix.Visible = false;
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(8, 16);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(32, 15);
            this.lblPrefix.TabIndex = 0;
            this.lblPrefix.Text = "前缀";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(52, 12);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(230, 23);
            this.txtPrefix.TabIndex = 1;
            this.txtPrefix.TextChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Location = new System.Drawing.Point(300, 16);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(32, 15);
            this.lblSuffix.TabIndex = 2;
            this.lblSuffix.Text = "后缀";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(356, 12);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(230, 23);
            this.txtSuffix.TabIndex = 3;
            this.txtSuffix.TextChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblAffixHint
            // 
            this.lblAffixHint.AutoSize = true;
            this.lblAffixHint.ForeColor = System.Drawing.Color.Gray;
            this.lblAffixHint.Location = new System.Drawing.Point(610, 16);
            this.lblAffixHint.Name = "lblAffixHint";
            this.lblAffixHint.Size = new System.Drawing.Size(100, 15);
            this.lblAffixHint.TabIndex = 4;
            this.lblAffixHint.Text = "后缀在扩展名前";
            // 
            // pnlNumber
            // 
            this.pnlNumber.Controls.Add(this.lblBase);
            this.pnlNumber.Controls.Add(this.txtBaseName);
            this.pnlNumber.Controls.Add(this.lblStart);
            this.pnlNumber.Controls.Add(this.numStart);
            this.pnlNumber.Controls.Add(this.lblDigits);
            this.pnlNumber.Controls.Add(this.numDigits);
            this.pnlNumber.Controls.Add(this.chkKeepExt);
            this.pnlNumber.Location = new System.Drawing.Point(8, 24);
            this.pnlNumber.Name = "pnlNumber";
            this.pnlNumber.Size = new System.Drawing.Size(800, 70);
            this.pnlNumber.TabIndex = 2;
            this.pnlNumber.Visible = false;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(8, 16);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(32, 15);
            this.lblBase.TabIndex = 0;
            this.lblBase.Text = "基名";
            // 
            // txtBaseName
            // 
            this.txtBaseName.Location = new System.Drawing.Point(52, 12);
            this.txtBaseName.Name = "txtBaseName";
            this.txtBaseName.Size = new System.Drawing.Size(180, 23);
            this.txtBaseName.TabIndex = 1;
            this.txtBaseName.Text = "file";
            this.txtBaseName.TextChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(250, 16);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(56, 15);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "起始序号";
            // 
            // numStart
            // 
            this.numStart.Location = new System.Drawing.Point(312, 12);
            this.numStart.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(70, 23);
            this.numStart.TabIndex = 3;
            this.numStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStart.ValueChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblDigits
            // 
            this.lblDigits.AutoSize = true;
            this.lblDigits.Location = new System.Drawing.Point(400, 16);
            this.lblDigits.Name = "lblDigits";
            this.lblDigits.Size = new System.Drawing.Size(32, 15);
            this.lblDigits.TabIndex = 4;
            this.lblDigits.Text = "位数";
            // 
            // numDigits
            // 
            this.numDigits.Location = new System.Drawing.Point(444, 12);
            this.numDigits.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numDigits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDigits.Name = "numDigits";
            this.numDigits.Size = new System.Drawing.Size(55, 23);
            this.numDigits.TabIndex = 5;
            this.numDigits.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numDigits.ValueChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // chkKeepExt
            // 
            this.chkKeepExt.AutoSize = true;
            this.chkKeepExt.Checked = true;
            this.chkKeepExt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepExt.Location = new System.Drawing.Point(515, 14);
            this.chkKeepExt.Name = "chkKeepExt";
            this.chkKeepExt.Size = new System.Drawing.Size(99, 19);
            this.chkKeepExt.TabIndex = 6;
            this.chkKeepExt.Text = "保留原扩展名";
            this.chkKeepExt.UseVisualStyleBackColor = true;
            this.chkKeepExt.CheckedChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // pnlRegex
            // 
            this.pnlRegex.Controls.Add(this.lblPattern);
            this.pnlRegex.Controls.Add(this.txtPattern);
            this.pnlRegex.Controls.Add(this.lblRReplace);
            this.pnlRegex.Controls.Add(this.txtRegexReplace);
            this.pnlRegex.Controls.Add(this.lblRegexHint);
            this.pnlRegex.Location = new System.Drawing.Point(8, 24);
            this.pnlRegex.Name = "pnlRegex";
            this.pnlRegex.Size = new System.Drawing.Size(800, 70);
            this.pnlRegex.TabIndex = 3;
            this.pnlRegex.Visible = false;
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.Location = new System.Drawing.Point(8, 16);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(32, 15);
            this.lblPattern.TabIndex = 0;
            this.lblPattern.Text = "正则";
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(52, 12);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(270, 23);
            this.txtPattern.TabIndex = 1;
            this.txtPattern.TextChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblRReplace
            // 
            this.lblRReplace.AutoSize = true;
            this.lblRReplace.Location = new System.Drawing.Point(336, 16);
            this.lblRReplace.Name = "lblRReplace";
            this.lblRReplace.Size = new System.Drawing.Size(44, 15);
            this.lblRReplace.TabIndex = 2;
            this.lblRReplace.Text = "替换为";
            // 
            // txtRegexReplace
            // 
            this.txtRegexReplace.Location = new System.Drawing.Point(392, 12);
            this.txtRegexReplace.Name = "txtRegexReplace";
            this.txtRegexReplace.Size = new System.Drawing.Size(220, 23);
            this.txtRegexReplace.TabIndex = 3;
            this.txtRegexReplace.TextChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblRegexHint
            // 
            this.lblRegexHint.AutoSize = true;
            this.lblRegexHint.ForeColor = System.Drawing.Color.Gray;
            this.lblRegexHint.Location = new System.Drawing.Point(628, 16);
            this.lblRegexHint.Name = "lblRegexHint";
            this.lblRegexHint.Size = new System.Drawing.Size(70, 15);
            this.lblRegexHint.TabIndex = 4;
            this.lblRegexHint.Text = "支持 $1 分组";
            // 
            // pnlCase
            // 
            this.pnlCase.Controls.Add(this.lblCase);
            this.pnlCase.Controls.Add(this.cmbCase);
            this.pnlCase.Controls.Add(this.lblCaseHint);
            this.pnlCase.Location = new System.Drawing.Point(8, 24);
            this.pnlCase.Name = "pnlCase";
            this.pnlCase.Size = new System.Drawing.Size(800, 70);
            this.pnlCase.TabIndex = 4;
            this.pnlCase.Visible = false;
            // 
            // lblCase
            // 
            this.lblCase.AutoSize = true;
            this.lblCase.Location = new System.Drawing.Point(8, 16);
            this.lblCase.Name = "lblCase";
            this.lblCase.Size = new System.Drawing.Size(32, 15);
            this.lblCase.TabIndex = 0;
            this.lblCase.Text = "转换";
            // 
            // cmbCase
            // 
            this.cmbCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCase.FormattingEnabled = true;
            this.cmbCase.Items.AddRange(new object[] {
            "全部大写",
            "全部小写",
            "单词首字母大写"});
            this.cmbCase.Location = new System.Drawing.Point(52, 12);
            this.cmbCase.Name = "cmbCase";
            this.cmbCase.Size = new System.Drawing.Size(190, 23);
            this.cmbCase.TabIndex = 1;
            this.cmbCase.SelectedIndexChanged += new System.EventHandler(this.Rule_Changed);
            // 
            // lblCaseHint
            // 
            this.lblCaseHint.AutoSize = true;
            this.lblCaseHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCaseHint.Location = new System.Drawing.Point(256, 16);
            this.lblCaseHint.Name = "lblCaseHint";
            this.lblCaseHint.Size = new System.Drawing.Size(110, 15);
            this.lblCaseHint.TabIndex = 2;
            this.lblCaseHint.Text = "仅改文件名主体";
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.AllowUserToResizeRows = false;
            this.dgvPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOld,
            this.colNew,
            this.colState});
            this.dgvPreview.Location = new System.Drawing.Point(12, 202);
            this.dgvPreview.MultiSelect = false;
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.RowTemplate.Height = 25;
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(816, 294);
            this.dgvPreview.TabIndex = 9;
            // 
            // colOld
            // 
            this.colOld.FillWeight = 45F;
            this.colOld.HeaderText = "原文件名";
            this.colOld.Name = "colOld";
            this.colOld.ReadOnly = true;
            // 
            // colNew
            // 
            this.colNew.FillWeight = 45F;
            this.colNew.HeaderText = "新文件名";
            this.colNew.Name = "colNew";
            this.colNew.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.FillWeight = 12F;
            this.colState.HeaderText = "状态";
            this.colState.MinimumWidth = 70;
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.Location = new System.Drawing.Point(12, 554);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(116, 30);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "应用重命名";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(136, 554);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(96, 30);
            this.btnUndo.TabIndex = 11;
            this.btnUndo.Text = "撤销上次";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblStatus.Location = new System.Drawing.Point(248, 560);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(140, 15);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "选择文件夹后自动预览";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 600);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.dgvPreview);
            this.Controls.Add(this.grpRule);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.lblFilterHint);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.lblFolder);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(760, 540);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量重命名";
            this.grpRule.ResumeLayout(false);
            this.pnlReplace.ResumeLayout(false);
            this.pnlReplace.PerformLayout();
            this.pnlAffix.ResumeLayout(false);
            this.pnlAffix.PerformLayout();
            this.pnlNumber.ResumeLayout(false);
            this.pnlNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigits)).EndInit();
            this.pnlRegex.ResumeLayout(false);
            this.pnlRegex.PerformLayout();
            this.pnlCase.ResumeLayout(false);
            this.pnlCase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilterHint;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.GroupBox grpRule;
        private System.Windows.Forms.Panel pnlReplace;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.Panel pnlAffix;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblSuffix;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label lblAffixHint;
        private System.Windows.Forms.Panel pnlNumber;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.TextBox txtBaseName;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.Label lblDigits;
        private System.Windows.Forms.NumericUpDown numDigits;
        private System.Windows.Forms.CheckBox chkKeepExt;
        private System.Windows.Forms.Panel pnlRegex;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label lblRReplace;
        private System.Windows.Forms.TextBox txtRegexReplace;
        private System.Windows.Forms.Label lblRegexHint;
        private System.Windows.Forms.Panel pnlCase;
        private System.Windows.Forms.Label lblCase;
        private System.Windows.Forms.ComboBox cmbCase;
        private System.Windows.Forms.Label lblCaseHint;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOld;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblStatus;
    }
}