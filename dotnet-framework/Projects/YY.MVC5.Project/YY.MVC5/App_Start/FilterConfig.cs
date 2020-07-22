using System.Web;
using System.Web.Mvc;
using YY.MVC5.Filter;

namespace YY.MVC5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomErrorCatchAttribute());
            filters.Add(new CustomAuthorizeAttribute("~/Login/Login"));
            filters.Add(new CompressActionFilterAttribute());
        }
    }
}
