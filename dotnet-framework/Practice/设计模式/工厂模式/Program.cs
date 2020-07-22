using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = CarFactory.CreatCar("BMW");
            c1.Run();

            Car c2 = CarFactory.CreatCar("GTR");
            c2.Run();
        }
    }

    abstract class Car
    {
        public abstract void Run();
    }

    class BMW : Car
    {
        public override void Run()
        {
            Trace.WriteLine("BMW Running...");
        }
    }
    class GTR : Car
    {
        public override void Run()
        {
            Trace.WriteLine("GTR Running...");
        }
    }


    class CarFactory
    {
        private CarFactory()
        {
        }

        public static Car CreatCar(string name)
        {
            if (Type.Equals(name,"BMW"))
            {
                return new BMW();
            }
            else if(Type.Equals(name, "GTR"))
            {
                return new GTR();
            }
            return null;
        }
    }
}
