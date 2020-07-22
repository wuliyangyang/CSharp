using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Web.Helpers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace YY.SOA.WebApi.Controllers
{
    public class CustomAuthenticationFilterAttribute: AuthorizeAttribute, IAuthorizationFilter
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetFilters().Any(t=>t is CustomAllowAnonymous))
            {
                return;
            }
            else 
            {
                var authorization = actionContext.Request.Headers.Authorization;//获取票据
                if (authorization!=null)
                {
                    if (Validate(authorization.Parameter))
                    {
                        
                        return;//校验成功
                    }
                    else
                    {
                        HandleUnauthorizedRequest(actionContext);

                    }
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);

            var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Unauthorized;
            var content = new
            {
                code = -1,
                success = false,
                errs = new[] { "服务端拒绝访问：你没有权限，或者掉线了" }
            };
            response.Content = new StringContent(Json.Encode(content), Encoding.UTF8, "application/json");
        }

        private bool Validate(string encryptString)
        {
            try
            {
                //拿到ticket解密一下，拿到用户数据，去数据库校验一下
                FormsAuthenticationTicket authentication = FormsAuthentication.Decrypt(encryptString);
                var userDate = authentication.UserData;
                var date1 = authentication.Expiration;
                var date2 = authentication.Expired;
                if (date2)
                {
                    return false;
                }

                return userDate.Equals("yy&123456");
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}