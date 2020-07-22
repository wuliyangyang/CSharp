using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmDoor
{
    class ADoor : Door, IAlarm
    {
        public void Alarming()
        {
            Console.WriteLine("Alarming");
        }

        public override void Close()
        {
            Console.WriteLine("door close");
        }

        public override void Open()
        {
            Console.WriteLine("door open");
        }
    }
}
