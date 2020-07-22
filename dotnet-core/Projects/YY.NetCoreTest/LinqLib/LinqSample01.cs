using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLib
{
    public class LinqSample01
    {
        public static void Run()
        {
            Stock stock = new Stock() { Name = "stock dome" };
            stock.Quotes = new List<Quote>()
            {
                new Quote(){ Stock = stock,Price=200,DateTime=DateTime.Parse("2020/06/09")},
                new Quote(){ Stock = stock,Price=180,DateTime=DateTime.Parse("2020/05/09")},
                new Quote(){ Stock = stock,Price=130,DateTime=DateTime.Parse("2020/04/09")},
                new Quote(){ Stock = stock,Price=150,DateTime=DateTime.Parse("2020/03/09")},
                new Quote(){ Stock = stock,Price=100,DateTime=DateTime.Parse("2020/09/09")},
            };
            Console.WriteLine($"stock :{stock}");

            //可读性不好，不推荐使用
            //var quote = stock.Quotes.Aggregate((t, s) => t.Price < s.Price ? t : s);

            //var quote = stock.Quotes.GetMin();
            var quote = stock.Quotes.GetMinItem(p => p.DateTime);
            Console.WriteLine(quote.Price);


        }
    }

    public static class LinqSampleExtend
    {
        public static Quote GetMin(this IEnumerable<Quote> quotes)
        {
            return quotes.Aggregate((t, s) => t.Price < s.Price ? t : s);
        }

        //扩展Aggregate，传入表达式，进行比较
        public static TSource GetMinItem<TSource,TCompareValue>(this IEnumerable<TSource> sources,
            Func<TSource,TCompareValue> compareFunc)
        {
            var comparer = Comparer<TCompareValue>.Default;
            return sources.Aggregate((minValue,itemValue)=>
            {
                var ret = comparer.Compare(compareFunc(minValue), compareFunc(itemValue));
                return ret < 0 ? minValue: itemValue;
            });
        }
    }

    public class Quote
    {
        public Stock Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class Stock
    {
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        public override string ToString()
        {
            return $"{Name} Min:{Quotes.Min(p => p.Price)} -- Max:{Quotes.Max(p => p.Price)}";
        }
    }
}
