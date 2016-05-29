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
    public partial class frmUserChangeEdit : All.Window.MainWindow
    {
        List<HeiFeiMideaDll.UserSet> allUsers;
        public frmUserChangeEdit()
        {
            InitializeComponent();
        }

        private void frmUserChangePassword_Load(object sender, EventArgs e)
        {
            InitUser();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPasswordAgain.Text)
            {
                All.Window.MessageBox.Show(this, "对不起，两次输入的密码不一致，请重新输入正确的用户密码！", "错误的用户密码", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswordAgain.Focus();
                txtPasswordAgain.SelectAll();
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
                    allUsers[tmpIndex].Word = txtPassword.Text;
                    if (HeiFeiMideaDll.UserSet.UpdateUser(allUsers[tmpIndex],frmMain.mMain.AllDataBase.LocalData))
                    {
                        All.Window.MetroMessageBox.Show(this, string.Format("当前选定的用户【{0}】密码已成功修改为新密码！", cbbName.Text), "修改成功！", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        All.Window.MetroMessageBox.Show(this, string.Format("当前选定的用户【{0}】密码修改失败，失败原因请查看故障文档", cbbName.Text), "修改失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (cbbName.Text == "Administrator")
            {
                All.Window.MetroMessageBox.Show(this, "Administrator是系统管理员账户，此账户不能从数据库中删除！", "删除失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (All.Window.MetroMessageBox.Show(this, string.Format("是否确认要删除选定的用户【{0}】？删除后必须重新添加此用户！", cbbName.Text), "是否继续？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            if (HeiFeiMideaDll.UserSet.DeleteUser(cbbName.Text,frmMain.mMain.AllDataBase.LocalData))
            {
                All.Window.MetroMessageBox.Show(this, string.Format("当前选定的用户【{0}】已成功从数据库删除！", cbbName.Text), "删除成功！", MessageBoxButtons.OK);
                InitUser();
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, string.Format("当前选定的用户【{0}】删除失败，失败原因请查看故障文档！", cbbName.Text), "删除失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbName.Text != "")
            {
                int index = allUsers.FindIndex(
                    user =>
                    {
                        return user.Text == cbbName.Text;
                    });
                if (index >= 0)
                {
                    txtPassword.Text = allUsers[index].Word;
                }
            }
        }
    }
}
