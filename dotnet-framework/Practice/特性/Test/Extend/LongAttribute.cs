using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Extend;

namespace AttributeTest.Extend
{
    [AttributeUsage(AttributeTargets.Property)]
   public class LongAttribute: AbstractAttribute
    {
        long _min = 0;
        long _max = 0;

        public LongAttribute()
        {

        }
        public LongAttribute(long min, long max)
        {
            this._min = min;
            this._max = max;
        }
        public override bool Validate(object obj)
        {
            return obj != null && long.TryParse(obj.ToString(), out long lvalue) && lvalue > _min && lvalue < _max;
        }
    }
}
