using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.IBLL;
using YY.IDAL;
using YY.DAL;
using YY.Model;
using System.Configuration;
using CommonLibs;
using System.Data.SqlClient;
using System.Data;

namespace YY.BLL
{
    public class UserServiceBLL : IUserServiceBLL
    {
        static string rateAssembly = ConfigurationManager.AppSettings["Rate"];
        static string huoqiRate = rateAssembly.Split(',')[0];     //活期利率
        private List<string> OpLogList = new List<string>();
        private IUserServiceDAL serviceDAL;
        public User User { get; private set; }
        public UserServiceBLL()
        {
            this.serviceDAL = new UserServiceDAL();
        }
        /// <summary>
        /// 打印信息
        /// </summary>
        /// <returns></returns>
        public int PrintUserInfo()
        {
            if (OpLogList.Count <= 0) return -1;
            LogTool logObj = new LogTool($"{ this.User.SName.Trim() }--{this.User.Account.Trim()}--{Functions.GetTimeStamp(2)}");
            foreach (string opLog in OpLogList)
            {
                logObj.log(opLog);
            }
            OpLogList.Clear();
            string baseInfo = $" 姓名:{this.User.SName.Trim()} 账号:{this.User.Account.Trim()} 余额:{this.User.Money}";
            logObj.log(baseInfo);
            return 0;
        }
        /// <summary>
        /// 查询余额
        /// </summary>
        /// <returns></returns>
        public double QueryMoney()
        {
            double money = this.User.Money;
            LogHelper.LogInfo($"余额查询，剩余:{money.ToString("0.000")}元");
            return money;//serviceDAL.QueryMoney(this.User.Account);
        }
        /// <summary>
        /// 存钱
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int SaveMoney(int count)
        {
            if (count <= 0) return -1;
            double currentMoney = QueryMoney();
            double  m = currentMoney + count;
            int ret = serviceDAL.UpdateMoney(this.User.Account, m);
            if (ret == 1) this.User.Money = m;
            string s = $"存钱{count}元,结果为:{ret}";
            LogAction(s);
            return ret;
        } 
        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int DrawMoney(int count)
        {
            if (count <= 0) return -1;
            double  currentMoney = QueryMoney();
            if (currentMoney < count) return -2;
            double m = currentMoney - count;
            int ret = serviceDAL.UpdateMoney(this.User.Account, m);
            if(ret==1) this.User.Money = m; 
            string s = $"取走{count}元,结果为:{ret}";
            LogAction(s);
            return ret;
        }
        /// <summary>
        ///假动作， 每次登陆成功，就算好利息，提交数据库更新钱的数量
        /// </summary>
        private void UpdateMoney()
        {
            DateTime now = DateTime.Now;
            DateTime lastTime = this.User.LastMoneyTime;
            double days = Functions.GetTimes(now ,lastTime)["Day"];
            this.User.Money = this.User.Money * (1 + Convert.ToDouble(huoqiRate) * days);
            serviceDAL.UpdateMoney(this.User.Account, this.User.Money);
        }
        private User GetUser(string account)
        {
            User user = new User();
            DataTable dt = serviceDAL.GetUserInfo(account);
            foreach (DataRow item in dt.Rows)
            {
                user.SId = Convert.ToInt32(item["SId"]);
                user.Account = account;
                user.PassWord = item["Pwd"].ToString();
                user.SName = item["SName"].ToString();
                user.Money = Convert.ToInt32(item["Money"]);
                user.LastMoneyTime = Convert.ToDateTime(item["LastMoneyTime"]);
            }
            return user;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string account, string pwd)
        {
            bool ret1 = serviceDAL.IsAccountExist(account);//查询账号是否存在
            if (!ret1)
            {
                LogHelper.LogInfo($"登录失败，账号:{account}不存在!!");
                return -1;
            }
            bool ret2 = serviceDAL.CheckPassWord(account, pwd);
            if (!ret2)
            {
                LogHelper.LogInfo($"登录失败，账号:{account}的密码错误!!");
                return -2;
            }
            this.User = GetUser(account);
            this.UpdateMoney();
            string s = $"姓名:{this.User.SName.Trim()},账号:{this.User.Account.Trim()}登录成功";
            LogAction(s);
            return 0;
        }
        private void LogAction(string msg)
        {
            OpLogList.Add(msg);
            LogHelper.LogInfo(msg);
        }
        public int RegisterUser(User user)
        {
            if (user.Money < 100) return -6;
            if (serviceDAL.IsAccountExist(user.Account)) return -2;
            if (string.IsNullOrWhiteSpace(user.Account)) return -3;
            if (string.IsNullOrWhiteSpace(user.PassWord)) return -4;
            if (string.IsNullOrWhiteSpace(user.SName)) return -5;
            int ret = serviceDAL.RegisterUser(user.SName, user.Account, user.PassWord, user.Money);
            if (ret == -1) LogHelper.LogError("服务器异常");
            if(ret==1) LogHelper.LogInfo($"姓名:{user.SName},账号:{user.Account},注册成功");
            return ret;
        }
    }
}
