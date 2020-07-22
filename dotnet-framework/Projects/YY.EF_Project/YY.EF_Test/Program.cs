using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.EF.Interface;
using YY.EF.Framework;
using Unity;
using Unity.Configuration;
using YY.EF.Model;

namespace YY.EF_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            #region IOC
            ///配置Unity的时候 记得在Nugget引用Unity、Unity.Interception.Configuration、Unity.Interception、Unity.Configuration
            //IUnityContainer container = ContainerFactory.GetContainer();
            //using (IUserService userService = container.Resolve<IUserService>())
            //{
            //    User user6 = userService.Find<User>(6);
            //    Console.WriteLine("-----------------------------------");
            //    User user66 = userService.Find<User>(6);

            //    var list = userService.Query<User>(c =>  c.Id > 10 && c.Id < 50 ) ;//传递表达式目录树
            //    foreach (var user in list)
            //    {
            //        Console.WriteLine($"{user.Name}");
            //    }
            //}
            #endregion

            #region General
            //using (JDDB context = new JDDB())
            //{
            //    context.Database.Log += c => Console.WriteLine(c);
            //    context.Users.Find(5);
            //    Console.WriteLine("**************************");
            //    context.Users.Find(5);
            //}
            #endregion

            QueryTest.Show();
            Console.ReadKey();
        }
    }
}
