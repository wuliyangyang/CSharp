using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressTreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OPExpVisitor oPExpVisitor = new OPExpVisitor();

            Expression<Func<int, int, int>> expression = (x, y) => x + y;
            Console.WriteLine(expression.Compile().Invoke(1, 2));

            oPExpVisitor.Visit(expression);

            Console.ReadKey();
        }
    }
}
