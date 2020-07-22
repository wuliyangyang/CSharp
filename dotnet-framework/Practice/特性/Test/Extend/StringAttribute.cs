using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Extend;

namespace AttributeTest.Extend
{
    [AttributeUsage(AttributeTargets.Property)]
   public class StringAttribute: AbstractAttribute
    {
        long _min = 0;
        long _max = 0;

        public StringAttribute()
        {

        }
        public StringAttribute(long min, long max)
        {
            this._min = min;
            this._max = max;
        }

      
        public override bool Validate(object obj)
        {
            
            return obj != null && obj.ToString().Length > _min && obj.ToString().Length < _max;
        }
    }
}
