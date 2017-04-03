namespace HeiFeiMidea
{
    partial class frmTestJson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestJson));
            this.corner1 = new All.Control.Corner();
            this.delay1 = new All.Control.Delay();
            this.icon1 = new All.Control.Icon();
            this.light1 = new All.Control.Light();
            this.arrowTitle1 = new All.Control.Metro.ArrowTitle();
            this.checkBox1 = new All.Control.Metro.CheckBox();
            this.comBoBox1 = new All.Control.Metro.ComBoBox();
            this.hexagon1 = new All.Control.Metro.Hexagon();
            this.itemBox1 = new All.Control.Metro.ItemBox();
            this.listBox1 = new All.Control.Metro.ListBox();
            this.listItemBox1 = new All.Control.Metro.ListItemBox();
            this.metroButton1 = new All.Control.Metro.MetroButton();
            this.moveButton1 = new All.Control.Metro.MoveButton();
            this.picturePlayer1 = new All.Control.PicturePlayer();
            this.plate1 = new All.Control.Plate();
            this.plateTime1 = new All.Control.PlateTime();
            this.shape1 = new All.Control.Shape();
            this.time1 = new All.Control.Time();
            this.SuspendLayout();
            // 
            // corner1
            // 
            this.corner1.Bold = 1;
            this.corner1.Location = new System.Drawing.Point(2, 33);
            this.corner1.Name = "corner1";
            this.corner1.Size = new System.Drawing.Size(104, 45);
            this.corner1.Space = All.Control.Corner.SpaceList.LeftTop;
            this.corner1.TabIndex = 0;
            this.corner1.Text = "corner1";
            // 
            // delay1
            // 
            this.delay1.Location = new System.Drawing.Point(25, 132);
            this.delay1.Name = "delay1";
            this.delay1.Size = new System.Drawing.Size(115, 112);
            this.delay1.TabIndex = 1;
            this.delay1.Text = "delay1";
            // 
            // icon1
            // 
            this.icon1.AutoHeight = true;
            this.icon1.Board = true;
            this.icon1.ClearColor = System.Drawing.Color.Black;
            this.icon1.FillColor = System.Drawing.Color.Green;
            this.icon1.Location = new System.Drawing.Point(43, 289);
            this.icon1.Name = "icon1";
            this.icon1.Picture = ((System.Drawing.Bitmap)(resources.GetObject("icon1.Picture")));
            this.icon1.SaveNewColor = true;
            this.icon1.ShowIcon = All.Control.Icon.ShowIconList.图像;
            this.icon1.ShowNum = "";
            this.icon1.Size = new System.Drawing.Size(96, 96);
            this.icon1.TabIndex = 2;
            this.icon1.Text = "icon1";
            // 
            // light1
            // 
            this.light1.BackColor = System.Drawing.Color.Green;
            this.light1.LedColor = System.Drawing.Color.Red;
            this.light1.Location = new System.Drawing.Point(146, 148);
            this.light1.Name = "light1";
            this.light1.Size = new System.Drawing.Size(96, 96);
            this.light1.TabIndex = 3;
            this.light1.Text = "light1";
            // 
            // arrowTitle1
            // 
            this.arrowTitle1.Icon = null;
            this.arrowTitle1.IconColor = System.Drawing.Color.Red;
            this.arrowTitle1.IconStyle = All.Control.Metro.ArrowTitle.IconStyleList.三角形;
            this.arrowTitle1.Location = new System.Drawing.Point(234, 258);
            this.arrowTitle1.Name = "arrowTitle1";
            this.arrowTitle1.Size = new System.Drawing.Size(265, 37);
            this.arrowTitle1.TabIndex = 4;
            this.arrowTitle1.Tail = true;
            this.arrowTitle1.Text = "arrowTitle1";
            this.arrowTitle1.Title = "这里填写显示标题";
            this.arrowTitle1.TitleColor = System.Drawing.Color.WhiteSmoke;
            this.arrowTitle1.TitleFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // checkBox1
            // 
            this.checkBox1.CheckColor = System.Drawing.Color.DarkGreen;
            this.checkBox1.Checked = false;
            this.checkBox1.CheckText = "ON";
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(217, 441);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(142, 48);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UnCheckColor = System.Drawing.Color.DimGray;
            this.checkBox1.UnCheckText = "OFF";
            // 
            // comBoBox1
            // 
            this.comBoBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comBoBox1.FormattingEnabled = true;
            this.comBoBox1.Icon = null;
            this.comBoBox1.IconStyle = All.Control.Metro.ComBoBox.IconStyleList.三角形;
            this.comBoBox1.ItemColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue};
            this.comBoBox1.Location = new System.Drawing.Point(30, 453);
            this.comBoBox1.Name = "comBoBox1";
            this.comBoBox1.Size = new System.Drawing.Size(136, 22);
            this.comBoBox1.TabIndex = 6;
            this.comBoBox1.Tail = true;
            this.comBoBox1.Title = "";
            this.comBoBox1.TitleColor = System.Drawing.Color.WhiteSmoke;
            this.comBoBox1.TitleFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // hexagon1
            // 
            this.hexagon1.Back = System.Drawing.Color.IndianRed;
            this.hexagon1.BackColor = System.Drawing.Color.Red;
            this.hexagon1.ButtonValue = All.Control.Metro.Hexagon.ButtonList.Hexagon;
            this.hexagon1.Icon = null;
            this.hexagon1.Location = new System.Drawing.Point(32, 481);
            this.hexagon1.Login = true;
            this.hexagon1.Name = "hexagon1";
            this.hexagon1.Size = new System.Drawing.Size(142, 152);
            this.hexagon1.TabIndex = 7;
            this.hexagon1.Text = "hexagon1";
            this.hexagon1.Title = "电压(V)";
            this.hexagon1.TitleFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.hexagon1.Value = "220.7";
            this.hexagon1.ValueFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            // 
            // itemBox1
            // 
            this.itemBox1.BackColor = System.Drawing.Color.White;
            this.itemBox1.CanFouce = false;
            this.itemBox1.Check = true;
            this.itemBox1.CheckColor = System.Drawing.Color.Red;
            this.itemBox1.Icon = null;
            this.itemBox1.Location = new System.Drawing.Point(199, 519);
            this.itemBox1.Name = "itemBox1";
            this.itemBox1.Size = new System.Drawing.Size(216, 79);
            this.itemBox1.TabIndex = 8;
            this.itemBox1.Text = "itemBox1";
            this.itemBox1.Title = "ItemBox";
            this.itemBox1.TitleFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.itemBox1.Value = "this is ItemBox";
            this.itemBox1.ValueFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Icon = null;
            this.listBox1.IconStyle = All.Control.Metro.ListBox.IconStyleList.三角形;
            this.listBox1.ItemColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue};
            this.listBox1.ItemHeight = 30;
            this.listBox1.Location = new System.Drawing.Point(274, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(277, 184);
            this.listBox1.TabIndex = 9;
            this.listBox1.Tail = true;
            this.listBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.listBox1.TitleColor = System.Drawing.Color.WhiteSmoke;
            this.listBox1.TitleFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // listItemBox1
            // 
            this.listItemBox1.BackColor = System.Drawing.Color.White;
            this.listItemBox1.Icon = null;
            this.listItemBox1.Location = new System.Drawing.Point(186, 333);
            this.listItemBox1.MouseInColor = System.Drawing.Color.Red;
            this.listItemBox1.Name = "listItemBox1";
            this.listItemBox1.Size = new System.Drawing.Size(229, 52);
            this.listItemBox1.TabIndex = 10;
            this.listItemBox1.Text = "listItemBox1";
            this.listItemBox1.Title = "listItemBox1";
            this.listItemBox1.TitleFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            // 
            // metroButton1
            // 
            this.metroButton1.Back = System.Drawing.Color.Red;
            this.metroButton1.BackColor = System.Drawing.Color.Red;
            this.metroButton1.Img = ((System.Drawing.Image)(resources.GetObject("metroButton1.Img")));
            this.metroButton1.Location = new System.Drawing.Point(413, 441);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(195, 72);
            this.metroButton1.TabIndex = 11;
            this.metroButton1.Title = "登出";
            this.metroButton1.Value = "LoginOut";
            // 
            // moveButton1
            // 
            this.moveButton1.Location = new System.Drawing.Point(503, 550);
            this.moveButton1.Name = "moveButton1";
            this.moveButton1.Size = new System.Drawing.Size(166, 83);
            this.moveButton1.TabIndex = 12;
            // 
            // picturePlayer1
            // 
            this.picturePlayer1.ChangeTime = 1000;
            this.picturePlayer1.DelayTime = 5000;
            this.picturePlayer1.FilePath = ((System.Collections.Generic.List<System.Drawing.Image>)(resources.GetObject("picturePlayer1.FilePath")));
            this.picturePlayer1.FlushList = All.Control.Player.FlushMethod.FlushList.横向百业窗;
            this.picturePlayer1.Location = new System.Drawing.Point(651, 413);
            this.picturePlayer1.Name = "picturePlayer1";
            this.picturePlayer1.Size = new System.Drawing.Size(144, 131);
            this.picturePlayer1.TabIndex = 13;
            this.picturePlayer1.Text = "picturePlayer1";
            // 
            // plate1
            // 
            this.plate1.ArrowColor = System.Drawing.Color.Red;
            this.plate1.ColorPart1 = System.Drawing.Color.Yellow;
            this.plate1.ColorPart2 = System.Drawing.Color.Green;
            this.plate1.ColorPart3 = System.Drawing.Color.Red;
            this.plate1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plate1.Format = "F1";
            this.plate1.Location = new System.Drawing.Point(568, 249);
            this.plate1.Max = 10D;
            this.plate1.Min = 0D;
            this.plate1.Name = "plate1";
            this.plate1.Part = 10;
            this.plate1.PartValue1 = 3;
            this.plate1.PartValue2 = 6;
            this.plate1.PlateColor = System.Drawing.Color.Brown;
            this.plate1.Size = new System.Drawing.Size(240, 240);
            this.plate1.TabIndex = 14;
            this.plate1.Text = "plate1";
            this.plate1.Title = "显示值";
            this.plate1.Value = 4.5D;
            // 
            // plateTime1
            // 
            this.plateTime1.ArrowColor = System.Drawing.Color.Red;
            this.plateTime1.Font = new System.Drawing.Font("黑体", 12F);
            this.plateTime1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.plateTime1.Location = new System.Drawing.Point(568, 4);
            this.plateTime1.Name = "plateTime1";
            this.plateTime1.Now = new System.DateTime(2016, 9, 15, 12, 12, 40, 0);
            this.plateTime1.PlateColor = System.Drawing.Color.Orange;
            this.plateTime1.Size = new System.Drawing.Size(240, 240);
            this.plateTime1.TabIndex = 15;
            this.plateTime1.Text = "plateTime1";
            this.plateTime1.Title = "北京时间";
            // 
            // shape1
            // 
            this.shape1.Location = new System.Drawing.Point(154, 30);
            this.shape1.Name = "shape1";
            this.shape1.ShapeValue = All.Control.Shape.ShapeList.圆形;
            this.shape1.Size = new System.Drawing.Size(59, 70);
            this.shape1.TabIndex = 16;
            this.shape1.Text = "shape1";
            // 
            // time1
            // 
            this.time1.Format = All.Control.Time.FormatList.日期和时间;
            this.time1.Location = new System.Drawing.Point(268, 392);
            this.time1.Name = "time1";
            this.time1.Now = new System.DateTime(2016, 9, 28, 10, 56, 20, 141);
            this.time1.Shardow = false;
            this.time1.Size = new System.Drawing.Size(294, 49);
            this.time1.TabIndex = 17;
            this.time1.Text = "time1";
            // 
            // frmTestJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 645);
            this.Controls.Add(this.time1);
            this.Controls.Add(this.shape1);
            this.Controls.Add(this.plateTime1);
            this.Controls.Add(this.plate1);
            this.Controls.Add(this.picturePlayer1);
            this.Controls.Add(this.moveButton1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.listItemBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.itemBox1);
            this.Controls.Add(this.hexagon1);
            this.Controls.Add(this.comBoBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.arrowTitle1);
            this.Controls.Add(this.light1);
            this.Controls.Add(this.icon1);
            this.Controls.Add(this.delay1);
            this.Controls.Add(this.corner1);
            this.Name = "frmTestJson";
            this.Text = "frmTestJson";
            this.Load += new System.EventHandler(this.frmTestJson_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private All.Control.Corner corner1;
        private All.Control.Delay delay1;
        private All.Control.Icon icon1;
        private All.Control.Light light1;
        private All.Control.Metro.ArrowTitle arrowTitle1;
        private All.Control.Metro.CheckBox checkBox1;
        private All.Control.Metro.ComBoBox comBoBox1;
        private All.Control.Metro.Hexagon hexagon1;
        private All.Control.Metro.ItemBox itemBox1;
        private All.Control.Metro.ListBox listBox1;
        private All.Control.Metro.ListItemBox listItemBox1;
        private All.Control.Metro.MetroButton metroButton1;
        private All.Control.Metro.MoveButton moveButton1;
        private All.Control.PicturePlayer picturePlayer1;
        private All.Control.Plate plate1;
        private All.Control.PlateTime plateTime1;
        private All.Control.Shape shape1;
        private All.Control.Time time1;
    }
}