using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeiFeiMideaPlayer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        { 

            //ZebraPrintHelper.PrintWithDRV(buff, "ZDesigner 105SLPlus-300dpi ZPL", false);

            All.Class.Process.Kill("Rename.exe");
            //if (System.Diagnostics.Process.GetProcessesByName(
            //    System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length <= 0)
            //{
            //if (System.IO.File.Exists(string.Format("{0}\\RemotListen.Exe", All.Class.FileIO.GetNowPath())))
            //{
            //    if (System.Diagnostics.Process.GetProcessesByName("RemotListen").Length <= 0)
            //    {
            //        remotListen = System.Diagnostics.Process.Start(string.Format("{0}\\RemotListen.Exe", All.Class.FileIO.GetNowPath()), "");
            //    }
            //}
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    Application.Run(new frmDelay());
                }
                catch (Exception e)
                {
                    All.Class.Error.AddUnKonwError(e);
                }
            //}
        }
    }
}
