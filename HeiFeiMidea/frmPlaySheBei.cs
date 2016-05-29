using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace HeiFeiMidea
{
    public partial class frmPlaySheBei : frmPlayWindow
    {
        List<string> SheBeiFiles = new List<string>();
        int videoIndex = 0;
        int ExitCount = -1;
        public frmPlaySheBei()
        {
            InitializeComponent();
        }
        private void frmPlaySheBei_Load(object sender, EventArgs e)
        {
            timFlush_Tick(timFlush, new EventArgs());
            timFlush.Enabled = true;

            mediaPlayer1.MediaEnd += mediaPlayer1_MediaEnd;
            ShowWindow();
        }

        void mediaPlayer1_MediaEnd()
        {
            videoIndex++;
            StartVideo();
        }
        private void StartVideo()
        {
            if (videoIndex >= SheBeiFiles.Count)
            {
                if (this.Playing)
                {
                    this.PlayNext();
                    return;
                }
                else
                {
                    videoIndex = 0;
                }
            }
            mediaPlayer1.SetFile(SheBeiFiles[videoIndex]);
            mediaPlayer1.Play();
        }
        private void LoadVideoName()
        {
            SheBeiFiles.Clear();
            videoIndex = 0;
            FileInfo fii;
            if (frmMain.mMain.FlushSheBei.NeedWeiHu != null && frmMain.mMain.FlushSheBei.NeedWeiHu.Count > 0)//有设备维护时，显示维护视频
            {
                for (int i = 0; i < frmMain.mMain.FlushSheBei.NeedWeiHu.Count; i++)
                {
                    if (File.Exists(string.Format("{0}\\{1}", frmMain.mMain.AllDataXml.LocalSet.VideoDirectory, frmMain.mMain.FlushSheBei.NeedWeiHu[i].Video)))//如果存在文件
                    {
                        fii = new FileInfo(string.Format("{0}\\{1}", frmMain.mMain.AllDataXml.LocalSet.VideoDirectory, frmMain.mMain.FlushSheBei.NeedWeiHu[i].Video));
                        if(All.Control.MediaPlayerLocal.CheckPlayFile(fii.Extension))
                        {
                            SheBeiFiles.Add(fii.FullName);
                        }
                    }
                }
            }
            else
            {
                if (Directory.Exists(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[2].Info[1]))
                {
                    DirectoryInfo di = new DirectoryInfo(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[2].Info[1]);
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        if (All.Control.MediaPlayerLocal.CheckPlayFile(fi.Extension))
                        {
                            SheBeiFiles.Add(fi.FullName);
                        }
                    }
                }
            }
            if (SheBeiFiles.Count <= 0)
            {
                ExitCount = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[2].DelayTime;
            }
            else
            {
                StartVideo();
            }
        }
        public override void HideWindow()
        {
            try
            {
                timFlush.Enabled = false;
                timFlush.Stop();
                mediaPlayer1.Stop();
            }
            catch { }
        }
        public override void ShowWindow()
        {
            LoadVideoName();
            timFlush.Enabled = true;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            HideWindow();
            mediaPlayer1.MediaEnd -= mediaPlayer1_MediaEnd;
            base.OnClosing(e);
        }
        private void timFlush_Tick(object sender, EventArgs e)
        {
            if (ExitCount > 0)
            {
                ExitCount--;
            }
            else if (ExitCount == 0)
            {
                this.PlayNext();
            }
            bool needFlush = false;
            if (frmMain.mMain.FlushSheBei.NeedWeiHu.Count <= 0)
            {
                if (listBox1.Items.Count <= 0 || All.Class.Num.ToString(listBox1.Items[0]) != "今日无维护计划")
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("今日无维护计划");
                }
            }
            else
            {
                if (listBox1.Items.Count != frmMain.mMain.FlushSheBei.NeedWeiHu.Count)
                {
                    needFlush = true;
                }
                else
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (All.Class.Num.ToString(listBox1.Items[i]) != string.Format("{0}需要维护", frmMain.mMain.FlushSheBei.NeedWeiHu[i].SheBei))
                        {
                            needFlush = true;
                            break;
                        }
                    }
                }
                if (needFlush)
                {
                    listBox1.Items.Clear();
                    for (int i = 0; i < frmMain.mMain.FlushSheBei.NeedWeiHu.Count; i++)
                    {
                        listBox1.Items.Add(string.Format("{0}需要维护", frmMain.mMain.FlushSheBei.NeedWeiHu[i].SheBei));
                    }
                }
            }
            needFlush = false;
            if (frmMain.mMain.FlushSheBei.NextWeiHu.Count <= 0)
            {
                if (listBox2.Items.Count <= 0 ||
                    (All.Class.Num.ToString(listBox1.Items[0]) != "当前无任何设备维护" &&
                    All.Class.Num.ToString(listBox1.Items[0]) != "当前所有设备需要马上维护"))
                {
                    if (frmMain.mMain.FlushSheBei.NeedWeiHu.Count <= 0)
                    {
                        listBox2.Items.Clear();
                        listBox2.Items.Add("当前无任何设备维护");
                    }
                    else
                    {
                        listBox2.Items.Clear();
                        listBox2.Items.Add("当前所有设备需要马上维护");
                    }
                }
            }
            else
            {
                if (listBox2.Items.Count != frmMain.mMain.FlushSheBei.NextWeiHu.Count)
                {
                    needFlush = true;
                }
                else
                {
                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        if (All.Class.Num.ToString(listBox2.Items[i]) != string.Format("{0:MM-dd}->{1}", frmMain.mMain.FlushSheBei.NextWeiHu[i].Next, frmMain.mMain.FlushSheBei.NextWeiHu[i].SheBei))
                        {
                            needFlush = true;
                            break;
                        }
                    }
                }
                if (needFlush)
                {
                    listBox2.Items.Clear();
                    for (int i = 0; i < frmMain.mMain.FlushSheBei.NextWeiHu.Count; i++)
                    {
                        listBox2.Items.Add(string.Format("{0:MM-dd}->{1}", frmMain.mMain.FlushSheBei.NextWeiHu[i].Next, frmMain.mMain.FlushSheBei.NextWeiHu[i].SheBei));
                    }
                }
            }
        }

        private void frmPlaySheBei_FormClosing(object sender, FormClosingEventArgs e)
        {
            timFlush.Enabled = false;
            timFlush.Stop();
        }
    }
}
