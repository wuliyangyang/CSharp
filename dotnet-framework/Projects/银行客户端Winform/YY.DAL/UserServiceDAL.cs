using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.IDAL;
using CommonLibs;
using System.Data;
using System.Data.SqlClient;

namespace YY.DAL
{
    public class UserServiceDAL : IUserServiceDAL
    {
        public bool CheckPassWord(string account, string pwd)
        {
            string cmd = $"select count(1) from UserInfo where Account='{account}' and Pwd='{pwd}' ";
            return DBHelper.Scalar(cmd) > 0 ? true : false;
        }

        public bool IsAccountExist(string account)
        {
            string cmd = $"select count(1) from UserInfo where Account='{account}' ";
            return DBHelper.Scalar(cmd) > 0 ? true : false;
        }

        public double QueryMoney(string account)
        {
            string cmd = $"select Money from UserInfo where Account='{account}' ";
            return DBHelper.Scalar(cmd);
        }

        public int UpdateMoney(string account, double count)
        {
            DateTime dateTime = DateTime.Now;
            SqlParameter[] sqlParameters = { new SqlParameter("@dateTime", dateTime) };
            string cmd = $" UPDATE UserInfo set [Money] = {count},LastMoneyTime=@dateTime WHERE Account='{account}' ";
            return DBHelper.ENQuery(cmd, sqlParameters);
        }

        public DataTable GetUserInfo(string account)
        {
            string cmd = $"select * from UserInfo where Account=@account";
            SqlParameter[] sqlParameters = { new SqlParameter("@account", account) };
            DataTable dataTable = DBHelper.Query(cmd, sqlParameters);
            return dataTable;
        }

        public int RegisterUser(string name, string account, string pwd, double money)
        {
            DateTime dateTime = DateTime.Now;
            SqlParameter[] sqlParameters = {
                new SqlParameter("@name", name) ,
                new SqlParameter("@account", account) ,
                new SqlParameter("@pwd", pwd) ,
                new SqlParameter("@money", money) ,
                new SqlParameter("@dateTime", dateTime) 
            };
            string cmd = $" Insert UserInfo values(@name,@account,@pwd,@money,@dateTime)";
            return DBHelper.ENQuery(cmd, sqlParameters);
        }
    }
}
