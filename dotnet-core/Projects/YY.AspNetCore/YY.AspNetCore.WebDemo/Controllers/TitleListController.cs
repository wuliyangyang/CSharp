using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Mvc;
using X.PagedList;
using YY.EF.Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using YY.EF.Core.Model;
using System.Linq.Expressions;
using YY.Framework;
using Microsoft.AspNetCore.Authorization;

namespace YY.AspNetCore.WebDemo.Controllers
{
    //[Authorize]
    public class TitleListController : Controller
    {
        private int pageSize = 20;
        private IImageService _imageService = null;
        private readonly ILogger<TitleListController> _logger;
        private readonly IConfiguration _configuration;
        public TitleListController(ILogger<TitleListController> logger, IConfiguration configuration,IImageService imageService)
        {
            _logger = logger;
            _configuration = configuration;
            _imageService = imageService;
        }
        public ActionResult Index(string searchString, string group, int? pageIndex)
        {
            #region 查询条件
            //searchString = base.HttpContext.Request.Form["searchString"];
            Expression<Func<ImageTitle, bool>> funcWhere = null;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                funcWhere = funcWhere.And(c => c.ImageTitle1.Contains(searchString));
                base.ViewBag.SearchString = searchString;
            }
            if (!string.IsNullOrWhiteSpace(group))
            {
                funcWhere = funcWhere.And(c => c.ImageGroup.Contains(group));
                base.ViewBag.Group = group;
            }
            funcWhere = funcWhere.And(c => c.ImageGroup != null && c.TotalCount != null);
            #endregion

            #region 排序
            Expression<Func<ImageTitle, int>> funOrderby = c => c.Id;
            #endregion

            int index = pageIndex ?? 1;

            PageResult<ImageTitle> imageTitleList = _imageService.QueryPage(funcWhere, pageSize, index, funOrderby, true);
            StaticPagedList<ImageTitle> pageList = new StaticPagedList<ImageTitle>(imageTitleList.DataList, index, pageSize, imageTitleList.TotalCount);

            return View(pageList);
        }
        public ActionResult Delete(int? id)
        {
            int index = id ?? -1;
            _imageService.Delete<ImageTitle>(index);
            return RedirectToAction("Index");
        }
    }
}