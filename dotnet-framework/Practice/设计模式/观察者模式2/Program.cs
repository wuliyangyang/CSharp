using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式2
{
    class Program
    {
        static void Main(string[] args)
        {
            Invader Enemy = new Invader();

            Enemy.Evt_Notify += new Civilian().Run;
            Enemy.Evt_Notify += new Avengers().FaceToFace;
            Enemy.Evt_Notify += new Shield().Fire;
            Enemy.Evt_Notify += new Police().Shoot;

            Enemy.Boom();

            Console.ReadKey();
        }
    }
}
