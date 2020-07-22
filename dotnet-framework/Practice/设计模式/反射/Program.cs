using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using MNetMQ;


namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameType = ConfigurationManager.AppSettings["SocketType"];
            string[] socketTypes = nameType.Split(',');

            Assembly ab =  Assembly.Load("MNetMQ");
            foreach (var item in ab.GetTypes())
            {
                Console.WriteLine("type: {0}",item.ToString());
               
            }

            Type t = ab.GetType(socketTypes[1]);
            //ISocket ob = (ISocket)Activator.CreateInstance(t);
            //Console.WriteLine(ob.PrintSocketType());

            Object ob = Activator.CreateInstance(t);

            Console.WriteLine("-------------get public method-------------");
            foreach (MethodInfo item in t.GetMethods())
            {
                Console.WriteLine("public method: {0}", item.Name);
            }

            Console.WriteLine("-------------get private method-------------");
            foreach (MethodInfo item in t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                Console.WriteLine("private method: {0}", item.Name);
            }

            Console.WriteLine("-------------call public method-------------");
            MethodInfo print = t.GetMethod("PrintSocketType");
            Console.WriteLine("socket type: {0}",print.Invoke(ob, null));


            Console.WriteLine("-------------call private method-------------");
            MethodInfo init = t.GetMethod("InitMembers",BindingFlags.Instance|BindingFlags.NonPublic);
            Console.WriteLine("call successfully");

            Console.WriteLine("-------------get property-------------");
            foreach ( PropertyInfo property in t.GetProperties())
            {
                Console.WriteLine("property: {0}", property.Name);
               
            }
            string ss = string.Join(",", t.GetProperties().Select(p => string.Format("[{0}]",p.Name)));
            Console.ReadKey();
        }
       
    }
}
