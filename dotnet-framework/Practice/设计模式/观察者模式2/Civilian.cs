using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式2
{
    class Civilian:IObserver
    {
        public void Run()
        {
            Console.WriteLine("平民逃跑避难！！！");
        }
    }
}
