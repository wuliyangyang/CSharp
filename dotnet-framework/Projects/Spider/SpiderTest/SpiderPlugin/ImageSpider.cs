using System;
using HtmlAgilityPack;
using SpiderBase;
using Newtonsoft.Json;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Linq;
using System.Net;
using log4net;
using Common;

namespace SpiderPlugin
{
    public class ImageSpider : BaseSpiderUtility
    {
        Logger logger = new Logger(typeof(ImageSpider));
        public ImageSpider()
        {
            Name = "ImageSpider";
        }

        private static string _searchUrl = "http://www.quantuwang.co/meinv";
        private static string _baseUrl = "http://www.quantuwang.co";

        public string DownImage(string url)
        {
            try
            {
                string xPath = "//*[@class=\"c_img\"]/a/img";
                var htmlNode = GetHtmlNodes(url, xPath).FirstOrDefault();
                string imageSrc = null;
                if (htmlNode != null)
                {
                    imageSrc = htmlNode.Attributes["src"].Value;
                }
                return imageSrc;
            }
            catch (Exception ex)
            {
                logger.error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取一张页面的所有图片url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetTotalCountOfOnePage(string url)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();

            string xPath = "//*[@class=\"index_left\"]/ul/li/a";
            var htmlNodes = GetHtmlNodes(url, xPath);
            if (htmlNodes != null)
            {
                foreach (var node in htmlNodes)
                {
                    string href = node.Attributes["href"].Value;
                    string title = node.InnerText;
                    string hUrl = ImageSpider._baseUrl + href;
                    if (!keyValues.ContainsKey(title))
                    {
                        keyValues.Add(title, hUrl);
                    }
                }
            }
            return keyValues;
        }
        /// <summary>
        /// 获取一个类型图片的总页码url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private List<string> GetCategoryTotalPage(string url)
        {
            List<string> pageList = new List<string>();
            pageList.Add(url);
            string xPath = "//*[@class=\"c_page\"]/a";
            var htmlNodes = GetHtmlNodes(url, xPath);
            if (htmlNodes != null)
            {
                foreach (var node in htmlNodes)
                {
                    string href = node.Attributes["href"].Value;
                    string index = node.InnerText;
                    string hUrl = ImageSpider._baseUrl + href;
                    pageList.Add(hUrl);
                }
            }
            return pageList;
        }

        /// <summary>
        /// 获取每张图片的资源img url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private List<string> GetImagePageList(string url)
        {

            List<string> ImagePageList = new List<string>();
            ImagePageList.Add(url);
            string xPath = "//*[@class=\"c_page\"]/a";
            var htmlNodes = GetHtmlNodes(url, xPath);
            if (htmlNodes != null)
            {
                foreach (var node in htmlNodes)
                {
                    string href = node.Attributes["href"].Value;
                    string index = node.InnerText;
                    string hUrl = ImageSpider._baseUrl + href;
                    ImagePageList.Add(hUrl);
                }
            }
            return ImagePageList;

        }

        /// <summary>
        /// 解析获取item，最后记得调用  base.PostItem(item),把item传出
        /// </summary>
        public override void Parse()
        {
            try
            {
                List<Task> tasks = new List<Task>();
                string xPath = "//*[@class=\"index_top_tag\"]/ul/li/a";
                //htmlNodes 图片种类
                var htmlNodes = GetHtmlNodes(_searchUrl, xPath);
                foreach (var node in htmlNodes)//语画界 秀人网
                {
                    string h = node.OuterHtml;
                    string href = node.Attributes["href"].Value;
                    string category = node.InnerText;
                    string url = ImageSpider._baseUrl + href;
                    List<string> categoryList = new List<string>()
                    { 
                        "秀人网",
                    };
                    List<string> ctpUrlList = GetCategoryTotalPage(url);//秀人网总页数

                    foreach (var ctpUrl in ctpUrlList)
                    {
                        Dictionary<string, string> tcoopUrldic = GetTotalCountOfOnePage(ctpUrl);
                        foreach (KeyValuePair<string, string> item in tcoopUrldic)
                        {

                            string tcoopTitle = item.Key;
                            string tcoopUrl = item.Value;
                            List<string> ImgPageList = GetImagePageList(tcoopUrl);

                            foreach (var imgItem in ImgPageList)
                            {
                                ItemModel itemMode = new ItemModel() { ImgSrc = DownImage(imgItem)};
                                itemMode.Category = category;
                                itemMode.Titile = tcoopTitle;
                                base.PostItem(itemMode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.error(ex.Message);
            }
        }
        protected override string DownHtml(string url, int timeout = 20000, string contentType = "text/html;charset utf-8")
        {
            return base.DownHtml(url, timeout, contentType);
        }
        protected override HtmlNodeCollection GetHtmlNodes(string url, string xPath)
        {
            return base.GetHtmlNodes(url, xPath);
        }
    }
}
