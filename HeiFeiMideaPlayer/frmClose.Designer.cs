namespace HeiFeiMideaPlayer
{
    partial class frmClose
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new All.Control.Metro.PicButton();
            this.btnCancel = new All.Control.Metro.PicButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(74, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(439, 35);
            this.label5.TabIndex = 51;
            this.label5.Text = "主机发送关机命令，程序即将退出并自动关机。";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.BackImage = null;
            this.btnClose.Border = true;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(156, 148);
            this.btnClose.Name = "btnClose";
            this.btnClose.PicBackColor = System.Drawing.Color.Black;
            this.btnClose.Size = new System.Drawing.Size(90, 24);
            this.btnClose.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnClose.TabIndex = 75;
            this.btnClose.Text = "关机[ 5s ]";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BackImage = null;
            this.btnCancel.Border = true;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(314, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PicBackColor = System.Drawing.Color.Black;
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 212);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmClose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmClose";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClose_FormClosing);
            this.Load += new System.EventHandler(this.frmClose_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private All.Control.Metro.PicButton btnClose;
        private All.Control.Metro.PicButton btnCancel;
        private System.Windows.Forms.Timer timer1;
    }
}