namespace HeiFeiMidea
{
    partial class frmPlayManagement
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
            this.textPlayer1 = new All.Control.TextPlayer();
            this.SuspendLayout();
            // 
            // textPlayer1
            // 
            this.textPlayer1.Date = "12月14日";
            this.textPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPlayer1.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPlayer1.ForeColor = System.Drawing.Color.Red;
            this.textPlayer1.Location = new System.Drawing.Point(0, 0);
            this.textPlayer1.Name = "textPlayer1";
            this.textPlayer1.Size = new System.Drawing.Size(960, 540);
            this.textPlayer1.TabIndex = 15;
            this.textPlayer1.Text = "textPlayer1";
            this.textPlayer1.Title = "通知";
            this.textPlayer1.Value = "   全体员工于今天晚上5：30到办公室开会。请收看到此消息的员工之间相互转达。所有人必须准时到达，后果自负";
            // 
            // frmPlayManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.textPlayer1);
            this.Name = "frmPlayManagement";
            this.ShowTitle = false;
            this.Text = "生产信息化 － 小时生产产量";
            this.Load += new System.EventHandler(this.frmPlayManagement_Load);
            this.Controls.SetChildIndex(this.textPlayer1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private All.Control.TextPlayer textPlayer1;


    }
}