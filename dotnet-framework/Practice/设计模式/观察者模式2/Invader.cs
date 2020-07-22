using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式2
{
    class Invader
    {
        public delegate void Notify();
        public event Notify Evt_Notify;
        public void Boom()
        {
            Console.WriteLine("入侵者搞爆破袭击！！！");
            if (Evt_Notify!=null)
            {
                Evt_Notify.Invoke();
            }
         
        }

        public void AddObserver(IObserver ob)
        {

        }
        public void RemoveObserver(IObserver ob)
        {

        }
    }
}
