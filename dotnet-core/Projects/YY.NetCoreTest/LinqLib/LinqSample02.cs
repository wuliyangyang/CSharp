using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLib
{
    public class LinqSample02
    {

        public static void Run()
        {
            var customers = new List<Customer>()
            {
                new Customer(){Age=18,Name="张三",Visiable=false },
                new Customer(){Age=28,Name="李四", },
                new Customer(){Age=38,Name="王五",},
            };

            var ret = customers.Where(a => a.Age>10);
            foreach (var item in ret)
            {
                Console.WriteLine(item.Age);
            }
        }

      
    }


    public static class LinqSample02Extend
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> func) where TSource : IVisiable
        {
            return Enumerable.Where(sources, item => item.Visiable == true && func(item));
        }
    }

    public interface IVisiable
    {
        bool Visiable { get; }
    }

    public class Customer : IVisiable
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public bool Visiable { get; set; }

        public Customer()
        {
            Visiable = true;
        }
    }
}
