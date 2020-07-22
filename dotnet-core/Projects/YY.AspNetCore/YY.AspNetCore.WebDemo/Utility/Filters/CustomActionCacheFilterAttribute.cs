using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YY.AspNetCore.WebDemo.Utility.Filters
{
    /// <summary>
    /// 浏览器 缓存，在响应头里面加--Response.Headers.Add("Cache-Control", "public,max-age=6000")
    /// </summary>
    public class CustomActionCacheFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("Cache-Control", "public,max-age=6000");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}
