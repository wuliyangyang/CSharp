using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator ct1 = new BMWCreatFactory();
            Creator ct2 = new GTRCreatFactory();

            Car c1 = ct1.CreatCar();
            c1.Run();
            Car c2 = ct2.CreatCar();
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
    abstract class Creator
    {
        public abstract Car CreatCar();
    }

    class BMWCreatFactory : Creator
    {
        public override Car CreatCar()
        {
            return new BMW();
        }
    }
    class GTRCreatFactory : Creator
    {
        public override Car CreatCar()
        {
            return new GTR();
        }
    }
}
