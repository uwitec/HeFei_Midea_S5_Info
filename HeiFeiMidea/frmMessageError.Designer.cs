namespace HeiFeiMidea
{
    partial class frmMessageError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageError));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.titleButton1 = new All.Control.Metro.TitleButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(18, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(551, 235);
            this.listBox1.TabIndex = 16;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // titleButton1
            // 
            this.titleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("titleButton1.BackgroundImage")));
            this.titleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.titleButton1.Location = new System.Drawing.Point(518, 18);
            this.titleButton1.Name = "titleButton1";
            this.titleButton1.Size = new System.Drawing.Size(32, 32);
            this.titleButton1.TabIndex = 17;
            this.titleButton1.Click += new System.EventHandler(this.titleButton1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(19, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 30);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Text = "故障列表";
            // 
            // frmMessageError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 308);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.titleButton1);
            this.Controls.Add(this.listBox1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMessageError";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "故障列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmMessageError_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private All.Control.Metro.TitleButton titleButton1;
        private System.Windows.Forms.Label lblTitle;
    }
}