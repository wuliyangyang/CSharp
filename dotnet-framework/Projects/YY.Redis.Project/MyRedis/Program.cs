using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRedis
{
    class Program
    {
        /// <summary>
        /// Redis 五大数据结构
        /// String、Hash、Set、ZSet、List
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("*****************RedisTest*****************");
            //ITest test = new ServiceStackTest();
            ITest test = new OverSellTest();
            //ITest test = new FriendManagerTest();
            //ITest test = new RankManagerTest();

            test.Show();

            Console.ReadKey();
        }
    }
}
