using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Person randomPerson = new Person();
                Console.WriteLine(randomPerson.ToString());
            }

            Console.ReadKey();
        }
    }
}
