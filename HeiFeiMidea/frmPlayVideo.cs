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
using All.Control;
namespace HeiFeiMidea
{
    public partial class frmPlayVideo : frmPlayWindow
    {
        List<Image> imageFiles = new List<Image>();
        List<string> videoFiles = new List<string>();
        int videoIndex = 0;
        enum PlayStatue
        {
            Image,
            Video,
            Null
        }
        PlayStatue ps = PlayStatue.Null;
        public frmPlayVideo()
        {
            DirectoryInfo di;
            if (Directory.Exists(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[7].Info[0]))
            {
                di = new DirectoryInfo(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[7].Info[0]);
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (All.Control.PicturePlayer.FileFilter.ToUpper().IndexOf(fi.Extension.ToUpper()) >= 0)
                    {
                        try
                        {
                            imageFiles.Add(Image.FromFile(fi.FullName));
                        }
                        catch
                        { }
                    }
                }
            }
            if (Directory.Exists(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[7].Info[1]))
            {
                di = new DirectoryInfo(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[7].Info[1]);
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (All.Control.MediaPlayerLocal.FileFilter.ToUpper().IndexOf(fi.Extension.ToUpper()) >= 0)
                    {
                        videoFiles.Add(fi.FullName);
                    }
                }
            }
            InitializeComponent();
        }

        private void mediaPlayer1_MediaEnd()
        {
            StartVideo();
        }
        delegate void StartHandle();
        private void StartVideo()
        {
            if (mediaPlayer1.InvokeRequired)
            {
                mediaPlayer1.Invoke(new StartHandle(StartVideo));
            }
            else
            {
                if (videoIndex >= videoFiles.Count)
                {
                    StartImage();
                }
                else
                {
                    picturePlayer1.Stop();
                    mediaPlayer1.BringToFront();
                    mediaPlayer1.SetFile(videoFiles[videoIndex]);
                    mediaPlayer1.Play();
                    videoIndex++;
                }
            }
        }
        private void StartImage()
        {
            if (picturePlayer1.InvokeRequired)
            {
                picturePlayer1.Invoke(new StartHandle(StartImage));
            }
            else
            {
                picturePlayer1.FilePath = imageFiles;
                picturePlayer1.BringToFront();
                picturePlayer1.Start();
            }
        }
        private void picturePlayer1_PlayOver()
        {
            if (this.Playing)
            {
                this.PlayNext();
            }
            else
            {
                videoIndex = 0;
                StartVideo();
            }
        }

        private void frmPlayVideo_Load(object sender, EventArgs e)
        {
            picturePlayer1.DelayTime = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[7].DelayTime * 1000;// -picturePlayer1.ChangeTime;
            picturePlayer1.PlayOver += picturePlayer1_PlayOver;
            mediaPlayer1.MediaEnd += mediaPlayer1_MediaEnd;
            ShowWindow();
        }
        public override void ShowWindow()
        {

            if (videoFiles.Count > 0)
            {
                ps = PlayStatue.Video;
                videoIndex = 0;
            }
            else
            {
                if (imageFiles.Count > 0)
                {
                    ps = PlayStatue.Image;
                }
            }
            switch (ps)
            {
                case PlayStatue.Image:
                    StartImage();
                    break;
                case PlayStatue.Video:
                    StartVideo();
                    break;
            }
        }
        public override void HideWindow()
        {
            try
            {
                mediaPlayer1.Stop();
                picturePlayer1.Stop();
            }
            catch { }
        }

        private void frmPlayVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideWindow();
            picturePlayer1.PlayOver -= picturePlayer1_PlayOver;
            mediaPlayer1.MediaEnd -= mediaPlayer1_MediaEnd;
            mediaPlayer1.Stop();
        }
    }
}
