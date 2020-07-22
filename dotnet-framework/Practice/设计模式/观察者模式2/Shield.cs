using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式2
{
    class Shield : IObserver
    {
        public void Fire()
        {
            Console.WriteLine("神盾局活力全开！！！");
        }
    }
}
