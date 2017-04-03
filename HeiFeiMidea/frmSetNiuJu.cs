using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeiFeiMidea
{
    public partial class frmSetNiuJu : All.Window.MainWindow
    {
        const int PicMaxCount = 100;
        StringFormat sf = new StringFormat();
        public frmSetNiuJu()
        {
            InitializeComponent();
        }

        private void frmSetNiuJu_Load(object sender, EventArgs e)
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            cbbID.Items.Clear();
            for (int i = 0; i < 16; i++)
            {
                cbbID.Items.Add(string.Format("{0:D2}#程序", i));
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = 0;
            for (int i = PicMaxCount - 1; i >= 0; i--)
            {
                if (picBack.Controls.Find(string.Format("Pic{0}", i), true).Length > 0)
                {
                    index = i + 1;
                    break;
                }
            }
            All.Control.MoveControl.MoveShape pic = new All.Control.MoveControl.MoveShape();
            pic.Name = string.Format("Pic{0}", index);
            pic.Location = new Point(0, 0);
            pic.Size = new Size(25, 25);
            pic.BackColor = Color.Blue;
            pic.Paint += pic_Paint;
            picBack.Controls.Add(pic);
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            All.Control.MoveControl.MoveShape tmp = (All.Control.MoveControl.MoveShape)sender;
            e.Graphics.DrawString(tmp.Name.Replace("Pic", ""), new Font("黑体", 8), new SolidBrush(Color.White), new RectangleF(0, 0, tmp.Width, tmp.Height), sf);
        }

        private void btnNiuJu1_Click(object sender, EventArgs e)
        {
            ofdNiuJuPic.Filter = string.Format("{0}", All.Control.PicturePlayer.FileFilter);
            ofdNiuJuPic.Title = "请选择扭矩底图文件";
            ofdNiuJuPic.InitialDirectory = frmMain.mMain.AllDataXml.LocalSet.NiuJuDirectory;
            ofdNiuJuPic.Multiselect = false;
            ofdNiuJuPic.FileName = "";
            if (ofdNiuJuPic.ShowDialog() == DialogResult.OK)
            {
                if (ofdNiuJuPic.FileName.IndexOf(frmMain.mMain.AllDataXml.LocalSet.NiuJuDirectory) < 0)
                {
                    All.Window.MetroMessageBox.Show(this, string.Format("底图文件位置错误，只能指定存放于文件夹{0}内的底图文件", frmMain.mMain.AllDataXml.LocalSet.NiuJuDirectory), "错误的路径",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtNiuJuPic1.Text = ofdNiuJuPic.FileName.Replace(frmMain.mMain.AllDataXml.LocalSet.NiuJuDirectory,"");
                try
                {
                    picBack.Image = Image.FromFile(ofdNiuJuPic.FileName);
                }
                catch { }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (All.Control.MoveControl.MoveControl.Count < 0)
            {
                All.Window.MetroMessageBox.Show(this, "当前没有选中位置,不能进行删除操作,请先选择要删除的位置", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            All.Control.MoveControl.MoveShape tmp;
            for (int i = 0; i < PicMaxCount; i++)
            {
                Control[] tmpCon = picBack.Controls.Find(string.Format("Pic{0}", i), true);
                if (tmpCon != null && tmpCon.Length == 1)
                {
                    tmp = (All.Control.MoveControl.MoveShape)tmpCon[0];
                    if (tmp.MoveControl.IsGetFocus)
                    {
                        picBack.Controls.Remove(tmp);
                        tmp.Dispose();
                        All.Control.MoveControl.MoveControl.ClearPaint();
                        break;
                    }
                }
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.LeftAlign();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.RightAlign();
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.TopAlign();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.BottonAlign();
        }

        private void btnVerital_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.VerticalAlign();
        }

        private void btnHorizen_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.Horizontal();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.ClearPaint();
        }
        private void ClassToFrm()
        {
            if (cbbID.SelectedIndex < 0 || cbbID.SelectedIndex >= cbbID.Items.Count)
            {
                return;
            }
            if (cbbSpace.SelectedIndex < 0 || cbbSpace.SelectedIndex >= cbbSpace.Items.Count)
            {
                return;
            }
            bool yaSuoJi = (cbbSpace.SelectedIndex == 0);
            bool fengJi = !yaSuoJi;
            int chengXuHao = cbbID.SelectedIndex;
            HeiFeiMideaDll.cNiuJu tmp = HeiFeiMideaDll.cNiuJu.Read(yaSuoJi, fengJi, chengXuHao, frmMain.mMain.AllDataBase.LocalData);
            foreach (Control c in picBack.Controls)
            {
                if (c is All.Control.MoveControl.MoveShape)
                {
                    c.Dispose();
                }
            }
            txtInfo.Text = tmp.Info;
            picBack.Controls.Clear();
            
            All.Control.MoveControl.MoveControl.ClearPaint();
            txtNiuJuPic1.Text = tmp.BackImage;
            if (System.IO.File.Exists(string.Format("{0}\\{1}", frmMain.mMain.AllDataXml.LocalSet.NiuJuDirectory, tmp.BackImage)))
            {
                try
                {
                    picBack.Image = Image.FromFile(string.Format("{0}\\{1}", frmMain.mMain.AllDataXml.LocalSet.NiuJuDirectory, tmp.BackImage));
                }
                catch
                {
                    picBack.Image = null;
                }
            }
            else
            {
                picBack.Image = null;
            }
            All.Control.MoveControl.MoveShape pic;
            for (int i = 0; i < tmp.Sons.Count; i++)
            {
                pic = new All.Control.MoveControl.MoveShape();
                pic.Name = string.Format("Pic{0}", i);
                pic.Location = tmp.Sons[i].Location;
                pic.Size = tmp.Sons[i].Size;
                pic.BackColor = Color.Blue;
                pic.Paint += pic_Paint;
                picBack.Controls.Add(pic);
            }

        }
        private HeiFeiMideaDll.cNiuJu FrmToClass()
        {
            HeiFeiMideaDll.cNiuJu result = new HeiFeiMideaDll.cNiuJu();
            result.YaSuoJi = (cbbSpace.SelectedIndex == 0);
            result.FengJi = !result.YaSuoJi;
            result.ChengXuHao = cbbID.SelectedIndex;
            result.BackImage = txtNiuJuPic1.Text;
            result.BackWidth = picBack.Width;
            result.BackHeight = picBack.Height;
            result.Info = txtInfo.Text;
            All.Control.MoveControl.MoveShape tmp;
            for (int i = 0; i < PicMaxCount; i++)
            {
                Control[] tmpCon = picBack.Controls.Find(string.Format("Pic{0}", i), true);
                if (tmpCon != null && tmpCon.Length == 1)
                {
                    tmp = (All.Control.MoveControl.MoveShape)tmpCon[0];
                    result.Sons.Add(new Rectangle(tmp.Left, tmp.Top, tmp.Width, tmp.Height));
                }
            }
            return result;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            HeiFeiMideaDll.cNiuJu tmp = new HeiFeiMideaDll.cNiuJu();
            if (picBack.Controls.Count <= 0)
            {
                All.Window.MetroMessageBox.Show(this, "当前设置不包含螺丝，请重新添加螺丝位置后再保存", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbbSpace.SelectedIndex < 0)
            {
                All.Window.MetroMessageBox.Show(this, "当前选择位置不正确，请先选择指定位置好再保存", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbbID.SelectedIndex < 0)
            {
                All.Window.MetroMessageBox.Show(this, "当前选择程序号不正确，请先选择正确的程序号再保存", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FrmToClass().Save(frmMain.mMain.AllDataBase.LocalData))
            {
                All.Window.MetroMessageBox.Show(this, "当前扭矩设置已成功保存到数据库", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "当前扭矩设置保存失败，请重新保存", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassToFrm();
        }

        private void cbbSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassToFrm();
        }

        private void btnSameWidth_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.SameWidth();
        }

        private void btnSameHeight_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.SameHeight();
        }

        private void btnSame_Click(object sender, EventArgs e)
        {
            All.Control.MoveControl.MoveControl.SameSize();
        }

    }
}
