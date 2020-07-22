using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
            Console.ReadKey();
        }

        public static void Init()
        {
            try
            {
                IBootstrap bootstrap = BootstrapFactory.CreateBootstrap();
                if (!bootstrap.Initialize())
                {
                    Console.WriteLine("Failed to initialize the service!");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Ready to  Start the service!");
                var result = bootstrap.Start();

                foreach (var server in bootstrap.AppServers)
                {
                    if (server.State == ServerState.Running)
                    {
                        Console.WriteLine($"{server.Name} Running");
                    }
                    else
                    {
                        Console.WriteLine($"{server.Name} Failed to Run");
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
