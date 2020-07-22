using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YY.MVC5.Filter
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {

        //执行action之前，执行此方法，可以过滤一下信息
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        //执行action之后，执行此方法
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //允许跨域
            filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            base.OnActionExecuted(filterContext);
        }
    }
}