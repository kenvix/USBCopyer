using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace USBCopyer
{
    public partial class donateForm : Form
    {
        public donateForm()
        {
            InitializeComponent();
            Icon = Program.ico;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                try
                {
                    Process.Start("explorer.exe", "\"https://github.com/kenvix/USBCopyer\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开失败：" + ex.ToString());
                }
        }
    }
}
