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
    public partial class frmMain : All.Window.MainWindow
    {
        bool autoPlay = true;
        int autoPlayTimeOut = 10;


        bool exit = false;
        public static cMain mMain = new cMain();
        All.Window.PlayWindow.AutoPlayOneByOne[] PlayThree = new All.Window.PlayWindow.AutoPlayOneByOne[3];
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            mMain.Load();
            mMain.Run();
            SetEnable(false);
            timAutoPlay.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmUserLogin fl = new frmUserLogin();
            if (fl.ShowDialog() == DialogResult.Yes)
            {
                SetEnable(true);
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            SetEnable(false);
        }
        private void SetEnable(bool Login)
        {
            if (All.Class.HardInfo.MyTestComputer())
            {
                Login = true;
            }
            btnLogin.Login = !Login;
            btnLogOut.Login = Login;
            btnChangePassword.Login = Login;
            btnLevel.Login = Login;
            btnAddUser.Login = Login;

            btnSetting.Login = Login;
            btnOrderIn.Login = Login;
            btnMaterial.Login = Login;
            btnZheWang.Login = Login;
            btnMode.Login = Login;
            btnNiuJu.Login = Login;
            btnError.Login = Login;
            btnStation.Login = Login;
            btnDevice.Login = Login;
            btnBosch.Login = Login;
            btnMode.Login = Login;
            btnStopTime.Login = Login;
            btnTimeRefresh.Login = Login;
            btnSetTime.Login = Login;
            btnLengNingSet.Login = Login;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            All.Window.AboutWindow frmAbout = new All.Window.AboutWindow(this.Text,
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                "苏州优备精密电子有限公司",
                "Suzhou UB Precision Co,.Ltd",
                "苏州工业园区东富路8号 东景工业坊12幢");
            frmAbout.ShowDialog();
            frmAbout.Dispose();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmUserAdd fu = new frmUserAdd();
            fu.ShowDialog();
        }

        private void btnBottlen_Click(object sender, EventArgs e)
        {
            frmPlayTick fpt = new frmPlayTick();
            fpt.ShowDialog();
        }

        private void btnHourTest_Click(object sender, EventArgs e)
        {
            frmPlayCounts fpc = new frmPlayCounts();
            fpc.ShowDialog();
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            frmPlayManagement fpm = new frmPlayManagement();
            fpm.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmUserChangeEdit fuc = new frmUserChangeEdit();
            fuc.ShowDialog();
        }


        private void btnOrderStatue_Click(object sender, EventArgs e)
        {
            frmPlayOrder fpo = new frmPlayOrder();
            fpo.ShowDialog();
        }
        private void btnLineStatue_Click(object sender, EventArgs e)
        {
            frmPlayLine fpl = new frmPlayLine();
            fpl.ShowDialog();
        }

        private void btnBarRepor_Click(object sender, EventArgs e)
        {
            frmReportBar frb = new frmReportBar();
            frb.ShowDialog();
        }

        private void btnOrderReport_Click(object sender, EventArgs e)
        {
            frmReportPingZhi fpz = new frmReportPingZhi();
            fpz.ShowDialog();
        }
        private void btnOrderIn_Click(object sender, EventArgs e)
        {
            frmSetOrder fso = new frmSetOrder();
            fso.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit && All.Window.MetroMessageBox.Show(this, "是否确认退出检测程序?", "确认退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            All.Class.Style.ChangeColor( Color.FromArgb(255,(byte)All.Class.Num.GetRandom(0, 255), (byte)All.Class.Num.GetRandom(0, 255), (byte)All.Class.Num.GetRandom(0, 255)));
        }


        private void btnNiuJu_Click(object sender, EventArgs e)
        {
            frmSetNiuJu fsn = new frmSetNiuJu();
            fsn.ShowDialog();
        }

        private void btnBosch_Click(object sender, EventArgs e)
        {
            frmSetBoShi fsb = new frmSetBoShi();
            fsb.ShowDialog();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetPlayer fsp = new frmSetPlayer();
            fsp.ShowDialog();
        }
        private void btnStation_Click(object sender, EventArgs e)
        {
            autoPlay = false;

            frmSetStation fss = new frmSetStation();
            fss.ShowDialog();
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            frmSetMode fsm = new frmSetMode();
            fsm.ShowDialog();
        }
        private void btnZheWang_Click(object sender, EventArgs e)
        {
            frmSetZheWang fsz = new frmSetZheWang();
            fsz.ShowDialog();
        }
        private void btnLevel_Click(object sender, EventArgs e)
        {
            frmUserLevel ful = new frmUserLevel();
            ful.ShowDialog();
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            frmPlayVideo fpv = new frmPlayVideo();
            fpv.ShowDialog();
        }
        private void btnMachineStatue_Click(object sender, EventArgs e)
        {
            frmPlayLineOther fpl = new frmPlayLineOther();
            fpl.ShowDialog();
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (PlayThree[0] != null)
            {
                PlayThree[0].Stop();
                PlayThree[0] = null;
            }
            if (PlayThree[1] != null)
            {
                PlayThree[1].Stop();
                PlayThree[1] = null;
            }
            if (PlayThree[2] != null)
            {
                PlayThree[2].Stop();
                PlayThree[2] = null;
            }
            PlayThree[0] = new All.Window.PlayWindow.AutoPlayOneByOne();
            PlayThree[1] = new All.Window.PlayWindow.AutoPlayOneByOne();
            PlayThree[2] = new All.Window.PlayWindow.AutoPlayOneByOne();
            
            for (int i = 0; i < frmMain.mMain.AllDataXml.AllPlaySet.AllPlay.Length; i++)
            {
                if (frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Play)
                {
                    frmPlayWindow fpw = new frmPlayWindow();
                    switch (frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Player)
                    {
                        case cDataXml.PlaySet.PlayList.部装线://引处其实已改为设备显示
                            fpw = new frmPlaySheBei();
                            fpw.DelayTime = 99999;
                            break;
                        case cDataXml.PlaySet.PlayList.订单:
                            fpw = new frmPlayOrder();
                            fpw.DelayTime = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime;
                            break;
                        case cDataXml.PlaySet.PlayList.管理信息:
                            fpw = new frmPlayManagement();
                            fpw.DelayTime = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime;
                            break;
                        case cDataXml.PlaySet.PlayList.媒体信息:
                            fpw = new frmPlayVideo();

                            int delayTime = 0;
                            //图片文件
                            DirectoryInfo di;
                            //获取图片数量
                            if (System.IO.Directory.Exists(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[0]))
                            {
                                di = new DirectoryInfo(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[0]);
                                foreach (FileInfo fi in di.GetFiles())
                                {
                                    if (All.Control.PicturePlayer.FileFilter.ToUpper().IndexOf(fi.Extension.ToUpper()) >= 0)
                                    {
                                        delayTime += frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime;
                                    }
                                }
                            }
                            //获取所有视频时长
                            if (System.IO.Directory.Exists(frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].Info[1]))
                            {
                                delayTime = 9999;//有视频播放时，将播放时间设为最大
                            }
                            fpw.DelayTime = 99999;
                            break;
                        case cDataXml.PlaySet.PlayList.生产瓶颈:
                            fpw = new frmPlayTick();
                            fpw.DelayTime = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime;
                            break;
                        case cDataXml.PlaySet.PlayList.停线信息:
                            fpw = new frmPlayAll();
                            fpw.DelayTime = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime;
                            break;
                        case cDataXml.PlaySet.PlayList.小时产量:
                            fpw = new frmPlayCounts();
                            fpw.DelayTime = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime;
                            break;
                        case cDataXml.PlaySet.PlayList.总装线:
                            fpw = new frmPlayLine();
                            fpw.DelayTime = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].DelayTime;
                            break;
                    }
                    PlayThree[frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].TVIndex].Add(fpw);
                    if ((frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].TVIndex) < Screen.AllScreens.Length)
                    {
                        fpw.ShowScreen = Screen.AllScreens[frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[i].TVIndex];
                    }
                }
            }
            PlayThree[0].Start();
            PlayThree[1].Start();
            PlayThree[2].Start();
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            frmSetMaterial fsm = new frmSetMaterial();
            fsm.ShowDialog();
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            frmSetError fse = new frmSetError();
            fse.ShowDialog();
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            if (All.Window.MetroMessageBox.Show(this, "是否确认执行所有分站从机关机命令？", "是否关机", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int j = 0; j < HeiFeiMideaDll.cMain.AllComputerCount; j++)
                {
                    mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart + j].Sons[0].WriteInternal<bool>(true, 0);
                }
                exit = true;
                this.Close();
                System.Diagnostics.Process.Start("ShutDown", "-p -f");
            }
        }

        private void btnTimeRefresh_Click(object sender, EventArgs e)
        {
            if (All.Window.MetroMessageBox.Show(this, "是否确认执行计时复位？", "是否复位", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmMain.mMain.FlushData.InitAllStopTime = true;
            }
        }

        private void btnDevice_Click(object sender, EventArgs e)
        {
            frmSetSheBei fss = new frmSetSheBei();
            fss.ShowDialog();
        }

        private void btnDeviceStatue_Click(object sender, EventArgs e)
        {
            frmPlaySheBei fps = new frmPlaySheBei();
            fps.ShowDialog();
        }

        private void btnStopTime_Click(object sender, EventArgs e)
        {
            frmMain.mMain.FlushData.StopAllStopTime = !frmMain.mMain.FlushData.StopAllStopTime;
            if (frmMain.mMain.FlushData.StopAllStopTime)
            {
                btnStopTime.Title = "恢复计时";
                btnStopTime.Value = "Run";
                btnStopTime.Back = Color.Green;
            }
            else
            {
                btnStopTime.Title = "停止计时";
                btnStopTime.Value = "Stop";
                btnStopTime.Back = Color.FromArgb(255, 192, 0, 0);
            }
        }

        private void btnCountReport_Click(object sender, EventArgs e)
        {
            frmReportAllError fra = new frmReportAllError();
            fra.ShowDialog();
        }

        private void btnRptUser_Click(object sender, EventArgs e)
        {
            frmReportUser fre = new frmReportUser();
            fre.ShowDialog();
        }

        private void btnReportNum_Click(object sender, EventArgs e)
        {
            frmReportCount frc = new frmReportCount();
            frc.ShowDialog();
        }

        private void btnAllInfo_Click(object sender, EventArgs e)
        {
            frmPlayAll fpa = new frmPlayAll();
            fpa.ShowDialog();
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            frmSetTime fst = new frmSetTime();
            fst.ShowDialog();
        }

        private void btnLengNingSet_Click(object sender, EventArgs e)
        {
            frmUserLengNin fln = new frmUserLengNin();
            fln.ShowDialog();
        }

        private void timAutoPlay_Tick(object sender, EventArgs e)
        {
            if (autoPlay)
            {
                autoPlayTimeOut--;
                if (autoPlayTimeOut <= 0)
                {
                    autoPlay = false;
                    btnPlay_Click(btnPlay, new EventArgs());
                }
            }
            else
            {
                autoPlayTimeOut = 10;
                timAutoPlay.Enabled = false;
                timAutoPlay.Stop();
            }
        }
    }
}
