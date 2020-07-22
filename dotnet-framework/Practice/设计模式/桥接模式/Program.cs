using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl rc = new ConcreteRemote();
            TV tv = new ChangHongTV();
            rc.Implementor = tv;
            rc.On();
            rc.NextChannel();
            rc.Off();
        }
    }

    abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void NextChannel();
    }

    class ChangHongTV : TV
    {
        public override void NextChannel()
        {
            Trace.WriteLine("长虹电视机换频道");
        }

        public override void Off()
        {
            Trace.WriteLine("长虹电视机关机");
        }

        public override void On()
        {
            Trace.WriteLine("长虹电视机开机");
        }
    }

    class RemoteControl
    {
        private TV implementor;
        public TV Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }

        public virtual void On()
        {
            implementor.On();
        }
        public virtual void Off()
        {
            implementor.Off();
        }
        public virtual void NextChannel()
        {
            implementor.NextChannel();
        }
    }

    class ConcreteRemote : RemoteControl
    {
        public override void NextChannel()
        {
            base.NextChannel();
        }
    }
}
