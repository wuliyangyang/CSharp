using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.WCF.Interface;
using YY.WCF.Models;
using Newtonsoft;
using System.Threading;
using System.ServiceModel;

namespace YY.WCF.Service
{
    public class WCFService : IWCFService
    {
        public void DoubleConmucation()
        {
            Thread.Sleep(2000);
            ICallBack callBack = OperationContext.Current.GetCallbackChannel<ICallBack>();
            callBack.Show("callback");
        }

        public int GetAddResult(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public User GetUser()
        {
            return new User() { Age = 18, Name = "zhangshan", Num = "1" };
        }

        public string GetUserJson()
        {
            User user = new User() { Age = 18, Name = "lisi", Num = "2" };
            string jsonStr =  Newtonsoft.Json.JsonConvert.SerializeObject(user);
            return jsonStr;
        }
    }
}
