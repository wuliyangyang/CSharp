using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.EF.Models;
using System.Diagnostics;
using YY.EF.Framework;
using YY.Business.Interface;
using YY.EF.Interface;
using YY.EF.Service;

namespace YY.Business.Service
{
    public class SpiderService:ISpiderService
    {
        private static object obj_dn = new object();
        private static object obj_da = new object();

        private static LogHelper logger = new LogHelper(typeof(SpiderService));
        private IImageService ImageService = null;
        public SpiderService(IImageService imageService)
        {
            //ImageService imageService = new ImageService(new MMContext());
            this.ImageService = imageService;
            HttpHelper.DownLoadFinish += ImageDownloadFinish;
            HttpHelper.DownLoadAllFinish += ImageDownloadAllFinish;
        }

        public void StartSpide(List<string> urls)
        {
            List<Task> tasks = new List<Task>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var url in urls)
            {
                string html = HttpHelper.DownHtml(url);
                HttpHelper.AnalysisHtml(html);
                Console.WriteLine("*********************************");
            }

        }
        private void ImageDownloadFinish(string name, string url, string file)
        {
            try
            {
                lock (obj_dn)
                {
                    Guid guid = Guid.NewGuid();
                    byte[] imageBytes = ImageHelper.ImageToBinary(file);

                    Image_001 image = new Image_001()
                    {
                        Name = name,
                        ImageId = guid.ToString(),
                        Url = url,
                        BinaryData = imageBytes
                    };
                    var ret = ImageService.Query<Image_001>(c => c.Url.Equals(url));
                    if (ret.Count() <= 0)
                        ImageService.Insert<Image_001>(image);
                    else
                        logger.Info($"{url} already in  DataBase!!!");

                    logger.Info($"{url} download finish!!!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
         
        }
        private void ImageDownloadAllFinish(string title)
        {
            try
            {
                lock (obj_da)
                {
                    ImageTitle imageTitle = new ImageTitle()
                    {
                        ImageTitle1 = title,
                        CreatTime = DateTime.Now
                    };
                    var ret = ImageService.Query<ImageTitle>(c => c.ImageTitle1.Equals(title));
                    if (ret.Count() <= 0)
                        ImageService.Insert<ImageTitle>(imageTitle);
                    else
                        logger.Info($"{title} already in  DataBase!!!");

                    logger.Info($"{title} download all finish!!!");
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
            
        }
    }
}
