using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBCopyer
{
    public partial class EditDir : Form
    {
        public static string input;
        public EditDir(string title,string text,string inputtext)
        {
            InitializeComponent();
            this.Text= title;
            this.label1.Text = text;
            this.textBox1.Text = inputtext;
        }

        private void EditDir_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "请选择一个目录",
                ShowNewFolderButton = true // 是否显示“新建文件夹”按钮
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath; // 获取选定路径
            }
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            input= textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }
    }
}
