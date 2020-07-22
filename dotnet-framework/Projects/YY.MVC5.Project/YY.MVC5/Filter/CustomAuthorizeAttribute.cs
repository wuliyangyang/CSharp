using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YY.Web.Core;

namespace YY.MVC5.Filter
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        private string _LoginUrl = null;
        public CustomAuthorizeAttribute(string loginUrl = "~/Login/Login")
        {
            this._LoginUrl = loginUrl;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            if (filterContext.ActionDescriptor.IsDefined(typeof(CustomAllowAttribute),true))
            {
                return;
            }
            else if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(CustomAllowAttribute), true))
            {
                return;
            }
            else
            {
                if (httpContext.Session["CurrentUser"]!=null && httpContext.Session["CurrentUser"] is CurrentUser)
                {
                    CurrentUser currentUser = (CurrentUser)httpContext.Session["CurrentUser"];

                    return;
                }
                else
                {
                    if (httpContext.Request.IsAjaxRequest())
                    {
                        //todo return json
                        filterContext.Result = new JsonResult()
                        {
                            Data = (CurrentUser)httpContext.Session["CurrentUser"]
                        };
                    }
                    httpContext.Session["CurrentUrl"] = httpContext.Request.Url.AbsoluteUri;
                    filterContext.Result = new RedirectResult(this._LoginUrl);  //短路器：指定了Result，那么请求就截止了，不会执行action
                }
            }
        }
    }
}