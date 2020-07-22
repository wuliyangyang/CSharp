using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeTest.Extend;

namespace AttributeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Student studentVip = new StudentVip()
            {
                Id = 1,
                Name = "zhangsanaaaaaaaaa",
                QQ = 3123123,
            };

            if (studentVip.Validate())
            {
                Console.WriteLine("student is ok");
            }
            else
            {
                Console.WriteLine("student is not ok");
            }
            Console.ReadKey();
        }
    }
}
