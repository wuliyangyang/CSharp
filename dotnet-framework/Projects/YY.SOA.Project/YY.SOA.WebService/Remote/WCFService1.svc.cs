using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using YY.SOA.WebService.Models;

namespace YY.SOA.WebService.Remote
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“WCFService1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 WCFService1.svc 或 WCFService1.svc.cs，然后开始调试。
    public class WCFService1 : IWCFService1
    {
        public void DoWork()
        {
            Console.WriteLine("do work");
        }

        public User GetUser()
        {
            User user = new User()
            {
                Age = 18,
                Name = "zhangsan",
                MobileNumber = "1234567891011"
            };
        return user;
        }
    }
}
