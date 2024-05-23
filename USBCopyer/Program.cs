using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace USBCopyer
{
    static class Program
    {
        public static bool showicon = !Properties.Settings.Default.autorunhide;//true;//修改BUG通过设置项改变自动运行隐藏。
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
                Application.SetCompatibleTextRenderingDefault(false);
                if (!System.IO.Directory.Exists(Host.confdir)) System.IO.Directory.CreateDirectory(Host.confdir);
                bool useUglyUI = false; 
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

                        case "/setting":
                        case "-setting":
                            Thread th = new Thread(() =>
                            {
                                Application.Run(new Setting());
                            });
                            th.SetApartmentState(ApartmentState.STA);
                            th.Start();
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

                        case "/uglyui":
                        case "-uglyui":
                            useUglyUI = true;
                            break;
                    }
                }
                
                if (!useUglyUI)
                    Application.EnableVisualStyles();

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

        /// <summary>
        /// 判断自身是否为管理员权限
        /// </summary>
        /// <returns>是否为管理员权限</returns>
        public static bool isAdminPermission()
        {
            //获得当前登录的Windows用户标示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理员
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查自身是否为管理员权限，并尝试索取
        /// </summary>
        /// <returns></returns>
        public static bool checkAdminPermission(string command = "")
        {
            if(!isAdminPermission())
            {
                if(MessageBox.Show("该操作需要管理员权限才能完成，是否立即以管理员权限重启 " + Application.ProductName + " ?", "需要管理员权限", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    //创建启动对象
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.UseShellExecute = true;
                    startInfo.WorkingDirectory = Environment.CurrentDirectory;
                    startInfo.FileName = Application.ExecutablePath;
                    startInfo.Arguments = command;
                    //设置启动动作,确保以管理员身份运行
                    startInfo.Verb = "runas";
                    try
                    {
                        System.Diagnostics.Process.Start(startInfo);
                        Environment.Exit(140);
                        return true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("操作失败。要继续操作，请先退出，然后以管理员权限运行本程序。\r\n" + ex.Message, "需要管理员权限", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
                return false;
            } 
            else
            {
                return true;
            }
        }
    }
}
