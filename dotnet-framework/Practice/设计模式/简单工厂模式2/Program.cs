using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MNetMQ;

namespace 简单工厂模式2
{
    class Program 
    {
        static void Main(string[] args)
        {
           ISocket socket = (ISocket)SingleObj.GetInstance().FactoryCreat();
          
           Console.WriteLine(socket.PrintSocketType());
           Console.ReadKey();
        }
    }
}
