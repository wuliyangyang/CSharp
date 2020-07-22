using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CommonLibs;
using YY.IBLL;

namespace YY.UI
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        IUserServiceBLL serviceBLL = Factory.GetServiceInstance();
        UserOPForm oPForm;
        RegisterForm registerForm;
        public LoginForm()
        {
            InitializeComponent();
            oPForm = new UserOPForm(serviceBLL);
            oPForm.Exit_Evt += Exit_Evt;

            registerForm = new RegisterForm();
            registerForm.Exit_Evt += Exit_Evt;
        }

        private void Exit_Evt(object obj)
        {
            if (obj is UserOPForm)
            {
                oPForm.Hide();
                this.Show();
            }
            else if (obj is RegisterForm)
            {
                registerForm.Hide();
                this.Show();
            }


        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string account = this.comboEditAccount.Text.Trim();
            string pwd = this.textEditPwd.Text.Trim();
            int ret = serviceBLL.Login(account, pwd);
            if (ret == 0)//登录成功
            {
                LogHelper.LogInfo("---------------------------------------------------------------");
                if (!this.comboEditAccount.Items.Contains(account)) this.comboEditAccount.Items.Add(account);
                oPForm.Show();
                this.Hide();
            }
            else if (ret == -1) XtraMessageBox.Show("账号不存在");
            else if (ret == -2) XtraMessageBox.Show("密码错误");

        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerForm.Show();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult ret = XtraMessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.No) return;
            LogHelper.LogInfo("关闭软件");
            LogHelper.LogInfo("******************************************");
            e.Cancel = false;
        }
    }
}
