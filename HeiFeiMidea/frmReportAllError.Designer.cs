namespace HeiFeiMidea
{
    partial class frmReportAllError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAllError));
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panSize = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rptSheBei1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rptSheBei2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panTtile = new System.Windows.Forms.Panel();
            this.btnSearch = new All.Control.Metro.PicButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.rptChaoShi1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptChaoShi2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptWuLiao1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptWuLiao2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panSize.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panTtile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(764, 86);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 54;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.tabControl1);
            this.panSize.Controls.Add(this.panTtile);
            this.panSize.Location = new System.Drawing.Point(128, 146);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(705, 361);
            this.panSize.TabIndex = 53;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(705, 324);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rptSheBei1);
            this.tabPage1.Location = new System.Drawing.Point(48, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设备报表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rptSheBei1
            // 
            this.rptSheBei1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptSheBei1.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptErrorSheBei.rdlc";
            this.rptSheBei1.Location = new System.Drawing.Point(3, 3);
            this.rptSheBei1.Name = "rptSheBei1";
            this.rptSheBei1.Size = new System.Drawing.Size(647, 310);
            this.rptSheBei1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rptSheBei2);
            this.tabPage2.Location = new System.Drawing.Point(40, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(661, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设备记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rptSheBei2
            // 
            this.rptSheBei2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptSheBei2.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptErrorSheBeiDetial.rdlc";
            this.rptSheBei2.Location = new System.Drawing.Point(3, 3);
            this.rptSheBei2.Name = "rptSheBei2";
            this.rptSheBei2.Size = new System.Drawing.Size(655, 310);
            this.rptSheBei2.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rptWuLiao1);
            this.tabPage3.Location = new System.Drawing.Point(48, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(653, 316);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "物料报表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rptWuLiao2);
            this.tabPage4.Location = new System.Drawing.Point(48, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(653, 316);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "物料记录";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.rptChaoShi1);
            this.tabPage5.Location = new System.Drawing.Point(48, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(653, 316);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "超时报表";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.rptChaoShi2);
            this.tabPage6.Location = new System.Drawing.Point(48, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(653, 316);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "超时记录";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panTtile
            // 
            this.panTtile.BackColor = System.Drawing.Color.Gray;
            this.panTtile.Controls.Add(this.btnSearch);
            this.panTtile.Controls.Add(this.dateTimePicker1);
            this.panTtile.Controls.Add(this.dateTimePicker2);
            this.panTtile.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTtile.Location = new System.Drawing.Point(0, 0);
            this.panTtile.Name = "panTtile";
            this.panTtile.Size = new System.Drawing.Size(705, 37);
            this.panTtile.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearch.BackImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackImage")));
            this.btnSearch.Border = false;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(602, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PicBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "查找";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "            到         yyyy - MM - dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(277, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(252, 29);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.CustomFormat = "            从      yyyy - MM - dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(10, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(261, 29);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // rptChaoShi1
            // 
            this.rptChaoShi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptChaoShi1.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptErrorChaoShi.rdlc";
            this.rptChaoShi1.Location = new System.Drawing.Point(3, 3);
            this.rptChaoShi1.Name = "rptChaoShi1";
            this.rptChaoShi1.Size = new System.Drawing.Size(647, 310);
            this.rptChaoShi1.TabIndex = 4;
            // 
            // rptChaoShi2
            // 
            this.rptChaoShi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptChaoShi2.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptErrorChaoShiDetial.rdlc";
            this.rptChaoShi2.Location = new System.Drawing.Point(3, 3);
            this.rptChaoShi2.Name = "rptChaoShi2";
            this.rptChaoShi2.Size = new System.Drawing.Size(647, 310);
            this.rptChaoShi2.TabIndex = 4;
            // 
            // rptWuLiao1
            // 
            this.rptWuLiao1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptWuLiao1.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptErrorWuLiao.rdlc";
            this.rptWuLiao1.Location = new System.Drawing.Point(3, 3);
            this.rptWuLiao1.Name = "rptWuLiao1";
            this.rptWuLiao1.Size = new System.Drawing.Size(647, 310);
            this.rptWuLiao1.TabIndex = 4;
            // 
            // rptWuLiao2
            // 
            this.rptWuLiao2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptWuLiao2.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptErrorWuLiaoDetial.rdlc";
            this.rptWuLiao2.Location = new System.Drawing.Point(3, 3);
            this.rptWuLiao2.Name = "rptWuLiao2";
            this.rptWuLiao2.Size = new System.Drawing.Size(647, 310);
            this.rptWuLiao2.TabIndex = 4;
            // 
            // frmReportAllError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panSize);
            this.Name = "frmReportAllError";
            this.Text = "异常影响记录报表";
            this.Load += new System.EventHandler(this.frmReportAllError_Load);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.panSize.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panTtile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private All.Control.Metro.TitleButton btnClose;
        private System.Windows.Forms.Panel panSize;
        private System.Windows.Forms.Panel panTtile;
        private All.Control.Metro.PicButton btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer rptSheBei1;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer rptSheBei2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private Microsoft.Reporting.WinForms.ReportViewer rptChaoShi1;
        private Microsoft.Reporting.WinForms.ReportViewer rptChaoShi2;
        private Microsoft.Reporting.WinForms.ReportViewer rptWuLiao1;
        private Microsoft.Reporting.WinForms.ReportViewer rptWuLiao2;
    }
}