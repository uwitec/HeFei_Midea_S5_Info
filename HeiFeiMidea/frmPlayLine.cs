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
    public partial class frmPlayLine : frmPlayWindow
    {
        cCarLocal.StatueCar statueCar;
        string old4M = "";
        /// <summary>
        /// 当前闪烁状态
        /// </summary>
        bool blinkShow = true;
        Label[] lblW = new Label[HeiFeiMideaDll.cMain.AllLedSpace];//从W01工位到W20共20个工位带报警灯
        Label[] lblUser = new Label[HeiFeiMideaDll.cMain.AllStopStationCount];//所有须要登陆的重要岗位
        All.Control.Corner[] lblLine = new All.Control.Corner[HeiFeiMideaDll.cMain.AllStopStationCount];//所有须要登陆的重要岗位的连接线
        Label[] lblLengNinUser = new Label[HeiFeiMideaDll.cMain.AllLengNinQiCount];
        All.Control.Corner[] lblLengNinLine = new All.Control.Corner[HeiFeiMideaDll.cMain.AllLengNinQiCount];
        All.Control.Icon[] LittleStation = new All.Control.Icon[HeiFeiMideaDll.cMain.AllStopStationCount];
        All.Control.Icon[] McgsStation = new All.Control.Icon[HeiFeiMideaDll.cMain.AllTestComputer];
        Label[] McgsName = new Label[HeiFeiMideaDll.cMain.AllTestComputer];
        All.Control.Icon[] TestStation = new All.Control.Icon[4];
        All.Control.Icon[] LengNinStation = new All.Control.Icon[HeiFeiMideaDll.cMain.AllLengNinQiCount];
        All.Control.Icon[] StationOther = new All.Control.Icon[HeiFeiMideaDll.cMain.AllOtherMachineCount];

        public frmPlayLine()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }

        private void frmPlayLine_Load(object sender, EventArgs e)
        {
            frmMain.mMain.FlushInfo.DelInfo += FlushInfo_DelInfo;
            InitForm();
            frmMain.mMain.FlushInfo.AddInfo += FlushInfo_AddInfo;
            timFlush_Tick(timFlush, new EventArgs());
            timFlush.Enabled = true;
        }

        void FlushInfo_DelInfo(string value)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new cFlushInfo.DelInfoHandle(FlushInfo_DelInfo), value);
            }
            else
            {
                listBox1.Items.Remove(value);
            }
        }

        void FlushInfo_AddInfo(string value)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new cFlushInfo.AddInfoHandle(FlushInfo_AddInfo), value);
            }
            else
            {
                listBox1.Items.Add(value);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }
        public override void HideWindow()
        {
            timFlush.Enabled = false;
        }
        public override void ShowWindow()
        {
            timFlush.Enabled = true;
        }
        private void InitForm()
        {
            Control[] tmpFindControl;
            for (int i = 0; i < frmMain.mMain.FlushInfo.AllInfo.Count; i++)
            {
                listBox1.Items.Add(frmMain.mMain.FlushInfo.AllInfo[i].GetShowValue());
            }
            for (int i = 0; i < lblW.Length; i++)
            {
                lblW[i] = (Label)this.Controls.Find(string.Format("lblW{0}", i + 1), true)[0];
                lblW[i].Tag = i + 1;
            }
            for (int i = 0; i < LittleStation.Length; i++)
            {
                //停车地标
                LittleStation[i] = (All.Control.Icon)this.Controls.Find(string.Format("LittleStation{0}", i), true)[0];
                LittleStation[i].Tag = i + 1;
                LittleStation[i].MouseEnter += frmPlayLine_MouseEnter;
                LittleStation[i].MouseLeave += frmPlayLine_MouseLeave;
                LittleStation[i].Visible = true;
                LittleStation[i].Click += LittleStation_Click;

                //用户登陆
                tmpFindControl = panLine.Controls.Find(string.Format("lblUser{0}", i), false);
                if (tmpFindControl != null && tmpFindControl.Length > 0)
                {
                    lblUser[i] = (Label)tmpFindControl[0];
                }
                tmpFindControl = panLine.Controls.Find(string.Format("lblLine{0}", i), false);
                if (tmpFindControl != null && tmpFindControl.Length > 0)
                {
                    lblLine[i] = (All.Control.Corner)tmpFindControl[0];
                }
            }
            for (int i = 0; i < McgsStation.Length; i++)
            {
                McgsStation[i] = (All.Control.Icon)this.Controls.Find(string.Format("mcgs{0}", i + 1), true)[0];
                McgsStation[i].Tag = i + 1;
                McgsName[i] = (Label)this.Controls.Find(string.Format("lblTestName{0}", i + 1), true)[0];
                McgsName[i].Text = frmMain.mMain.AllCars.AllInfoStation[i + 1].StationName;
            }
            for (int i = 0; i < TestStation.Length; i++)
            {
                TestStation[i] = (All.Control.Icon)this.Controls.Find(string.Format("Test{0}", i + 1), true)[0];
                TestStation[i].Tag = i + 1;
            }
            for (int i = 0; i < LengNinStation.Length; i++)
            {
                LengNinStation[i] = (All.Control.Icon)this.Controls.Find(string.Format("LengNinStation{0}", i + 1), true)[0];
                LengNinStation[i].Tag = i + 1;
                LengNinStation[i].MouseEnter += frmPlayLine_LengNingMouseEnter;
                LengNinStation[i].MouseLeave += frmPlayLine_LengNingMouseLevel;
                tmpFindControl = panLine.Controls.Find(string.Format("lblLengNinUser{0}", i), false);
                if (tmpFindControl != null && tmpFindControl.Length > 0)
                {
                    lblLengNinUser[i] = (Label)tmpFindControl[0];
                }
                tmpFindControl = panLine.Controls.Find(string.Format("lblLengNinLine{0}", i), false);
                if (tmpFindControl != null && tmpFindControl.Length > 0)
                {
                    lblLengNinLine[i] = (All.Control.Corner)tmpFindControl[0];
                }
            }
            for (int i = 0; i < StationOther.Length; i++)
            {
                StationOther[i] = (All.Control.Icon)this.Controls.Find(string.Format("StationOther{0}", i + 1), true)[0];
                StationOther[i].Tag = i + 1;
            }
            panLine.MouseMove += panLine_MouseMove;
        }

        void frmPlayLine_LengNingMouseEnter(object sender, EventArgs e)
        {
            All.Control.Icon icon = (All.Control.Icon)sender;
            int index = (int)icon.Tag;
            if (index <= 0 || index > HeiFeiMideaDll.cMain.AllLengNinQiCount)
            {
                return;
            }
            lblLengNingGongWei.Text = string.Format("工位号：{0}", index);
            lblLengNingTiaoMa.Text = string.Format("条形码：{0}", frmMain.mMain.AllCars.AllStatueLengNinQi.AllLengNinStation[index - 1].BarCode);
            if ((icon.Left + icon.Width + panLengNing.Width) <= panLine.Width)
            {
                panLengNing.Left = icon.Left + icon.Width;
            }
            else
            {
                panLengNing.Left = icon.Left - panLengNing.Width;
            }
            if ((icon.Top + icon.Height + panLengNing.Height) <= panLine.Height)
            {
                panLengNing.Top = icon.Top + icon.Height;
            }
            else
            {
                panLengNing.Top = icon.Top - panLengNing.Height;
            }
            panLengNing.Visible = true;
            panLengNing.BringToFront();
        }
        void frmPlayLine_LengNingMouseLevel(object sender, EventArgs e)
        {
            All.Control.Icon icon = (All.Control.Icon)sender;
            Rectangle r = panLengNing.RectangleToScreen(new Rectangle(icon.Location, icon.Size));
            Point p = MousePosition;
            if (!r.Contains(p))
            {
                panLengNing.Visible = false;
            }
        }

        void panLine_MouseMove(object sender, MouseEventArgs e)
        {
            panTestNo.Visible = false;
            panLengNing.Visible = false;
        }

        private void frmPlayLine_MouseLeave(object sender, EventArgs e)
        {
            All.Control.Icon icon = (All.Control.Icon)sender;
            Rectangle r = panLine.RectangleToScreen(new Rectangle(icon.Location, icon.Size));
            Point p = MousePosition;
            if (!r.Contains(p))
            {
                panTestNo.Visible = false;
            }
        }

        private void frmPlayLine_MouseEnter(object sender, EventArgs e)
        {
            All.Control.Icon icon = (All.Control.Icon)sender;
            int index = (int)icon.Tag;
            cCarLocal.StatueCar cs = frmMain.mMain.AllCars.GetCarFromLineStationIndex(index);
            if (cs == null)
            {
                return;
            }
            lblTestNo.Text = string.Format("{0}", cs.TestNo + 1);
            lblWorkStation.Text = string.Format("{0}", cs.WorkLineStation);
            lblTestBarCode.Text = cs.BarCode;
            if ((icon.Left + icon.Width + panTestNo.Width) <= panLine.Width)
            {
                panTestNo.Left = icon.Left + icon.Width;
            }
            else
            {
                panTestNo.Left = icon.Left - panTestNo.Width;
            }
            if ((icon.Top + icon.Height + panTestNo.Height) <= panLine.Height)
            {
                panTestNo.Top = icon.Top + icon.Height;
            }
            else
            {
                panTestNo.Top = icon.Top - panTestNo.Height;
            }
            panTestNo.Visible = true;
            panTestNo.BringToFront();
        }
        private void timFlush_Tick(object sender, EventArgs e)
        {
            blinkShow = !blinkShow;
            int index = 0;
            #region//刷新4M切换
            //刷新4M切换
            if (System.IO.File.Exists(string.Format("{0}\\Data\\Xml\\4M管理信息.txt", All.Class.FileIO.GetNowPath())))
            {
                string readValue = All.Class.FileIO.ReadFile(string.Format("{0}\\Data\\Xml\\4M管理信息.txt", All.Class.FileIO.GetNowPath()), Encoding.GetEncoding("GB2312"));
                if (readValue != "")
                {
                    if (!grp4M.Visible)
                    {
                        grp4M.Visible = true;
                        pan4Box.Visible = false;
                        lbl4MTitle.Visible = true;
                    }
                    string[] tmpValue = readValue.Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (old4M != readValue)
                    {
                        old4M = readValue;
                        lst4M.Items.Clear();
                        tmpValue.ToList().ForEach(
                           str =>
                           {
                               lst4M.Items.Add(str);
                           });
                    }
                    for (int i = 0; i < lblW.Length; i++)
                    {
                        for (int j = 0; j < tmpValue.Length; j++)
                        {
                            index = tmpValue[j].IndexOf(string.Format("W{0:D2}", i + 1));
                            if (index >= 0)
                            {
                                if (!blinkShow)
                                {
                                    lblW[i].ForeColor = Color.FromArgb(255, 40, 40, 40);
                                }
                                else
                                {
                                    lblW[i].ForeColor = Color.Yellow;
                                }
                                break;
                            }
                        }
                        if (index < 0)
                        {
                            lblW[i].ForeColor = Color.White;
                        }
                    }
                }
                else
                {
                    if (!pan4Box.Visible)
                    {
                        pan4Box.Visible = true;
                        grp4M.Visible = false;
                        lbl4MTitle.Visible = false;
                    }
                    itemTime.Value = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                    itemRun.Value = string.Format("{0:HH:mm:ss}", new DateTime(0).Add(DateTime.Now - cMain.StartTime));
                    itemMaterial.Value = (frmMain.mMain.FlushSingleMaterial.Connect ? "连接正常" : "连接失败");
                }
            }
            else
            {
                All.Class.FileIO.Write(string.Format("{0}\\Data\\Xml\\4M管理信息.txt", All.Class.FileIO.GetNowPath()), "");
            }
            #endregion
            #region//总生产线PLC显示
            if (frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Conn)
            {
                iconPlc.FillColor = Color.Green;
            }
            else
            {
                iconPlc.FillColor = (blinkShow ? Color.Purple : Color.FromArgb(255, 40, 40, 40));
            }
            #endregion
            #region//小车显示
            for (int i = 0; i < LittleStation.Length; i++)
            {
                if (frmMain.mMain.AllCars.AllStatueLineStation[i].HaveCar)
                {
                    if (frmMain.mMain.AllCars.AllStatueLineStation[i].Blink && !blinkShow)
                    {
                        LittleStation[i].FillColor = Color.FromArgb(255, 40, 40, 40);
                    }
                    else
                    {
                        LittleStation[i].FillColor = frmMain.mMain.AllCars.AllStatueLineStation[i].Color;
                    }}
                else
                {
                    LittleStation[i].FillColor = Color.FromArgb(255, 40, 40, 40);
                }
                statueCar = frmMain.mMain.AllCars.GetCarFromLineStationIndex(i + 1);
                if (statueCar == null)
                {
                    LittleStation[i].ShowNum = "";
                }
                else
                {
                    LittleStation[i].ShowNum = string.Format("{0}", statueCar.TestNo + 1);
                }
            }
            #endregion
            #region//工位屏显示
            for (int i = 0; i < McgsStation.Length; i++)
            {
                if (frmMain.mMain.AllPCs.AllMcgs.Mcgs[i].Connect)
                {
                    McgsStation[i].FillColor = Color.Green;
                }
                else
                {
                    if (!blinkShow)
                    {
                        McgsStation[i].FillColor = Color.FromArgb(255, 40, 40, 40);
                    }
                    else
                    {
                        McgsStation[i].FillColor = Color.Purple;
                    }
                }
            }
            #endregion
            #region//性能检显示
            for (int i = 0; i < TestStation.Length; i++)
            {
                if (!frmMain.mMain.FlushSingleTest.Connect[i] && !blinkShow)
                {
                    TestStation[i].FillColor = Color.FromArgb(255, 40, 40, 40);
                }
                else
                {
                    TestStation[i].FillColor = frmMain.mMain.FlushSingleTest.ShowColor[i];
                }
            }
            #region
            #region//其他工位，机器人，打包，绕膜等
            for (int i = 0; i < StationOther.Length; i++)
            {
                if (frmMain.mMain.AllCars.AllStatueOther[i].Blink && !blinkShow)
                {
                    StationOther[i].FillColor = Color.FromArgb(255, 40, 40, 40);
                }
                else
                {
                    StationOther[i].FillColor = frmMain.mMain.AllCars.AllStatueOther[i].Color;
                }
            }
            #endregion
            //折弯机
            if (frmMain.mMain.FlushSingleZheWang.Blink && !blinkShow)
            {
                iconZheWang.FillColor = Color.FromArgb(255, 40, 40, 40);
            }
            else
            {
                iconZheWang.FillColor = frmMain.mMain.FlushSingleZheWang.Color;
            }
            #endregion
            //抽空充注等爱华科的东西
            if (frmMain.mMain.FlushSingleChouKongChongZhu.BlinkOne && !blinkShow)
            {
                IconEmptyOne.FillColor = Color.FromArgb(255, 40, 40, 40);
            }
            else
            {
                IconEmptyOne.FillColor = frmMain.mMain.FlushSingleChouKongChongZhu.ColorOne;
            }
            if (frmMain.mMain.FlushSingleChouKongChongZhu.BlinkTwo && !blinkShow)
            {
                IconEmptyTwo.FillColor = Color.FromArgb(255, 40, 40, 40);
            }
            else
            {
                IconEmptyTwo.FillColor = frmMain.mMain.FlushSingleChouKongChongZhu.ColorTwo;
            }
            if (frmMain.mMain.FlushSingleChongHaiHuiShou.Blink && !blinkShow)
            {
                iconChongHaiHuiShou.FillColor = Color.FromArgb(255, 40, 40, 40);
            }
            else
            {
                iconChongHaiHuiShou.FillColor = frmMain.mMain.FlushSingleChongHaiHuiShou.Color;
            }
            if (frmMain.mMain.FlushSingleJianLou.Blink && !blinkShow)
            {
                iconHaiJian.FillColor = Color.FromArgb(255, 40, 40, 40);
            }
            else
            {
                iconHaiJian.FillColor = frmMain.mMain.FlushSingleJianLou.Color;
            }
            #endregion
            #region//注油机
            if (frmMain.mMain.FlushSingleOil.Blink && !blinkShow)
            {
                iconOil.FillColor = Color.FromArgb(255, 40, 40, 40);
            }
            else
            {
                iconOil.FillColor = frmMain.mMain.FlushSingleOil.ShowColor;
            }
            #endregion
            #region//冷凝器线体
            for (int i = 0; i < LengNinStation.Length; i++)
            {
                LengNinStation[i].FillColor = frmMain.mMain.AllCars.AllStatueLengNinQi.AllLengNinStation[i].Color;
            }
            if (frmMain.mMain.AllCars.AllStatueLengNinQi.Blink && !blinkShow)
            {
                iconLengNingQiPlc.FillColor = Color.FromArgb(255, 40, 40, 40);
            }
            else
            {
                iconLengNingQiPlc.FillColor = frmMain.mMain.AllCars.AllStatueLengNinQi.Color;
            }
            #endregion
            #region//用户登陆
            for (int i = 0; i < frmMain.mMain.FlushUserLogin.AllUserStatue.Length; i++)
            {
                if (lblUser[i] != null)
                {
                    lblUser[i].Visible = frmMain.mMain.FlushUserLogin.AllUserStatue[i].HaveUser;
                    if (frmMain.mMain.FlushUserLogin.AllUserStatue[i].LoginUser)
                    {
                        lblUser[i].ForeColor = Color.Green;
                    }
                    else if (!blinkShow)
                    {
                        lblUser[i].ForeColor = Color.FromArgb(255, 40, 40, 40);
                    }
                    else
                    {
                        lblUser[i].ForeColor = Color.Purple;
                    }
                }
                if (lblLine[i] != null)
                {
                    lblLine[i].Visible = frmMain.mMain.FlushUserLogin.AllUserStatue[i].HaveUser;
                }
            }
            for (int i = 0; i < frmMain.mMain.FlushUserLogin.LengNinUserStatue.Length; i++)
            {
                if (lblLengNinUser[i] != null)
                {
                    lblLengNinUser[i].Visible = frmMain.mMain.FlushUserLogin.LengNinUserStatue[i].HaveUser;
                    if (frmMain.mMain.FlushUserLogin.LengNinUserStatue[i].LoginUser)
                    {
                        lblLengNinUser[i].ForeColor = Color.Green;
                    }
                    else if (!blinkShow)
                    {
                        lblLengNinUser[i].ForeColor = Color.FromArgb(255, 40, 40, 40);
                    }
                    else
                    {
                        lblLengNinUser[i].ForeColor = Color.Purple;
                    }
                }
                if (lblLengNinLine[i] != null)
                {
                    lblLengNinLine[i].Visible = frmMain.mMain.FlushUserLogin.LengNinUserStatue[i].HaveUser;
                }
            }
            #endregion
        }

        private void frmPlayLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.mMain.FlushInfo.AddInfo += FlushInfo_AddInfo;
            frmMain.mMain.FlushInfo.DelInfo += FlushInfo_DelInfo;
            timFlush.Enabled = false;
            timFlush.Stop();
        }
        private void iconZheWang_Click(object sender, EventArgs e)
        {
        }
        private void ShowErrorMessage(object sender, EventArgs e)
        {
            All.Control.Icon icon = (All.Control.Icon)sender;
            ShowErrorMessage(cSheBei.GetMachineError(icon.Name));
        }

        private void LittleStation_Click(object sender, EventArgs e)
        {
            All.Control.Icon icon = (All.Control.Icon)sender;
            ShowErrorMessage(cSheBei.GetMachineError(string.Format("LittleStation{0}",icon.ShowNum)));
        }
        private void ShowErrorMessage(string[] value)
        {
            frmMessageError fm = new frmMessageError(value);
            fm.ShowDialog();
            fm.Dispose();
        }
        
    }
}
