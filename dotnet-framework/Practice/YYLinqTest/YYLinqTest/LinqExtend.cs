using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYLinqTest
{
    public static class LinqExtend
    {
        public static  List<T> Where<T>(this List<T> t, Func<T, bool> func)
        {
            List<T> ts = new List<T>();
            foreach (var item in t)
            {
                if (func.Invoke(item))
                {
                    ts.Add(item);
                }
            }
            return ts;
        }

        public static IEnumerable<T> WhereExtend<T>(this IEnumerable<T> t, Func<T, bool> func)
        {
            foreach (var item in t)
            {
                if (func.Invoke(item))
                {
                    yield return item;
                }
            }
        }
    }
}
