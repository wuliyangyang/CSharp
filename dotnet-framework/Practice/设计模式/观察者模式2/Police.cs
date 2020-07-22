using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式2
{
    class Police : IObserver
    {
        public void Shoot()
        {
            Console.WriteLine("警察开枪射击!!");
        }
    }
}
