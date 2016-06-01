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
    public partial class frmUserAdd : All.Window.MainWindow
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }

        private void frmUserAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                All.Window.MessageBox.Show(this, "对不起，用户名称不能为空，请重新输入正确的用户名称！", "错误的用户名称", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                txtName.SelectAll();
                return;
            }
            if (txtPassword.Text != txtPasswordAgain.Text)
            {
                All.Window.MessageBox.Show(this, "对不起，两次输入的密码不一致，请重新输入正确的用户密码！", "错误的用户密码", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswordAgain.Focus();
                txtPasswordAgain.SelectAll();
                return;
            }

            List<HeiFeiMideaDll.UserSet> allUsers = HeiFeiMideaDll.UserSet.GetAllUser(frmMain.mMain.AllDataBase.LocalData);

            int tmpIndex = allUsers.FindIndex(user =>
                  {
                      return user.Text == txtName.Text;
                  });
            if (tmpIndex >= 0)
            {
                All.Window.MessageBox.Show(this, "对不起，当前输入的用户名称已存在，请重新输入其他的用户名称！", "错误的用户名称", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                txtName.SelectAll();
                return;
            }
            if(HeiFeiMideaDll.UserSet.InsertUser(new HeiFeiMideaDll.UserSet(txtName.Text, txtPassword.Text),frmMain.mMain.AllDataBase.LocalData))
            {
                HeiFeiMideaDll.LengNinUser.InsertUser(new HeiFeiMideaDll.LengNinUser(txtName.Text, txtPassword.Text), frmMain.mMain.AllDataBase.LocalData);
                All.Window.MessageBox.Show(this, string.Format("当前用户【{0}】已成功添加到数据库", txtName.Text), "用户添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                All.Window.MessageBox.Show(this, string.Format("当前用户【{0}】添加数据库失败,失败原因请查看故障文件", txtName.Text), "用户添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
