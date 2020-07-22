using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using log4net;
using YY.EF.Framework;

namespace YY.Business.Service
{
    public class HttpHelper
    {
        private static LogHelper logger = new LogHelper(typeof(HttpHelper));

        public static Action<string,string,string> DownLoadFinish;
        public static Action<string> DownLoadAllFinish;
        private static string url;
        private static string _path = ConfigurationManager.AppSettings["path"];
        public static void DownImage(string url, int index, string pageNum, string title)
        {
            try
            {
                string html = DownHtml(url);
                string xPath = "//*[@class=\"picsbox picsboxcenter\"]/p/a/img";
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);
                var htmlNode = document.DocumentNode.SelectSingleNode(xPath);
                if (htmlNode != null)
                {
                    string imagePath = htmlNode.Attributes["src"].Value;
                    string path1 = System.Environment.CurrentDirectory;
                    string path2 = Path.Combine(path1, "images\\" + title);
                    if (_path != "default")
                    {
                        path2 = _path;
                    }
                    if (!Directory.Exists(path2))
                    {
                        Directory.CreateDirectory(path2);
                    }

                    string localImagePath = path2 + $"\\{index}.png";
                    using (WebClient client = new WebClient())
                    {
                      
                        client.DownloadFile(new Uri(imagePath), localImagePath);
                        DownLoadFinish?.Invoke(title, imagePath, localImagePath);
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }

        public static void SpiderHtmlImage(string url, string PageNum, string title)
        {
            try
            {
                //string xPath = "//*[@class=\"jin-img\"]/ul/li/a/img";
                string html = DownHtml(url);
                string xPath = "//*[@class=\"itempage\"]/a";
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);
                var htmlNodes = document.DocumentNode.SelectNodes(xPath);
                if (htmlNodes != null)
                {
                    string s = htmlNodes[0].InnerText;
                    s = s.Replace("共", "");
                    s = s.Replace("页:", "");
                    int count = int.Parse(s);


                    for (int i = 1; i <= count; i++)
                    {
                        string htmlTail = i == 1 ? $"index.html" : $"index_{i}.html";
                        string urlNew;
                        if (HttpHelper.url.Contains(PageNum))
                            urlNew = HttpHelper.url + htmlTail;
                        else
                            urlNew = HttpHelper.url + $"{ PageNum}/" + htmlTail;
                        
                        DownImage(urlNew, i, PageNum, title);
                    }
                    DownLoadAllFinish?.Invoke(title);
                }
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        public static void AnalysisHtml(string html)
        {
            try
            {
                List<Task> tasks = new List<Task>();
                string xPath = "//*[@class=\"new-img\"]/ul/li/a";
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);
                var htmlNodes = document.DocumentNode.SelectNodes(xPath);
                foreach (var node in htmlNodes)
                {
                    string h = node.OuterHtml;
                    string href = node.Attributes["href"].Value;
                    string title = node.Attributes["title"].Value;
                    string[] ss = href.Split('/');
                    string url = HttpHelper.url + ss[2] + @"/";
                    // Console.WriteLine(h);

                    Task task = Task.Run(() =>
                    {
                        SpiderHtmlImage(url, ss[2], title);
                    });
                    tasks.Add(task);
                }
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
            }
        }
        public static string DownHtml(string url)
        {
            if (string.IsNullOrWhiteSpace(HttpHelper.url))
            {
                HttpHelper.url = url;
            }
            string html;
            HttpWebRequest httpWebRequest = HttpWebRequest.CreateHttp(url);
            httpWebRequest.Timeout = 30000;
            httpWebRequest.ContentType = "text/html;charset gb2312";
            httpWebRequest.CookieContainer = new CookieContainer();
            try
            {
                using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        logger.Info("请求失败！！！");
                        html = null;
                        return html;
                    }
                    else
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312")))
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
                logger.Info(ex.Message);
                html = null;
                return html;
            }
        }
    }
}
