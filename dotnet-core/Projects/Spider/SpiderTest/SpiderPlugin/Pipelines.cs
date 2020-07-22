using SpiderBase;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Common;
using System.Net;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

namespace SpiderPlugin
{
    public class Pipelines : IPipelines
    {
        Logger logger = new Logger(typeof(Pipelines));
        /// <summary>
        /// Process Item
        /// </summary>
        /// <param name="model">数据模型</param>
        public void ProcessItem(IBaseModel model)
        {
            ItemModel item = model as ItemModel;//用数据时，需要转换一下

            //do something
            Task.Run(() => {
                int id = Thread.CurrentThread.ManagedThreadId;
                string jsonStr = JsonConvert.SerializeObject(item);
                logger.Info(jsonStr + $"----threadID:{id}");
                DownImage(item.ImgSrc, item.Titile, item.Category); 
            });


        }
        private static string _path = ConfigurationManager.AppSettings["Path"];
        private void DownImage(string imageSrc,  string title, string category)
        {
            try
            {
                string path1 = System.Environment.CurrentDirectory;
                string path2 = Path.Combine(path1, $"images\\全图网\\{category}\\" + title);
                if (_path != "default") path2 = _path;

                if (!Directory.Exists(path2)) Directory.CreateDirectory(path2);

                string[]  dataStr= imageSrc.Split('/');
                string imageName = dataStr[dataStr.Length-1];
                string localImagePath = path2 + $"\\{imageName}";
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(imageSrc), localImagePath);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
