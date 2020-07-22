using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTest
{
    class InvokeCenter
    {
        public static void ManagerStudent<T>(T  student)where T: Student
        {
            Type type = typeof(T);
            if (type.IsDefined(typeof(CustomAttribute),true))
            {
                foreach (CustomAttribute item in type.GetCustomAttributes(typeof(CustomAttribute), true))
                {
                    item.Show();
                }
                foreach (var prop in type.GetProperties())
                {
                    if (prop.IsDefined(typeof(CustomAttribute), true))
                    {
                        foreach (CustomAttribute item in prop.GetCustomAttributes(typeof(CustomAttribute), true))
                        {
                            item.Show();
                        }
                    }
                }
                foreach (var method in type.GetMethods())
                {
                    if (method.IsDefined(typeof(CustomAttribute), true))
                    {
                        foreach (CustomAttribute item in method.GetCustomAttributes(typeof(CustomAttribute), true))
                        {
                            item.Show();
                        }
                    }
                }
            }
        }
    }
}
