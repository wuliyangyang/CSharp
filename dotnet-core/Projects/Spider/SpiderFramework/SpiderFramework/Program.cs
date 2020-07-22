using System;
using Common;
using log4net;
using SpiderBase;

namespace SpiderFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger(typeof(Program));
            logger.Info("Hello World!");

            SpiderMan.Start();

        }
    }
}
