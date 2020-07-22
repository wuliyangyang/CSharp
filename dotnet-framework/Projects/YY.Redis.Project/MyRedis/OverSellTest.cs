using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Redis.Service;

namespace MyRedis
{

    /// <summary>
    /// 商品秒杀
    /// </summary>
    public class OverSellTest : ITest
    {
        public void Show()
        {
            bool IsGoOn = true;
            RedisStringService stringService = new RedisStringService();
            stringService.Set<int>("stock", 10);


            Console.WriteLine("********秒杀活动开始*******");
            for (int i = 0; i < 10000; i++)
            {
                int k = i;
                Task.Run(() =>
                {
                    if (IsGoOn)
                    {
                        long n = stringService.Decr("stock");
                        if (n >= 0)
                        {
                            Console.WriteLine($"用户{k}秒杀成功，商品编号为{n}");
                        }
                        else
                        {
                            if (IsGoOn)
                            {
                                IsGoOn = false;
                            }
                            Console.WriteLine($"用户{k},秒杀失败");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"秒杀活动结束........");
                    }
                    Task.Delay(200);
                });
            }
        }
    }
}
