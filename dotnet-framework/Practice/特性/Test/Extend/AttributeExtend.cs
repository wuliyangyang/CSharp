using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Extend;

namespace AttributeTest.Extend
{
    public static class AttributeExtend
    {
        public static bool Validate<T>(this T t)
        {
            Type type = t.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractAttribute),true))
                {
                    object value = prop.GetValue(t);
                    object[] longAttributes = prop.GetCustomAttributes(typeof(AbstractAttribute), true);

                    foreach (AbstractAttribute att in longAttributes)
                    {
                        if (!att.Validate(value))
                        {
                            Console.WriteLine($"{att.Name} is not qualified");
                            return false;
                        }
                        Console.WriteLine($"{att.Name} is  qualified");
                    }
                }
            }
            return true;
        }
    }
}
