using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeTest.Extend;

namespace AttributeTest
{
   
    public class Student
    {
        public int Id { get; set; }
        [String(0,10,Name ="名字")]
        public string Name { get; set; }

        [Custom("aaa", Description = "sfsdf", Remark = "fsafas")]
        public void Study()
        {
            Console.WriteLine("study...");
        }
    }
}
