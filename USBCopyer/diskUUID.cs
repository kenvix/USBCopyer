using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace USBCopyer
{
    public partial class diskUUID : Form
    {

        public diskUUID()
        {
            InitializeComponent();
            Icon = Program.ico;
            version.Text += Application.ProductVersion;
            getDisk();
        }

        void getDisk()
        {
            string[] logicalDiskList = Directory.GetLogicalDrives();
            diskList.Items.Clear();
            foreach (string logicalDisk in logicalDiskList)
            {
                diskList.Items.Add(logicalDisk.Substring(0, 2));
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            getDisk();
        }

        private string GetDriveTypeDescription(uint driveType)
        {
            switch (driveType)
            {
                case 0: return "未知";
                case 1: return "未格式化";
                case 2: return "可移动磁盘";
                case 3: return "本地磁盘";
                case 4: return "网络驱动器";
                case 5: return "光盘驱动器";
                case 6: return "虚拟磁盘";
                default: return "无法识别";
            }
        }

        private void diskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            thisDiskName.Text = "";
            thisDiskSer.Text = "";
            thisDiskFileSystem.Text = "";
            thisDiskDescription.Text = "";
            try
            {
                string disk = diskList.SelectedItem.ToString() + Path.DirectorySeparatorChar;

                StringBuilder volumeName = new StringBuilder(256);
                StringBuilder fileSystemName = new StringBuilder(256);
                GetVolumeInformation(
                    disk + Path.DirectorySeparatorChar,
                    volumeName,
                    volumeName.Capacity,
                    out uint serialNumber,
                    out uint maxComponentLength,
                    out uint fileSystemFlags,
                    fileSystemName,
                    fileSystemName.Capacity);

                thisDiskID.Text = diskList.SelectedItem.ToString();
                thisDiskID2.Text = disk;
                thisDiskName.Text = volumeName.ToString();
                thisDiskFileSystem.Text = fileSystemName.ToString();
                uint driveType = GetDriveType(disk);
                string driveTypeStr = GetDriveTypeDescription(driveType);
                thisDiskDescription.Text = $"[{driveType}] {driveTypeStr}";
                thisDiskSer.Text = serialNumber.ToString("X8");
            }
            catch (Exception) { }
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool GetVolumeInformation(
        string lpRootPathName,
        StringBuilder lpVolumeNameBuffer,
        int nVolumeNameSize,
        out uint lpVolumeSerialNumber,
        out uint lpMaximumComponentLength,
        out uint lpFileSystemFlags,
        StringBuilder lpFileSystemNameBuffer,
        int nFileSystemNameSize);

        [DllImport("kernel32.dll")]
        static extern uint GetDriveType(string lpRootPathName);
    }
}
