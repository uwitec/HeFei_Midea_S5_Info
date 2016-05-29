using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace HeiFeiMideaPlayer
{
    public partial class frmDelay :All.Window.BaseWindow
    {

        frmMain mMain = new frmMain();
        Thread ThFlushCode;
        public frmDelay()
        {
            InitializeComponent();
        }
        private void frmDelay_Load(object sender, EventArgs e)
        {
            mMain.FormClosed += mMain_FormClosed;

            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;

            Init();

            frmMain.mMain.LoadLocal();
            frmMain.mMain.AllMeterData.AllReadValue.StringValue.ChangeValue += StringValue_ChangeValue;
            frmMain.mMain.FlushLocal();
            ThFlushCode = new Thread(() => FlushCode());
            ThFlushCode.IsBackground = true;
            ThFlushCode.Start();
        }

        void mMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Init()
        {
            lblCode.Text = string.Format("V{0}", HeiFeiMideaDll.cProgramCode.GetExeCode(new string[] { "HeiFeiMideaPlayer.exe" },"99.99.99.99")["HeiFeiMideaPlayer.exe"]);
            lblCopyRight.Text = string.Format("All CopyRight © 2015-{0:yyyy} By ShuaiShuai", DateTime.Now);
            lblIpAddress.Text = string.Format("IP地址：{0}", All.Class.HardInfo.GetIpAddress("192.168.1"));
            btnOver.Visible = All.Class.HardInfo.MyTestComputer();
        }
        delegate void FlushInfoHandle(string info);
        private void FlushInfo(string info)
        {
            if (lblInfo.InvokeRequired)
            {
                lblInfo.Invoke(new FlushInfoHandle(FlushInfo), info);
            }
            else
            {
                lblInfo.Text = info;
            }
        }
        private void FlushCode()
        {
            while (true)
            {
                Dictionary<string, string> buff = HeiFeiMideaDll.cProgramCode.GetExeCode(cMain.AllFile,"999.999.999.999");
                buff.Add("RandomNumForNewValueChange", string.Format("{0:F5}", All.Class.Num.GetRandom(0, 10000)));
                frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(
                    All.Class.SSFile.Dictionary2Text(buff), 6);
                Thread.Sleep(1000);
            }
        }
        private void StringValue_ChangeValue(string Value, string OldValue, string Info, int index)
        {
            switch (index)
            {
                case 2:
                    ThFlushCode.Abort();
                    FlushInfo("主机连接成功，开始检测程序版本。。。");
                    Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(Value);
                    bool downFile = false;
                    for (int i = 0; i < buff.Count; i++)
                    {
                        string file = buff.Keys.ToList()[i];
                        bool update = All.Class.Num.ToBool(buff[file]);
                        if (update || (file != "RandomNumForNewValueChange" && !System.IO.File.Exists(string.Format("{0}\\{1}", All.Class.FileIO.GetNowPath(), file))))
                        {
                            Thread.Sleep(500);
                            if (cMain.DownOnlyOneTime.ToList().FindIndex(
                                tmpFile =>
                                {
                                    return tmpFile == file;
                                }) < 0 || !System.IO.File.Exists(string.Format("{0}\\{1}", All.Class.FileIO.GetNowPath(), file)))
                            {
                                downFile = true;
                                FlushInfo(string.Format("正在更新文件{0},请稍候。。。", file));
                                All.Class.DownLoadFile.FtpDownLoad(string.Format("{0}//{1}", cMain.RemotFtp, file), string.Format("{0}\\Rename\\{1}", All.Class.FileIO.GetNowPath(), file));
                            }
                        }
                    }
                    if (downFile)
                    {
                        //打开复制软件
                        FlushInfo("软件更新完毕，请等待程序重启。。。");
                        if (System.IO.File.Exists(".\\Rename\\Rename.Exe"))
                        {
                            All.Class.Process.Kill("Rename.exe");
                            System.IO.File.Move(".\\Rename\\Rename.exe", ".\\Rename.exe");
                        }
                        System.Diagnostics.Process.Start(".\\Rename.exe", "");
                        StartOrClose(false);
                    }
                    else
                    {
                        StartOrClose(true);
                    }
                    break;
            }
        }

        delegate void StartOrCloseHandle(bool start);
        private void StartOrClose(bool start)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new StartOrCloseHandle(StartOrClose), start);
            }
            else
            {
                if (start)
                {
                    mMain.Show();
                    this.Visible = false;
                }
                else
                {
                    this.Close();
                    Application.Exit();
                }
            }
        }
        private void frmDelay_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnOver_Click(object sender, EventArgs e)
        {
            StringValue_ChangeValue("", "", "", 2);
        }
    }
}
