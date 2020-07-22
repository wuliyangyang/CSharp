using Common;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace SpiderBase
{
    public abstract class BaseSpiderUtility
    {
        Logger logger = new Logger(typeof(BaseSpiderUtility));

        public string Name { get; set; }

        public  Action<IBaseModel> GetImgSrc;

        public abstract void Parse();
        /// <summary>
        /// 传送数据对象到pipeline
        /// </summary>
        /// <param name="baseModel"></param>
        protected virtual void PostItem(IBaseModel baseModel)
        {
            GetImgSrc?.Invoke(baseModel);
        }
        /// <summary>
        /// 获取需要的节点集合
        /// </summary>
        /// <param name="url"></param>
        /// <param name="xPath"></param>
        /// <returns></returns>
        protected virtual HtmlNodeCollection GetHtmlNodes(string url, string xPath)
        {
            string html = DownHtml(url);
            if (html == null) return null;
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            //htmlNodes 图片种类
            var htmlNodes = document.DocumentNode.SelectNodes(xPath);
            return htmlNodes;
        }
        /// <summary>
        /// 下载目标页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        protected virtual string DownHtml(string url,int timeout=20000,string contentType= "text/html;charset utf-8")
        {
            string html;
            HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(url);
            httpWebRequest.Timeout = timeout;
            httpWebRequest.ContentType = contentType;
            httpWebRequest.CookieContainer = new CookieContainer();
            try
            {
                using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        //logger.Info("请求失败！！！");
                        html = null;
                        return html;
                    }
                    else
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                        {
                            html = reader.ReadToEnd();
                            reader.Close();
                            return html;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.error(ex.Message);
                html = null;
                return html;
            }
        }
    }
}
