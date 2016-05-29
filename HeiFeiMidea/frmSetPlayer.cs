using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeiFeiMidea
{
    public partial class frmSetPlayer : All.Window.MainWindow
    {
        Panel[] allPan = new Panel[HeiFeiMideaDll.cMain.AllPlays];
        Size[] oldSize = new Size[HeiFeiMideaDll.cMain.AllPlays];
        Button[] AllBtn = new Button[HeiFeiMideaDll.cMain.AllPlays];
        bool[] showOver = new bool[HeiFeiMideaDll.cMain.AllPlays];
        RadioButton[] AllRbt = new RadioButton[HeiFeiMideaDll.cMain.AllPlays];
        RadioButton[] AllRbtTv = new RadioButton[HeiFeiMideaDll.cMain.AllPlays];
        RadioButton[] AllRbtT = new RadioButton[HeiFeiMideaDll.cMain.AllPlays];

        TextBox[] AllTxt = new TextBox[HeiFeiMideaDll.cMain.AllPlays];
        TextBox[] AllInfo0 = new TextBox[HeiFeiMideaDll.cMain.AllPlays];
        TextBox[] AllInfo1 = new TextBox[HeiFeiMideaDll.cMain.AllPlays];
        TextBox[] AllInfo2 = new TextBox[HeiFeiMideaDll.cMain.AllPlays];

        All.Control.Metro.CheckBox[] AllChk = new All.Control.Metro.CheckBox[HeiFeiMideaDll.cMain.AllPlays];
        public frmSetPlayer()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void frmSetPlayer_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData();
        }
       
        private void InitFrm()
        {
            for (int i = 0; i < allPan.Length; i++)
            {
                allPan[i] = (Panel)this.Controls.Find(string.Format("pan{0}", i + 1), true)[0];
                oldSize[i] = allPan[i].Size;
                AllBtn[i] = (Button)this.Controls.Find(string.Format("btn{0}", i + 1), true)[0];
                AllBtn[i].Click += frmSetPlayer_Click;
                AllBtn[i].Tag = i;
                AllChk[i] = (All.Control.Metro.CheckBox)this.Controls.Find(string.Format("chk{0}", i + 1), true)[0];
                AllRbt[i] = (RadioButton)this.Controls.Find(string.Format("rbt{0}", i + 1), true)[0];
                AllRbtTv[i] = (RadioButton)this.Controls.Find(string.Format("rbtTV{0}", i + 1), true)[0];
                AllRbtT[i] = (RadioButton)this.Controls.Find(string.Format("rbtT{0}", i + 1), true)[0];
                AllTxt[i] = (TextBox)this.Controls.Find(string.Format("txt{0}", i + 1), true)[0];
                if (this.Controls.Find(string.Format("txtInfo0{0}", i + 1), true).Length > 0)
                {
                    AllInfo0[i] = (TextBox)this.Controls.Find(string.Format("txtInfo0{0}", i + 1), true)[0];
                }
                if (this.Controls.Find(string.Format("txtInfo1{0}", i + 1), true).Length > 0)
                {
                    AllInfo1[i] = (TextBox)this.Controls.Find(string.Format("txtInfo1{0}", i + 1), true)[0];
                }
                if (this.Controls.Find(string.Format("txtInfo2{0}", i + 1), true).Length > 0)
                {
                    AllInfo2[i] = (TextBox)this.Controls.Find(string.Format("txtInfo2{0}", i + 1), true)[0];
                }

                showOver[i] = true;
            }
            //for (int i = 0; i < allPan.Length; i++)
            //{
            //    frmSetPlayer_Click(AllBtn[i], new EventArgs());
            //}
        }
        private void InitData()
        {
            for (int i = 0; i < allPan.Length; i++)
            {
                AllChk[i].Checked = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Play;
                if (frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].TVIndex == 0)
                {
                    AllRbt[i].Checked = true;
                }
                switch (frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].TVIndex)
                {
                    case 0:
                        AllRbt[i].Checked = true;
                        break;
                    case 1:
                        AllRbtTv[i].Checked = true;
                        break;
                    default:
                        AllRbtT[i].Checked = true;
                        break;
                }
                AllTxt[i].Text = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime.ToString();
                if (AllInfo0[i] != null)
                {
                    AllInfo0[i].Text = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[0];
                }
                if (AllInfo1[i] != null)
                {
                    AllInfo1[i].Text = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[1];
                }
                if (AllInfo2[i] != null)
                {
                    AllInfo2[i].Text = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[2];
                }
            }
        }

        private void frmSetPlayer_Click(object sender, EventArgs e)
        {
            Button tmp = (Button)sender;
            int index = All.Class.Num.ToInt(tmp.Tag);
            if (showOver[index])
            {
                showOver[index] = false;
                allPan[index].Height = 40;
                tmp.BackgroundImage = HeiFeiMidea.Properties.Resources.Download___01;
            }
            else
            {
                showOver[index] = true;
                allPan[index].Height = oldSize[index].Height;
                tmp.BackgroundImage = HeiFeiMidea.Properties.Resources.Upload___01;
            }
            for (int i = index + 1; i < allPan.Length; i++)
            {
                allPan[i].Top = allPan[i - 1].Top + allPan[i - 1].Height;
            }
            int height = 0;
            allPan.ToList().ForEach(pan => {
                height += pan.Height;
            });
            if (height > panSet.Height)
            {
                for (int i = 0; i < allPan.Length; i++)
                {
                    allPan[i].Width = oldSize[i].Width;
                }
            }
            else
            {
                for (int i = 0; i < allPan.Length; i++)
                {
                    allPan[i].Width = panSet.Width - 2;
                }
            }
                
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < allPan.Length; i++)
            {
                frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Play = AllChk[i].Checked;
                if (AllRbt[i].Checked)
                {
                    frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].TVIndex = 0;// (AllRbt[i].Checked ? 0 : 1);
                }
                else if (AllRbtTv[i].Checked)
                {
                    frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].TVIndex = 1;
                }
                else
                {
                    frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].TVIndex = 2;
                }
                frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime = All.Class.Num.ToInt(AllTxt[i].Text);
                if (AllInfo0[i] != null)
                {
                    frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[0] = AllInfo0[i].Text;
                }
                if (AllInfo1[i] != null)
                {
                    frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[1] = AllInfo1[i].Text;
                }
                if (AllInfo2[i] != null)
                {
                    frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[2] = AllInfo2[i].Text;
                }
                frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Save();
            }
            All.Window.MetroMessageBox.Show(this, "所有播放数据已成功保存至数据库", "数据保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            dlgShowFile.Description = "选择要播放的图片文件夹";
            dlgShowFile.ShowNewFolderButton = false;
            dlgShowFile.RootFolder = Environment.SpecialFolder.MyComputer;
            if (txtInfo08.Text != "" && System.IO.Directory.Exists(txtInfo08.Text))
            {
                dlgShowFile.SelectedPath = txtInfo08.Text;
            }
            if (dlgShowFile.ShowDialog() == DialogResult.OK)
            {
                txtInfo08.Text = dlgShowFile.SelectedPath;
            }
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            dlgShowFile.Description = "选择要播放的视频文件夹";
            dlgShowFile.ShowNewFolderButton = false;
            dlgShowFile.RootFolder = Environment.SpecialFolder.MyComputer;
            if (txtInfo18.Text != "" && System.IO.Directory.Exists(txtInfo18.Text))
            {
                dlgShowFile.SelectedPath = txtInfo18.Text;
            }
            if (dlgShowFile.ShowDialog() == DialogResult.OK)
            {
                txtInfo18.Text = dlgShowFile.SelectedPath;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }

        private void btnShiPinVideo_Click(object sender, EventArgs e)
        {
            dlgShowFile.Description = "选择要播放的视频文件夹";
            dlgShowFile.ShowNewFolderButton = false;
            dlgShowFile.RootFolder = Environment.SpecialFolder.MyComputer;
            if (txtInfo03.Text != "" && System.IO.Directory.Exists(txtInfo03.Text))
            {
                dlgShowFile.SelectedPath = txtInfo03.Text;
            }
            if (dlgShowFile.ShowDialog() == DialogResult.OK)
            {
                txtInfo03.Text = dlgShowFile.SelectedPath;
            }
        }
    }
}
