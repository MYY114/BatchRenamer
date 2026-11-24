using System;
using System.Threading;
using System.Windows.Forms;

namespace BatchRenamer
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            bool createdNew;
            using (var mutex = new Mutex(true, @"Local\BatchRenamer.SingleInstance.Mutex", out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("批量重命名已经在运行。", "批量重命名",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += (s, e) =>
                    MessageBox.Show("发生未处理错误：\n" + e.Exception.Message, "批量重命名",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Application.Run(new MainForm());
                GC.KeepAlive(mutex);
            }
        }
    }
}