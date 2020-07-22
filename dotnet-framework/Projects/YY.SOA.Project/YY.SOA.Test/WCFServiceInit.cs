using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using YY.WCF.Interface;
using YY.WCF.Models;
using YY.WCF.Service;

namespace YY.SOA.Test
{
   public class WCFServiceInit
    {
        public static void Process()
        {
            List<ServiceHost> serviceHosts = new List<ServiceHost>()
            {
                new ServiceHost(typeof(WCFService)),
            };

            foreach (var host in serviceHosts)
            {
                host.Opening += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备打开");
                host.Opened += (s, e) => Console.WriteLine($"{host.GetType().Name} 已经正常打开");
                host.Closing += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备关闭");
                host.Closed += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备关闭");

                host.Open();
            }

            Console.Read();
            foreach (var host in serviceHosts)
            {
                host.Close();
            }

            Console.ReadKey();
        }
    }
}
