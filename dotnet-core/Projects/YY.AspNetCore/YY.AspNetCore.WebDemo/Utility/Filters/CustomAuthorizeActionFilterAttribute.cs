using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YY.Framework.SessionExt;
using YY.Web.Core;

namespace YY.AspNetCore.WebDemo.Utility.Filters
{

    /// <summary>
    /// action filter 用来做权限验证
    /// </summary>
    public class CustomAuthorizeActionFilterAttribute : ActionFilterAttribute, IFilterMetadata
    {
        private readonly ILogger<CustomAuthorizeActionFilterAttribute> _logger;
        public CustomAuthorizeActionFilterAttribute(ILogger<CustomAuthorizeActionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var att = context.Filters;
            bool isAllow = att.Any(a => a is AllowAnonymousAttribute||a is CustomAllowFilterAttribute);
            if (isAllow)//判断是否允许
            {
                return;
            }
            else
            {
                CurrentUser currentUser = (CurrentUser)context.HttpContext.Session.GetObject("CurrentUser");
                if (currentUser == null)
                {
                    string currentUrl = context.HttpContext.Request.Path.Value;
                    context.HttpContext.Session.SetString("CurrentUrl", currentUrl);
                    _logger.LogInformation($"currentUrl:{currentUrl}");
                    context.Result = new RedirectResult("~/Login/Login");
                }
                else
                {
                    _logger.LogInformation($"用户{currentUser.Name}登录系统！！");
                }
            }
            //var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            //if (controllerActionDescriptor!=null)
            //{
            //    var att = controllerActionDescriptor.MethodInfo.GetCustomAttributes(true);
            //    bool isAllow = att.Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute)) || a.GetType().Equals(typeof(CustomAllowFilterAttribute)));
            //    if (isAllow)//判断是否允许
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        CurrentUser currentUser = (CurrentUser)context.HttpContext.Session.GetObject("CurrentUser");
            //        if (currentUser == null)
            //        {
            //            string currentUrl = context.HttpContext.Request.Path.Value;
            //            context.HttpContext.Session.SetString("CurrentUrl", currentUrl);
            //            _logger.LogInformation($"currentUrl:{currentUrl}");
            //            context.Result = new RedirectResult("~/Login/Login");
            //        }
            //        else
            //        {
            //            _logger.LogInformation($"用户{currentUser.Name}登录系统！！");
            //        }
            //    }
            //}

        }

        private bool IsAjaxRequest(Microsoft.AspNetCore.Http.HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            return "XMLHttpRequest".Equals(header);
        }
    }
}
