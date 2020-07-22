using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace YY.MVC5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //set �Լ��Ŀ�����
            ControllerBuilder.Current.SetControllerFactory(new YYControllerFactory());
        }

        //����ȫ���쳣�������쳣���ͻ���
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Server.ClearError();
            
            //����Ҳ����ֱ�ӷ�����ͼ
            //Response.Redirect("");
            //Context.RewritePath("");
        }
    }
}
