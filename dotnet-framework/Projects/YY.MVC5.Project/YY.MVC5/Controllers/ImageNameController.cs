using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YY.EF.Interface;
using YY.EF.Service;
using YY.EF.Models;
using PagedList.Mvc;
using PagedList;
using YY.Framework;
using System.Linq.Expressions;
using YY.MVC5.Filter;

namespace YY.MVC5.Controllers
{
    [CustomAuthorize]
    public class ImageNameController : Controller
    {
        // GET: ImgaeName
        private int pageSize = 20;
        private IImageService _imageService = null;
        Logger logger = new Logger(typeof(ImageNameController));
        public ImageNameController(IImageService imageService)
        {
            logger.Info($"{typeof(ImageNameController).Name } 被构造");
            this._imageService = imageService;
        }
        public ActionResult Index(string searchString, string group,int? pageIndex)
        {
            #region 查询条件
            //searchString = base.HttpContext.Request.Form["searchString"];
            searchString = base.HttpContext.Request["searchString"];
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