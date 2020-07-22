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
    public class QueryTest
    {
        public static void Show()
        {
            using (JDDB context = new JDDB())
            {
                context.Database.Log += c => Console.WriteLine(c);
                {
                  
                    var list = context.Users.Where(c => new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10 }.Contains(c.Id));

                    foreach (var u in list)
                    {
                        Console.WriteLine(u.Name);
                    }
                }

                Console.WriteLine("******************************************************************");
                {

                    var list = from u in context.Users where new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10 }.Contains(u.Id) select u;
                    foreach (var u in list)
                    {
                        Console.WriteLine(u.Name);
                    }

                }
                Console.WriteLine("******************************************************************");
                {

                    var list0 = context.Users.Where(u => new int[] { 1, 3, 5, 7, 9, 11, 13, 16, 25, 64, 34, 42, 34, 76, 87, 89, 99, 90 }.Contains(u.Id)
                    ).OrderBy(u => u.Id).Select(u => new { Account = u.Account, Password = u.Password }).Skip(2).Take(10);

                    foreach (var u in list0)
                    {
                        Console.WriteLine(u.Account+" "+u.Password);
                    }
                    Console.WriteLine($"list0 count:{list0.Count()}");

                    var list1 = (from u in context.Users
                                 where new int[] { 1, 3, 5, 7, 9, 11, 13, 16, 25, 64, 34, 42, 34, 76, 87, 89, 99, 90 }.Contains(u.Id)
                                 orderby u.Id
                                 select new
                                 {
                                     Account = u.Account,
                                     Password = u.Password
                                 }
                              ).Skip(2).Take(10);

                    foreach (var u in list1)
                    {
                        Console.WriteLine(u.Account + " "+u.Password);
                    }
                    Console.WriteLine($"list1 count:{list1.Count()}");

                }
                {
                    var list = from u in context.Users
                               join c in context.Companies on u.Id equals c.Id
                               where new int[] { 1, 3, 5, 7, 9, 11, 13, 16, 25, 64, 34 }.Contains(u.Id)
                               select new { Name = c.Name, Account = u.Account, Password = u.Password };
                    foreach (var l in list)
                    {
                        Console.WriteLine(l.Name + " " + l.Account + " " + l.Password);
                    }         
                }

                {
                    var list1 = context.Users.Where(u => new int[] { 1, 3, 5, 7, 9, 11, 13, 16, 25, 64, 34 }.Contains(u.Id));
                    var list2 = context.Companies.Where(c => new int[] { 1, 3, 5, 7, 9, 11, 13, 16, 25, 64, 34 }.Contains(c.Id));
                       

                    foreach (var l in list2)
                    {
                        Console.WriteLine(l.Name);
                    }
                }
            }
        }
    }
}
