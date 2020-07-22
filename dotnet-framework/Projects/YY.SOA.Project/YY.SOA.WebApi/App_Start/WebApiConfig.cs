using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using YY.SOA.WebApi.Controllers;

namespace YY.SOA.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.DependencyResolver = new IOCDependencyResolver(ContainerFactory.GetContainer());

            config.Filters.Add(new CustomAuthenticationFilterAttribute());
            config.Filters.Add(new CustomActionFilterAttribute());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "CustomApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
