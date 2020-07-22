using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YY.AspNetCore.WebDemo.Utility.Filters
{

    /// <summary>
    /// 异常Filter
    /// </summary>
    public class CustomExceptionFilterAttribute: ExceptionFilterAttribute, IFilterMetadata
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger, IModelMetadataProvider modelMetadataProvider)
        {
            _logger = logger;
            _modelMetadataProvider = modelMetadataProvider;
        }

        /// <summary>
        /// 如果异常没有处理，就会进入函数
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)//判断 异常是否被处理了
            {
                if (IsAjaxRequest(context.HttpContext.Request))
                {

                    context.Result = new JsonResult(
                        new
                        {
                            Result = false,
                            Msg = context.Exception.Message,
                        });//中断式---请求到这里结束了，不再继续Action
                }
                else
                {
                    var  result = new ViewResult()
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState),
                    };
                    result.ViewData.Add("Exception", context.Exception);
                    _logger.LogError($"出异常了:{context.Exception.Message}");
                    context.Result = result;
                }
            }
        }

        private bool IsAjaxRequest(HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            return "XMLHttpRequest".Equals(header);
        }
    }
}
