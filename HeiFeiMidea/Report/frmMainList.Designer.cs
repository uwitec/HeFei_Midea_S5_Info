namespace HeiFeiMidea.Report
{
    partial class frmMainList
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainList));
            this.dtTestAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsReport = new HeiFeiMidea.Report.dsReport();
            this.panSize = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnClose = new All.Control.Metro.TitleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtTestAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            this.panSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtTestAllBindingSource
            // 
            this.dtTestAllBindingSource.DataMember = "dtTestAll";
            this.dtTestAllBindingSource.DataSource = this.dsReport;
            // 
            // dsReport
            // 
            this.dsReport.DataSetName = "dsReport";
            this.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panSize
            // 
            this.panSize.BackColor = System.Drawing.Color.White;
            this.panSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSize.Controls.Add(this.reportViewer1);
            this.panSize.Location = new System.Drawing.Point(127, 128);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(700, 383);
            this.panSize.TabIndex = 64;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dtTestAll";
            reportDataSource2.Value = this.dtTestAllBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptMainList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(698, 381);
            this.reportViewer1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(787, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 65;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMainList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panSize);
            this.Name = "frmMainList";
            this.Text = "上线记录报表";
            this.Load += new System.EventHandler(this.frmMainList_Load);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtTestAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).EndInit();
            this.panSize.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dtTestAllBindingSource;
        private dsReport dsReport;
        public System.Windows.Forms.Panel panSize;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private All.Control.Metro.TitleButton btnClose;
    }
}