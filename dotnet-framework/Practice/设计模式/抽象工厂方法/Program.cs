using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂方法
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory fac1 = new NanChangFactory();
            AbstractFactory fac2 = new ZhuHaiFactory();

            fac1.MakeYaBo().Print();
            fac1.MakeYaJia().Print();

            fac2.MakeYaBo().Print();
            fac2.MakeYaJia().Print() ;

        }
    }


    abstract class YaBo
    {
        public abstract void Print();
    }
    abstract class YaJia
    {
        public abstract void Print();
    }

    class NanChangYaBo : YaBo
    {
        public override void Print()
        {
            Trace.WriteLine("南昌鸭脖");
        }
    }
    class NanChangYaJia : YaJia
    {
        public override void Print()
        {
            Trace.WriteLine("南昌鸭架");
        }
    }
    class ZhuHaiYaBo : YaBo
    {
        public override void Print()
        {
            Trace.WriteLine("珠海鸭脖");
        }
    }
    class ZhuHaiYaJia : YaJia
    {
        public override void Print()
        {
            Trace.WriteLine("珠海鸭架");
        }
    }

    abstract class AbstractFactory
    {
        public abstract YaBo MakeYaBo();
        public abstract YaJia MakeYaJia();

    }
    class NanChangFactory : AbstractFactory
    {
        public override YaBo MakeYaBo()
        {
            return new NanChangYaBo();
        }

        public override YaJia MakeYaJia()
        {
            return new NanChangYaJia();
        }
    }

    class ZhuHaiFactory : AbstractFactory
    {
        public override YaBo MakeYaBo()
        {
            return new ZhuHaiYaBo();
        }

        public override YaJia MakeYaJia()
        {
            return new ZhuHaiYaJia();
        }
    }

}
