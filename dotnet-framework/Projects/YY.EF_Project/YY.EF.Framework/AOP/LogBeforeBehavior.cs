using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace YY.EF.Framework
{
    public class LogBeforeBehavior : IInterceptionBehavior
    {
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine($"{input.MethodBase.Name} LogBeforeBehavior..Start.");
            foreach (var item in input.Inputs)
            {
                Console.WriteLine($"{item.GetType().Name}：{Newtonsoft.Json.JsonConvert.SerializeObject(item)}");
            }
            Console.WriteLine($"{input.MethodBase.Name} LogBeforeBehavior.. End.");
            IMethodReturn methodReturn = getNext()(input, getNext);//执行后面的全部动作
            return methodReturn;
        }
    }
}
