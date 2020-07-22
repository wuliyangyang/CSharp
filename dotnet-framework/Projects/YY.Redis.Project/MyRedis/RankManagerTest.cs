using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YY.Redis.Service;

namespace MyRedis
{

    /// <summary>
    /// 排行榜：实时刷礼物
    /// </summary>
    public class RankManagerTest : ITest
    {

        List<string> userList = new List<string>()
        { "大炮","二炮","山炮","老陆","老沈"};
        public void Show()
        {
            using (RedisZSetService zSetService = new RedisZSetService())
            {
                zSetService.FlushAll();
                foreach (var user in userList)
                {
                    zSetService.IncrementItemInSortedSet("陈一发儿", user, new Random().Next(1, 200));
                }
                Task.Run(() =>
                {
                    while (true)
                    {
                        foreach (var user in userList)
                        {
                            Thread.Sleep(300);
                            zSetService.IncrementItemInSortedSet("陈一发儿", user, new Random().Next(1, 200));
                        }
                        Thread.Sleep(3000);
                    }
                });

                Task.Run(() =>
                {
                    while (true)
                    {
                        Console.WriteLine($"**********礼物排行榜***********");
                        int i = 1;
                        IDictionary<string, double> valuePairs = zSetService.GetAllWithScoresFromSortedSet("陈一发儿");
                        foreach (var item in valuePairs)
                        {
                            Console.WriteLine($"排行的{i++} {item.Key} 分数是:{item.Value}");
                        }
                        Thread.Sleep(3000);
                    }
                });
                Console.Read();
            }
        }
    }
}
