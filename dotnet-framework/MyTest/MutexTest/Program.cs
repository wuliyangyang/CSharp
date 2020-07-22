using System;
using System.Diagnostics;
using System.Threading;
namespace ThreadExample
{
    public class MutexSample
    {
        static Mutex gM1;
        static Mutex gM2;
        static Mutex gM3;
        static Mutex gM4;
        const int ITERS = 100;
        static AutoResetEvent Event1 = new AutoResetEvent(false);
        static AutoResetEvent Event2 = new AutoResetEvent(false);
        static AutoResetEvent Event3 = new AutoResetEvent(false);
        static AutoResetEvent Event4 = new AutoResetEvent(false);
        static AutoResetEvent[] evs = new AutoResetEvent[4];
        public static void Main(String[] args)
        {
            Console.WriteLine("Mutex Sample ");
            //创建一个Mutex对象，并且命名为MyMutex
            gM1 = new Mutex(true, "MyMutex");
            //创建一个未命名的Mutex 对象.
            gM2 = new Mutex(true);
            gM3 = new Mutex(true);
            gM4 = new Mutex(true);
            Console.WriteLine(" - Main Owns gM1 and gM2");
            
            evs[0] = Event1; //为后面的线程t1,t2,t3,t4定义AutoResetEvent对象
            evs[1] = Event2;
            evs[2] = Event3;
            evs[3] = Event4;
            MutexSample tm = new MutexSample();
            Thread t1 = new Thread(new ThreadStart(tm.t1Start));
            Thread t2 = new Thread(new ThreadStart(tm.t2Start));
            Thread t3 = new Thread(new ThreadStart(tm.t3Start));
            Thread t4 = new Thread(new ThreadStart(tm.t4Start));
            t1.Start();// 使用Mutex.WaitAll()方法等待一个Mutex数组中的对象全部被释放
            t2.Start();// 使用Mutex.WaitOne()方法等待gM1的释放
            t3.Start();// 使用Mutex.WaitAny()方法等待一个Mutex数组中任意一个对象被释放
            t4.Start();// 使用Mutex.WaitOne()方法等待gM2的释放
            Thread.Sleep(1000);
            Console.WriteLine(" - Main releases gM1");
            gM1.ReleaseMutex(); //线程t2,t3结束条件满足
            Thread.Sleep(1000);
            Console.WriteLine(" - Main releases gM2");
            gM2.ReleaseMutex(); //线程t1,t4结束条件满足
            Console.WriteLine(" - Main releases gM3");
            gM3.ReleaseMutex();
            Thread.Sleep(1000);
            Console.WriteLine(" - Main releases gM4");
            gM4.ReleaseMutex();

            WaitHandle.WaitAll(evs); //等待所有四个线程结束

            Console.WriteLine(" Mutex Sample");
            Console.ReadKey();
        }
        public void t1Start()
        {
            Console.WriteLine("t1Start started, Mutex.WaitAll(Mutex[])");
            Mutex[] gMs = new Mutex[2];
            gMs[0] = gM3;//创建一个Mutex数组作为Mutex.WaitAll()方法的参数
            gMs[1] = gM4;
            Mutex.WaitAll(gMs);//等待gM1和gM2都被释放
            Thread.Sleep(1000);
            Console.WriteLine("t1Start finished, Mutex.WaitAll(Mutex[]) satisfied");
            Event1.Set(); //线程结束，将Event1设置为有信号状态
        }
        public void t2Start()
        {
            Console.WriteLine("t2Start started, gM1.WaitOne( )");
            gM1.WaitOne();//等待gM1的释放
            Console.WriteLine("t2Start finished, gM1.WaitOne( ) satisfied");
            Event2.Set();//线程结束，将Event2设置为有信号状态
        }
        public void t3Start()
        {
            Console.WriteLine("t3Start started, Mutex.WaitAny(Mutex[])");
            Mutex.WaitAny(evs);//等待数组中任意一个Mutex对象被释放
            Console.WriteLine("t3Start finished, Mutex.WaitAny(Mutex[])");
            Event3.Set();//线程结束，将Event3设置为有信号状态
        }
        public void t4Start()
        {
            Console.WriteLine("t4Start started, gM2.WaitOne( )");
            gM2.WaitOne();//等待gM2被释放
            Console.WriteLine("t4Start finished, gM2.WaitOne( )");
            Event4.Set();//线程结束，将Event4设置为有信号状态
        }
    }
}