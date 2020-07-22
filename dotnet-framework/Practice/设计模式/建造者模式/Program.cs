using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Director d = new Director();
            B1 b1 = new B1();
            d.Constract(b1).GetComputer().Show(); ;
   
        }
    }

    class Director
    {
        public Builder Constract(Builder b)
        {
            b.BuildCPU();
            b.BuildMainBorad();
            return b;
        }
    }
    abstract class Builder
    {
        public abstract void BuildCPU();
        public abstract void BuildMainBorad();
        public abstract Computer GetComputer();
    }

    class B1 : Builder
    {
        Computer C = new Computer();
        public override void BuildCPU()
        {
            C.AddParts("CUP");
        }

        public override void BuildMainBorad()
        {
            C.AddParts("MainBoard");
        }

        public override Computer GetComputer()
        {
            return C;
        }
    }
    class Computer
    {
        List<string> list = new List<string>();

        public void AddParts(string part)
        {
            list.Add(part);
        }

        public void Show()
        {
            Trace.WriteLine("开始组装...");
            foreach (var part in list)
            {
                Trace.WriteLine(part + "组装完成...");
            }
            Trace.WriteLine("完成组装...");
        }
    }
}
