using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace USBCopyer
{
    public partial class Setting : Form
    {
        public Host host;

        public Setting()
        {
            InitializeComponent();
            version.Text += Application.ProductVersion;
            dir.Text = Properties.Settings.Default.dir;
            conflict.SelectedIndex = Properties.Settings.Default.conflict;
            autorm.Checked = Properties.Settings.Default.autorm;
            hidemsg.Checked = Properties.Settings.Default.hidemsg;
            sleep.Text = Properties.Settings.Default.sleep.ToString();
            mode.SelectedIndex = Properties.Settings.Default.mode;
            black.Text = Properties.Settings.Default.black;
            white.Text = Properties.Settings.Default.white;
            copynoext.Checked = Properties.Settings.Default.copynoext;
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
            try
            {
                if(!IsInteger(sleep.Text))
                {
                    MessageBox.Show("延迟复制时间只能为正整数", "保存设置失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Properties.Settings.Default.dir = dir.Text;
                Properties.Settings.Default.conflict = conflict.SelectedIndex;
                Properties.Settings.Default.autorm = autorm.Checked;
                Properties.Settings.Default.hidemsg = hidemsg.Checked;
                Properties.Settings.Default.sleep = int.Parse(sleep.Text);
                Properties.Settings.Default.mode = mode.SelectedIndex;
                Properties.Settings.Default.black = black.Text;
                Properties.Settings.Default.white = white.Text;
                Properties.Settings.Default.copynoext = copynoext.Checked;
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "保存设置失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("USBCopyer.exe [/hide] \r\n\r\n /hide     以隐藏模式启动，只能通过任务管理器结束进程","命令行帮助");
        }

        public static bool IsInteger(string s)
        {
            string pattern = @"^\d*$";
            return Regex.IsMatch(s, pattern);
        }

    }
}
