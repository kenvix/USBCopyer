using System;
using System.Windows.Forms;

namespace USBCopyer
{
    static class Program
    {
        public static bool showicon = true;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "/hide":
                    case "-hide":
                        showicon = false;
                        break;
                }
            }
            Application.Run(new Host());
        }
    }
}
