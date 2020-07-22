using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new IPhone();
            Decorator d1 = new Sticker(phone);
            d1.Print();

            Decorator d2 = new Accessories(phone);
            d2.Print();

            Console.WriteLine("----------------------------------------");

            Sticker s = new Sticker(phone);
            Accessories a = new Accessories(s);
            a.Print();
            
            Console.ReadKey();
        }
    }

    abstract class Phone
    {
        public abstract void Print();
    }

    class IPhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("苹果手机开始。。。");
        }
    }

    abstract class Decorator : Phone
    {
        private Phone phone;
        public Decorator(Phone p)
        {
            this.phone = p;
        }

        public override void Print()
        {
            phone.Print();
        }
    }

    class Sticker : Decorator
    {
        public Sticker(Phone p) : base(p)
        {
        }

        public override void Print()
        {
            base.Print();
            NewAction();
        }

        public void NewAction()
        {
            Console.WriteLine("添加新的行为贴膜");
        }
    }
    class Accessories : Decorator
    {
        public Accessories(Phone p) : base(p)
        {
        }

        public override void Print()
        {
            base.Print();
            NewAction();
        }

        public void NewAction()
        {
            Console.WriteLine("添加新的行为挂饰");
        }
    }

}
