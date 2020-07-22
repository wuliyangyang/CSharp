using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YY.MVC5.Filter
{
    public class CustomErrorCatchAttribute: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            if (!filterContext.ExceptionHandled)//表示异常没有被别的handler处理
            {
                filterContext.ExceptionHandled = true;
                if (httpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new{ Error = filterContext.Exception.Message }
                    };
                }
                else
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
                    };
                }
            }
        }
    }
}