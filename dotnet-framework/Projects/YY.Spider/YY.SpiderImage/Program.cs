using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Business.Interface;
using Unity;


namespace YY.SpiderImage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> urls = new List<string>()
            {
                @"https://www.7160.com/rentiyishu/",
                @"https://www.7160.com/zhenrenxiu/",

            };
            for (int i = 2; i <= 5; i++)
            {
                string url1 = $"https://www.7160.com/rentiyishu/list_1_{i}.html";
                string url2 = $"https://www.7160.com//zhenrenxiu/list_11_{i}.html";
                urls.Add(url1);
                urls.Add(url2);
            }

            ISpiderService spiderService = ContainerFactory.GetContainer().Resolve<ISpiderService>();
            spiderService.StartSpide(urls);

            Console.ReadKey();
        }

    }
}
