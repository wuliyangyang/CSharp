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
using DevExpress.LookAndFeel;
using DevExpress.XtraWaitForm;
using YY.Model;
using YY.IBLL;
using System.Threading;
using CommonLibs;

namespace YY.UI
{
    public partial class UserOPForm : DevExpress.XtraEditors.XtraForm
    {
        public event Nofity Exit_Evt;

        private IUserServiceBLL userService;

        public UserOPForm(IUserServiceBLL userService)
        {
            InitializeComponent();
            // this.CloseBox = false;
            this.userService = userService;

        }
        #region Button Click
        //取钱按钮
        private void DrawBtn_Click(object sender, EventArgs e)
        {
            MoneyOP(sender);
            this.groupControl3.Hide();
        }
        //存钱按钮
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            MoneyOP(sender);
            this.groupControl3.Show();
        }
        private void MoneyOP(object sender)
        {
            this.groupControl2.Show();
            SimpleButton btn = sender as SimpleButton;
            this.actionLabel.Text = btn.Text;
        }
        //查询按钮
        private void QueryBtn_Click(object sender, EventArgs e)
        {
            this.groupControl2.Hide();
            double  menoy = this.userService.QueryMoney();
            XtraMessageBox.Show($"余额：{menoy.ToString("0.000")}元");
        }
        //打印按钮
        private void PrintBtn_Click(object sender, EventArgs e)
        {
            //隐藏右边界面
            this.groupControl2.Hide();
            int ret = userService.PrintUserInfo();
            if(ret==0)XtraMessageBox.Show("打印成功");
            else XtraMessageBox.Show("没有存款和取款记录，打印失败");
        }
        //确认按钮
        private void OKBtn_Click(object sender, EventArgs e)
        {
            int ret;
            int money = 0;
            try
            {
                money = Convert.ToInt32(this.textEditMoney.Text);
            }
            catch (Exception)
            {
            }
            switch (this.actionLabel.Text)
            {
                case "取款":
                    ret = this.userService.DrawMoney(money);
                    if (ret == 1) XtraMessageBox.Show("取款成功");
                    else if (ret == -1) XtraMessageBox.Show($"请输入正确的金额");
                    else if (ret == -2) XtraMessageBox.Show($"您最多只能取走{this.userService.QueryMoney()}元");
                    break;
                case "存款":
                    ret = this.userService.SaveMoney(money);
                    if (ret == 1) XtraMessageBox.Show("存款成功");
                    else if (ret == -1) XtraMessageBox.Show($"请输入正确的金额");
                    break;
                default:
                    break;
            }
            this.textEditMoney.Text = "";
            this.PrintBtn.Enabled = true;

        }
        //退出按钮
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            IsExitOrNot();
        }
        private void IsExitOrNot()
        {
            DialogResult ret = XtraMessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.No) return;
            if (this.Exit_Evt != null)
            {
                this.Invoke(Exit_Evt, this);
            }
            LogHelper.LogInfo("退出系统");
            LogHelper.LogInfo("---------------------------------------------------------------");
        }
        #endregion

        #region Form Eevnt
        private void UserOPForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            IsExitOrNot();
        }
        private void UserOPForm_Load(object sender, EventArgs e)
        {
            this.groupControl2.Hide();  //隐藏右边界面
            this.progressPanel1.Hide();
            this.labelName.Hide();
            this.PrintBtn.Enabled = false;
            this.labelTime.Text = CommonLibs.Functions.GetTimeStamp();
            this.timer1.Start();
        }
        #endregion

        #region Timer Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                this.labelTime.Text = CommonLibs.Functions.GetTimeStamp();
            }));
        }
        #endregion
    }
}