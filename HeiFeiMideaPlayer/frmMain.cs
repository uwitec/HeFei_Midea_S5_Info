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
using System.Windows.Forms.DataVisualization.Charting;
namespace HeiFeiMideaPlayer
{
    public partial class frmMain : All.Window.MainWindow
    {
        All.Control.Icon[] AllIcon = new All.Control.Icon[HeiFeiMideaDll.cMain.AllLengNinQiCount + 4];//9个板+折弯+PC+PLC+检漏
        public static cMain mMain = new cMain();
        frmClose frmCloseWindow;
        Rectangle mediaPlayScreen = Rectangle.Empty;
        Rectangle tabShowScreen = Rectangle.Empty;
        Label[] lblBar = new Label[3];
        Label[] lblOrder = new Label[3];
        Label[] lblTime = new Label[3];
        Label[] lblResult = new Label[3];
        Label[] lblUser = new Label[3];
        //All.Control.Light[] lightY = new All.Control.Light[22];

        frmLogin fLogin;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {


            mMain.AddInfoValue += mMain_AddInfoValue;
            mMain.AllMeterData.GetError += AllMeterData_GetError;
            mMain.LoadRemot();

            InitFrm();
            InitData();

            mMain.RunRemot();
            timFlush.Enabled = true;

        }
        #region//条码功能
        #endregion
        #region//数据显示
        private void AllMeterData_GetError(Exception e)
        {
            mMain.AddInfo(e.Message);
        }
        private void mMain_AddInfoValue(string value)
        {
            if (txtInfo.InvokeRequired)
            {
                txtInfo.Invoke(new cMain.AddInfoHandle(mMain_AddInfoValue), value);
            }
            else
            {
                if (txtInfo.Text.Length>5000)
                {
                    txtInfo.Text = "";
                }
                txtInfo.AppendText(string.Format("{0}\r\n",value));
            }
        }
        #endregion
        private void StringValue_ChangeValue(string Value, string OldValue, string Info, int index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    if (Value != "" && fLogin == null)
                    {
                        //员工条码登陆
                        if ((Value.Length < 16) ||
                           ((Value.Length % 2) == 0 && Value.Substring(0, Value.Length / 2) == Value.Substring(Value.Length / 2)))
                        {
                            CheckUser(Value.Trim());
                        }
                        else//生产条码扫描
                        {
                            ReadBarCode(Value, index);
                        }
                    }
                    break;
                case 3:
                    string[] buff = frmMain.mMain.OrderSet.GetNextBarCode(false, true);
                    if (buff != null && buff.Length == 2)
                    {
                        All.Class.Form.SetControlInfo(lblNextBar, "Text", buff[0]);
                        All.Class.Form.SetControlInfo(lblNextOrder, "Text", buff[1]);
                        btnPrint_Click(null, new EventArgs());
                    }
                    break;
            }
        }
        #region//界面初始化
        private void InitData()
        {
            frmMain.mMain.AllMeterData.AllReadValue.BoolValue.ChangeValue += BoolValue_ChangeValue;
            frmMain.mMain.AllMeterData.AllReadValue.StringValue.ChangeValue += StringValue_ChangeValue;
            frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].MeterConnChange += frmMain_MeterConnChange;//远程连接
            switch (frmMain.mMain.AllDataXml.LocalSettings.TestNo)
            {
                case 1:
                    btnSwitch_Click(btnSwitch, new EventArgs());
                    break;
            }
        }

        void BoolValue_ChangeValue(bool Value, bool OldValue, string Info, int index)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new All.Communite.DataReadAndWrite.AllData.Data<bool>.ChangeValueHandle(BoolValue_ChangeValue), Value, OldValue, Info, index);
            }
            else
            {
                switch (index)
                {
                    case 0:
                        if (frmCloseWindow == null)
                        {
                            frmCloseWindow = new frmClose();
                            if (frmCloseWindow.ShowDialog() == DialogResult.Yes)
                            {
                                Exit = true;
                                this.Close();
                                System.Diagnostics.Process.Start("ShutDown", "-p -f");
                            }
                            frmCloseWindow.Dispose();
                            frmCloseWindow = null;
                        }
                        break;
                }
            }
        }

        private void frmMain_MeterConnChange(string text, bool conn)
        {
            frmMain.mMain.AddInfo(string.Format("主机通讯连接{0}", (conn ? "恢复" : "失败")));
        }
        private void InitFrm()
        {
            for (int i = 0; i < lblBar.Length; i++)
            {
                lblBar[i] = (Label)this.Controls.Find(string.Format("lblBar{0}", i + 1), true)[0];
                lblOrder[i] = (Label)this.Controls.Find(string.Format("lblOrder{0}", i + 1), true)[0];
                lblTime[i] = (Label)this.Controls.Find(string.Format("lblTime{0}", i + 1), true)[0];
                lblResult[i] = (Label)this.Controls.Find(string.Format("lblResult{0}", i + 1), true)[0];
                lblUser[i] = (Label)this.Controls.Find(string.Format("lblUser{0}", i + 1), true)[0];
            }
            #region//初始化显示界面
            //初始化选项卡
            if (mMain.StationSet.TestOne == 0)
            {
                tabControl1.TabPages.Remove(tabTestOne);
            }
            if (mMain.StationSet.TestTwo == 0)
            {
                tabControl1.TabPages.Remove(tabTestTwo);
            }
            if (mMain.StationSet.TestThree == 0)
            {
                tabControl1.TabPages.Remove(tabTestThree);
            }
            if (!mMain.StationSet.MaterialShow)
            {
                tabControl1.TabPages.Remove(tabMaterial);
            }
            if (!mMain.StationSet.ErrorShow)
            {
                tabControl1.TabPages.Remove(tabError);
            }
            if (!mMain.StationSet.RepairShow)
            {
                tabControl1.TabPages.Remove(tabRepair);
            }
            if (!mMain.StationSet.InLine)
            {
                tabControl1.TabPages.Remove(tabInLine);
            }
            else
            {
                InitChart();
                timFlushLenNingQi.Enabled = true;
            }
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 1)
            {
                grpBarCode.Visible = true;
                grpBarCode.Location = panEmptyOne.Location;
                frmMain.mMain.AiWrite.PrintOverShangXianOK += AiWrite_PrintOverOK;
                frmMain.mMain.AiWrite.PrintAllOver += AiWrite_PrintAllOver;
            }
            else
            {
                grpBarCode.Visible = false;
            }
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 2 || frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7)
            {
                mediaPlayer1.Visible = false;
                picNiuJu.Size = panNiuJu.Size;
                picNiuJu.Location = new Point(0, 0);

                grpNiuJuResult.Visible = true;
                grpNiuJuResult.Location = panEmptyOne.Location;
            }
            else
            {
                grpNiuJuResult.Visible = false;
                grpNiuJu.Visible = false;
            }

            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 5)
            {
                grpLenNingQi.Visible = true;
                grpLenNingQi.Location = panEmptyOne.Location;
            }
            else
            {
                grpLenNingQi.Visible = false;
            }
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7)
            {
                picNiuJu2.Size = panNiuJu.Size;
                picNiuJu2.Location = new Point(0, 0);

                grpNiuJuResult2.Visible = true;
                grpNiuJuResult2.Location = panEmptyTwo.Location;
            }
            else
            {
                grpNiuJuResult2.Visible = false;
                picNiuJu2.Visible = false;
            }
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 9)
            {
                timFlushImage.Enabled = true;
                mediaPlayer1.Visible = false;
                picYinXiang.Size = panYinXiang.Size;
                picYinXiang.Location = new Point(0, 0);
                grpXiangJi.Location = panEmptyOne.Location;

                grpBiaoTie.Location = panEmptyTwo.Location;
                grpBiaoTie.Visible = true;
            }
            else
            {
                grpYinXiang.Visible = false;
                grpXiangJi.Visible = false;
                grpBiaoTie.Visible = false;
            }
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 11)
            {
                grpZheWang.Visible = true;
                grpZheWang.Location = panEmptyOne.Location;
                frmMain.mMain.FlushZheWang.ZheWangJi.ZheWangOver += ZheWangJi_ZheWangOver;
            }
            else
            {
                grpZheWang.Visible = false;
            }
            //初始化界面
            lblText.Text = string.Format(string.Format("生产信息化 - {0}", mMain.StationSet.StationName));

            #endregion
            #region//初始化叫料界面
            List<HeiFeiMideaDll.cDataLocal.StatueMaterial> allCallMaterial = mMain.AllDataBase.Local.GetStatueMaterial(mMain.AllDataXml.LocalSettings.TestNo);
            for (int i = 0; i < dgvMaterial.Columns.Count; i++)
            {
                dgvMaterial.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMaterial.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvMaterial.Columns["colIndex"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMaterial.Columns["colStatue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMaterial.Columns["colCall"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMaterial.Columns["colCancel"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMaterial.Columns["colIndex"].Width = 80;
            dgvMaterial.Columns["colStatue"].Width = 100;
            dgvMaterial.Columns["colCall"].Width = 100;
            dgvMaterial.Columns["colCancel"].Width = 100;
            dgvMaterial.Columns["colCallOver"].Visible = false;
            dgvMaterial.Columns["colIndex"].DataPropertyName = "Index";
            dgvMaterial.Columns["colStatue"].DataPropertyName = "Statue";
            dgvMaterial.Columns["colMaterial"].DataPropertyName = "Material";
            dgvMaterial.Columns["colCall"].DataPropertyName = "Call";
            dgvMaterial.Columns["colCancel"].DataPropertyName = "Cancel";
            dgvMaterial.Columns["colCallOver"].DataPropertyName = "CallOver";
            DataGridViewImageColumn dgimg = (DataGridViewImageColumn)dgvMaterial.Columns["colStatue"];
            dgimg.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DataGridViewButtonColumn dgbtn = (DataGridViewButtonColumn)dgvMaterial.Columns["colCall"];
            dgbtn.Text = "叫料";
            dgbtn = (DataGridViewButtonColumn)dgvMaterial.Columns["colCancel"];
            dgbtn.Text = "取消";

            List<HeiFeiMideaDll.cDataLocal.Material> allMaterial = mMain.AllDataBase.Local.GetMaterial(mMain.AllDataXml.LocalSettings.TestNo);
            DataTable dt = new DataTable();
            dt.Columns.Add("Index", typeof(int));
            dt.Columns.Add("Statue", typeof(Image));
            dt.Columns.Add("Material", typeof(string));
            dt.Columns.Add("Call", typeof(string));
            dt.Columns.Add("Cancel", typeof(string));
            dt.Columns.Add("CallOver", typeof(bool));
            int index = 0;
            DataRow dr;
            allMaterial.ForEach(
                material =>
                {
                    dr = dt.NewRow();
                    dr["Index"] = 0;
                    dr["Material"] = material.Text;
                    index = allCallMaterial.FindIndex(
                        callMaterial =>
                        {
                            return callMaterial.Material == material.Text;
                        }
                        );
                    if (index < 0)
                    {
                        dr["Statue"] = HeiFeiMideaPlayer.Properties.Resources.Empty.ToBitmap();
                        dr["CallOver"] = false;
                        dr["index"] = 0;
                    }
                    else
                    {
                        dr["Statue"] = HeiFeiMideaPlayer.Properties.Resources.Call.ToBitmap();
                        dr["CallOver"] = true;
                        dr["Index"] = allCallMaterial[index].MaterialCount;
                    }
                    dr["Call"] = "增加";
                    dr["Cancel"] = "减少";
                    dt.Rows.Add(dr);
                });
            dgvMaterial.DataSource = dt;
            dgvMaterial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMaterial.ColumnHeadersHeight = 40;
            dgvMaterial.Font = new Font("宋体", 14, FontStyle.Regular);
            dgvMaterial.RowTemplate.Height = 40;
            dgvMaterial.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 14, FontStyle.Bold);
            dgvMaterial.Update();
            #endregion
            #region//初始化故障输入界面
            for (int i = 0; i < dgvError.Columns.Count; i++)
            {
                dgvError.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvError.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvError.Columns["colErrorIndex"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvError.Columns["colErrorStatue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvError.Columns["colErrorIn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvError.Columns["colErrorOut"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvError.Columns["colErrorFrom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvError.Columns["colErrorIndex"].Width = 80;
            dgvError.Columns["colErrorStatue"].Width = 100;
            dgvError.Columns["colErrorIn"].Width = 100;
            dgvError.Columns["colErrorOut"].Width = 100;
            dgvError.Columns["colErrorFrom"].Width = 200;
            dgvError.Columns["colError"].Width = 180;
            dgvError.Columns["ColErrorIndex"].Visible = false;
            dgvError.Columns["colErrorOver"].Visible = false;
            dgvError.Columns["colErrorSpace"].Visible = false;
            dgvError.Columns["colErrorIndex"].DataPropertyName = "Index";
            dgvError.Columns["colErrorStatue"].DataPropertyName = "Statue";
            dgvError.Columns["colError"].DataPropertyName = "Error";
            dgvError.Columns["colErrorIn"].DataPropertyName = "Call";
            dgvError.Columns["colErrorOut"].DataPropertyName = "Cancel";
            dgvError.Columns["colErrorOver"].DataPropertyName = "CallOver";
            dgvError.Columns["colErrorFrom"].DataPropertyName = "ErrorFrom";
            dgvError.Columns["colErrorSpace"].DataPropertyName = "ErrorSpace";
            
            dgimg = (DataGridViewImageColumn)dgvError.Columns["colErrorStatue"];
            dgimg.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgbtn = (DataGridViewButtonColumn)dgvError.Columns["colErrorIn"];
            dgbtn.Text = "故障输入";
            dgbtn = (DataGridViewButtonColumn)dgvError.Columns["colErrorOut"];
            dgbtn.Text = "取消输入";

            dt = new DataTable();
            dt.Columns.Add("Index", typeof(int));
            dt.Columns.Add("Statue", typeof(Image));
            dt.Columns.Add("Error", typeof(string));
            dt.Columns.Add("Call", typeof(string));
            dt.Columns.Add("Cancel", typeof(string));
            dt.Columns.Add("CallOver", typeof(bool));
            dt.Columns.Add("ErrorFrom", typeof(string));
            dt.Columns.Add("ErrorSpace", typeof(string));
            index = 0;
            dgvError.DataSource = dt;
            dgvError.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvError.ColumnHeadersHeight = 40;
            dgvError.Font = new Font("宋体", 14, FontStyle.Regular);
            dgvError.RowTemplate.Height = 40;
            dgvError.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 14, FontStyle.Bold);
            dgvError.Update();
            #endregion
            #region//初始化返修界面
            for (int i = 0; i < dgvRepair.Columns.Count; i++)
            {
                dgvRepair.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvRepair.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvRepair.Columns["colRepairIndex"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRepair.Columns["colRepairStatue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRepair.Columns["colRepairIn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRepair.Columns["colRepairOut"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvRepair.Columns["colRepairIndex"].Width = 80;
            dgvRepair.Columns["colRepairStatue"].Width = 100;
            dgvRepair.Columns["colRepairIn"].Width = 100;
            dgvRepair.Columns["colRepairOut"].Width = 100;
            dgvRepair.Columns["colRepairOver"].Visible = false;
            dgvRepair.Columns["colErrorFrom2"].Visible = false;
            dgvRepair.Columns["colErrorSpace2"].Visible = false;
            dgvRepair.Columns["colRepairIndex"].DataPropertyName = "Index";
            dgvRepair.Columns["colRepairStatue"].DataPropertyName = "Statue";
            dgvRepair.Columns["colRepair"].DataPropertyName = "Repair";
            dgvRepair.Columns["colRepairIn"].DataPropertyName = "Call";
            dgvRepair.Columns["colRepairOut"].DataPropertyName = "Cancel";
            dgvRepair.Columns["colRepairOver"].DataPropertyName = "CallOver";
            dgvRepair.Columns["colErrorFrom2"].DataPropertyName = "ErrorFrom";
            dgvRepair.Columns["colErrorSpace2"].DataPropertyName = "ErrorSpace";
            dgimg = (DataGridViewImageColumn)dgvRepair.Columns["colRepairStatue"];
            dgimg.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgbtn = (DataGridViewButtonColumn)dgvRepair.Columns["colRepairIn"];
            dgbtn.Text = "返修完成";
            dgbtn = (DataGridViewButtonColumn)dgvRepair.Columns["colRepairOut"];
            dgbtn.Text = "取消完成";
            InitRepairData(null);
            dgvRepair.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRepair.ColumnHeadersHeight = 40;
            dgvRepair.Font = new Font("宋体", 14, FontStyle.Regular);
            dgvRepair.RowTemplate.Height = 40;
            dgvRepair.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 14, FontStyle.Bold);
            dgvRepair.Update();
            #endregion
        }


        #endregion
        #region//用户登陆
        private void picLogin_Click(object sender, EventArgs e)
        {
            fLogin = new frmLogin();
            if (fLogin.ShowDialog() == DialogResult.Yes)
            {
                //lblText.Text = string.Format(string.Format("生产信息化 - {0} - 用户：{1}", mMain.StationSet.StationName,
                //     fl.UserName));
                //lblUser1.Text = fl.UserName;
                //frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>((new string[] { lblUser1.Text, lblUser1.Text, lblUser1.Text }).ToList(), 3, 5);
            }
            fLogin.Dispose();
            fLogin = null;
        }
        private void picLogin2_Click(object sender, EventArgs e)
        {

            //frmLogin fl = new frmLogin();
            //if (fl.ShowDialog() == DialogResult.Yes)
            //{
            //    lblUser2.Text = fl.UserName;
            //    frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(lblUser2.Text, 4);
            //}
        }

        private void picLogin3_Click(object sender, EventArgs e)
        {

            //frmLogin fl = new frmLogin();
            //if (fl.ShowDialog() == DialogResult.Yes)
            //{
            //    lblUser3.Text = fl.UserName;
            //    frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(lblUser3.Text, 5);
            //}
        }
        #endregion
        bool Exit = false;
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Exit)
            {
                if (All.Window.MetroMessageBox.Show(this, "是否确定退出测试程序？", "是否确定退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                timFlush.Stop();
                timFlushImage.Stop();
                timNiuJu.Stop();
                mediaPlayer1.Stop();   
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        delegate void PlayFileHandle();
        private void PlayFile()
        {
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 2 ||
                frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7)
            {
                return;
            }
            if (mediaPlayer1.InvokeRequired)
            {
                mediaPlayer1.Invoke(new PlayFileHandle(PlayFile));
            }
            else
            {
                string file = "";
                int start = 0;

                if (mMain.AllDataXml.LocalSettings.TestNo == 11)
                {
                    if (frmMain.mMain.CarLocal.ModeZheWangSet.ID == "")
                    {
                        return;
                    }
                    file = frmMain.mMain.CarLocal.ModeZheWangSet.PlayFile;
                    start = frmMain.mMain.CarLocal.ModeZheWangSet.Start;
                }
                else
                {
                        if (frmMain.mMain.CarLocal.ModeSet[0].ID == "")
                        {
                            return;
                        }
                        file = frmMain.mMain.CarLocal.ModeSet[0].PlayFile[mMain.AllDataXml.LocalSettings.TestNo - 1];

                        start = frmMain.mMain.CarLocal.ModeSet[0].Start[mMain.AllDataXml.LocalSettings.TestNo - 1];
                    
                }
                if (file == "" || start < 0)
                {
                    return;
                }
                mediaPlayer1.Refresh();
                string curFile = string.Format("{0}\\Video\\{1}", cMain.MediaFile, file);
                if (!System.IO.File.Exists(curFile))
                {
                    DownLoad(file, "Video");
                }
                else
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(curFile);
                    long localLast = fi.Length;
                    fi = null;
                    long remotLast = All.Class.DownLoadFile.FtpFileLength(string.Format("{0}//Video//{1}", cMain.RemotFtp, file), "", "");
                    if (localLast != remotLast)
                    {
                        DownLoad(file, "Video");
                    }
                }
                if (System.IO.File.Exists(curFile))
                {
                    mediaPlayer1.SetFile(curFile);
                    mediaPlayer1.Play();
                }
                else
                {
                    frmMain.mMain.AddInfo(string.Format("从主机下载文件{0}失败", file));
                }
            }
        }
        private void DownLoad(string file, string directory)
        {
            All.Class.DownLoadFile.FtpDownLoad(string.Format("{0}//{1}//{2}", cMain.RemotFtp, directory, file), string.Format("{0}\\{1}\\{2}", cMain.MediaFile, directory, file));
        }

        private void mediaPlayer1_MediaEnd()
        {
            PlayFile();
        }

        private void mediaPlayer1_OnMouseDoubleClick()
        {
            mediaPlayer1.BringToFront();
            if (mediaPlayScreen == Rectangle.Empty)
            {
                mediaPlayScreen = mediaPlayer1.Bounds;
                mediaPlayer1.Size = Screen.PrimaryScreen.Bounds.Size;
                mediaPlayer1.Location = new Point(0, 0);
                return;
            }
            if (mediaPlayer1.Size == Screen.PrimaryScreen.Bounds.Size)
            {
                mediaPlayer1.Size = mediaPlayScreen.Size;
                mediaPlayer1.Location = mediaPlayScreen.Location;
                mediaPlayScreen = Rectangle.Empty;
                return;
            }
        }
        #region//选项卡切换，切换显示
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count <= 0)
            {
                return;
            }
            if (tabShowScreen == Rectangle.Empty)
            {
                tabShowScreen = tabControl1.Bounds;
            }
            switch (tabControl1.TabPages[tabControl1.SelectedIndex].Name)
            {
                case "tabMaterial":
                case "tabError":
                case "tabRepair":
                case "tabInLine":
                    tabControl1.Height = panList.Height;
                    tabControl1.BringToFront();
                    break;
                case "tabTestOne":
                    tabControl1.Size = tabShowScreen.Size;
                    picNiuJu.BringToFront();
                    break;
                case "tabTestTwo":
                    tabControl1.Size = tabShowScreen.Size;
                    picNiuJu2.BringToFront();
                    break;
                case "tabTestThree":
                    tabControl1.Size = tabShowScreen.Size;
                    break;
            }
        }
        #endregion
        private void panAllSize_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            All.Class.Style.ChangeColor(Color.FromArgb(255, (byte)All.Class.Num.GetRandom(0, 255), (byte)All.Class.Num.GetRandom(0, 255), (byte)All.Class.Num.GetRandom(0, 255)));
        }
        #region//呼叫物料表格
        private void dgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)dgvMaterial.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                return;
            }
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dt.Columns.Count)
            {
                return;
            }
            if (e.RowIndex < 0 || e.RowIndex >= dt.Rows.Count)
            {
                return;
            }
            int count = All.Class.Num.ToInt(dt.Rows[e.RowIndex][0]);
            switch (e.ColumnIndex)
            {
                case 3:
                    if (count <= 0)
                    {
                        mMain.AddInfo(string.Format("呼叫物料：{0}", dt.Rows[e.RowIndex][2]));
                        dt.Rows[e.RowIndex][1] = HeiFeiMideaPlayer.Properties.Resources.Call.ToBitmap();
                        dt.Rows[e.RowIndex]["CallOver"] = true;
                    }
                    dt.Rows[e.RowIndex][0] = count + 1;//数量加一
                    dgvMaterial.DataSource = dt;
                    break;
                case 4:
                    if (count > 0)
                    {
                        count = count - 1;
                        dt.Rows[e.RowIndex][0] = count;
                    }
                    else
                    {
                        return;
                    }
                    if (count == 0)
                    {
                        dt.Rows[e.RowIndex][1] = HeiFeiMideaPlayer.Properties.Resources.Empty.ToBitmap();
                        dt.Rows[e.RowIndex]["CallOver"] = false;
                        mMain.AddInfo(string.Format("取消呼叫：{0}", dt.Rows[e.RowIndex][2]));

                        HeiFeiMideaDll.cDataLocal.StatueMaterial tmp = new HeiFeiMideaDll.cDataLocal.StatueMaterial(mMain.AllDataXml.LocalSettings.TestNo, dt.Rows[e.RowIndex][2].ToString(), e.RowIndex);
                        frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("delete from StatueMaterial where WorkStation={0} and Material='{1}'",
                            mMain.AllDataXml.LocalSettings.TestNo, dt.Rows[e.RowIndex][2].ToString()));
                        frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("Insert into StatueMaterial Values({0},'{1}',{2},{3},'{4:yyyy-MM-dd HH:mm:ss}','true')",
                            tmp.WorkStation, tmp.Material, tmp.MaterialNum, tmp.MaterialCount, tmp.SendTime));
                    }
                    dgvMaterial.DataSource = dt;
                    break;
            }
        }
        #endregion
        #region//故障录入
        private void dgvError_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)dgvError.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                return;
            }
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dt.Columns.Count)
            {
                return;
            }
            if (e.RowIndex < 0 || e.RowIndex >= dt.Rows.Count)
            {
                return;
            }
            switch (dgvError.Columns[e.ColumnIndex].Name)
            {
                case "colErrorIn":
                    if (!All.Class.Num.ToBool(dt.Rows[e.RowIndex]["CallOver"]))
                    {
                        dt.Rows[e.RowIndex][1] = HeiFeiMideaPlayer.Properties.Resources.No.ToBitmap();
                        dt.Rows[e.RowIndex]["CallOver"] = true;
                        mMain.AddInfo(string.Format("输入故障：{0}", dt.Rows[e.RowIndex][2]));
                    }
                    dgvError.DataSource = dt;
                    break;
                case "colErrorOut":
                    if (All.Class.Num.ToBool(dt.Rows[e.RowIndex]["CallOver"]))
                    {
                        dt.Rows[e.RowIndex][1] = HeiFeiMideaPlayer.Properties.Resources.Empty.ToBitmap();
                        dt.Rows[e.RowIndex]["CallOver"] = false;
                        mMain.AddInfo(string.Format("取消故障：{0}", dt.Rows[e.RowIndex][2]));
                    }
                    dgvError.DataSource = dt;
                    break;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvError.EndEdit();
            DataTable dt = (DataTable)dgvError.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                return;
            }
            List<ErrorIn> ErrorName = new List<ErrorIn>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (All.Class.Num.ToBool(dt.Rows[i]["CallOver"]))
                {
                    ErrorName.Add(new ErrorIn(All.Class.Num.ToString(dt.Rows[i]["Error"]),
                        All.Class.Num.ToString(dt.Rows[i]["ErrorFrom"]),
                        All.Class.Num.ToInt(dt.Rows[i]["ErrorSpace"])));
                }
            }
            if (ErrorName.Count > 0)
            {
                int index = 0;
                ErrorName.ForEach(
                    str =>
                    {
                        frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("insert into StatueError (WorkStation,BarCode,Error,ErrorNum,ErrorTime,Repair,RepairTime,ErrorFrom,ErrorSpace) Values ({0},'{1}','{2}',{3},'{4:yyyy-MM-dd HH:mm:ss}','false','{4:yyyy-MM-dd HH:mm:ss}','{5}',{6})",
                            frmMain.mMain.AllDataXml.LocalSettings.TestNo, lblErrorBarCode.Text, str.ErrorName, index++, DateTime.Now,str.ErrorFrom,str.ErrorSpace));
                        if (str.ErrorSpace > 0 && str.ErrorSpace <= frmMain.mMain.FlushAllUser.allLineStation.Count)
                        {
                            frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("insert into StatueUserError (UserName,TestTime,Error,BarCode) values ('{0}','{1:yyyy-MM-dd HH:mm:ss}','{2}','{3}')",
                                frmMain.mMain.FlushAllUser.allLineStation[str.ErrorSpace - 1].UserName, DateTime.Now, str.ErrorName,lblErrorBarCode.Text));
                        }
                    });
                All.Window.MetroMessageBox.Show(this, "当前选择故障已成功录入系统", "录入成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt.Rows.Clear();
                dgvError.DataSource = dt;
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "对不起，当前没有选择的故障，不能输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region//上线工位。即条码生成工位
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(btnPrint_Click), sender, e);
            }
            else
            {
                if (sender == null)//上位机传输过来的打印命令
                {
                    if (!chkAutoPrint.Checked)
                    {
                        return;
                    }
                }
                if (lblNextBar.Text != "")
                {
                    btnPrint.Enabled = false;
                    frmMain.mMain.AiWrite.PrintBar(lblNextBar.Text, HeiFeiMideaDll.cMain.AllComputerList.上线);
                }
            }
        }
        /// <summary>
        /// 打印操作执行完成后
        /// </summary>
        private void AiWrite_PrintAllOver()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new cAiWrite.PrintAllOverHandle(AiWrite_PrintAllOver));
            }
            else
            {
                btnPrint.Enabled = true;
            }
        }
        /// <summary>
        /// 手动补一个条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNextBar_Click(object sender, EventArgs e)
        {
            All.Window.KeyBoard kb = new All.Window.KeyBoard(lblNextBar.Text);
            if (kb.ShowDialog() == DialogResult.Yes)
            {
                using (DataTable dt = frmMain.mMain.AllDataBase.DataBarCode.Read(string.Format("select Boss,Mode,OrderName from AllBarCode where Midea='{0}'", kb.Value)))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        frmMain.mMain.AiWrite.PrintBar(kb.Value, HeiFeiMideaDll.cMain.AllComputerList.上线);
                        frmMain.mMain.AddInfo(string.Format("当前条码{0}，正在打印中，请稍候...", kb.Value));
                    }
                    else
                    {
                        All.Window.MetroMessageBox.Show(this, "当前条码非系统内打印条码，不能重新打印", "错误的条码", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } 
            }
            kb.Dispose();
        }
        /// <summary>
        /// 打印OK后,只有1号工位才会调用
        /// </summary>
        /// <param name="mBarCode"></param>
        /// <param name="bBarCode"></param>
        private void AiWrite_PrintOverOK(string mBarCode, string bBarCode,string mMode)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new cAiWrite.PrintOverOKHandle(AiWrite_PrintOverOK), mBarCode, bBarCode,mMode);
            }
            else
            {
                HeiFeiMideaDll.OrderSet tmpOrderSet = HeiFeiMideaDll.OrderSet.GetOrder(frmMain.mMain.OrderSet.TodayOrder, mBarCode, frmMain.mMain.AllDataXml.LocalSettings.TestNo);

                string[] buff = frmMain.mMain.OrderSet.GetNextBarCode(false, true);
                if (buff != null && buff.Length == 2)
                {
                    All.Class.Form.SetControlInfo(lblNextBar, "Text", buff[0]);
                    All.Class.Form.SetControlInfo(lblNextOrder, "Text", buff[1]);
                }

                frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("delete from PrintMachine where BarCode='{0}'", mBarCode));

                if (frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("insert into PrintMachine (orderName,BarCode,InLineTime,Mode,TestYear,TestMonth,TestDay) values('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}','{3}',{2:yyyy},{2:MM},{2:dd})",
                    tmpOrderSet.OrderName, mBarCode, DateTime.Now, "")) <= 0)
                {
                    frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("insert into PrintMachine (orderName,BarCode,InLineTime,Mode,TestYear,TestMonth,TestDay) values('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}','{3}',{2:yyyy},{2:MM},{2:dd})",
                       tmpOrderSet.OrderName, mBarCode, DateTime.Now, ""));
                }

                frmMain.mMain.AllDataBase.DataBarCode.Write(string.Format("delete from AllBarCode where Midea='{0}'", mBarCode));
                frmMain.mMain.AllDataBase.DataBarCode.Write(string.Format("insert into AllBarCode (Midea,Boss,Mode,OrderName) values ('{0}','{1}','{2}','{3}')", mBarCode, bBarCode, mMode, tmpOrderSet.OrderName));

                //Dictionary<string, string> buff = new Dictionary<string, string>();
                //buff.Add("BarCode", mBarCode);
                //buff.Add("BoShiBarCode", bBarCode);
                //buff.Add("Random", All.Class.Num.GetRandom(0, 1000).ToString());
                //buff.Add("Mode", mMode);

                //frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 0);

            }
        }
        private void ZheWangJi_ZheWangOver(string Mode)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new FlushZheWang.ZheWang.ZheWangOverHandle(ZheWangJi_ZheWangOver), Mode);
            }
            else
            {
                lblZheWangJiXing.Text = Mode;
                frmMain.mMain.AllDataXml.LocalZheWangs.ZheWangIndex++;
                frmMain.mMain.AllDataXml.LocalZheWangs.Save();
                lblPrintBar.Text = string.Format("{0}{1:yyyyMMdd}{2:D4}", lblZheWangJiXing.Text, DateTime.Now, frmMain.mMain.AllDataXml.LocalZheWangs.ZheWangIndex);
                cReport.Save(lblPrintBar.Text);
                btnOneIn_Click(btnOneIn, null);
                frmMain.mMain.AiWrite.PrintBar(lblPrintBar.Text, HeiFeiMideaDll.cMain.AllComputerList.折弯机);
            }
        }
        private void lblPrintBar_Click(object sender, EventArgs e)
        {
            All.Window.KeyBoard k = new All.Window.KeyBoard(lblPrintBar.Text);
            if (k.ShowDialog() == DialogResult.Yes)
            {
                lblPrintBar.Text = k.Value;
                frmMain.mMain.AiWrite.PrintBar(lblPrintBar.Text, HeiFeiMideaDll.cMain.AllComputerList.折弯机);
            }
        }
        private void btnOneIn_Click(object sender, EventArgs e)
        {
            if (lblPrintBar.Text.Length > 10)
            {
                frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(GetSendLenNingInValue(), 0);
            }
        }
        private string GetSendLenNingInValue()
        {
            if (lblPrintBar.Text.Length < 10)
            {
                return "";
            }
            Dictionary<string,string> buff = new Dictionary<string, string>();
            buff.Add("BarCode", lblPrintBar.Text);
            buff.Add("Random", All.Class.Num.GetRandom(0, 1000).ToString());
            return All.Class.SSFile.Dictionary2Text(buff);
                                              
        }
        private void btnThreeIn_Click(object sender, EventArgs e)
        {
            if (lblPrintBar.Text.Length > 10)
            {
                frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(GetSendLenNingInValue(), 1);
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 1)
            {
                string[] nextValue = frmMain.mMain.OrderSet.GetNextBarCode(true, false);
                lblNextBar.Text = nextValue[0];
                lblNextOrder.Text = nextValue[1];
            }
        }
        #endregion
        private void timFlush_Tick(object sender, EventArgs e)
        {
            //刷新小窗体的显示
            List<HeiFeiMideaDll.TestError> tmpBuff;
            if (frmMain.mMain.CarLocal.ModeIDChangeOne)
            {
                frmMain.mMain.CarLocal.ModeIDChangeOne = false;
                lblErrorBarCode.Text = frmMain.mMain.CarLocal.AllStatueStation[0].BarCode;
                //有条码刷新时，更新要打印的条码。
                if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 1)
                {
                    string[] buff = frmMain.mMain.OrderSet.GetNextBarCode(false, true);
                    if (buff != null && buff.Length == 2)
                    {
                        All.Class.Form.SetControlInfo(lblNextBar, "Text", buff[0]);
                        All.Class.Form.SetControlInfo(lblNextOrder, "Text", buff[1]);
                    }
                }
                mediaPlayer1.Stop();
                if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 2 ||
                    frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7)
                {
                    ShowNiuJuImage(0);
                }
                else if (frmMain.mMain.AllDataXml.LocalSettings.TestNo != 9)//影像检测显示的是影像数据
                {
                    PlayFile();
                }
                if (frmMain.mMain.CarLocal.AllStatueStation[0].BarCode != "")
                {
                    tmpBuff = cRepair.GetErrorFromBar(frmMain.mMain.CarLocal.AllStatueStation[0].BarCode);
                    if (tmpBuff != null && tmpBuff.Count > 0)
                    {
                        frmMain.mMain.AddInfo(string.Format("故障条码:{0}", frmMain.mMain.CarLocal.AllStatueStation[0].BarCode));
                        for (int i = 0; i < tmpBuff.Count; i++)
                        {
                            frmMain.mMain.AddInfo(string.Format("故障内容:{0}", tmpBuff[i].Error));
                        }
                    }
                }
                frmMain.mMain.CarLocal.ModeIDChangeOne = false;
            }
            if (frmMain.mMain.CarLocal.ModeIDChangeTwo)
            {
                frmMain.mMain.CarLocal.ModeIDChangeTwo = false;
                if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7)
                {
                    ShowNiuJuImage(1);
                }
                if (frmMain.mMain.CarLocal.AllStatueStation[1].BarCode != "")
                {
                    lblYinXiangBar.Text = frmMain.mMain.CarLocal.AllStatueStation[1].BarCode;
                    tmpBuff = cRepair.GetErrorFromBar(frmMain.mMain.CarLocal.AllStatueStation[1].BarCode);
                    if (tmpBuff != null && tmpBuff.Count > 0)
                    {
                        frmMain.mMain.AddInfo(string.Format("故障条码:{0}", frmMain.mMain.CarLocal.AllStatueStation[1].BarCode));
                        for (int i = 0; i < tmpBuff.Count; i++)
                        {
                            frmMain.mMain.AddInfo(string.Format("故障内容:{0}", tmpBuff[i].Error));
                        }
                    }

                }
            }
            //刷新标签的显示
            //if (lblUser[0].Text.IndexOf("(无)") >= 0)
            //{
            //    lblText.Text = string.Format(string.Format("生产信息化 - {0} - 用户：{1}", mMain.StationSet.StationName,
            //         frmMain.mMain.CarLocal.AllStatueStation[0].UserName));
            //}
            for (int i = 0; i < lblBar.Length; i++)
            {
                lblBar[i].Text = frmMain.mMain.CarLocal.AllStatueStation[i].BarCode;
                lblOrder[i].Text = frmMain.mMain.CarLocal.AllStatueStation[i].OrderName;
                lblTime[i].Text = frmMain.mMain.CarLocal.AllStatueStation[i].TestTime.ToString();
                if (frmMain.mMain.CarLocal.AllStatueStation[i].TestResult)
                {
                    lblResult[i].Text = "合格";
                    lblResult[i].ForeColor = Color.Green;
                }
                else
                {
                    lblResult[i].Text = "不合格";
                    lblResult[i].ForeColor = Color.Red;
                }
                if (lblUser[i].Text.IndexOf("(无)") >= 0)
                {
                    lblUser[i].Text = frmMain.mMain.CarLocal.AllStatueStation[i].UserName;
                }
            }
        }
        private void InitRepairData(List<HeiFeiMideaDll.TestError> allErrors)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            int index = 0;
            dt.Columns.Add("Index", typeof(int));
            dt.Columns.Add("Statue", typeof(Image));
            dt.Columns.Add("Repair", typeof(string));
            dt.Columns.Add("Call", typeof(string));
            dt.Columns.Add("Cancel", typeof(string));
            dt.Columns.Add("CallOver", typeof(bool));
            dt.Columns.Add("ErrorFrom", typeof(string));
            dt.Columns.Add("ErrorSpace", typeof(int));
            if (allErrors != null)
            {
                allErrors.ForEach(
                    error =>
                    {
                        dr = dt.NewRow();
                        dr["Index"] = index++;
                        dr["Statue"] = HeiFeiMideaPlayer.Properties.Resources.Empty.ToBitmap();
                        dr["Repair"] = error.Error;
                        dr["Call"] = "返修完成";
                        dr["Cancel"] = "取消完成";
                        dr["CallOver"] = false;
                        dr["ErrorFrom"] = error.ErrorFrom;
                        dr["ErrorSpace"] = error.ErrorSpace;
                        dt.Rows.Add(dr);
                    });
            }
            dgvRepair.DataSource = dt;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvRepair.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                return;
            }
            List<ErrorIn> buff = new List<ErrorIn>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (All.Class.Num.ToBool(dt.Rows[i]["CallOver"]))
                {
                    buff.Add(new ErrorIn(
                        All.Class.Num.ToString(dt.Rows[i]["Repair"]),
                        All.Class.Num.ToString(dt.Rows[i]["ErrorFrom"]),
                        All.Class.Num.ToInt(dt.Rows[i]["ErrorSpace"])));
                }
            }
            if (buff.Count > 0)
            {
                int index = 0;
                buff.ForEach(
                    str =>
                    {
                        frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("delete from StatueError where Barcode='{0}' and Error='{1}'", lblRepairBarCode.Text, str));

                        frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("insert into StatueError (WorkStation,BarCode,Error,ErrorNum,ErrorTime,Repair,RepairTime,ErrorFrom,ErrorSpace) Values ({0},'{1}','{2}',{3},'{4:yyyy-MM-dd HH:mm:ss}','True','{4:yyyy-MM-dd HH:mm:ss}','{5}',{6})",
                            frmMain.mMain.AllDataXml.LocalSettings.TestNo, lblRepairBarCode.Text, str.ErrorName, index++, DateTime.Now,str.ErrorFrom,str.ErrorSpace));
                    });
                All.Window.MetroMessageBox.Show(this, "当前选择维修完成故障已成功录入系统", "录入成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "对不起，当前没有完成任何故障", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRepair_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)dgvRepair.DataSource;
            if (dt == null || dt.Rows.Count <= 0)
            {
                return;
            }
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dt.Columns.Count)
            {
                return;
            }
            if (e.RowIndex < 0 || e.RowIndex >= dt.Rows.Count)
            {
                return;
            }
            switch (e.ColumnIndex)
            {
                case 3:
                    if (!All.Class.Num.ToBool(dt.Rows[e.RowIndex]["CallOver"]))
                    {
                        dt.Rows[e.RowIndex][1] = HeiFeiMideaPlayer.Properties.Resources.Ok.ToBitmap();
                        dt.Rows[e.RowIndex]["CallOver"] = true;
                        mMain.AddInfo(string.Format("返修完成：{0}", dt.Rows[e.RowIndex][2]));
                    }
                    dgvRepair.DataSource = dt;
                    break;
                case 4:
                    if (All.Class.Num.ToBool(dt.Rows[e.RowIndex]["CallOver"]))
                    {
                        dt.Rows[e.RowIndex][1] = HeiFeiMideaPlayer.Properties.Resources.Empty.ToBitmap();
                        dt.Rows[e.RowIndex]["CallOver"] = false;
                        mMain.AddInfo(string.Format("取消完成：{0}", dt.Rows[e.RowIndex][2]));
                    }
                    dgvRepair.DataSource = dt;
                    break;
            }
        }

        private void btnMaterialCall_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvMaterial.DataSource;
            bool save = false;
            int count = 0;
            HeiFeiMideaDll.cDataLocal.StatueMaterial tmp;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                count = All.Class.Num.ToInt(dt.Rows[i][0]);
                if (count > 0)
                {
                    save = true;
                    tmp = new HeiFeiMideaDll.cDataLocal.StatueMaterial(mMain.AllDataXml.LocalSettings.TestNo, dt.Rows[i][2].ToString(), i);
                    frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("Insert into StatueMaterial Values({0},'{1}',{2},{3},'{4:yyyy-MM-dd HH:mm:ss}','false')",
                        tmp.WorkStation, tmp.Material, tmp.MaterialNum, count, tmp.SendTime));
                }
            }
            if (save)
            {
                All.Window.MetroMessageBox.Show(this, "所选物料已正常呼叫，请等待物料送达", "呼叫成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "当前没有选择任何物料，不能正常呼叫，请检查", "呼叫失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMaterialCancel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvMaterial.DataSource;
            bool save = false;
            int count = 0;
            HeiFeiMideaDll.cDataLocal.StatueMaterial tmp;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                count = All.Class.Num.ToInt(dt.Rows[i][0]);
                if (count > 0)
                {
                    save = true;
                    tmp = new HeiFeiMideaDll.cDataLocal.StatueMaterial(mMain.AllDataXml.LocalSettings.TestNo, dt.Rows[i][2].ToString(), i);
                    frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("delete from StatueMaterial where WorkStation={0} and Material='{1}'",
                                mMain.AllDataXml.LocalSettings.TestNo, dt.Rows[i][2].ToString()));
                    frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("Insert into StatueMaterial Values({0},'{1}',{2},{3},'{4:yyyy-MM-dd HH:mm:ss}','true')",
                        tmp.WorkStation, tmp.Material, tmp.MaterialNum, count, tmp.SendTime));
                }
            }
            if (save)
            {
                All.Window.MetroMessageBox.Show(this, "所选物料呼叫已取消", "取消成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "当前没有呼叫任何物料，不能正常取消，请检查", "取消失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Index"] = 0;
                dt.Rows[i][1] = HeiFeiMideaPlayer.Properties.Resources.Empty.ToBitmap();
                dt.Rows[i]["CallOver"] = false;
            }
            dgvMaterial.DataSource = dt;
        }
        delegate void ReadBarCodeHandle(string barCode, int barIndex);
        private void ReadBarCode(string barCode, int barIndex)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ReadBarCodeHandle(ReadBarCode), barCode, barIndex);
            }
            else
            {
                Dictionary<string, string> buff = new Dictionary<string, string>();
                frmMain.mMain.AddInfo("扫描条码:");
                frmMain.mMain.AddInfo(barCode);
                if (tabControl1.SelectedIndex >= 0 && tabControl1.SelectedIndex < tabControl1.TabPages.Count)
                {
                    switch (tabControl1.TabPages[tabControl1.SelectedIndex].Name)
                    {
                        case "tabRepair"://返修查询
                            lblRepairBarCode.Text = barCode;
                            InitRepairData(cRepair.GetErrorFromBar(barCode));
                            break;
                        default:
                            lblErrorBarCode.Text = barCode;
                            switch (mMain.AllDataXml.LocalSettings.TestNo)
                            {
                                case 0://电脑工位
                                    break;
                                case 5:
                                    if (rbtFanXiu.Checked)//返修上线
                                    {
                                        lblLengNinQi.Text = barCode;
                                        buff = new Dictionary<string, string>();
                                        buff.Add("BarCode", barCode);
                                        buff.Add("Random", All.Class.Num.GetRandom(0, 1000).ToString());
                                        frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 0);
                                    }
                                    else//冷凝器上线
                                    {
                                        lblLengNinQi.Text = barCode;
                                        if (barCode.Length <= 12)
                                        {
                                            mMain.AddInfo(string.Format("不是正确的冷凝器条码,条码的长度不够，不能正确识别冷凝器型号", barCode));
                                            return;
                                        }
                                        string zheWangID = barCode.Substring(0, barCode.Length - 12);
                                        if (frmMain.mMain.CarLocal.ModeSet[0] == null || frmMain.mMain.CarLocal.ModeSet[0].Mode == "")
                                        {
                                            mMain.AddInfo("当前小车上机器条码无对应机型，不法判断冷凝器是否匹配");
                                            return;
                                        }
                                        if (frmMain.mMain.CarLocal.ModeSet[0].ZheWangID == zheWangID)
                                        {
                                            buff = new Dictionary<string, string>();
                                            buff.Add("BarCode", frmMain.mMain.CarLocal.AllStatueStation[0].BarCode);
                                            buff.Add("LengNingBarCode", barCode);
                                            buff.Add("Random", All.Class.Num.GetRandom(0, 1000).ToString());
                                            frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 1);
                                            mMain.AddInfo("冷凝器匹配通过");
                                            frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<ushort>(1, 0);
                                        }
                                        else
                                        {
                                            mMain.AddInfo(string.Format("冷凝器匹配失败,正确的冷凝器型号为{0}",frmMain.mMain.CarLocal.ModeSet[0].ZheWangID));
                                            frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<ushort>(2, 0);
                                        }
                                    }
                                    break;
                                case 7:
                                    switch (barIndex)
                                    {
                                        case 0://1号条码枪
                                            if (frmMain.mMain.CarLocal.ModeSet[0] == null || frmMain.mMain.CarLocal.ModeSet[0].ID == "")
                                            {
                                                frmMain.mMain.AddInfo(string.Format("当前机型为空，无法判断当前给定的条码信号"));
                                                return;
                                            }
                                            if (barCode.IndexOf(frmMain.mMain.CarLocal.ModeSet[0].DianKongID) >= 0 &&
                                                frmMain.mMain.CarLocal.ModeSet[0].DianKongID != "")
                                            {
                                                buff = new Dictionary<string, string>();
                                                buff.Add("TestBarCode", barCode);
                                                buff.Add("BarCode", frmMain.mMain.CarLocal.AllStatueStation[0].BarCode);
                                                frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 0);
                                                frmMain.mMain.AddInfo("电控条码判断通过");
                                                return;
                                            }
                                            else
                                            {
                                                if (frmMain.mMain.CarLocal.FengJiNowID[0] >= 4)
                                                {
                                                    frmMain.mMain.AddInfo("电控条码判断失败");
                                                    return;
                                                }
                                            }
                                            if (barCode.IndexOf(frmMain.mMain.CarLocal.ModeSet[0].FengJiID[frmMain.mMain.CarLocal.FengJiNowID[0]]) >= 0
                                                && frmMain.mMain.CarLocal.ModeSet[0].FengJiID[frmMain.mMain.CarLocal.FengJiNowID[0]] != "")
                                            {
                                                buff = new Dictionary<string, string>();
                                                buff.Add("TestBarCode", barCode);
                                                buff.Add("BarCode", frmMain.mMain.CarLocal.AllStatueStation[0].BarCode);
                                                frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 1);
                                                frmMain.mMain.AddInfo("电控条码判断通过");
                                                frmMain.mMain.CarLocal.FengJiNowID[0]++;
                                                return;
                                            }
                                            frmMain.mMain.AddInfo("当前条码与风机和电控都不匹配");
                                            break;
                                        case 1://2号条码枪
                                            if (frmMain.mMain.CarLocal.ModeSet[1] == null || frmMain.mMain.CarLocal.ModeSet[1].ID == "")
                                            {
                                                frmMain.mMain.AddInfo(string.Format("当前机型为空，无法判断当前给定的条码信号"));
                                                return;
                                            }
                                            if (barCode.IndexOf(frmMain.mMain.CarLocal.ModeSet[1].DianKongID) >= 0 &&
                                                frmMain.mMain.CarLocal.ModeSet[1].DianKongID != "")
                                            {
                                                buff = new Dictionary<string, string>();
                                                buff.Add("TestBarCode", barCode);
                                                buff.Add("BarCode", frmMain.mMain.CarLocal.AllStatueStation[1].BarCode);
                                                frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 0);
                                                frmMain.mMain.AddInfo("电控条码判断通过");
                                                return;
                                            }
                                            else
                                            {
                                                if (frmMain.mMain.CarLocal.FengJiNowID[1] >= 4)
                                                {
                                                    frmMain.mMain.AddInfo("电控条码判断失败");
                                                    return;
                                                }
                                            }
                                            if (barCode.IndexOf(frmMain.mMain.CarLocal.ModeSet[1].FengJiID[frmMain.mMain.CarLocal.FengJiNowID[1]]) >= 0 &&
                                                frmMain.mMain.CarLocal.ModeSet[1].FengJiID[frmMain.mMain.CarLocal.FengJiNowID[1]] != "")
                                            {
                                                buff = new Dictionary<string, string>();
                                                buff.Add("TestBarCode", barCode);
                                                buff.Add("BarCode", frmMain.mMain.CarLocal.AllStatueStation[1].BarCode);
                                                frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 1);
                                                frmMain.mMain.AddInfo("电控条码判断通过");
                                                frmMain.mMain.CarLocal.FengJiNowID[1]++;
                                                return;
                                            }
                                            frmMain.mMain.AddInfo("当前条码与风机和电控都不匹配");

                                            break;
                                    }
                                    break;
                                case 1:
                                    //上传上位机
                                    buff = new Dictionary<string, string>();
                                    buff.Add("BarCode", barCode);
                                    buff.Add("Random", All.Class.Num.GetRandom(0, 1000).ToString());
                                    using (DataTable dt = frmMain.mMain.AllDataBase.DataBarCode.Read(string.Format("select Boss,Mode,OrderName from AllBarCode where Midea='{0}'", barCode)))
                                    {
                                        if (dt != null && dt.Rows.Count > 0)
                                        {
                                            buff.Add("BoShiBarCode", All.Class.Num.ToString(dt.Rows[0]["Boss"]));
                                            buff.Add("Mode", All.Class.Num.ToString(dt.Rows[0]["Mode"]));
                                            buff.Add("OrderName", All.Class.Num.ToString(dt.Rows[0]["OrderName"]));
                                        }
                                    }
                                    frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 0);
                                    break;
                                case 8:
                                    buff = new Dictionary<string, string>();
                                    buff.Add("BarCode", barCode);
                                    buff.Add("Random", All.Class.Num.GetRandom(0, 1000).ToString());
                                    frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 0);
                                    break;
                                case 11:
                                    //
                                    cReport.Repair(barCode);
                                    buff = new Dictionary<string, string>();
                                    buff.Add("BarCode", barCode);
                                    buff.Add("Random", All.Class.Num.GetRandom(0, 1000).ToString());
                                    frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 1);
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private void rbtLenNingQi_CheckedChanged(object sender, EventArgs e)
        {
            lblCheck.Text = (rbtLenNingQi.Checked ? "冷凝器条码" : "返修机条码");
        }

        private void btnFlush_Click(object sender, EventArgs e)
        {
            List<HeiFeiMideaDll.cDataLocal.StatueMaterial> allCallMaterial = mMain.AllDataBase.Local.GetStatueMaterial(mMain.AllDataXml.LocalSettings.TestNo);

            List<HeiFeiMideaDll.cDataLocal.Material> allMaterial = mMain.AllDataBase.Local.GetMaterial(mMain.AllDataXml.LocalSettings.TestNo);
            DataTable dt = new DataTable();
            dt.Columns.Add("Index", typeof(int));
            dt.Columns.Add("Statue", typeof(Image));
            dt.Columns.Add("Material", typeof(string));
            dt.Columns.Add("Call", typeof(string));
            dt.Columns.Add("Cancel", typeof(string));
            dt.Columns.Add("CallOver", typeof(bool));
            int index = 0;
            DataRow dr;
            allMaterial.ForEach(
                material =>
                {
                    dr = dt.NewRow();
                    dr["Material"] = material.Text;
                    index = allCallMaterial.FindIndex(
                        callMaterial =>
                        {
                            return callMaterial.Material == material.Text;
                        }
                        );
                    if (index < 0)
                    {
                        dr["Statue"] = HeiFeiMideaPlayer.Properties.Resources.Empty.ToBitmap();
                        dr["CallOver"] = false;
                        dr["index"] = 0;
                    }
                    else
                    {
                        dr["Statue"] = HeiFeiMideaPlayer.Properties.Resources.Call.ToBitmap();
                        dr["CallOver"] = true;
                        dr["Index"] = allCallMaterial[index].MaterialCount;
                    }
                    dr["Call"] = "增加";
                    dr["Cancel"] = "减少";
                    dt.Rows.Add(dr);
                });
            dgvMaterial.DataSource = dt;
            dgvMaterial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMaterial.ColumnHeadersHeight = 40;
            dgvMaterial.Font = new Font("宋体", 14, FontStyle.Regular);
            dgvMaterial.RowTemplate.Height = 40;
            dgvMaterial.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 14, FontStyle.Bold);
            dgvMaterial.Update();
        }

        private void lblNextOrder_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        delegate void ShowNiuJuImageHandle(int index);
        private void ShowNiuJuImage(int index)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ShowNiuJuImageHandle(ShowNiuJuImage), index);
            }
            else
            {
                PictureBox tmpNiuJu = null;
                switch (index)
                {
                    case 0:
                        tmpNiuJu = picNiuJu;
                        lblNiuJuResult.Text = "";
                        showOne = false;
                        TestOneOver = false;
                        break;
                    case 1:
                        tmpNiuJu = picNiuJu2;
                        lblNiuJuResult2.Text = "";
                        showTwo = false;
                        TestTwoOver = false;
                        break;
                }
                foreach (Control c in tmpNiuJu.Controls)
                {
                    c.Dispose();
                }
                tmpNiuJu.Controls.Clear();
                if (tmpNiuJu.Image != null)
                {
                    tmpNiuJu.Image.Dispose();
                    tmpNiuJu.Image = null;
                }
                if (frmMain.mMain.CarLocal.NiuJu[index] != null)
                {
                    if (frmMain.mMain.CarLocal.NiuJu[index].BackImage != null)
                    {
                        if (frmMain.mMain.CarLocal.NiuJu[index].BackImage != "")
                        {
                            string curFile = string.Format("{0}\\NiuJu\\{1}", cMain.MediaFile, frmMain.mMain.CarLocal.NiuJu[index].BackImage);
                            if (!System.IO.File.Exists(curFile))//可能会存在2个工位用同一张图，这个时候下载会报错。
                            {
                                DownLoad(frmMain.mMain.CarLocal.NiuJu[index].BackImage, "NiuJu");
                            }
                            if (System.IO.File.Exists(curFile))
                            {
                                try
                                {
                                    tmpNiuJu.Image = Image.FromFile(curFile);
                                }
                                catch
                                {
                                    mMain.AddInfo("扭矩图像加载失败,请检查图像格式");
                                    return;
                                }
                            }
                            else
                            {
                                frmMain.mMain.AddInfo(string.Format("从主机下载文件{0}失败", frmMain.mMain.CarLocal.NiuJu[index].BackImage));
                            }
                        }
                    }
                    All.Control.Shape led;
                    for (int i = 0; i < frmMain.mMain.CarLocal.NiuJu[index].Sons.Count; i++)
                    {
                        led = new All.Control.Shape();
                        led.Name = string.Format("Led{0}{1}",index, i); 
                        led.Left = frmMain.mMain.CarLocal.NiuJu[index].Sons[i].X;
                        led.Top = frmMain.mMain.CarLocal.NiuJu[index].Sons[i].Y;
                        led.Width = frmMain.mMain.CarLocal.NiuJu[index].Sons[i].Width;
                        led.Height = frmMain.mMain.CarLocal.NiuJu[index].Sons[i].Height;
                        led.BackColor = Color.Red;
                        tmpNiuJu.Controls.Add(led);
                    }
                    if (tmpNiuJu.Controls.Count > 0)
                    {
                        timNiuJu.Enabled = true;
                    }
                }
            }
        }
        bool oldNiuJuShow = true;
        bool showOne = false;
        bool showTwo = false;
        bool TestOneOver = false;
        bool TestTwoOver = false;
        private void timNiuJu_Tick(object sender, EventArgs e)
        {
            oldNiuJuShow = !oldNiuJuShow;
            switch (frmMain.mMain.AllDataXml.LocalSettings.TestNo)
            {
                case 2:
                    if (frmMain.mMain.FlushNiuJu.CountOne >= 0 && frmMain.mMain.CarLocal.AllStatueStation[0].BarCode != "" && frmMain.mMain.CarLocal.ModeSet[0].ID.Length > 0)
                    {
                        if (picNiuJu.Controls.Count > 0)
                        {
                            if (frmMain.mMain.FlushNiuJu.CountOne >= 0 && frmMain.mMain.FlushNiuJu.CountOne <= picNiuJu.Controls.Count)
                            {
                                All.Control.Shape tmpShape;
                                if (frmMain.mMain.FlushNiuJu.CountOne == picNiuJu.Controls.Count)
                                {
                                    lblNiuJuResult.Text = "OK";
                                    lblNiuJuResult.ForeColor = Color.Green;
                                    timNiuJu.Enabled = false;
                                }
                                else
                                {
                                    lblNiuJuResult.Text = "Test";
                                    lblNiuJuResult.ForeColor = Color.Gold;
                                }
                                for (int i = 0; i < picNiuJu.Controls.Count; i++)
                                {
                                    Control[] tmpControl = picNiuJu.Controls.Find(string.Format("Led{0}{1}",0, i), true);
                                    if (tmpControl == null || tmpControl.Length < 1)
                                    {
                                        continue;
                                    }
                                    tmpShape = (All.Control.Shape)tmpControl[0];
                                    if (i < frmMain.mMain.FlushNiuJu.CountOne)
                                    {
                                        tmpShape.BackColor = Color.LightGreen;
                                        tmpShape.Visible = true;
                                    }
                                    else if (i == frmMain.mMain.FlushNiuJu.CountOne)
                                    {
                                        tmpShape.Visible = oldNiuJuShow;
                                        tmpShape.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        tmpShape.BackColor = Color.Red;
                                        tmpShape.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 7:
                    bool StopTimeOne = true;
                    bool StopTimeTwo = true;
                    if (frmMain.mMain.FlushNiuJu.CountTwo >= 0 && frmMain.mMain.CarLocal.AllStatueStation[0].BarCode != "" && frmMain.mMain.CarLocal.ModeSet[0].ID.Length > 0)
                    {
                        if (picNiuJu.Controls.Count > 0)
                        {
                            if (frmMain.mMain.FlushNiuJu.CountTwo >= 0 && frmMain.mMain.FlushNiuJu.CountTwo <= picNiuJu.Controls.Count)
                            {
                                All.Control.Shape tmpShape;
                                if (frmMain.mMain.FlushNiuJu.CountTwo == picNiuJu.Controls.Count)
                                {
                                    lblNiuJuResult.Text = "OK";
                                    lblNiuJuResult.ForeColor = Color.Green;
                                    StopTimeOne = true;
                                    TestOneOver = true;
                                }
                                else
                                {
                                    StopTimeOne = false;
                                    lblNiuJuResult.Text = "Test";
                                    lblNiuJuResult.ForeColor = Color.Gold;
                                    if (!showOne)
                                    {
                                        tabControl1.SelectedTab = tabTestOne;
                                        showOne = true;
                                    }
                                }
                                for (int i = 0; i < picNiuJu.Controls.Count; i++)
                                {
                                    Control[] tmpControl = picNiuJu.Controls.Find(string.Format("Led{0}{1}", 0, i), true);
                                    if (tmpControl == null || tmpControl.Length < 1)
                                    {
                                        continue;
                                    }
                                    tmpShape = (All.Control.Shape)tmpControl[0];
                                    if (i < frmMain.mMain.FlushNiuJu.CountTwo)
                                    {
                                        tmpShape.BackColor = Color.LightGreen;
                                        tmpShape.Visible = true;
                                    }
                                    else if (i == frmMain.mMain.FlushNiuJu.CountTwo)
                                    {
                                        tmpShape.Visible = oldNiuJuShow;
                                        tmpShape.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        tmpShape.BackColor = Color.Red;
                                        tmpShape.Visible = true;
                                    }
                                }
                            }
                        }
                        else
                        { TestOneOver = true; }
                    }
                    else
                    { TestOneOver = true; }
                    if (frmMain.mMain.FlushNiuJu.CountThree >= 0 && frmMain.mMain.CarLocal.AllStatueStation[1].BarCode != "" && frmMain.mMain.CarLocal.ModeSet[1].ID.Length > 0)
                    {
                        if (picNiuJu2.Controls.Count > 0)
                        {
                            if (frmMain.mMain.FlushNiuJu.CountThree >= 0 && frmMain.mMain.FlushNiuJu.CountThree <= picNiuJu2.Controls.Count)
                            {
                                All.Control.Shape tmpShape;
                                if (frmMain.mMain.FlushNiuJu.CountThree == picNiuJu2.Controls.Count)
                                {
                                    lblNiuJuResult2.Text = "OK";
                                    lblNiuJuResult2.ForeColor = Color.Green;
                                    StopTimeTwo = true;
                                    TestTwoOver = true;
                                }
                                else
                                {
                                    lblNiuJuResult2.Text = "Test";
                                    lblNiuJuResult2.ForeColor = Color.Gold;
                                    StopTimeTwo = false;
                                    if (!showTwo && TestOneOver)
                                    {
                                        tabControl1.SelectedTab = tabTestTwo;
                                        showTwo = true;
                                    }
                                }
                                for (int i = 0; i < picNiuJu2.Controls.Count; i++)
                                {
                                    Control[] tmpControl = picNiuJu2.Controls.Find(string.Format("Led{0}{1}", 1, i), true);
                                    if (tmpControl == null || tmpControl.Length < 1)
                                    {
                                        continue;
                                    }
                                    tmpShape = (All.Control.Shape)tmpControl[0];
                                    if (i < frmMain.mMain.FlushNiuJu.CountThree)
                                    {
                                        tmpShape.BackColor = Color.LightGreen;
                                        tmpShape.Visible = true;
                                    }
                                    else if (i == frmMain.mMain.FlushNiuJu.CountThree)
                                    {
                                        tmpShape.Visible = oldNiuJuShow;
                                        tmpShape.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        tmpShape.BackColor = Color.Red;
                                        tmpShape.Visible = true;
                                    }
                                }
                            }
                        }
                        else
                        { TestTwoOver = true; }
                    }
                    else
                    { TestTwoOver = true; }
                    if (StopTimeOne && StopTimeTwo)
                    {
                        timNiuJu.Enabled = false;
                    }
                    break;
            }
        }
        string oldYinXiangFile = "";
        private void timFlushImage_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.MinValue;
            string fileName = "";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(frmMain.mMain.AllDataXml.LocalSettings.YinXiangFile);
            if (di != null)
            {
                System.IO.FileInfo[] fi = di.GetFiles();
                if (fi != null && fi.Length > 0)
                {
                    for (int i = 0; i < fi.Length; i++)
                    {
                        if (fi[i].LastWriteTime > dt)
                        {
                            dt = fi[i].LastWriteTime;
                            fileName = fi[i].FullName;
                        }
                    }
                    fi = null;
                    di = null;
                }
            }
            if (fileName == "")
            {
                if (picYinXiang.Image != null)
                {
                    picYinXiang.Image.Dispose();
                }
                picYinXiang.Image = null;
                lblXiangJi.Text = "";
            }
            else
            {
                if (oldYinXiangFile != fileName)
                {
                    try
                    {
                        using (Graphics g = Graphics.FromHwnd(picYinXiang.Handle))
                        {
                            g.RotateTransform(180);
                            Image i = Image.FromFile(fileName);
                            g.DrawImage(i, new Rectangle(-picYinXiang.Width, -picYinXiang.Height, picYinXiang.Width, picYinXiang.Height), new Rectangle(0, 0, i.Width, i.Height), GraphicsUnit.Pixel);
                            i.Dispose();
                            g.RotateTransform(180);
                            i = null;
                        }
                    }
                    catch { }
                }
                bool[] tmpBool = All.Class.Num.Ushort2Bool(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[0]);
                if (tmpBool[2])
                {
                    lblXiangJi.Text = "NG";
                    lblXiangJi.ForeColor = Color.Red;
                }
                else
                {
                    lblXiangJi.Text = "OK";
                    lblXiangJi.ForeColor = Color.Green;
                }
            }
            oldYinXiangFile = fileName;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPrintYingXiang_Click(object sender, EventArgs e)
        {
            frmMain.mMain.AiWrite.PrintBar(lblYinXiangBar.Text, HeiFeiMideaDll.cMain.AllComputerList.影像检);
        }

        private void lblYinXiangBar_Click(object sender, EventArgs e)
        {
            All.Window.KeyBoard kb = new All.Window.KeyBoard(lblYinXiangBar.Text);
            if (kb.ShowDialog() == DialogResult.Yes)
            {
                lblYinXiangBar.Text = kb.Value;
                frmMain.mMain.AiWrite.PrintBar(lblYinXiangBar.Text, HeiFeiMideaDll.cMain.AllComputerList.影像检);
            }
            kb.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dtAll;
            DataTable dtMonth;
            DataTable dtDay;
            DataTable dtPass;
            DataTable dtRepair;

            rptMonth.LocalReport.DataSources.Clear();
            rptDay.LocalReport.DataSources.Clear();
            rptPass.LocalReport.DataSources.Clear();
            rptDetial.LocalReport.DataSources.Clear();
            rptReturn.LocalReport.DataSources.Clear();

            cReport.GetReport(dateTimePicker2.Value, dateTimePicker1.Value, out dtAll, out dtMonth, out dtDay, out dtPass, out dtRepair);

            rptMonth.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtTestCount", dtMonth));

            rptDay.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtTestCount", dtDay));

            rptDetial.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtTestAll", dtAll));

            rptPass.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtTestCount", dtPass));

            rptReturn.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtTestCount", dtRepair));

            rptMonth.RefreshReport();
            rptDay.RefreshReport();
            rptPass.RefreshReport();
            rptDetial.RefreshReport();
            rptReturn.RefreshReport();
        }

        private void timFlushLenNingQi_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < AllIcon.Length; i++)
            {
                if (frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Value[i + 1])
                {
                    AllIcon[i].FillColor = Color.Green;
                }
                else
                {
                    if (i < HeiFeiMideaDll.cMain.AllLengNinQiCount)
                    {
                        AllIcon[i].FillColor = Color.FromArgb(255, 40, 40, 40);
                    }
                    else
                    {
                        AllIcon[i].FillColor = Color.Red;
                    }
                }
            }

            List<string> x = new List<string>();
            List<int> y = new List<int>();
            int allCount = 0;
            cReport.ReadEveryHour(out x, out y, out allCount);

            
            chart1.Series[0].Points.DataBindXY(x,y);

            itemTime.Value = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            itemCount.Value = string.Format("{0}", allCount);
        }
        /// <summary>
        /// 初始化冷凝器线的柱状图
        /// </summary>
        private void InitChart()
        {
            //线体图
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllLengNinQiCount; i++)
            {
                AllIcon[i] = (All.Control.Icon)panel7.Controls.Find(string.Format("LengNinStation{0}", i + 1), true)[0];
            }
            AllIcon[HeiFeiMideaDll.cMain.AllLengNinQiCount + 0] = iconZheWang;
            AllIcon[HeiFeiMideaDll.cMain.AllLengNinQiCount + 1] = mcgs11;
            AllIcon[HeiFeiMideaDll.cMain.AllLengNinQiCount + 2] = iconLengNingQiPlc;
            AllIcon[HeiFeiMideaDll.cMain.AllLengNinQiCount + 3] = iconHaiJian;

            //图表
            Title title = new Title("今日每小时上线数量", Docking.Top, new Font("宋体", 16, FontStyle.Bold), Color.White);
            chart1.Titles.Add(title);
            //图示
            chart1.Legends[0].Enabled = true;
            chart1.Legends[0].BackColor = Color.Black;
            chart1.Legends[0].Docking = Docking.Right;
            chart1.Legends[0].ForeColor = Color.White;
            //3D
            //chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            //图形类型
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LineColor = Color.White;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//竖直网格线
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].BackColor = Color.Black;//整体背景色
            chart1.BackColor = Color.Black;//背景色

            //chart1.ChartAreas[0].Area3DStyle.PointDepth = 5;//3D进深为20像素
            //chart1.Series[0]["DrawingStyle"] = "Cylinder";//圆柱


            chart1.Series[0].LabelForeColor = Color.White;//圆柱上方文字颜色
            chart1.Series[0].Font = new Font("黑体", 10, FontStyle.Bold);//圆柱上方文字字体
            chart1.Series[0]["ColumnLabelStyle"] = "center";
            chart1.Series[0].LegendText = "产量(片)";
            chart1.Series[0].LabelFormat = "{0}(片)";

            chart1.Palette = ChartColorPalette.None;
            chart1.PaletteCustomColors = new Color[] { Color.Green };
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            cReport.Error(lblPrintBar.Text);
        }
        /// <summary>
        /// 从密码判断员工登陆
        /// </summary>
        /// <param name="userPassword"></param>
        private void CheckUser(string userPassword)
        {
            bool tmpBool = false;
            bool tmpLoginOk = false;

            List<int> workStation = new List<int>();
            string userName = "";
            using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select * from SetUsers where UserPassword='{0}'", userPassword.Trim())))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    userName = All.Class.Num.ToString(dt.Rows[0]["UserName"]);
                    for (int i = 0; i < HeiFeiMideaDll.cMain.AllStopStationCount; i++)
                    {
                        tmpBool = All.Class.Num.ToBool(dt.Rows[0][string.Format("Use{0}", i)]);
                        if (tmpBool)
                        {
                            workStation.Add(i);
                            tmpLoginOk = true;
                        }
                    }
                }
                else
                {
                    frmMain.mMain.AddInfo(string.Format("员工条码【{0}】没有找到对应的人员，请添加后登陆", userPassword.Trim()));
                    return;
                }
            }
            if (!tmpLoginOk)
            {
                frmMain.mMain.AddInfo(string.Format("【{0}】没有任何操作权限，登陆失败", userName));
            }
            else
            {
                //更改对应位置用户名
                for (int i = 0; i < workStation.Count; i++)
                {
                    frmMain.mMain.AllDataBase.FlushData.Write(
                        string.Format("Update InfoLineStation Set UserName='{0}' where workStation={1}", userName, workStation[i]));
                }
                //记录今天员工的操作状态
                using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select UserName from StatueUserLogin where UserName='{0}'", userName)))
                {
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        frmMain.mMain.AllDataBase.FlushData.Write(
                            string.Format("insert into StatueUserLogin (UserName,TestYear,TestMonth,Test{0:dd}) Values ('{1}',{0:yyyy},{0:MM},'true')", DateTime.Now, userName));
                    }
                    else
                    {
                        frmMain.mMain.AllDataBase.FlushData.Write(
                            string.Format("update StatueUserLogin Set Test{0:dd}='true' where UserName='{1}'", DateTime.Now, userName));
                    }
                }
                frmMain.mMain.AddInfo(string.Format("【{0}】登陆成功", userName));
            }
        }

        private void btnAddError_Click(object sender, EventArgs e)
        {
            frmErrorFrom fer = new frmErrorFrom();
            if (fer.ShowDialog() == DialogResult.Yes)
            {
                DataTable dt = (DataTable)dgvError.DataSource;
                DataRow dr = dt.NewRow();
                dr["Index"] = dt.Rows.Count + 1;
                dr["Statue"] = HeiFeiMideaPlayer.Properties.Resources.No.ToBitmap();
                dr["Error"] = fer.Error;
                dr["Call"] = "故障输入";
                dr["Cancel"] = "取消输入";
                dr["CallOver"] = true;
                dr["ErrorFrom"] = fer.Source;
                dr["ErrorSpace"] = fer.ErrorWorkStation.ToString();
                dt.Rows.Add(dr);
            }
        }

        private void dgvError_Click(object sender, EventArgs e)
        {

        }

    }
    public class ErrorIn
    {
        public string ErrorName
        { get; set; }
        public string ErrorFrom
        { get; set; }
        public int ErrorSpace
        { get; set; }
        public ErrorIn(string errorName, string errorFrom,int errorSpace)
        {
            this.ErrorName = errorName;
            this.ErrorFrom = errorFrom;
            this.ErrorSpace = errorSpace;
        }
    }
}
