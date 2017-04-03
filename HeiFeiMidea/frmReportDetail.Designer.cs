namespace HeiFeiMidea
{
    partial class frmReportDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportDetail));
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panSize = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rptChongZhu = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptChongHaiYaLiQuXian = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptChongHaiHuiShou = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptYinXiang = new System.Windows.Forms.Panel();
            this.rptAnGui = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptJianCeData = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptXingNengQuXian = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptChouKongQuXIan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptOil = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptPeiJian = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptAnZhuang = new Microsoft.Reporting.WinForms.ReportViewer();
            this.listBox1 = new All.Control.Metro.ListBox();
            this.rptLouLv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptTestJianLou = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panSize.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(764, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 65;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.panel1);
            this.panSize.Controls.Add(this.listBox1);
            this.panSize.Location = new System.Drawing.Point(125, 126);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(714, 394);
            this.panSize.TabIndex = 66;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rptLouLv);
            this.panel1.Controls.Add(this.rptTestJianLou);
            this.panel1.Controls.Add(this.rptChongZhu);
            this.panel1.Controls.Add(this.rptChongHaiYaLiQuXian);
            this.panel1.Controls.Add(this.rptChongHaiHuiShou);
            this.panel1.Controls.Add(this.rptYinXiang);
            this.panel1.Controls.Add(this.rptAnGui);
            this.panel1.Controls.Add(this.rptJianCeData);
            this.panel1.Controls.Add(this.rptXingNengQuXian);
            this.panel1.Controls.Add(this.rptChouKongQuXIan);
            this.panel1.Controls.Add(this.rptOil);
            this.panel1.Controls.Add(this.rptPeiJian);
            this.panel1.Controls.Add(this.rptAnZhuang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(240, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 389);
            this.panel1.TabIndex = 56;
            // 
            // rptChongZhu
            // 
            this.rptChongZhu.DocumentMapWidth = 72;
            this.rptChongZhu.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptChongZhu.rdlc";
            this.rptChongZhu.Location = new System.Drawing.Point(246, 185);
            this.rptChongZhu.Name = "rptChongZhu";
            this.rptChongZhu.Size = new System.Drawing.Size(97, 76);
            this.rptChongZhu.TabIndex = 10;
            this.rptChongZhu.Visible = false;
            // 
            // rptChongHaiYaLiQuXian
            // 
            this.rptChongHaiYaLiQuXian.DocumentMapWidth = 72;
            this.rptChongHaiYaLiQuXian.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptChongHaiShuiShouTmp.rdlc";
            this.rptChongHaiYaLiQuXian.Location = new System.Drawing.Point(132, 185);
            this.rptChongHaiYaLiQuXian.Name = "rptChongHaiYaLiQuXian";
            this.rptChongHaiYaLiQuXian.Size = new System.Drawing.Size(97, 76);
            this.rptChongHaiYaLiQuXian.TabIndex = 9;
            this.rptChongHaiYaLiQuXian.Visible = false;
            // 
            // rptChongHaiHuiShou
            // 
            this.rptChongHaiHuiShou.DocumentMapWidth = 72;
            this.rptChongHaiHuiShou.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptChongHaiHuiShou.rdlc";
            this.rptChongHaiHuiShou.Location = new System.Drawing.Point(20, 185);
            this.rptChongHaiHuiShou.Name = "rptChongHaiHuiShou";
            this.rptChongHaiHuiShou.Size = new System.Drawing.Size(97, 76);
            this.rptChongHaiHuiShou.TabIndex = 8;
            this.rptChongHaiHuiShou.Visible = false;
            // 
            // rptYinXiang
            // 
            this.rptYinXiang.Location = new System.Drawing.Point(356, 103);
            this.rptYinXiang.Name = "rptYinXiang";
            this.rptYinXiang.Size = new System.Drawing.Size(97, 76);
            this.rptYinXiang.TabIndex = 7;
            this.rptYinXiang.Click += new System.EventHandler(this.rptYinXiang_Click);
            this.rptYinXiang.MouseLeave += new System.EventHandler(this.rptYinXiang_MouseLeave);
            this.rptYinXiang.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptYinXiang_MouseMove);
            // 
            // rptAnGui
            // 
            this.rptAnGui.DocumentMapWidth = 72;
            this.rptAnGui.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptAnJian.rdlc";
            this.rptAnGui.Location = new System.Drawing.Point(246, 103);
            this.rptAnGui.Name = "rptAnGui";
            this.rptAnGui.Size = new System.Drawing.Size(97, 76);
            this.rptAnGui.TabIndex = 6;
            this.rptAnGui.Visible = false;
            // 
            // rptJianCeData
            // 
            this.rptJianCeData.DocumentMapWidth = 72;
            this.rptJianCeData.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rtpJianCeQuXianData.rdlc";
            this.rptJianCeData.Location = new System.Drawing.Point(132, 103);
            this.rptJianCeData.Name = "rptJianCeData";
            this.rptJianCeData.Size = new System.Drawing.Size(97, 76);
            this.rptJianCeData.TabIndex = 5;
            this.rptJianCeData.Visible = false;
            // 
            // rptXingNengQuXian
            // 
            this.rptXingNengQuXian.DocumentMapWidth = 72;
            this.rptXingNengQuXian.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptJianCeQuXian.rdlc";
            this.rptXingNengQuXian.Location = new System.Drawing.Point(20, 103);
            this.rptXingNengQuXian.Name = "rptXingNengQuXian";
            this.rptXingNengQuXian.Size = new System.Drawing.Size(97, 76);
            this.rptXingNengQuXian.TabIndex = 4;
            this.rptXingNengQuXian.Visible = false;
            // 
            // rptChouKongQuXIan
            // 
            this.rptChouKongQuXIan.DocumentMapWidth = 72;
            this.rptChouKongQuXIan.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptChouKongQuXian.rdlc";
            this.rptChouKongQuXIan.Location = new System.Drawing.Point(356, 21);
            this.rptChouKongQuXIan.Name = "rptChouKongQuXIan";
            this.rptChouKongQuXIan.Size = new System.Drawing.Size(97, 76);
            this.rptChouKongQuXIan.TabIndex = 3;
            this.rptChouKongQuXIan.Visible = false;
            // 
            // rptOil
            // 
            this.rptOil.DocumentMapWidth = 72;
            this.rptOil.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptOil.rdlc";
            this.rptOil.Location = new System.Drawing.Point(246, 21);
            this.rptOil.Name = "rptOil";
            this.rptOil.Size = new System.Drawing.Size(97, 76);
            this.rptOil.TabIndex = 2;
            this.rptOil.Visible = false;
            // 
            // rptPeiJian
            // 
            this.rptPeiJian.DocumentMapWidth = 72;
            this.rptPeiJian.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptPeiJian.rdlc";
            this.rptPeiJian.Location = new System.Drawing.Point(132, 21);
            this.rptPeiJian.Name = "rptPeiJian";
            this.rptPeiJian.Size = new System.Drawing.Size(97, 76);
            this.rptPeiJian.TabIndex = 1;
            this.rptPeiJian.Visible = false;
            // 
            // rptAnZhuang
            // 
            this.rptAnZhuang.DocumentMapWidth = 72;
            this.rptAnZhuang.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptAnZhuangList.rdlc";
            this.rptAnZhuang.Location = new System.Drawing.Point(20, 21);
            this.rptAnZhuang.Name = "rptAnZhuang";
            this.rptAnZhuang.Size = new System.Drawing.Size(97, 76);
            this.rptAnZhuang.TabIndex = 0;
            this.rptAnZhuang.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.LightGray;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Icon = null;
            this.listBox1.IconStyle = All.Control.Metro.ListBox.IconStyleList.增高列表;
            this.listBox1.ItemColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGray,
        System.Drawing.Color.LightGray};
            this.listBox1.ItemHeight = 64;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 394);
            this.listBox1.TabIndex = 55;
            this.listBox1.Tail = false;
            this.listBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.listBox1.TitleColor = System.Drawing.Color.White;
            this.listBox1.TitleFont = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // rptLouLv
            // 
            this.rptLouLv.DocumentMapWidth = 72;
            this.rptLouLv.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptLouLv.rdlc";
            this.rptLouLv.Location = new System.Drawing.Point(132, 267);
            this.rptLouLv.Name = "rptLouLv";
            this.rptLouLv.Size = new System.Drawing.Size(97, 76);
            this.rptLouLv.TabIndex = 12;
            this.rptLouLv.Visible = false;
            // 
            // rptTestJianLou
            // 
            this.rptTestJianLou.DocumentMapWidth = 72;
            this.rptTestJianLou.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptJianLou.rdlc";
            this.rptTestJianLou.Location = new System.Drawing.Point(20, 267);
            this.rptTestJianLou.Name = "rptTestJianLou";
            this.rptTestJianLou.Size = new System.Drawing.Size(97, 76);
            this.rptTestJianLou.TabIndex = 11;
            this.rptTestJianLou.Visible = false;
            // 
            // frmReportDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panSize);
            this.Controls.Add(this.btnClose);
            this.Name = "frmReportDetail";
            this.Text = "详细信息";
            this.Load += new System.EventHandler(this.frmReportDetail_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.panSize.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private All.Control.Metro.TitleButton btnClose;
        private System.Windows.Forms.Panel panSize;
        private All.Control.Metro.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rptAnZhuang;
        private Microsoft.Reporting.WinForms.ReportViewer rptPeiJian;
        private Microsoft.Reporting.WinForms.ReportViewer rptOil;
        private Microsoft.Reporting.WinForms.ReportViewer rptChouKongQuXIan;
        private Microsoft.Reporting.WinForms.ReportViewer rptXingNengQuXian;
        private Microsoft.Reporting.WinForms.ReportViewer rptJianCeData;
        private Microsoft.Reporting.WinForms.ReportViewer rptAnGui;
        private System.Windows.Forms.Panel rptYinXiang;
        private Microsoft.Reporting.WinForms.ReportViewer rptChongHaiHuiShou;
        private Microsoft.Reporting.WinForms.ReportViewer rptChongHaiYaLiQuXian;
        private Microsoft.Reporting.WinForms.ReportViewer rptChongZhu;
        private Microsoft.Reporting.WinForms.ReportViewer rptLouLv;
        private Microsoft.Reporting.WinForms.ReportViewer rptTestJianLou;
    }
}