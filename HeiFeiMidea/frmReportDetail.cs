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
    public partial class frmReportDetail : All.Window.MainWindow
    {
        string barCode = "";
        string lenNingCode = "";
        public frmReportDetail(string barcode, string lenNingcode)
        {
            barCode = barcode;
            lenNingCode = lenNingcode;
            InitializeComponent();
        }

        private void frmReportDetail_Load(object sender, EventArgs e)
        {
            InitFrm();
            panel1.Height = listBox1.Height;
        }
        private void InitFrm()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("安装记录");//OK
            listBox1.Items.Add("配件记录");//OK
            listBox1.Items.Add("注油记录");//Ok
            listBox1.Items.Add("检漏记录");//OK
            listBox1.Items.Add("检漏曲线A");//OK
            listBox1.Items.Add("检漏曲线B");//OK
            listBox1.Items.Add("抽空曲线");//Ok
            listBox1.Items.Add("充注记录");//OK
            listBox1.Items.Add("安检记录");//Ok
            listBox1.Items.Add("检测记录");//Ok
            listBox1.Items.Add("检测实时");//Ok
            listBox1.Items.Add("检测曲线");//Ok
            listBox1.Items.Add("影像记录");//Ok
            listBox1.Items.Add("氦检记录");
            listBox1.Items.Add("漏率曲线");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt;
            Report.dsReport dsr;
            Microsoft.Reporting.WinForms.ReportDataSource rd;
            All.Class.Sqlce sql = new All.Class.Sqlce();
            string direcotry = "";
            string fileName = "";
            switch (listBox1.Text)
            {
                case "氦检记录":
                case "漏率曲线":
                    direcotry = HeiFeiMidea.CheckTestResultFile.CheckLenNingFile(lenNingCode);
                    fileName = "AllLenNingValue.sdf";
                    //if (!System.IO.File.Exists(string.Format("{0}\\{1}",direcotry,fileName)))
                    //{
                    //    direcotry = string.Format("{0}\\Data\\TestData\\LenNingFile\\U880-22016102700{1:D2}\\", Application.StartupPath, (int)All.Class.Num.GetRandom(1, 40));
                    //}
                    break;
                default:
                    direcotry = HeiFeiMidea.CheckTestResultFile.CheckTestFile(barCode);
                    fileName = "AllTestValue.sdf";
                    break;
            }
            if (!sql.Login(direcotry, fileName, "", ""))
            {
                All.Window.MetroMessageBox.Show(this, "打开对应数据库失败，当前未保存此项数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (listBox1.Text)
            {
                case "安装记录":
                    rptAnZhuang.Location = new Point(0, 0);
                    rptAnZhuang.Size = panel1.Size;
                    rptAnZhuang.BringToFront();
                    rptAnZhuang.Visible = true;

                    dt = sql.Read("select * from TestAnZhuang");
                    dt.TableName = "dtAnZhuang";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtAnZhuang", dsr.Tables["dtAnZhuang"]);
                    rptAnZhuang.LocalReport.DataSources.Clear();
                    rptAnZhuang.LocalReport.DataSources.Add(rd);
                    rptAnZhuang.RefreshReport();
                    break;
                case "配件记录":
                    rptPeiJian.Location = new Point(0, 0);
                    rptPeiJian.Size = panel1.Size;
                    rptPeiJian.BringToFront();
                    rptPeiJian.Visible = true;

                    dt = sql.Read("select * from TestYaSuoJi");
                    dt.TableName = "dtPeiJian";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtPeiJian", dsr.Tables["dtPeiJian"]);
                    rptPeiJian.LocalReport.DataSources.Clear();
                    rptPeiJian.LocalReport.DataSources.Add(rd);
                    rptPeiJian.RefreshReport();
                    break;
                case "注油记录":
                    rptOil.Location = new Point(0, 0);
                    rptOil.Size = panel1.Size;
                    rptOil.BringToFront();
                    rptOil.Visible = true;

                    dt = sql.Read("select * from TestOil");
                    dt.TableName = "dtOil";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtOil", dsr.Tables["dtOil"]);
                    rptOil.LocalReport.DataSources.Clear();
                    rptOil.LocalReport.DataSources.Add(rd);
                    rptOil.RefreshReport();
                    break;
                case "检漏记录":
                    rptChongHaiHuiShou.Location = new Point(0, 0);
                    rptChongHaiHuiShou.Size = panel1.Size;
                    rptChongHaiHuiShou.BringToFront();
                    rptChongHaiHuiShou.Visible = true;

                    dt = sql.Read("select * from TestChongHaiHuiShou");
                    dt.TableName = "dtChongHaiHuiShou";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtChongHaiHuiShou", dsr.Tables["dtChongHaiHuiShou"]);
                    rptChongHaiHuiShou.LocalReport.DataSources.Clear();
                    rptChongHaiHuiShou.LocalReport.DataSources.Add(rd);
                    rptChongHaiHuiShou.RefreshReport();
                    break;
                case "检漏曲线A":
                    rptChongHaiYaLiQuXian.Location = new Point(0, 0);
                    rptChongHaiYaLiQuXian.Size = panel1.Size;
                    rptChongHaiYaLiQuXian.BringToFront();
                    rptChongHaiYaLiQuXian.Visible = true;

                    dt = sql.Read("select * from TestChongHaiA");
                    dt.TableName = "dtChongHaiHuiShouTmp";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtChongHaiHuiShouTmp", dsr.Tables["dtChongHaiHuiShouTmp"]);
                    rptChongHaiYaLiQuXian.LocalReport.DataSources.Clear();
                    rptChongHaiYaLiQuXian.LocalReport.DataSources.Add(rd);
                    rptChongHaiYaLiQuXian.RefreshReport();
                    break;
                case "检漏曲线B":
                    rptChongHaiYaLiQuXian.Location = new Point(0, 0);
                    rptChongHaiYaLiQuXian.Size = panel1.Size;
                    rptChongHaiYaLiQuXian.BringToFront();
                    rptChongHaiYaLiQuXian.Visible = true;

                    dt = sql.Read("select * from TestChongHaiB");
                    dt.TableName = "dtChongHaiHuiShouTmp";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtChongHaiHuiShouTmp", dsr.Tables["dtChongHaiHuiShouTmp"]);
                    rptChongHaiYaLiQuXian.LocalReport.DataSources.Clear();
                    rptChongHaiYaLiQuXian.LocalReport.DataSources.Add(rd);
                    rptChongHaiYaLiQuXian.RefreshReport();
                    break;
                case "充注记录":
                    rptChongZhu.Location = new Point(0, 0);
                    rptChongZhu.Size = panel1.Size;
                    rptChongZhu.BringToFront();
                    rptChongZhu.Visible = true;

                    dt = sql.Read("select * from TestChongZhu");
                    dt.TableName = "dtChongZhu";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtChongZhu", dsr.Tables["dtChongZhu"]);
                    rptChongZhu.LocalReport.DataSources.Clear();
                    rptChongZhu.LocalReport.DataSources.Add(rd);
                    rptChongZhu.RefreshReport();
                    break;
                case "抽空曲线":
                    rptChouKongQuXIan.Location = new Point(0, 0);
                    rptChouKongQuXIan.Size = panel1.Size;
                    rptChouKongQuXIan.BringToFront();
                    rptChouKongQuXIan.Visible = true;

                    dt = sql.Read("select Data1,Data2,Data3,Data4,Data5 from TestChouKong");
                    if (dt != null)
                    {
                        dt.Columns.Add("ID", typeof(int));
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt.Rows[i]["ID"] = i + 1;
                        }
                    }
                    dt.TableName = "dtChouKongQuXian";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtChouKongQuXian", dsr.Tables["dtChouKongQuXian"]);
                    rptChouKongQuXIan.LocalReport.DataSources.Clear();
                    rptChouKongQuXIan.LocalReport.DataSources.Add(rd);
                    rptChouKongQuXIan.RefreshReport();
                    break;
                case "检测记录":
                    rptJianCeData.Location = new Point(0, 0);
                    rptJianCeData.Size = panel1.Size;
                    rptJianCeData.BringToFront();
                    rptJianCeData.Visible = true;

                    dt = sql.Read("select * from TestJianCe");
                    dt.TableName = "dtTestStep";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtTestStep", dsr.Tables["dtTestStep"]);
                    rptJianCeData.LocalReport.DataSources.Clear();
                    rptJianCeData.LocalReport.DataSources.Add(rd);
                    rptJianCeData.RefreshReport();
                    break;
                case "检测实时":
                    rptJianCeData.Location = new Point(0, 0);
                    rptJianCeData.Size = panel1.Size;
                    rptJianCeData.BringToFront();
                    rptJianCeData.Visible = true;

                    dt = sql.Read("select * from TestJianCeTmp");
                    dt.TableName = "dtTestStep";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtTestStep", dsr.Tables["dtTestStep"]);
                    rptJianCeData.LocalReport.DataSources.Clear();
                    rptJianCeData.LocalReport.DataSources.Add(rd);
                    rptJianCeData.RefreshReport();
                    break;
                case "检测曲线":
                    rptXingNengQuXian.Location = new Point(0, 0);
                    rptXingNengQuXian.Size = panel1.Size;
                    rptXingNengQuXian.BringToFront();
                    rptXingNengQuXian.Visible = true;

                    dt = sql.Read("select * from TestJianCeTmp");
                    dt.TableName = "dtTestStep";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtTestStep", dsr.Tables["dtTestStep"]);
                    rptXingNengQuXian.LocalReport.DataSources.Clear();
                    rptXingNengQuXian.LocalReport.DataSources.Add(rd);
                    rptXingNengQuXian.RefreshReport();
                    break;
                case "安检记录":
                    rptAnGui.Location = new Point(0, 0);
                    rptAnGui.Size = panel1.Size;
                    rptAnGui.BringToFront();
                    rptAnGui.Visible = true;

                    dt = sql.Read("select * from TestAnGui");
                    dt.TableName = "dtAnGui";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtAnGui", dsr.Tables["dtAnGui"]);
                    rptAnGui.LocalReport.DataSources.Clear();
                    rptAnGui.LocalReport.DataSources.Add(rd);
                    rptAnGui.RefreshReport();
                    break;
                case "影像记录":
                    rptYinXiang.Location = new Point(0, 0);
                    rptYinXiang.Size = panel1.Size;
                    rptYinXiang.BringToFront();
                    rptYinXiang.Visible = true;
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(direcotry);
                    allYinXiangFile.Clear();
                    foreach (System.IO.FileInfo fi in di.GetFiles())
                    {
                        if (All.Control.PicturePlayer.FileFilter.ToUpper().IndexOf(fi.Extension.ToUpper()) >= 0)
                        {
                            allYinXiangFile.Add(fi.FullName);
                        }
                    }
                    InitImage();
                    break;
                case "氦检记录":
                    rptTestJianLou.Location = new Point(0, 0);
                    rptTestJianLou.Size = panel1.Size;
                    rptTestJianLou.BringToFront();
                    rptTestJianLou.Visible = true;

                    dt = sql.Read("select * from TestJianLou");
                    dt.TableName = "dtTestJianLou";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtTestJianLou", dsr.Tables["dtTestJianLou"]);
                    rptTestJianLou.LocalReport.DataSources.Clear();
                    rptTestJianLou.LocalReport.DataSources.Add(rd);
                    rptTestJianLou.RefreshReport();
                    break;
                case "漏率曲线":
                    rptLouLv.Location = new Point(0, 0);
                    rptLouLv.Size = panel1.Size;
                    rptLouLv.BringToFront();
                    rptLouLv.Visible = true;
                    dt = sql.Read("select * from TestLouLv");
                    dt.TableName = "dtTestLouLv";
                    dsr = new Report.dsReport();
                    dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);
                    rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtTestLouLv", dsr.Tables["dtTestLouLv"]);
                    rptLouLv.LocalReport.DataSources.Clear();
                    rptLouLv.LocalReport.DataSources.Add(rd);
                    rptLouLv.RefreshReport();
                    break;
            }
            sql.Close();
        }
        #region//图片
        int yinXiangImageIndex = 0;
        List<string> allYinXiangFile = new List<string>();
        private void rptYinXiang_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < rptYinXiang.Width / 2)
            {
                Cursor = new Cursor(HeiFeiMidea.Properties.Resources.Arrow___Left.Handle);
            }
            else
            {
                Cursor = new Cursor(HeiFeiMidea.Properties.Resources.Arrow___Right.Handle);
            }
        }
        private void InitImage()
        {
            yinXiangImageIndex = 0;
            ChangeImage();
        }
        private void ChangeImage()
        {
            if (allYinXiangFile != null && allYinXiangFile.Count > 0)
            {
                if (yinXiangImageIndex < 0 || yinXiangImageIndex >= allYinXiangFile.Count)
                {
                    yinXiangImageIndex = ((yinXiangImageIndex + allYinXiangFile.Count) % allYinXiangFile.Count);
                }
                if (System.IO.File.Exists(allYinXiangFile[yinXiangImageIndex]))
                {
                    using (Graphics g = Graphics.FromHwnd(rptYinXiang.Handle))
                    {
                        g.Clear(Color.Black);
                        g.RotateTransform(180);
                        using (Image image = Image.FromFile(allYinXiangFile[yinXiangImageIndex]))
                        {
                            g.DrawImage(image, new Rectangle(-rptYinXiang.Width, -rptYinXiang.Height, rptYinXiang.Width, rptYinXiang.Height),
                                new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                        }
                    }
                }
            }
        }
        private void rptYinXiang_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void rptYinXiang_Click(object sender, EventArgs e)
        {
            Point midPoint = rptYinXiang.PointToScreen(new Point(rptYinXiang.Width / 2, 0));
            if (midPoint.X < MousePosition.X)
            {
                yinXiangImageIndex++;
            }
            else
            {
                yinXiangImageIndex--;
            }
            ChangeImage();
        }
        #endregion
    }
}