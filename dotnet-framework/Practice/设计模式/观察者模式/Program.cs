using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    delegate void NotifyHandler(object sender);
    class Program
    {
       
        static void Main(string[] args)
        {
            TenXun tx = new TenXunGame();
            tx.AddObserver(new Subscrib("ob1"));
            tx.AddObserver(new Subscrib("ob2"));

            tx.Notify();
            Console.ReadKey();
        }
    }

    abstract class TenXun
    {
        public event NotifyHandler Notify_Evt;
        List<IObserver> Ilist = new List<IObserver>();

        public void AddObserver(IObserver ob)
        {
            Ilist.Add(ob);
            Notify_Evt += ob.RecvMsg;
        }
        public void RemoveObserver(IObserver ob)
        {
            Ilist.Remove(ob);
        }

        public void Notify()
        {
            if (Notify_Evt!=null)
            {
                this.Notify_Evt(this);

            }
        }
    }

    class TenXunGame : TenXun
    {

    }
    interface IObserver
    {
        void RecvMsg(object sender);
    }
    class Subscrib : IObserver
    {
        public string Name { get; set; }
        public Subscrib(string name)
        {
            this.Name = name;
        }
        void IObserver.RecvMsg(object sender)
        {
            Console.WriteLine("get notify");
        }
    }
}
