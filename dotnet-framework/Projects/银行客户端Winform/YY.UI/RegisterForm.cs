using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using YY.IBLL;
using YY.Model;
using CommonLibs;

namespace YY.UI
{
    public partial class RegisterForm : DevExpress.XtraEditors.XtraForm
    {
        public event Nofity Exit_Evt;
        private IUserServiceBLL userService;
        public RegisterForm()
        {
            InitializeComponent();
            this.userService = Factory.GetServiceInstance();
        }

        private User CreateRegisterInfo()
        {
            int money = 0;
            try
            {
                money = Convert.ToInt32(this.textEditMoney.Text);
            }
            catch (Exception){}
            User user = new User()
            {
                SName = this.textEditName.Text,
                Account = this.textEditAccount.Text,
                PassWord = this.textEditPwd.Text,
                Money = money
            };
            return user;
        }

        private void ClearText()
        {
            this.textEditName.Text = "";
            this.textEditAccount.Text = "";
            this.textEditPwd.Text = "";
            this.textEditMoney.Text = "";
        }
        private void OkBtn_Click(object sender, EventArgs e)
        {
            User user = CreateRegisterInfo();
            int ret = this.userService.RegisterUser(user);
            /*
             * //ret=1/-1/-2/-3/-4/-5/-6
             * -1 服务器出问题
             * -2/-3/-4/-5/-6填写信息问题
             */
            if (ret == 1)
            {
                XtraMessageBox.Show("注册成功");
                ClearText();
            }
            else if (ret == -1)
                XtraMessageBox.Show("服务器异常");
            else
                XtraMessageBox.Show("注册失败，请检查填写的信息是否正确", "提示");

        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            DialogResult ret = XtraMessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.No) return;
            ClearText();
            if (this.Exit_Evt != null)
            {
                this.Invoke(Exit_Evt, this);
            }
        }
    }
}