using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeTest.Extend;

namespace AttributeTest
{
    [Custom("aaa", Description = "sfsdf", Remark = "fsafas")]
    public class StudentVip:Student
    {
        [LongAttribute(10000,999999999,Name ="QQ")]
        public int QQ { get; set; }

    }
}
