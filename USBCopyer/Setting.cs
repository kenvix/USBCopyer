using System;
using System.IO;
using System.Windows.Forms;

namespace USBCopyer
{
    public partial class Setting : Form
    {
        public Host host;

        public Setting()
        {
            InitializeComponent();
            dir.Text = Properties.Settings.Default.dir;
            conflict.SelectedIndex = Properties.Settings.Default.conflict;
            autorm.Checked = Properties.Settings.Default.autorm;
            hidemsg.Checked = Properties.Settings.Default.hidemsg;
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            host.openLogFile();
        }

        private void dirDialogButton_Click(object sender, EventArgs e)
        {
            if(folderBrowser.ShowDialog() == DialogResult.OK)
            {
                dir.Text = folderBrowser.SelectedPath;
            }
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            host.openFile();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            host.openBlog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dir = dir.Text;
            Properties.Settings.Default.conflict = conflict.SelectedIndex;
            Properties.Settings.Default.autorm = autorm.Checked;
            Properties.Settings.Default.hidemsg = hidemsg.Checked;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.dir))
            {
                if (!Directory.Exists(Properties.Settings.Default.dir))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.dir);
                }
                host.dir = Properties.Settings.Default.dir + "\\";
            }
            Properties.Settings.Default.Save();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("USBCopyer.exe [/hide] \r\n\r\n /hide     以隐藏模式启动，只能通过任务管理器结束进程","命令行帮助");
        }
    }
}
