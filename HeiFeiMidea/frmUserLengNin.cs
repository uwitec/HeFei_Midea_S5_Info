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
    public partial class frmUserLengNin : All.Window.MainWindow
    {
        All.Control.Metro.CheckBox[] AllSpace = new All.Control.Metro.CheckBox[HeiFeiMideaDll.cMain.AllLengNinQiCount];
        TextBox[] lblTitle = new TextBox[HeiFeiMideaDll.cMain.AllLengNinQiCount];
        List<HeiFeiMideaDll.LengNinUser> allUsers;
        
        public frmUserLengNin()
        {
            InitializeComponent();
        }

        private void frmLenNingUser_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitUser();
        }
        private void InitFrm()
        {

            List<HeiFeiMideaDll.InfoLengNin> infoLengNin = HeiFeiMideaDll.InfoLengNin.Load(frmMain.mMain.AllDataBase.ReadData);

            for (int i = 0; i < HeiFeiMideaDll.cMain.AllLengNinQiCount; i++)
            {
                AllSpace[i] = (All.Control.Metro.CheckBox)this.Controls.Find(string.Format("checkBox{0}", i), true)[0];
                lblTitle[i] = (TextBox)this.Controls.Find(string.Format("textBox{0}", i + 1), true)[0];
                if (i < infoLengNin.Count)
                {
                    lblTitle[i].Text = infoLengNin[i].StationName;
                }
            }
        }
        private void InitUser()
        {
            cbbName.Items.Clear();
            allUsers = HeiFeiMideaDll.LengNinUser.GetAllUser(frmMain.mMain.AllDataBase.LocalData);
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lblTitle.Length; i++)
            {
                frmMain.mMain.AllDataBase.LocalData.Write(string.Format("update InfoLengNinStation set StationName='{0}' where WorkStation={1}", lblTitle[i].Text, i + 1));
            }


            if (cbbName.SelectedIndex < 0 || cbbName.SelectedIndex > allUsers.Count)
            {
                All.Window.MetroMessageBox.Show(this, "当前选定的用户名称不对，不能保存权限数据！", "错误的用户", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (HeiFeiMideaDll.LengNinUser.UpdateUser(allUsers[tmpIndex], frmMain.mMain.AllDataBase.LocalData))
                    {
                        All.Window.MetroMessageBox.Show(this, string.Format("当前选定的用户【{0}】权限已修改为新的权限！", cbbName.Text), "修改成功！", MessageBoxButtons.OK);
                    }
                    else
                    {
                        All.Window.MetroMessageBox.Show(this, string.Format("当前选定的用户【{0}】权限修改失败，失败原因请查看故障文档", cbbName.Text), "修改失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            frmMain.mMain.FlushUserLogin.FlushLengNinShowLineIcon();
        }

        private void cbbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbName.SelectedIndex >= 0 && cbbName.SelectedIndex < allUsers.Count)
            {
                for (int i = 0; i < AllSpace.Length; i++)
                {
                    AllSpace[i].Checked = allUsers[cbbName.SelectedIndex].Use[i];
                }
            }
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
            for (int i = 0; i < AllSpace.Length; i++)
            {
                AllSpace[i].Checked = false;
            }
        }
    }
}
