namespace USBCopyer
{
    partial class Setting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.saveButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.dir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dirDialogButton = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.conflict = new System.Windows.Forms.ComboBox();
            this.fileButton = new System.Windows.Forms.Button();
            this.autorm = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.hidemsg = new System.Windows.Forms.CheckBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copynoext = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.white = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.black = new System.Windows.Forms.TextBox();
            this.mode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sleep = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel10 = new System.Windows.Forms.LinkLabel();
            this.DiskModeWhite = new System.Windows.Forms.RadioButton();
            this.DiskModeBlack = new System.Windows.Forms.RadioButton();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.label20 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.blackid = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.blackdisk = new System.Windows.Forms.TextBox();
            this.autorunhide = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.multirun = new System.Windows.Forms.CheckBox();
            this.autorunButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.filesize = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.filesizetype = new System.Windows.Forms.ComboBox();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SkipEmptyFolder = new System.Windows.Forms.CheckBox();
            this.SkipOtherDisk = new System.Windows.Forms.CheckBox();
            this.SkipLocalDisk = new System.Windows.Forms.CheckBox();
            this.SkipUDisk = new System.Windows.Forms.CheckBox();
            this.SkipDVD = new System.Windows.Forms.CheckBox();
            this.SkipNetworkDisk = new System.Windows.Forms.CheckBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.linkLabel11 = new System.Windows.Forms.LinkLabel();
            this.WaitCallback = new System.Windows.Forms.CheckBox();
            this.EnableDiskDetectedCallback = new System.Windows.Forms.CheckBox();
            this.EnableAllCompletedCallback = new System.Windows.Forms.CheckBox();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.lb_type = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(661, 504);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(96, 30);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "保存设置 (&S)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(661, 540);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(99, 30);
            this.logButton.TabIndex = 1;
            this.logButton.Text = "查看日志 (&L)";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // dir
            // 
            this.dir.Location = new System.Drawing.Point(84, 9);
            this.dir.Name = "dir";
            this.dir.Size = new System.Drawing.Size(350, 21);
            this.dir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "存储目录：";
            // 
            // dirDialogButton
            // 
            this.dirDialogButton.Location = new System.Drawing.Point(440, 7);
            this.dirDialogButton.Name = "dirDialogButton";
            this.dirDialogButton.Size = new System.Drawing.Size(75, 23);
            this.dirDialogButton.TabIndex = 4;
            this.dirDialogButton.Text = "浏览 ...";
            this.dirDialogButton.UseVisualStyleBackColor = true;
            this.dirDialogButton.Click += new System.EventHandler(this.dirDialogButton_Click);
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "请选择一个文件夹用于存储从存储设备自动复制的文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "文件冲突解决方案：";
            // 
            // conflict
            // 
            this.conflict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conflict.FormattingEnabled = true;
            this.conflict.Items.AddRange(new object[] {
            "若版本较新，则覆盖",
            "重命名新文件",
            "直接覆盖",
            "跳过"});
            this.conflict.Location = new System.Drawing.Point(141, 82);
            this.conflict.Name = "conflict";
            this.conflict.Size = new System.Drawing.Size(314, 20);
            this.conflict.TabIndex = 6;
            this.conflict.SelectedIndexChanged += new System.EventHandler(this.conflict_SelectedIndexChanged);
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(532, 540);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(123, 30);
            this.fileButton.TabIndex = 7;
            this.fileButton.Text = "查看文件 (&F)";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // autorm
            // 
            this.autorm.AutoSize = true;
            this.autorm.Location = new System.Drawing.Point(460, 19);
            this.autorm.Name = "autorm";
            this.autorm.Size = new System.Drawing.Size(300, 16);
            this.autorm.TabIndex = 8;
            this.autorm.Text = "如果之前已经复制过，则先清空旧的复制结果再复制";
            this.autorm.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel1.Location = new System.Drawing.Point(88, 605);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "作者：Kenvix";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(491, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "留空表示存放到当前程序运行目录下面的 USBCopyerData 文件夹。文件夹内使用设备ID分类";
            // 
            // hidemsg
            // 
            this.hidemsg.AutoSize = true;
            this.hidemsg.Location = new System.Drawing.Point(536, 11);
            this.hidemsg.Name = "hidemsg";
            this.hidemsg.Size = new System.Drawing.Size(96, 16);
            this.hidemsg.TabIndex = 12;
            this.hidemsg.Text = "隐藏程序通知";
            this.hidemsg.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel2.Location = new System.Drawing.Point(397, 606);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(113, 12);
            this.linkLabel2.TabIndex = 13;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "命令行参数帮助 (&H)";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_type);
            this.groupBox1.Controls.Add(this.cb_type);
            this.groupBox1.Controls.Add(this.copynoext);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.white);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.black);
            this.groupBox1.Controls.Add(this.mode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 200);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "按扩展名选择性复制";
            // 
            // copynoext
            // 
            this.copynoext.AutoSize = true;
            this.copynoext.Location = new System.Drawing.Point(357, 24);
            this.copynoext.Name = "copynoext";
            this.copynoext.Size = new System.Drawing.Size(132, 16);
            this.copynoext.TabIndex = 22;
            this.copynoext.Text = "复制无扩展名的文件";
            this.copynoext.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(281, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "每个扩展名用半角逗号(,)分割，前面不需要加点(.)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(316, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "先选择工作模式再填写黑白名单";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "白名单扩展名：";
            // 
            // white
            // 
            this.white.Location = new System.Drawing.Point(105, 88);
            this.white.Name = "white";
            this.white.Size = new System.Drawing.Size(384, 21);
            this.white.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "黑名单扩展名：";
            // 
            // black
            // 
            this.black.Location = new System.Drawing.Point(105, 53);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(384, 21);
            this.black.TabIndex = 15;
            // 
            // mode
            // 
            this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode.FormattingEnabled = true;
            this.mode.Items.AddRange(new object[] {
            "复制所有文件",
            "黑名单模式",
            "白名单模式"});
            this.mode.Location = new System.Drawing.Point(105, 22);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(230, 20);
            this.mode.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "模式：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(227, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "延迟复制：当插入 USB 存储设备后，延迟";
            // 
            // sleep
            // 
            this.sleep.Location = new System.Drawing.Point(255, 114);
            this.sleep.MaxLength = 9;
            this.sleep.Name = "sleep";
            this.sleep.Size = new System.Drawing.Size(135, 21);
            this.sleep.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(396, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "秒再复制";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(171, 606);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(29, 12);
            this.version.TabIndex = 18;
            this.version.Text = "Ver.";
            // 
            // linkLabel9
            // 
            this.linkLabel9.AutoSize = true;
            this.linkLabel9.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel9.Location = new System.Drawing.Point(359, 606);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(29, 12);
            this.linkLabel9.TabIndex = 19;
            this.linkLabel9.TabStop = true;
            this.linkLabel9.Text = "重设";
            this.linkLabel9.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel9_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 606);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "//";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel4.Location = new System.Drawing.Point(13, 605);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(59, 12);
            this.linkLabel4.TabIndex = 21;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "USBCopyer";
            this.linkLabel4.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel5.Location = new System.Drawing.Point(292, 607);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(53, 12);
            this.linkLabel5.TabIndex = 22;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "检查更新";
            this.linkLabel5.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel10);
            this.groupBox2.Controls.Add(this.DiskModeWhite);
            this.groupBox2.Controls.Add(this.DiskModeBlack);
            this.groupBox2.Controls.Add(this.linkLabel7);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.linkLabel3);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.blackid);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.blackdisk);
            this.groupBox2.Location = new System.Drawing.Point(12, 395);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 199);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "磁盘黑/白名单设置";
            // 
            // linkLabel10
            // 
            this.linkLabel10.AutoSize = true;
            this.linkLabel10.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel10.Location = new System.Drawing.Point(10, 165);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(209, 12);
            this.linkLabel10.TabIndex = 30;
            this.linkLabel10.TabStop = true;
            this.linkLabel10.Text = "序列号和分区号有什么区别？怎么用？";
            this.linkLabel10.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel10_LinkClicked);
            // 
            // DiskModeWhite
            // 
            this.DiskModeWhite.AutoSize = true;
            this.DiskModeWhite.Location = new System.Drawing.Point(194, 78);
            this.DiskModeWhite.Name = "DiskModeWhite";
            this.DiskModeWhite.Size = new System.Drawing.Size(83, 16);
            this.DiskModeWhite.TabIndex = 29;
            this.DiskModeWhite.TabStop = true;
            this.DiskModeWhite.Text = "白名单模式";
            this.DiskModeWhite.UseVisualStyleBackColor = true;
            // 
            // DiskModeBlack
            // 
            this.DiskModeBlack.AutoSize = true;
            this.DiskModeBlack.Location = new System.Drawing.Point(105, 78);
            this.DiskModeBlack.Name = "DiskModeBlack";
            this.DiskModeBlack.Size = new System.Drawing.Size(83, 16);
            this.DiskModeBlack.TabIndex = 28;
            this.DiskModeBlack.TabStop = true;
            this.DiskModeBlack.Text = "黑名单模式";
            this.DiskModeBlack.UseVisualStyleBackColor = true;
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel7.Location = new System.Drawing.Point(352, 78);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(137, 12);
            this.linkLabel7.TabIndex = 27;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "这两种模式有什么区别？";
            this.linkLabel7.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel7_LinkClicked);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 78);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 24;
            this.label20.Text = "模式：";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel3.Location = new System.Drawing.Point(322, 165);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(167, 12);
            this.linkLabel3.TabIndex = 26;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "查看磁盘信息 获取序列号 (&V)";
            this.linkLabel3.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked_1);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 26;
            this.label15.Text = "序列号：";
            // 
            // blackid
            // 
            this.blackid.Location = new System.Drawing.Point(105, 137);
            this.blackid.Name = "blackid";
            this.blackid.Size = new System.Drawing.Size(384, 21);
            this.blackid.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "分区号(盘符)：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(485, 36);
            this.label13.TabIndex = 23;
            this.label13.Text = "不复制(黑名单模式)或只复制(白名单模式)某些分区号或序列号的数据\r\n\r\n用半角逗号(,)分割，只写一个字母即可。如 H 表示 H 盘。分区号和序列号的关系为 \"" +
    "或\"";
            // 
            // blackdisk
            // 
            this.blackdisk.Location = new System.Drawing.Point(105, 105);
            this.blackdisk.MaxLength = 51;
            this.blackdisk.Name = "blackdisk";
            this.blackdisk.Size = new System.Drawing.Size(384, 21);
            this.blackdisk.TabIndex = 23;
            // 
            // autorunhide
            // 
            this.autorunhide.AutoSize = true;
            this.autorunhide.Location = new System.Drawing.Point(15, 55);
            this.autorunhide.Name = "autorunhide";
            this.autorunhide.Size = new System.Drawing.Size(108, 16);
            this.autorunhide.TabIndex = 25;
            this.autorunhide.Text = "以隐藏模式启动";
            this.autorunhide.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(227, 60);
            this.label16.TabIndex = 23;
            this.label16.Text = "以隐藏模式启动将看不到图标\r\n\r\n若要停止或调整USBCopyer的设置，请在任\r\n\r\n务管理器中结束USBCopyer的进程";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = global::USBCopyer.Properties.Resources.GPL_Logo;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = global::USBCopyer.Properties.Resources.GPL_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(670, 580);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 39);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // multirun
            // 
            this.multirun.AutoSize = true;
            this.multirun.Location = new System.Drawing.Point(536, 33);
            this.multirun.Name = "multirun";
            this.multirun.Size = new System.Drawing.Size(132, 16);
            this.multirun.TabIndex = 27;
            this.multirun.Text = "允许多重运行(多开)";
            this.multirun.UseVisualStyleBackColor = true;
            // 
            // autorunButton
            // 
            this.autorunButton.Location = new System.Drawing.Point(15, 22);
            this.autorunButton.Name = "autorunButton";
            this.autorunButton.Size = new System.Drawing.Size(228, 23);
            this.autorunButton.TabIndex = 28;
            this.autorunButton.Text = "设置/取消 开机自动启动 (&A)";
            this.autorunButton.UseVisualStyleBackColor = true;
            this.autorunButton.Click += new System.EventHandler(this.autorunButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(149, 12);
            this.label17.TabIndex = 29;
            this.label17.Text = "大小限制：只复制文件大小";
            // 
            // filesize
            // 
            this.filesize.Location = new System.Drawing.Point(269, 143);
            this.filesize.MaxLength = 9;
            this.filesize.Name = "filesize";
            this.filesize.Size = new System.Drawing.Size(121, 21);
            this.filesize.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(396, 148);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "MB 的文件";
            // 
            // filesizetype
            // 
            this.filesizetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filesizetype.FormattingEnabled = true;
            this.filesizetype.Items.AddRange(new object[] {
            "不限制",
            "大于",
            "小于"});
            this.filesizetype.Location = new System.Drawing.Point(174, 143);
            this.filesizetype.Name = "filesizetype";
            this.filesizetype.Size = new System.Drawing.Size(89, 20);
            this.filesizetype.TabIndex = 23;
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel6.Font = new System.Drawing.Font("宋体", 12F);
            this.linkLabel6.LinkColor = System.Drawing.Color.DarkViolet;
            this.linkLabel6.Location = new System.Drawing.Point(529, 580);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(152, 16);
            this.linkLabel6.TabIndex = 32;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "捐赠 USBCopyer (&D)";
            this.linkLabel6.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel6_LinkClicked_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SkipEmptyFolder);
            this.groupBox3.Controls.Add(this.SkipOtherDisk);
            this.groupBox3.Controls.Add(this.SkipLocalDisk);
            this.groupBox3.Controls.Add(this.SkipUDisk);
            this.groupBox3.Controls.Add(this.SkipDVD);
            this.groupBox3.Controls.Add(this.SkipNetworkDisk);
            this.groupBox3.Controls.Add(this.autorm);
            this.groupBox3.Location = new System.Drawing.Point(12, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(758, 117);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "复制选项";
            // 
            // SkipEmptyFolder
            // 
            this.SkipEmptyFolder.AutoSize = true;
            this.SkipEmptyFolder.Location = new System.Drawing.Point(622, 85);
            this.SkipEmptyFolder.Name = "SkipEmptyFolder";
            this.SkipEmptyFolder.Size = new System.Drawing.Size(126, 16);
            this.SkipEmptyFolder.TabIndex = 14;
            this.SkipEmptyFolder.Text = "不要复制 空文件夹";
            this.SkipEmptyFolder.UseVisualStyleBackColor = true;
            // 
            // SkipOtherDisk
            // 
            this.SkipOtherDisk.AutoSize = true;
            this.SkipOtherDisk.Location = new System.Drawing.Point(622, 63);
            this.SkipOtherDisk.Name = "SkipOtherDisk";
            this.SkipOtherDisk.Size = new System.Drawing.Size(144, 16);
            this.SkipOtherDisk.TabIndex = 13;
            this.SkipOtherDisk.Text = "不要复制其他特殊磁盘";
            this.SkipOtherDisk.UseVisualStyleBackColor = true;
            // 
            // SkipLocalDisk
            // 
            this.SkipLocalDisk.AutoSize = true;
            this.SkipLocalDisk.Location = new System.Drawing.Point(622, 42);
            this.SkipLocalDisk.Name = "SkipLocalDisk";
            this.SkipLocalDisk.Size = new System.Drawing.Size(138, 16);
            this.SkipLocalDisk.TabIndex = 12;
            this.SkipLocalDisk.Text = "不要复制 硬盘驱动器";
            this.SkipLocalDisk.UseVisualStyleBackColor = true;
            // 
            // SkipUDisk
            // 
            this.SkipUDisk.AutoSize = true;
            this.SkipUDisk.Location = new System.Drawing.Point(460, 85);
            this.SkipUDisk.Name = "SkipUDisk";
            this.SkipUDisk.Size = new System.Drawing.Size(168, 16);
            this.SkipUDisk.TabIndex = 11;
            this.SkipUDisk.Text = "不要复制 可移动磁盘(U盘)";
            this.SkipUDisk.UseVisualStyleBackColor = true;
            // 
            // SkipDVD
            // 
            this.SkipDVD.AutoSize = true;
            this.SkipDVD.Location = new System.Drawing.Point(460, 63);
            this.SkipDVD.Name = "SkipDVD";
            this.SkipDVD.Size = new System.Drawing.Size(162, 16);
            this.SkipDVD.TabIndex = 10;
            this.SkipDVD.Text = "不要复制 光盘和虚拟光驱";
            this.SkipDVD.UseVisualStyleBackColor = true;
            // 
            // SkipNetworkDisk
            // 
            this.SkipNetworkDisk.AutoSize = true;
            this.SkipNetworkDisk.Location = new System.Drawing.Point(460, 42);
            this.SkipNetworkDisk.Name = "SkipNetworkDisk";
            this.SkipNetworkDisk.Size = new System.Drawing.Size(138, 16);
            this.SkipNetworkDisk.TabIndex = 9;
            this.SkipNetworkDisk.Text = "不要复制 网络驱动器";
            this.SkipNetworkDisk.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(423, 333);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 12);
            this.label19.TabIndex = 27;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.autorunButton);
            this.groupBox4.Controls.Add(this.autorunhide);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(520, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 154);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "开机自动启动";
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel8.Location = new System.Drawing.Point(530, 607);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(53, 12);
            this.linkLabel8.TabIndex = 35;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "开源信息";
            this.linkLabel8.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel8_LinkClicked);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.linkLabel11);
            this.groupBox5.Controls.Add(this.WaitCallback);
            this.groupBox5.Controls.Add(this.EnableDiskDetectedCallback);
            this.groupBox5.Controls.Add(this.EnableAllCompletedCallback);
            this.groupBox5.Location = new System.Drawing.Point(520, 357);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 141);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "高级功能";
            // 
            // linkLabel11
            // 
            this.linkLabel11.AutoSize = true;
            this.linkLabel11.LinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel11.Location = new System.Drawing.Point(9, 118);
            this.linkLabel11.Name = "linkLabel11";
            this.linkLabel11.Size = new System.Drawing.Size(197, 12);
            this.linkLabel11.TabIndex = 31;
            this.linkLabel11.TabStop = true;
            this.linkLabel11.Text = "这是什么？有什么用处？如何使用？";
            this.linkLabel11.VisitedLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel11.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel11_LinkClicked);
            // 
            // WaitCallback
            // 
            this.WaitCallback.AutoSize = true;
            this.WaitCallback.Location = new System.Drawing.Point(11, 91);
            this.WaitCallback.Name = "WaitCallback";
            this.WaitCallback.Size = new System.Drawing.Size(240, 16);
            this.WaitCallback.TabIndex = 14;
            this.WaitCallback.Text = "(回调2)等待完成，并只允许返回0时复制";
            this.WaitCallback.UseVisualStyleBackColor = true;
            // 
            // EnableDiskDetectedCallback
            // 
            this.EnableDiskDetectedCallback.AutoSize = true;
            this.EnableDiskDetectedCallback.Location = new System.Drawing.Point(11, 57);
            this.EnableDiskDetectedCallback.Name = "EnableDiskDetectedCallback";
            this.EnableDiskDetectedCallback.Size = new System.Drawing.Size(180, 28);
            this.EnableDiskDetectedCallback.TabIndex = 13;
            this.EnableDiskDetectedCallback.Text = "回调2：启用 找到新磁盘回调\r\nDiskDetectedCallback";
            this.EnableDiskDetectedCallback.UseVisualStyleBackColor = true;
            // 
            // EnableAllCompletedCallback
            // 
            this.EnableAllCompletedCallback.AutoSize = true;
            this.EnableAllCompletedCallback.Location = new System.Drawing.Point(12, 23);
            this.EnableAllCompletedCallback.Name = "EnableAllCompletedCallback";
            this.EnableAllCompletedCallback.Size = new System.Drawing.Size(192, 28);
            this.EnableAllCompletedCallback.TabIndex = 12;
            this.EnableAllCompletedCallback.Text = "回调1：启用 全部复制完成回调\r\nAllCompletedCallback";
            this.EnableAllCompletedCallback.UseVisualStyleBackColor = true;
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "空",
            "文档",
            "视频",
            "压缩包",
            "图片"});
            this.cb_type.Location = new System.Drawing.Point(105, 124);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(230, 20);
            this.cb_type.TabIndex = 23;
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Location = new System.Drawing.Point(10, 124);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(41, 12);
            this.lb_type.TabIndex = 24;
            this.lb_type.Text = "类型：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 30);
            this.button1.TabIndex = 37;
            this.button1.Text = "保存设置并重启";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 631);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.linkLabel8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.linkLabel6);
            this.Controls.Add(this.filesizetype);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.filesize);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.multirun);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel9);
            this.Controls.Add(this.version);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.sleep);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.hidemsg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.conflict);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dirDialogButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dir);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 602);
            this.Name = "Setting";
            this.Text = "USBCopyer 设置";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.TextBox dir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dirDialogButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox conflict;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.CheckBox autorm;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox hidemsg;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox white;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox black;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox sleep;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.CheckBox copynoext;
        private System.Windows.Forms.LinkLabel linkLabel9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox blackid;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox blackdisk;
        private System.Windows.Forms.CheckBox autorunhide;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox multirun;
        private System.Windows.Forms.Button autorunButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox filesize;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox filesizetype;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox SkipUDisk;
        private System.Windows.Forms.CheckBox SkipDVD;
        private System.Windows.Forms.CheckBox SkipNetworkDisk;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton DiskModeWhite;
        private System.Windows.Forms.RadioButton DiskModeBlack;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.LinkLabel linkLabel10;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.LinkLabel linkLabel11;
        private System.Windows.Forms.CheckBox WaitCallback;
        private System.Windows.Forms.CheckBox EnableDiskDetectedCallback;
        private System.Windows.Forms.CheckBox EnableAllCompletedCallback;
        private System.Windows.Forms.CheckBox SkipOtherDisk;
        private System.Windows.Forms.CheckBox SkipLocalDisk;
        private System.Windows.Forms.CheckBox SkipEmptyFolder;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Button button1;
    }
}

