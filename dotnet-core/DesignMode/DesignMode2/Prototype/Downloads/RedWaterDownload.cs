using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode2.Prototype.Downloads
{
    public class RedWaterDownload : IDownload
    {
        public void DownloadVideo(Video video)
        {
            video.Watermark = "RedWater";
            Console.WriteLine($"{this.GetType().Name}");
        }
    }
}
