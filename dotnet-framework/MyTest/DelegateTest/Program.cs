using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DelegateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("{0:N2}", Byte.MaxValue % 100);

            Action<string> action = new Action<string>(LookBook);
            action("C#");

            Func<string> func1 = new Func<string>(BuyBook);
            Console.WriteLine(func1());

            Func<string, string> func2 = new Func<string, string>(BuyBook);
            Console.WriteLine(func2("C++"));

            Console.ReadKey();
        }

        private static void LookBook(string book)
        {
            Console.WriteLine("look:{0}", book);
        }

        private static string BuyBook()
        {
            return "buy one..";
        }
        private static string BuyBook(string book)
        {
            return string.Format("buy:{0}",book);
        }
    }
}
