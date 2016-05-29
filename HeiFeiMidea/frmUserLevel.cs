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
    public partial class frmUserLevel : All.Window.MainWindow
    {
        const int WidthStep = 230;
        const int HeightStep = 40;

        int visableIndex = 1;
        int maxHeight = 0;
        All.Control.Metro.CheckBox[] AllSpace = new All.Control.Metro.CheckBox[HeiFeiMideaDll.cMain.AllStopStationCount + 1];
        Label[] lblTitle = new Label[HeiFeiMideaDll.cMain.AllStopStationCount + 1];
        List<HeiFeiMideaDll.UserSet> allUsers;
        public frmUserLevel()
        {
            InitializeComponent();
            InitFrm();
        }

        private void frmuserLevel_Load(object sender, EventArgs e)
        {
            InitUser();
        }
        private void InitFrm()
        {
            AllSpace[0] = chk1;
            lblTitle[0] = lbl1;
            Point P1, P2;
            for (int i = 1; i < HeiFeiMideaDll.cMain.AllStopStationCount + 1; i++)
            {
                GetLocation(lbl1.Location, chk1.Location, frmMain.mMain.AllCars.AllInfoLineStation[i - 1].TestStation, out P1, out P2);

                AllSpace[i] = new All.Control.Metro.CheckBox();
                AllSpace[i].CheckColor = System.Drawing.Color.LimeGreen;
                AllSpace[i].Checked = false;
                AllSpace[i].Location = P2;
                AllSpace[i].Size = new System.Drawing.Size(64, 28);
                AllSpace[i].UnCheckColor = System.Drawing.Color.DarkGray;
                AllSpace[i].Visible = frmMain.mMain.AllCars.AllInfoLineStation[i - 1].TestStation;
                groupBox2.Controls.Add(AllSpace[i]);

                lblTitle[i] = new Label();
                lblTitle[i].Visible = frmMain.mMain.AllCars.AllInfoLineStation[i - 1].TestStation;
                lblTitle[i].AutoSize = true;
                lblTitle[i].Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblTitle[i].ForeColor = System.Drawing.Color.White;
                lblTitle[i].Location = P1;
                lblTitle[i].Size = new System.Drawing.Size(64, 21);
                lblTitle[i].Text = frmMain.mMain.AllCars.AllInfoLineStation[i - 1].StationName;
                groupBox2.Controls.Add(lblTitle[i]);
            }
            groupBox2.Height = maxHeight;
            btnSave.Top = groupBox2.Height + groupBox2.Top + 10;
            panMain.Height = groupBox2.Height + 50 + groupBox2.Top;
        }
        private void GetLocation(Point FirstPoint,Point SecondPoint,bool Visable,out Point P1,out Point P2)
        {
            P1 = Point.Empty;
            P2 = Point.Empty;
            if (Visable)
            {
                int rowIndex = (int)Math.Floor(visableIndex / 3.0f);
                int colIndex = (int)(visableIndex % 3);
                int XAdd = colIndex * WidthStep;
                int YAdd = rowIndex * HeightStep;
                P1 = new Point(FirstPoint.X + XAdd, FirstPoint.Y + YAdd);
                P2 = new Point(SecondPoint.X + XAdd, SecondPoint.Y + YAdd);
                visableIndex++;
                maxHeight = P1.Y + HeightStep;
            }
        }
        private void InitUser()
        {
            cbbName.Items.Clear();
            allUsers = HeiFeiMideaDll.UserSet.GetAllUser(frmMain.mMain.AllDataBase.LocalData);
            if (allUsers != null && allUsers.Count > 0)
            {
                allUsers.ForEach(user =>
                {
                    cbbName.Items.Add(user.Text);
                    cbbName.Text = user.Text;
                });
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AllSpace.Length; i++)
            {
                AllSpace[i].Checked = true;
            }
        }

        private void btnNoAll_Click(object sender, EventArgs e)
        {
            for (int i = 0;  i < AllSpace.Length; i++)
            {
                AllSpace[i].Checked = false;
            }
        }

        private void cbbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbName.SelectedIndex >= 0 && cbbName.SelectedIndex < allUsers.Count)
            {
                for (int i = 0;  i < AllSpace.Length; i++)
                {
                    AllSpace[i].Checked = allUsers[cbbName.SelectedIndex].Use[i];
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbbName.SelectedIndex < 0 || cbbName.SelectedIndex > allUsers.Count)
            {
                All.Window.MessageBox.Show(this, "当前选定的用户名称不对，不能保存权限数据！", "错误的用户", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbbName.Text == "Administrator")
            {
                All.Window.MetroMessageBox.Show(this, "Administrator是系统管理员账户，此账户具有所有权限，不能更改！", "删除的用户！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (allUsers != null && allUsers.Count > 0)
            {
                int tmpIndex = allUsers.FindIndex(user =>
                      {
                          return user.Text == cbbName.Text;
                      });
                if (tmpIndex >= 0)
                {
                    for (int i = 0; i < AllSpace.Length; i++)
                    {
                        allUsers[tmpIndex].Use[i] = AllSpace[i].Checked;
                    }
                    if (HeiFeiMideaDll.UserSet.UpdateUser(allUsers[tmpIndex], frmMain.mMain.AllDataBase.LocalData))
                    {
                        All.Window.MetroMessageBox.Show(this, string.Format("当前选定的用户【{0}】权限已修改为新的权限！", cbbName.Text), "修改成功！", MessageBoxButtons.OK);
                    }
                    else
                    {
                        All.Window.MetroMessageBox.Show(this, string.Format("当前选定的用户【{0}】权限修改失败，失败原因请查看故障文档", cbbName.Text), "修改失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
 
                }
            }
            frmMain.mMain.FlushUserLogin.FlushAllUserForShowLineIcon();
        }
    }
}
