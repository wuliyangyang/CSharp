using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using YY.WCF.Models;

namespace YY.WCF.Interface
{

    //http 不支持双工 tcp可以
    [ServiceContract(CallbackContract =typeof(ICallBack))]
    public interface IWCFService
    {
        [OperationContract]
        User GetUser();
        [OperationContract]
        string GetUserJson();
        [OperationContract]
        int GetAddResult(int a,int b);
        [OperationContract(IsOneWay =true)]
        void DoubleConmucation();
    }
}
