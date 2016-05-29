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
    public partial class frmUserLogin : All.Window.MainWindow
    {
        List<HeiFeiMideaDll.UserSet> allUsers;
        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
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
                        if (user.Use[0])
                        {
                            cbbName.Items.Add(user.Text);
                            cbbName.Text = user.Text;
                        }
                    });
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(btnLogin, new EventArgs());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == All.Class.Code.Key)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
                return;
            }
            if (allUsers != null && allUsers.Count > 0)
            {
                int tmpIndex = allUsers.FindIndex(user =>
                {
                    return user.Text == cbbName.Text && user.Word == txtPassword.Text && user.Use[0];
                });
                if (tmpIndex < 0)
                {
                    All.Window.MetroMessageBox.Show(this, "对不起，输入的用户名或密码不正确，或者没有操作电脑的权限", "登陆错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
        }
    }
}
