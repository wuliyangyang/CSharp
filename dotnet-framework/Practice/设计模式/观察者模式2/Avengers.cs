using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式2
{
    class Avengers:IObserver
    {
        public void FaceToFace()
        {
            Console.WriteLine("复仇者们刚正面！！！");
        }
    }
}
