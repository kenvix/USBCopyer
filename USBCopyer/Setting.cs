using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;

namespace USBCopyer
{
    public partial class Setting : Form
    {
        public Host host;

        public Setting()
        {
            InitializeComponent();
            Icon = Program.ico;
            version.Text += Application.ProductVersion;
            Text += Program.isAdminPermission() ? " (管理员)" : " (低权限模式)";
            dir.Text = Properties.Settings.Default.dir;
            conflict.SelectedIndex = Properties.Settings.Default.conflict;
            autorm.Checked = Properties.Settings.Default.autorm;
            hidemsg.Checked = Properties.Settings.Default.hidemsg;
            sleep.Text = Properties.Settings.Default.sleep.ToString();
            mode.SelectedIndex = Properties.Settings.Default.mode;
            filesizetype.SelectedIndex = Properties.Settings.Default.filesizetype;
            filesize.Text = Properties.Settings.Default.filesize.ToString();
            black.Text = Properties.Settings.Default.black;
            white.Text = Properties.Settings.Default.white;
            copynoext.Checked = Properties.Settings.Default.copynoext;
            blackdisk.Text = Properties.Settings.Default.blackdisk;
            blackid.Text = Properties.Settings.Default.blackid;
            autorunhide.Checked = Properties.Settings.Default.autorunhide;
            multirun.Checked = Properties.Settings.Default.multirun;

            SkipDVD.Checked = Properties.Settings.Default.SkipDVD;
            SkipUDisk.Checked = Properties.Settings.Default.SkipUDisk;
            SkipNetworkDisk.Checked = Properties.Settings.Default.SkipNetworkDisk;
            SkipOtherDisk.Checked = Properties.Settings.Default.SkipOtherDisk;
            SkipLocalDisk.Checked = Properties.Settings.Default.SkipLocalDisk;
            EnableAllCompletedCallback.Checked = Properties.Settings.Default.EnableAllCompletedCallback;
            EnableDiskDetectedCallback.Checked = Properties.Settings.Default.EnableDiskDetectedCallback;
            WaitCallback.Checked = Properties.Settings.Default.WaitCallback;
            SkipEmptyFolder.Checked = Properties.Settings.Default.SkipEmptyFolder;
            if (Properties.Settings.Default.UseBlackDisk) DiskModeBlack.Checked = true;
            else DiskModeWhite.Checked = true;
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

        protected void Save_Config()
        {
            try
            {
                if (string.IsNullOrEmpty(sleep.Text))
                {
                    sleep.Text = "0";
                }
                if (string.IsNullOrEmpty(filesize.Text))
                {
                    filesize.Text = "0";
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
                Properties.Settings.Default.multirun = multirun.Checked;
                Properties.Settings.Default.autorunhide = autorunhide.Checked;
                Properties.Settings.Default.filesizetype = filesizetype.SelectedIndex;
                Properties.Settings.Default.filesize = int.Parse(filesize.Text);
                if (!string.IsNullOrEmpty(Properties.Settings.Default.dir))
                {
                    if (!Directory.Exists(Properties.Settings.Default.dir))
                    {
                        Directory.CreateDirectory(Properties.Settings.Default.dir);
                    }
                    Host.dir = Properties.Settings.Default.dir + "\\";
                }

                Properties.Settings.Default.SkipDVD = SkipDVD.Checked;
                Properties.Settings.Default.SkipUDisk = SkipUDisk.Checked;
                Properties.Settings.Default.SkipNetworkDisk = SkipNetworkDisk.Checked;
                Properties.Settings.Default.SkipOtherDisk = SkipOtherDisk.Checked;
                Properties.Settings.Default.SkipLocalDisk = SkipLocalDisk.Checked;
                Properties.Settings.Default.SkipEmptyFolder = SkipEmptyFolder.Checked;
                Properties.Settings.Default.EnableAllCompletedCallback = EnableAllCompletedCallback.Checked;
                Properties.Settings.Default.EnableDiskDetectedCallback = EnableDiskDetectedCallback.Checked;
                Properties.Settings.Default.WaitCallback = WaitCallback.Checked;
                if (DiskModeBlack.Checked) Properties.Settings.Default.UseBlackDisk = true;
                else if (DiskModeWhite.Checked) Properties.Settings.Default.UseBlackDisk = false;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存设置失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save_Config();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("USBCopyer.exe [/hide] [/gui] [/reset] \r\n\r\n /hide     以隐藏模式启动，只能通过任务管理器结束进程\r\n /gui      除非使用 /hide 参数，否则无论如何都不要使用隐藏模式启动\r\n /reset     恢复默认设置并退出，若失败，返回退出码1\r\n\r\n例如，以下命令使USBCopyer以隐藏模式启动：\r\nUSBCopyer.exe /hide", "命令行帮助");
        }

        public static bool IsInteger(string s)
        {
            string pattern = @"^\d*$";
            return Regex.IsMatch(s, pattern);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult doReset = MessageBox.Show("将会重置所有设置项，确定吗？", "重设确认", MessageBoxButtons.OKCancel);
            if(doReset == DialogResult.OK) Properties.Settings.Default.Reset();
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new diskUUID()).Show();
        }

        private void conflict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void autorunButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Program.checkAdminPermission("/setting")) return;
                Properties.Settings.Default.autorunhide = autorunhide.Checked;
                Properties.Settings.Default.Save();
                RegistryKey run = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (run.GetValue("USBCopyer") == null || !run.GetValue("USBCopyer").ToString().Contains(Application.ExecutablePath))
                {
                    if (autorunhide.Checked)
                    {
                        run.SetValue("USBCopyer", Application.ExecutablePath + " /autorun /hide");
                    }
                    else
                    {
                        run.SetValue("USBCopyer", Application.ExecutablePath + " /autorun");
                    }
                    MessageBox.Show("设置开机启动成功\r\n\r\n注意：任务管理器或杀毒软件可能会阻止 USBCopyer 的开机自启动", "设置开机启动成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    run.DeleteValue("USBCopyer");
                    MessageBox.Show("取消开机启动成功", "取消开机启动成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置开机启动失败，此操作可能已被杀毒软件拦截\r\n\r\n" + ex.ToString(), "设置开机启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new donateForm()).Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            (new donateForm()).Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("当你要把USBCopyer用作自动备份特定U盘的工具，请使用白名单模式\r\n白名单模式下，只有预先设置好的U盘才会被USBCopyer复制\r\n\r\n当你要把USBCopyer用作偷U盘文件的工具，请使用黑名单模式\r\n黑名单模式下，USBCopyer会复制除预先设置好的U盘以外的全部U盘\r\n\r\n另外，分区号和序列号是“或”的关系，只要有一者符合即命中","黑白名单模式帮助",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new donateForm()).Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("选项“分区号(盘符)”解释\r\n在此处填写你想要应用黑/白名单模式的盘符\r\n用半角逗号(,)分割，只写一个字母即可。如 H 表示不复制 H 盘\r\neg: 你可以将DVD驱动器的盘符（假设为G:\\）加入黑名单来防止复制DVD驱动器，只需填入 G 即可\r\n\r\n选项“序列号”解释\r\n在此处填写磁盘序列号，每一个磁盘都有唯一的序列号，使用此功能来精确复制特定磁盘\r\n使用USBCopyer右键菜单的 “查看磁盘信息” 功能获取磁盘序列号", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", "\"https://kenvix.com/post/usbcopyer-callback/\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开失败：" + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save_Config();
            try
            {
                Process.Start("cmd.exe", "/c title Restarting USBCopyer && echo Killing USBCopyer && taskkill /f /pid " + Process.GetCurrentProcess().Id + " && echo Starting USBCopyer && start \"\" \"" + Application.ExecutablePath + "\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show("快速重启失败:\r\n" + ex.Message);
            }
        }

        protected void Set_type(string x)
        {
            black.Text = white.Text = x;
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_type.SelectedIndex)
            {
                case 1:
                    Set_type("doc,docx,pdf");
                    break;
                case 2:
                    Set_type("mp4,mkv,avi");
                    break;
                case 3:
                    Set_type("zip,rar,7z");
                    break;
                case 4:
                    Set_type("png,jpg,bmp");
                    break;
                default:
                    Set_type("");
                    break;
            }
        }
    }
}
