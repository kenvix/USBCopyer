using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Management;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace USBCopyer
{
    public partial class Host : Form
    {
        public string title   = "USBCopyer";
        public string dir     = Application.StartupPath + @"\USBCopyerData\";
        public string[] white;
        public string[] black;
        public FileStream logf;
        public StreamWriter logw;
        public Host()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.dir))
            {
                dir = Properties.Settings.Default.dir + "\\";
            }
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                logf = File.Open(dir + ".log", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                logw = new StreamWriter(logf);
                logw.BaseStream.Seek(0, SeekOrigin.End);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title + " 初始化失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(1);
            }
            nameMenuItem.Text += " V" + Application.ProductVersion;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.black))
            {
                black = Properties.Settings.Default.black.Split(',');
            } else
            {
                black = new string[0];
            }
            if(!string.IsNullOrEmpty(Properties.Settings.Default.white))
            {
                white = Properties.Settings.Default.white.Split(',');
            } else
            {
                white = new string[0];
            }
            if (Program.hide)
            {
                nicon.Visible = false;
            }
            msg("运行中: " + DateTime.Now.ToString());
        }

        public void msg(string str, string t = "")
        {
            string tit = string.IsNullOrEmpty(t) ? title : title + " - " + t;
            if (nicon.Visible && !Properties.Settings.Default.hidemsg)
            {
                nicon.ShowBalloonTip(1000, tit, str, ToolTipIcon.Info);
            }
            log(tit + "：" + str);
        }

        public void error(string msg, string title = "错误")
        {
            log(title + "：" + msg.Replace("\r\n", " "),2);
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void success(string msg, string title = "操作完成")
        {
            log(title + "：" + msg.Replace("\r\n", " "));
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="str">日志内容</param>
        /// <param name="type">日志类型（0=INFO,1=WARN,2=ERROR）</param>
        public void log(string str, int type = 0)
        {
            string typet;
            switch(type)
            {
                case 0:
                    typet = "INFO";
                    break;
                case 1:
                    typet = "WARN";
                    break;
                case 2:
                    typet = "ERROR";
                    break;
                default:
                    typet = "UNKNOWN";
                    break;
            }
            string logtext = "["+DateTime.Now.ToString()+"]"+"["+typet+"] "+str+"\r\n";
            Console.Write(logtext);
            logw.WriteLine(logtext);
            logw.Flush();
        }

        private void ExitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == 0x0219 && EnableToolStripMenuItem.Checked)
            {
                string disk = string.Empty;
                switch (m.WParam.ToInt32())
                {
                    case 0x8000:
                    {
                            DEV_BROADCAST_HDR dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));

                            if (dbhdr.dbch_devicetype == 0x00000002)
                            {
                                DEV_BROADCAST_VOLUME dbv = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
                                if (dbv.dbcv_flags == 0)
                                {
                                    char[] volums = GetVolumes(dbv.dbcv_unitmask);
                                    disk += volums[0].ToString() + ":";
                                    ManagementObject diskinfo = new ManagementObject("win32_logicaldisk.deviceid=\""+disk+"\"");
                                    string diskser = diskinfo.Properties["VolumeSerialNumber"].Value.ToString();
                                    msg(disk + " - " + diskser, "存储设备已插入");
                                    Thread th = new Thread(() =>
                                    {
                                        if(Properties.Settings.Default.sleep > 0)
                                        {
                                            log("延迟复制：将在 " + Properties.Settings.Default.sleep + "秒后进行复制");
                                            Thread.Sleep(Properties.Settings.Default.sleep * 1000);
                                            if(!Directory.Exists(disk + "\\"))
                                            {
                                                log("在延迟复制期间存储设备已拔出，复制取消：" + disk + " - " + diskser);
                                                return;
                                            }
                                        }
                                        if(Properties.Settings.Default.autorm && Directory.Exists(dir + diskser))
                                        {
                                            log("清空输出目录：" + dir + diskser);
                                            Directory.Delete(dir + diskser, true);
                                        }
                                        CopyDirectory(disk + "\\", dir + diskser);
                                        log("设备数据复制完成：" + disk + " - " + diskser);
                                    });
                                    th.Start();
                                }
                            }
                            break;
                    }
                    case 0x8004:
                    {
                            DEV_BROADCAST_HDR dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                            if (dbhdr.dbch_devicetype == 0x00000002)
                            {
                                DEV_BROADCAST_VOLUME dbv = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
                                if (dbv.dbcv_flags == 0)
                                {
                                    try
                                    {
                                        char[] volums = GetVolumes(dbv.dbcv_unitmask);
                                        disk = disk.Replace(volums[0] + ",", "");
                                        ManagementObject diskinfo = new ManagementObject("win32_logicaldisk.deviceid=\""+disk+"\"");
                                        string diskser = diskinfo.Properties["VolumeSerialNumber"].Value.ToString();
                                        msg(disk + " - " + diskser, "存储设备已拔出");
                                    }
                                    catch(Exception ex)
                                    {
                                        log("获取拔出的设备失败，设备可能被强制拔出：" + ex.ToString());
                                    }
                                }
                            }
                            break;
                     }
                }
            }
            base.DefWndProc(ref m);
        }

        /// <summary>
        /// 根据驱动器掩码返回驱动器号数组
        /// </summary>
        /// <param name="Mask">掩码</param>
        /// <returns>返回驱动器号数组</returns>
        public static char[] GetVolumes(UInt32 Mask)
        {
            List<char> Volumes = new List<char>();

            for (int i = 0; i < 32; i++)
            {
                uint p = (uint)Math.Pow(2, i);
                if ((p | Mask) == p)
                {
                    Volumes.Add((char)('A' + i));
                }
            }

            return Volumes.ToArray();
        }

        private void EnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableToolStripMenuItem.Checked = EnableToolStripMenuItem.Checked ? false : true;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct DEV_BROADCAST_HDR
        {
            public UInt32 dbch_size;
            public UInt32 dbch_devicetype;
            public UInt32 dbch_reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct DEV_BROADCAST_VOLUME
        {
            public UInt32 dbcv_size;
            public UInt32 dbcv_devicetype;
            public UInt32 dbcv_reserved;
            public UInt32 dbcv_unitmask;
            public UInt16 dbcv_flags;
        }

        /// <summary>
        /// 复制文件夹（及文件夹下所有子文件夹和文件）
        /// </summary>
        /// <param name="sourcePath">待复制的文件夹路径</param>
        /// <param name="destinationPath">目标路径</param>
        public void CopyDirectory(String sourcePath, String destinationPath)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(sourcePath);
                Directory.CreateDirectory(destinationPath);
                foreach (FileSystemInfo fsi in info.GetFileSystemInfos())
                {
                    String destName = Path.Combine(destinationPath, fsi.Name);

                    if (fsi is FileInfo)
                    {   //如果是文件，复制文件
                        try
                        {
                            FileInfo fi1 = new FileInfo(fsi.FullName);
                            if(checkExt(fi1.Extension))
                            {
                                log("复制文件：" + destName);
                                if (File.Exists(destName))
                                {
                                    switch (Properties.Settings.Default.conflict)
                                    {
                                        case 0:
                                            FileInfo fi2 = new FileInfo(destName);
                                            if (fi1.LastWriteTime > fi2.LastWriteTime)
                                            {
                                                File.Copy(fsi.FullName, destName, true);
                                            }
                                            break;
                                        case 1:
                                            destName = (new Random()).Next(0, 9999999) + "-" + destName;
                                            File.Copy(fsi.FullName, destName);
                                            break;
                                        case 2:
                                            File.Copy(fsi.FullName, destName, true);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    File.Copy(fsi.FullName, destName);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log("复制文件：" + destName + "：失败：" + ex.ToString());
                        }
                    }
                    else //如果是文件夹，新建文件夹，递归
                    {
                        try
                        {
                            Directory.CreateDirectory(destName);
                            CopyDirectory(fsi.FullName, destName);
                        }
                        catch (Exception ex)
                        {
                            log("创建目录："+destName+"：失败：" + ex.ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                log("复制目录失败，设备可能被强行拔出：" + ex.ToString());
            }
        }

        private bool checkExt(string ext)
        {
            if (string.IsNullOrEmpty(ext) && Properties.Settings.Default.copynoext) return true;
            string extn = ext.Substring(1);
            switch(Properties.Settings.Default.mode)
            {
                case 1: //黑
                    if(black.Contains(extn))
                    {
                        return false;
                    }
                    return true;
                case 2: //白
                    if (white.Contains(extn))
                    {
                        return true;
                    }
                    return false;
                default:
                    return true;
            }
        }

        private void HideHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nicon.Visible = nicon.Visible ? false : true;
        }

        private void LogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openLogFile();
        }

        public void openLogFile()
        {
            try
            {
                Process.Start(dir + ".log");
            }
            catch (Exception)
            {
                try
                {
                    Process.Start("notepad.exe", "\"" + dir + ".log" + "\"");
                }
                catch (Exception ex)
                {
                    error("打开日志文件失败：" + ex.ToString());
                }
            }
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Setting dia = new Setting();
                dia.host = this;
                Application.Run(dia);
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void FileStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        public void openFile()
        {
            try
            {
                Process.Start("explorer.exe", "\"" + dir + "\"");
            }
            catch (Exception ex)
            {
                error("打开失败：" + ex.ToString());
            }
        }

        public void openBlog()
        {
            try
            {
                Process.Start("explorer.exe", "http://zhizhe8.net/");
            }
            catch (Exception ex)
            {
                error("打开失败：" + ex.ToString());
            }
        }

        private void BlogMenuItem_Click(object sender, EventArgs e)
        {
            openBlog();
        }
    }
}
