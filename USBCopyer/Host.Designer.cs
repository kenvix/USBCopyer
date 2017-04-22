using System;

namespace USBCopyer
{
    partial class Host
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.niconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.EnableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.FileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.diskUUIDList = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.HideHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KillCopyThreadStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // nicon
            // 
            this.nicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nicon.BalloonTipText = "已启动";
            this.nicon.BalloonTipTitle = "USBCopyer";
            this.nicon.ContextMenuStrip = this.niconMenu;
            this.nicon.Text = "USBCopyer";
            this.nicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nicon_MouseDoubleClick);
            // 
            // niconMenu
            // 
            this.niconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameMenuItem,
            this.BlogMenuItem,
            this.toolStripSeparator5,
            this.EnableToolStripMenuItem,
            this.KillCopyThreadStripMenuItem,
            this.toolStripSeparator2,
            this.SettingToolStripMenuItem,
            this.toolStripSeparator3,
            this.FileStripMenuItem,
            this.LogToolStripMenuItem,
            this.toolStripSeparator4,
            this.diskUUIDList,
            this.clearLog,
            this.HideHToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitXToolStripMenuItem});
            this.niconMenu.Name = "niconMenu";
            this.niconMenu.Size = new System.Drawing.Size(193, 298);
            this.niconMenu.TabStop = true;
            // 
            // nameMenuItem
            // 
            this.nameMenuItem.Name = "nameMenuItem";
            this.nameMenuItem.Size = new System.Drawing.Size(192, 22);
            this.nameMenuItem.Text = "USBCopyer";
            this.nameMenuItem.Click += new System.EventHandler(this.nameMenuItem_Click);
            // 
            // BlogMenuItem
            // 
            this.BlogMenuItem.Name = "BlogMenuItem";
            this.BlogMenuItem.Size = new System.Drawing.Size(192, 22);
            this.BlogMenuItem.Text = "作者：Kenvix";
            this.BlogMenuItem.Click += new System.EventHandler(this.BlogMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(189, 6);
            // 
            // EnableToolStripMenuItem
            // 
            this.EnableToolStripMenuItem.Checked = true;
            this.EnableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableToolStripMenuItem.Name = "EnableToolStripMenuItem";
            this.EnableToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.EnableToolStripMenuItem.Text = "已启用 (&E)";
            this.EnableToolStripMenuItem.Click += new System.EventHandler(this.EnableToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.SettingToolStripMenuItem.Text = "设置 (&S)";
            this.SettingToolStripMenuItem.Click += new System.EventHandler(this.SettingToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // FileStripMenuItem
            // 
            this.FileStripMenuItem.Name = "FileStripMenuItem";
            this.FileStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.FileStripMenuItem.Text = "查看文件 (&F)";
            this.FileStripMenuItem.Click += new System.EventHandler(this.FileStripMenuItem_Click);
            // 
            // LogToolStripMenuItem
            // 
            this.LogToolStripMenuItem.Name = "LogToolStripMenuItem";
            this.LogToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.LogToolStripMenuItem.Text = "查看日志 (&L)";
            this.LogToolStripMenuItem.Click += new System.EventHandler(this.LogToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(189, 6);
            // 
            // diskUUIDList
            // 
            this.diskUUIDList.Name = "diskUUIDList";
            this.diskUUIDList.Size = new System.Drawing.Size(192, 22);
            this.diskUUIDList.Text = "查看磁盘信息 (&V)";
            this.diskUUIDList.Click += new System.EventHandler(this.diskUUIDList_Click);
            // 
            // clearLog
            // 
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(192, 22);
            this.clearLog.Text = "清除日志 (&C)";
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // HideHToolStripMenuItem
            // 
            this.HideHToolStripMenuItem.Name = "HideHToolStripMenuItem";
            this.HideHToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.HideHToolStripMenuItem.Text = "隐藏图标 (&H)";
            this.HideHToolStripMenuItem.Click += new System.EventHandler(this.HideHToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // ExitXToolStripMenuItem
            // 
            this.ExitXToolStripMenuItem.Name = "ExitXToolStripMenuItem";
            this.ExitXToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ExitXToolStripMenuItem.Text = "退出 (&X)";
            this.ExitXToolStripMenuItem.Click += new System.EventHandler(this.ExitXToolStripMenuItem_Click);
            // 
            // KillCopyThreadStripMenuItem
            // 
            this.KillCopyThreadStripMenuItem.Name = "KillCopyThreadStripMenuItem";
            this.KillCopyThreadStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.KillCopyThreadStripMenuItem.Text = "立即停止复制操作 (&K)";
            this.KillCopyThreadStripMenuItem.Click += new System.EventHandler(this.KillCopyThreadStripMenuItem_Click);
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 353);
            this.Name = "Host";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.niconMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nicon;
        private System.Windows.Forms.ContextMenuStrip niconMenu;
        private System.Windows.Forms.ToolStripMenuItem EnableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideHToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitXToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem FileStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem nameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlogMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem clearLog;
        private System.Windows.Forms.ToolStripMenuItem diskUUIDList;
        private System.Windows.Forms.ToolStripMenuItem KillCopyThreadStripMenuItem;
    }
}