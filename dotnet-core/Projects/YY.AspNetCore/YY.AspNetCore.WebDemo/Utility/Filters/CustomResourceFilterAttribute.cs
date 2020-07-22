using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YY.AspNetCore.WebDemo.Utility.Filters
{
    /// <summary>
    /// 服务器 缓存
    /// </summary>
    public class CustomResourceFilterAttribute : Attribute, IResourceFilter, IFilterMetadata
    {
        private static Dictionary<string, IActionResult> CustomCache = new Dictionary<string, IActionResult>();
        /// <summary>
        /// 发生在其他动作之前
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //if 有缓存，直接返回缓存
            string key = context.HttpContext.Request.Path;
            if (CustomCache.ContainsKey(key))
            {
                context.Result = CustomCache[key];//断路器--到Result生成了，但是Result还需要转换成Html
            }
        }
        /// <summary>
        /// 发生在其他动作之后
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //这个应该缓存起来
            string key = context.HttpContext.Request.Path;
            if (!CustomCache.ContainsKey(key))
            {
                CustomCache.Add(key, context.Result);
            }
        }
    }
}
