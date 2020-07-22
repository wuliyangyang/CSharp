using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YY.Redis.Init;
using YY.Redis.Service;

namespace MyRedis
{
    public class ServiceStackTest : ITest
    {
        public void Show()
        {
            Student student = new Student()
            {
                Id = 1,
                Age = 20,
                Name = "YY"
            };

            //using (RedisStringService stringService = new RedisStringService())
            //{
            //    stringService.Set("1", "a");
            //    Console.WriteLine($"{stringService.Get("1")}");
            //}

            //using (RedisHashService hashService = new RedisHashService())
            //{
            //    hashService.FlushAll();
            //    hashService.SetEntryInHash("student", "id", "123");
            //    hashService.SetEntryInHash("student", "name1", "yy");
            //    hashService.SetEntryInHash("student", "age", "20");

            //    var ret1 = hashService.GetAllEntriesFromHash("student");
            //    var id = hashService.GetValueFromHash("student", "id");
            //    var name1 = hashService.GetValueFromHash("student", "name1");
            //    var age = hashService.GetValueFromHash("student", "age");


            //    hashService.SetEntryInHashIfNotExists("student", "name2", "zhangsan");
            //    var ret2 = hashService.GetAllEntriesFromHash("student");
            //    var name2 = hashService.GetValueFromHash("student", "name2");

            //    Console.WriteLine($"id:{id} name1:{name1} age:{age} name2:{name2}");
            //}

            //using (RedisSetService setService = new RedisSetService())
            //{
            //service.FlushAll();//清理全部数据

            //setService.Add("advanced", "111");
            //setService.Add("advanced", "112");
            //setService.Add("advanced", "114");
            //setService.Add("advanced", "114");
            //setService.Add("advanced", "115");
            //setService.Add("advanced", "115");
            //setService.Add("advanced", "113");

            //var result = setService.GetAllItemsFromSet("advanced");

            //var random = setService.GetRandomItemFromSet("advanced");//随机获取
            //setService.GetCount("advanced");//独立的ip数
            //setService.RemoveItemFromSet("advanced", "114");
            //}


            //排序
            //using (RedisZSetService zSetService = new RedisZSetService())
            //{
            //    zSetService.FlushAll();//清理全部数据

            //    zSetService.Add("advanced", "1");
            //    zSetService.Add("advanced", "2");
            //    zSetService.Add("advanced", "5");

            //    var ret1 = zSetService.GetAll("advanced");
            //    var ret2 = zSetService.GetAllDesc("advanced");


            //    zSetService.AddItemToSortedSet("Sort", "BY", 123234);
            //    zSetService.AddItemToSortedSet("Sort", "走自己的路", 123);
            //    zSetService.AddItemToSortedSet("Sort", "redboy", 45);
            //    zSetService.AddItemToSortedSet("Sort", "大蛤蟆", 7567);
            //    zSetService.AddItemToSortedSet("Sort", "路人甲", 9879);
            //    zSetService.AddRangeToSortedSet("Sort", new List<string>() { "123", "花生", "加菲猫" }, 3232);
            //    var result3 = zSetService.GetAllWithScoresFromSortedSet("Sort");

            //}

            using (RedisListService listService = new RedisListService())
            {
                listService.FlushAll();

                listService.Add("newblog", "fsdf");
                listService.Add("newblog", "fs");
                listService.Add("newblog", "fsdfsd");
                listService.Add("newblog", "fsdfs");

                var ret1 = listService.Get("newblog");
                var ret2 = listService.Get("newblog", 0, 2);
                listService.TrimList("newblog", 0, 200);  //保存list 最近的200个数据


                Task.Run(() =>
                {
                    using (RedisListService service = new RedisListService())
                    {
                        service.Subscribe("pub", (c, m, s) =>
                        {
                            Console.WriteLine($"channel:{c} message:{m}");
                            if (m == "exit")
                            {
                                s.UnSubscribeFromChannels("pub");
                            }
                        });
                    }
                });

                Task.Run(() =>
                {
                    using (RedisListService service = new RedisListService())
                    {
                        while (true)
                        {
                            service.Publish("pub", "hello world!!!");
                            Thread.Sleep(2000);
                        }
                    }
                });
                Console.ReadKey();
            }
        }
    }
}
