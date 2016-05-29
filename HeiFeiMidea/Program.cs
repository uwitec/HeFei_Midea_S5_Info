using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeiFeiMidea
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.TickCount < 100000)
            {
                System.Threading.Thread.Sleep(15000);//开机，数据库，网络连接等要准备，所以延时15秒给开机用
            }
            //System.Threading.Thread.Sleep(15000);//开机，数据库，网络连接等要准备，所以延时15秒给开机用

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (System.Diagnostics.Process.GetProcessesByName(
                System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                return;
            }
            Application.Run(new frmMain());
        }
    }
}
