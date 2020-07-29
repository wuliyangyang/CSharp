using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode2.Prototype.Downloads
{
    public class GreenWaterDownload : IDownload
    {
        public void DownloadVideo(Video video)
        {
            video.Watermark = "GreenWater";
            Console.WriteLine($"{this.GetType().Name}");
        }
    }
}
