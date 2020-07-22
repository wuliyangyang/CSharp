using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Redis.Service;

namespace MyRedis
{
    /// <summary>
    /// 去重，点赞
    /// </summary>
    public class FriendManagerTest : ITest
    {
        public void Show()
        {
            using(RedisSetService setService = new RedisSetService())
            {
                setService.FlushAll();

                setService.Add("YY", "1");
                setService.Add("YY", "2");
                setService.Add("YY", "3");
                setService.Add("YY", "MM");

                setService.Add("MM", "YY");
                setService.Add("MM", "3");
                setService.Add("MM", "4");

                var ret = setService.GetIntersectFromSets("YY","MM");
                foreach (var item in ret)
                {
                    Console.WriteLine($"MM YY 的交集 {item}");
                }
            }
        }
    }
}
