using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYLinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student() { Name = $"{i}a", Id = i });
            }

            List<Student> sds = students.Where(s => s.Id > 3);
            foreach (var item in sds)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("----------------------------------------");
            List<Student> sdss = students.WhereExtend(s => s.Id > 3).ToList();
            foreach (var item in sdss)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }
}
