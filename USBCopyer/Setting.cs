using System;
using System.Diagnostics;
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
            blackdisk.Text = Properties.Settings.Default.blackdisk;
            blackid.Text = Properties.Settings.Default.blackid;
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
                if(string.IsNullOrEmpty(sleep.Text))
                {
                    sleep.Text = "0";
                }
                else
                {
                    if (!IsInteger(sleep.Text))
                    {
                        MessageBox.Show("延迟复制时间只能为正整数", "保存设置失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
                Properties.Settings.Default.blackdisk = blackdisk.Text;
                Properties.Settings.Default.blackid = blackid.Text;
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(MessageBox.Show("你可以在 \"开始菜单\" 的 \"启动\" 文件夹创建本程序的快捷方式，然后程序就可以自动启动了。\r\n\r\n如果你想要以隐藏模式启动程序，请右键快捷方式，点击 属性，在 目标 后面加上 /hide，在 USBCopyer.exe 后加上 /hide 即可\r\n\r\n如果你启用了UAC并且因开机时无法获取管理员权限而导致程序无法启动，那么用添加计划任务的方法替代创建快捷方式的方法\r\n\r\n按 确定 打开 \"启动\" 目录，按 取消 返回", "开机启动帮助", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    Process.Start("explorer.exe", Environment.GetFolderPath(Environment.SpecialFolder.Startup));
                }
                catch (Exception) { }
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            host.openPage();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            host.openPage();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("当你插入磁盘时，程序会通知你 \"存储设备已插入\"，磁盘卷标后面的英文字母或数字即为磁盘序列号。如 F: - A636F053 则表示磁盘序列号为 A636F053\r\n你可以在程序日志中找到序列号\r\n\r\n使用磁盘序列号可以明确指定不复制某个磁盘，而分区号只能指定不复制某个分区。你可以使用磁盘序列号黑名单来实现从自动一个U盘复制文件到另一个U盘", "获取磁盘序列号");
        }
    }
}
