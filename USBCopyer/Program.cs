using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace USBCopyer
{
    static class Program
    {
        public static bool showicon = true;
        public static EventLog logger = new EventLog();
        public static System.Drawing.Icon ico = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            logger.Source = Application.ProductName;
            try
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

                        case "/gui":
                        case "-gui":
                            showicon = true;
                            break;

                        case "/reset":
                        case "-reset":
                            try
                            {
                                Properties.Settings.Default.Reset();
                                Properties.Settings.Default.Save();
                                Environment.Exit(0);
                            }
                            catch (Exception)
                            {
                                Environment.Exit(1);
                            }
                            break;
                    }
                }
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
                //处理UI线程异常
                Application.ThreadException += new ThreadExceptionEventHandler((object sender, ThreadExceptionEventArgs e) =>
                {
                    log("程序遇到未处理的异常：" + e.Exception.ToString());
                });
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((object sender, UnhandledExceptionEventArgs e) =>
                {
                    log("程序遇到未处理的异常：" + e.ExceptionObject.ToString());
                });
                Application.Run(new Host());
            }
            catch(Exception ex)
            {
                log("程序遇到致命异常：" + ex.ToString(), 2);
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="str">日志内容</param>
        /// <param name="type">日志类型（0=INFO,1=WARN,2=ERROR）</param>
        public static void log(string str, int type = 0)
        {
            EventLogEntryType etype;
            switch (type)
            {
                case 0:
                    etype = EventLogEntryType.Information;
                    break;
                case 1:
                    etype = EventLogEntryType.Warning;
                    break;
                case 2:
                    etype = EventLogEntryType.Error;
                    break;
                default:
                    etype = EventLogEntryType.Information;
                    break;
            }
            Console.Write(str);
            logger.WriteEntry(str, etype);
        }
    }
}
