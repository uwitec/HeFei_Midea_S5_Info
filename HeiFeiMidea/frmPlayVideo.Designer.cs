namespace HeiFeiMidea
{
    partial class frmPlayVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayVideo));
            this.picturePlayer1 = new All.Control.PicturePlayer();
            this.mediaPlayer1 = new All.Control.MediaPlayDirect();
            this.SuspendLayout();
            // 
            // picturePlayer1
            // 
            this.picturePlayer1.BackColor = System.Drawing.Color.Black;
            this.picturePlayer1.ChangeTime = 1000;
            this.picturePlayer1.DelayTime = 5000;
            this.picturePlayer1.FilePath = ((System.Collections.Generic.List<System.Drawing.Image>)(resources.GetObject("picturePlayer1.FilePath")));
            this.picturePlayer1.FlushList = All.Control.Player.FlushMethod.FlushList.随机;
            this.picturePlayer1.Location = new System.Drawing.Point(0, 0);
            this.picturePlayer1.Name = "picturePlayer1";
            this.picturePlayer1.Size = new System.Drawing.Size(960, 540);
            this.picturePlayer1.TabIndex = 15;
            this.picturePlayer1.Text = "picturePlayer1";
            // 
            // mediaPlayer1
            // 
            this.mediaPlayer1.BackColor = System.Drawing.Color.Black;
            this.mediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.mediaPlayer1.Name = "mediaPlayer1";
            this.mediaPlayer1.Size = new System.Drawing.Size(960, 540);
            this.mediaPlayer1.TabIndex = 16;
            // 
            // frmPlayVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.mediaPlayer1);
            this.Controls.Add(this.picturePlayer1);
            this.Name = "frmPlayVideo";
            this.ShowTitle = false;
            this.Text = "frmPlayVideo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayVideo_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayVideo_Load);
            this.Controls.SetChildIndex(this.picturePlayer1, 0);
            this.Controls.SetChildIndex(this.mediaPlayer1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private All.Control.PicturePlayer picturePlayer1;
        private All.Control.MediaPlayDirect mediaPlayer1;
    }
}