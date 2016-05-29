namespace HeiFeiMidea
{
    partial class frmSetZheWang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetZheWang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panMain = new System.Windows.Forms.Panel();
            this.btnDel = new All.Control.Metro.PicButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnList = new All.Control.Metro.PicButton();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnSave = new All.Control.Metro.PicButton();
            this.gpVideo = new System.Windows.Forms.GroupBox();
            this.btnOpenVideo = new All.Control.Metro.PicButton();
            this.lblWorkStation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panVideo = new System.Windows.Forms.Panel();
            this.tbPlay = new System.Windows.Forms.TrackBar();
            this.btnPlay = new All.Control.Metro.PicButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.mediaPlayer1 = new All.Control.MediaPlayerLocal();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colWorkStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVideoFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ofdVideo = new System.Windows.Forms.OpenFileDialog();
            this.timVideo = new System.Windows.Forms.Timer(this.components);
            this.panMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpVideo.SuspendLayout();
            this.panVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(764, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 50;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.btnDel);
            this.panMain.Controls.Add(this.groupBox1);
            this.panMain.Controls.Add(this.btnSave);
            this.panMain.Controls.Add(this.gpVideo);
            this.panMain.Location = new System.Drawing.Point(206, 202);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(850, 520);
            this.panMain.TabIndex = 68;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.SystemColors.Control;
            this.btnDel.BackImage = null;
            this.btnDel.Border = true;
            this.btnDel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(626, 490);
            this.btnDel.Name = "btnDel";
            this.btnDel.PicBackColor = System.Drawing.Color.Black;
            this.btnDel.Size = new System.Drawing.Size(89, 28);
            this.btnDel.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnDel.TabIndex = 107;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnList);
            this.groupBox1.Controls.Add(this.txtMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(24, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 62);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.SystemColors.Control;
            this.btnList.BackImage = ((System.Drawing.Image)(resources.GetObject("btnList.BackImage")));
            this.btnList.Border = false;
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnList.Location = new System.Drawing.Point(248, 23);
            this.btnList.Name = "btnList";
            this.btnList.PicBackColor = System.Drawing.Color.Black;
            this.btnList.Size = new System.Drawing.Size(28, 27);
            this.btnList.Style = All.Control.Metro.PicButton.Styles.Tabpage;
            this.btnList.TabIndex = 66;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // txtMode
            // 
            this.txtMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMode.Location = new System.Drawing.Point(354, 22);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(443, 29);
            this.txtMode.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(302, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 102;
            this.label1.Text = "机型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 21);
            this.label5.TabIndex = 62;
            this.label5.Text = "折弯ID";
            // 
            // txtInfo
            // 
            this.txtInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfo.Location = new System.Drawing.Point(624, 22);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(173, 29);
            this.txtInfo.TabIndex = 105;
            this.txtInfo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(572, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 104;
            this.label2.Text = "描述";
            this.label2.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(77, 22);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(174, 29);
            this.txtID.TabIndex = 101;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(235, 22);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(44, 29);
            this.textBox5.TabIndex = 106;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackImage = null;
            this.btnSave.Border = true;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(732, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.PicBackColor = System.Drawing.Color.Black;
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gpVideo
            // 
            this.gpVideo.Controls.Add(this.btnOpenVideo);
            this.gpVideo.Controls.Add(this.lblWorkStation);
            this.gpVideo.Controls.Add(this.label4);
            this.gpVideo.Controls.Add(this.panVideo);
            this.gpVideo.Controls.Add(this.dataGridView1);
            this.gpVideo.Controls.Add(this.txtVideoFile);
            this.gpVideo.Controls.Add(this.label3);
            this.gpVideo.Controls.Add(this.textBox4);
            this.gpVideo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpVideo.ForeColor = System.Drawing.Color.Black;
            this.gpVideo.Location = new System.Drawing.Point(24, 68);
            this.gpVideo.Name = "gpVideo";
            this.gpVideo.Size = new System.Drawing.Size(812, 394);
            this.gpVideo.TabIndex = 106;
            this.gpVideo.TabStop = false;
            // 
            // btnOpenVideo
            // 
            this.btnOpenVideo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOpenVideo.BackImage = ((System.Drawing.Image)(resources.GetObject("btnOpenVideo.BackImage")));
            this.btnOpenVideo.Border = false;
            this.btnOpenVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenVideo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOpenVideo.Location = new System.Drawing.Point(767, 20);
            this.btnOpenVideo.Name = "btnOpenVideo";
            this.btnOpenVideo.PicBackColor = System.Drawing.Color.Black;
            this.btnOpenVideo.Size = new System.Drawing.Size(27, 26);
            this.btnOpenVideo.Style = All.Control.Metro.PicButton.Styles.Tabpage;
            this.btnOpenVideo.TabIndex = 109;
            this.btnOpenVideo.Click += new System.EventHandler(this.btnOpenVideo_Click);
            // 
            // lblWorkStation
            // 
            this.lblWorkStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWorkStation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkStation.ForeColor = System.Drawing.Color.White;
            this.lblWorkStation.Location = new System.Drawing.Point(96, 21);
            this.lblWorkStation.Name = "lblWorkStation";
            this.lblWorkStation.Size = new System.Drawing.Size(184, 26);
            this.lblWorkStation.TabIndex = 113;
            this.lblWorkStation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 112;
            this.label4.Text = "当前工位";
            // 
            // panVideo
            // 
            this.panVideo.Controls.Add(this.tbPlay);
            this.panVideo.Controls.Add(this.btnPlay);
            this.panVideo.Controls.Add(this.lblTime);
            this.panVideo.Controls.Add(this.mediaPlayer1);
            this.panVideo.Location = new System.Drawing.Point(11, 53);
            this.panVideo.Name = "panVideo";
            this.panVideo.Size = new System.Drawing.Size(621, 335);
            this.panVideo.TabIndex = 111;
            // 
            // tbPlay
            // 
            this.tbPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPlay.Location = new System.Drawing.Point(36, 310);
            this.tbPlay.Name = "tbPlay";
            this.tbPlay.Size = new System.Drawing.Size(515, 45);
            this.tbPlay.TabIndex = 110;
            this.tbPlay.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbPlay.Scroll += new System.EventHandler(this.tbPlay_Scroll);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPlay.BackImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackImage")));
            this.btnPlay.Border = false;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPlay.Location = new System.Drawing.Point(3, 305);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.PicBackColor = System.Drawing.Color.Black;
            this.btnPlay.Size = new System.Drawing.Size(30, 29);
            this.btnPlay.Style = All.Control.Metro.PicButton.Styles.Tabpage;
            this.btnPlay.TabIndex = 108;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(548, 308);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(71, 21);
            this.lblTime.TabIndex = 107;
            this.lblTime.Text = "000/000";
            // 
            // mediaPlayer1
            // 
            this.mediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mediaPlayer1.Location = new System.Drawing.Point(1, 8);
            this.mediaPlayer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mediaPlayer1.Name = "mediaPlayer1";
            this.mediaPlayer1.Position = 0;
            this.mediaPlayer1.Size = new System.Drawing.Size(607, 292);
            this.mediaPlayer1.TabIndex = 0;
            this.mediaPlayer1.Volumn = 50;
            this.mediaPlayer1.MediaMouseDoubleClick += new All.Control.MediaPlayerLocal.MouseDoubleClickHandle(this.mediaPlayer1_MediaMouseDoubleClick);
            this.mediaPlayer1.Load += new System.EventHandler(this.mediaPlayer1_Load);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorkStation,
            this.colStart,
            this.colEnd,
            this.colFile});
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dataGridView1.Location = new System.Drawing.Point(638, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(155, 322);
            this.dataGridView1.TabIndex = 106;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // colWorkStation
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colWorkStation.DefaultCellStyle = dataGridViewCellStyle1;
            this.colWorkStation.HeaderText = "位置";
            this.colWorkStation.Name = "colWorkStation";
            this.colWorkStation.ReadOnly = true;
            this.colWorkStation.Width = 150;
            // 
            // colStart
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStart.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStart.HeaderText = "起点";
            this.colStart.Name = "colStart";
            this.colStart.Width = 70;
            // 
            // colEnd
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEnd.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEnd.HeaderText = "终点";
            this.colEnd.Name = "colEnd";
            this.colEnd.Width = 70;
            // 
            // colFile
            // 
            this.colFile.HeaderText = "文件名";
            this.colFile.Name = "colFile";
            this.colFile.Visible = false;
            this.colFile.Width = 1000;
            // 
            // txtVideoFile
            // 
            this.txtVideoFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoFile.Location = new System.Drawing.Point(354, 18);
            this.txtVideoFile.Name = "txtVideoFile";
            this.txtVideoFile.Size = new System.Drawing.Size(415, 29);
            this.txtVideoFile.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(302, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 104;
            this.label3.Text = "视频";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(754, 18);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 29);
            this.textBox4.TabIndex = 114;
            // 
            // ofdVideo
            // 
            this.ofdVideo.FileName = "openFileDialog1";
            // 
            // timVideo
            // 
            this.timVideo.Interval = 300;
            this.timVideo.Tick += new System.EventHandler(this.timVideo_Tick);
            // 
            // frmSetZheWang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.btnClose);
            this.Name = "frmSetZheWang";
            this.Text = "折弯机型设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetZheWang_FormClosing);
            this.Load += new System.EventHandler(this.frmSetZheWang_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panMain, 0);
            this.panMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpVideo.ResumeLayout(false);
            this.gpVideo.PerformLayout();
            this.panVideo.ResumeLayout(false);
            this.panVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private All.Control.Metro.TitleButton btnClose;
        public System.Windows.Forms.Panel panMain;
        private All.Control.Metro.PicButton btnDel;
        private System.Windows.Forms.GroupBox groupBox1;
        private All.Control.Metro.PicButton btnList;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox textBox5;
        private All.Control.Metro.PicButton btnSave;
        private System.Windows.Forms.GroupBox gpVideo;
        private All.Control.Metro.PicButton btnOpenVideo;
        private System.Windows.Forms.Label lblWorkStation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panVideo;
        private System.Windows.Forms.TrackBar tbPlay;
        private All.Control.Metro.PicButton btnPlay;
        private System.Windows.Forms.Label lblTime;
        private All.Control.MediaPlayerLocal mediaPlayer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtVideoFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.OpenFileDialog ofdVideo;
        private System.Windows.Forms.Timer timVideo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFile;
    }
}