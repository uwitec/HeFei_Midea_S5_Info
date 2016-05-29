namespace HeiFeiMidea
{
    partial class frmPlaySheBei
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlaySheBei));
            this.itemCurCount = new All.Control.Metro.ItemBox();
            this.itemNeedCount = new All.Control.Metro.ItemBox();
            this.itemAllCount = new All.Control.Metro.ItemBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.listBox1 = new All.Control.Metro.ListBox();
            this.mediaPlayer1 = new All.Control.MediaPlayDirect();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new All.Control.Metro.ListBox();
            this.timFlush = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemCurCount
            // 
            this.itemCurCount.BackColor = System.Drawing.Color.White;
            this.itemCurCount.CanFouce = false;
            this.itemCurCount.Check = true;
            this.itemCurCount.CheckColor = System.Drawing.Color.Blue;
            this.itemCurCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemCurCount.Icon")));
            this.itemCurCount.Location = new System.Drawing.Point(405, 345);
            this.itemCurCount.Name = "itemCurCount";
            this.itemCurCount.Size = new System.Drawing.Size(198, 73);
            this.itemCurCount.TabIndex = 33;
            this.itemCurCount.Text = "itemBox4";
            this.itemCurCount.Title = "下次维护";
            this.itemCurCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCurCount.Value = "";
            this.itemCurCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCurCount.Visible = false;
            // 
            // itemNeedCount
            // 
            this.itemNeedCount.BackColor = System.Drawing.Color.White;
            this.itemNeedCount.CanFouce = false;
            this.itemNeedCount.Check = true;
            this.itemNeedCount.CheckColor = System.Drawing.Color.Green;
            this.itemNeedCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemNeedCount.Icon")));
            this.itemNeedCount.Location = new System.Drawing.Point(405, 266);
            this.itemNeedCount.Name = "itemNeedCount";
            this.itemNeedCount.Size = new System.Drawing.Size(198, 73);
            this.itemNeedCount.TabIndex = 32;
            this.itemNeedCount.Text = "itemBox3";
            this.itemNeedCount.Title = "须要维护";
            this.itemNeedCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNeedCount.Value = "";
            this.itemNeedCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNeedCount.Visible = false;
            // 
            // itemAllCount
            // 
            this.itemAllCount.BackColor = System.Drawing.Color.White;
            this.itemAllCount.CanFouce = false;
            this.itemAllCount.Check = true;
            this.itemAllCount.CheckColor = System.Drawing.Color.Olive;
            this.itemAllCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemAllCount.Icon")));
            this.itemAllCount.Location = new System.Drawing.Point(405, 187);
            this.itemAllCount.Name = "itemAllCount";
            this.itemAllCount.Size = new System.Drawing.Size(198, 73);
            this.itemAllCount.TabIndex = 31;
            this.itemAllCount.Text = "itemBox2";
            this.itemAllCount.Title = "设备数量";
            this.itemAllCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemAllCount.Value = "";
            this.itemAllCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemAllCount.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(23, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 222);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(15, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 20);
            this.label16.TabIndex = 175;
            this.label16.Text = "今日维护与保养";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Icon = null;
            this.listBox1.IconStyle = All.Control.Metro.ListBox.IconStyleList.三角形;
            this.listBox1.ItemColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue};
            this.listBox1.ItemHeight = 33;
            this.listBox1.Location = new System.Drawing.Point(3, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(192, 197);
            this.listBox1.TabIndex = 22;
            this.listBox1.Tail = false;
            this.listBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.listBox1.TitleColor = System.Drawing.Color.WhiteSmoke;
            this.listBox1.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // mediaPlayer1
            // 
            this.mediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer1.Location = new System.Drawing.Point(3, 22);
            this.mediaPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.mediaPlayer1.Name = "mediaPlayer1";
            this.mediaPlayer1.Size = new System.Drawing.Size(715, 444);
            this.mediaPlayer1.TabIndex = 35;
            this.mediaPlayer1.Volumn = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mediaPlayer1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(227, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(721, 469);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "维护与保养视频";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(23, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 245);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 175;
            this.label1.Text = "最近维护与保养";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.Black;
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Icon = null;
            this.listBox2.IconStyle = All.Control.Metro.ListBox.IconStyleList.三角形;
            this.listBox2.ItemColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue};
            this.listBox2.ItemHeight = 33;
            this.listBox2.Location = new System.Drawing.Point(3, 22);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(192, 220);
            this.listBox2.TabIndex = 22;
            this.listBox2.Tail = false;
            this.listBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.listBox2.TitleColor = System.Drawing.Color.WhiteSmoke;
            this.listBox2.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // timFlush
            // 
            this.timFlush.Interval = 500;
            this.timFlush.Tick += new System.EventHandler(this.timFlush_Tick);
            // 
            // frmPlaySheBei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.itemCurCount);
            this.Controls.Add(this.itemNeedCount);
            this.Controls.Add(this.itemAllCount);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPlaySheBei";
            this.Text = "设备维护与保养";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlaySheBei_FormClosing);
            this.Load += new System.EventHandler(this.frmPlaySheBei_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.itemAllCount, 0);
            this.Controls.SetChildIndex(this.itemNeedCount, 0);
            this.Controls.SetChildIndex(this.itemCurCount, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private All.Control.Metro.ItemBox itemCurCount;
        private All.Control.Metro.ItemBox itemNeedCount;
        private All.Control.Metro.ItemBox itemAllCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private All.Control.Metro.ListBox listBox1;
        private All.Control.MediaPlayDirect mediaPlayer1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private All.Control.Metro.ListBox listBox2;
        private System.Windows.Forms.Timer timFlush;
    }
}