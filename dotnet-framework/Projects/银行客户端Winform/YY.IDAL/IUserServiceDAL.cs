using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.IDAL
{
    public interface IUserServiceDAL
    {
        int UpdateMoney(string account, double  count);
        double  QueryMoney(string account);
        int RegisterUser(string account,string pwd,string name,double  money);
        bool IsAccountExist(string account);
        bool CheckPassWord(string account, string pwd);
        DataTable GetUserInfo(string account);
    }
}
