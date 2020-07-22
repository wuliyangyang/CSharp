using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YY.MVC5.Filter
{
    public class CompressActionFilterAttribute:ActionFilterAttribute
    {

        //执行action之前，执行此方法，可以过滤一下信息
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //foreach (var item in filterContext.ActionParameters)
            //{
            //    //参数检测  敏感词过滤
            //}  

            var httpResponse = filterContext.HttpContext.Response;
            var httpRequest = filterContext.HttpContext.Request;
            string acceptEncoding = httpRequest.Headers["Accept-Encoding"];
            if (!string.IsNullOrWhiteSpace(acceptEncoding) && acceptEncoding.ToUpper().Contains("GZIP"))
            {
                httpResponse.AddHeader("Content-Encoding", "gzip"); //响应头指定类型
                httpResponse.Filter = new GZipStream(httpResponse.Filter, CompressionMode.Compress);//响应头压缩类型
            }
        }

        //执行action之后，执行此方法
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}