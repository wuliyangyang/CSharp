using DesignMode2.Composite;
using DesignMode2.Prototype;
using DesignMode2.Prototype.Downloads;
using System;

namespace DesignMode2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region 1、原型模式
            {
                /*实例：使用原型模式来数据库下载视频
                 * 1.Video角色
                 * 2.VideoCache角色
                 * 3.IDownload下载解决
                 * 4.实现ICloneable接口
                 */

                //Video video1 = VideoCache.GetVideo("1");
                //Video video2 = VideoCache.GetVideo("1");

                //IDownload redDownload = new RedWaterDownload();
                //redDownload.DownloadVideo(video1);
                //Console.WriteLine($"Watermark:{video1.Watermark}");

                //IDownload greenDownload = new GreenWaterDownload();
                //greenDownload.DownloadVideo(video2);
                //Console.WriteLine($"Watermark:{video2.Watermark}");

            }
            #endregion

            #region 2、组合模式
            {
                //一个类 ，自我关联

                //Employee CEO = new Employee("Rich", "CEO", 30000);
                //Employee mP1 = new Employee("Jack", "PM", 20000);
                //Employee mP2 = new Employee("Duke", "PM", 20000);

                //Employee sw = new Employee("haha", "sw", 10000);

                //CEO.AddEmployee(mP1);
                //CEO.AddEmployee(mP2);

                //mP1.AddEmployee(sw);
            }
            #endregion
        }
    }
}
