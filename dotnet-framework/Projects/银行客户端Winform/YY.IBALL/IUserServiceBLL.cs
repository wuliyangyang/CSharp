using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Model;

namespace YY.IBLL
{
    public interface IUserServiceBLL
    {
        int SaveMoney(int count);
        int DrawMoney(int count);
        double  QueryMoney();
        int PrintUserInfo();
        int Login(string account, string pwd);
        int RegisterUser(User user);
    }
}
