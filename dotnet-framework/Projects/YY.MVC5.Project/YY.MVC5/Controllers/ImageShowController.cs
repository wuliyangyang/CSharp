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
using System.Drawing;
using YY.MVC5.Filter;
using System.Net;

namespace YY.MVC5.Controllers
{
    [CustomAuthorize]
    public class ImageShowController : Controller
    {
        // GET: ImageShow
        private IImageService _imageService = null;
        Logger logger = new Logger(typeof(ImageShowController));
 
        public ImageShowController(IImageService imageService)
        {
            logger.Info($"{typeof(ImageShowController).Name } 被构造");
            this._imageService = imageService;
        }

        public ActionResult Index(string title, string group,int? pageIndex)
        {
            ActionResult actionResult = null;
            title = title.Trim();
            switch (group)
            {
                case "人体艺术":
                    actionResult = Rentiyishu(title, pageIndex);
                    break;
                case "真人秀":
                    actionResult = Zhenrenxiu(title, pageIndex);
                    break;
                case "性感美女":
                    actionResult = Xingganmeinv(title, pageIndex);
                    break;
                case "性感模特":
                    actionResult = Xingganmote(title, pageIndex);
                    break;
                default:
                    actionResult = QuanTuWang(title, pageIndex);
                    break;
            }

            return actionResult;
        }
        public ActionResult GetActionResult<T>(string title, int? pageIndex, Expression<Func<T, bool>> expression1, Expression<Func<T, int>> expression2) where T:class
        {
            logger.Info($"{typeof(ActionResult).Name } 运行。。。");
            Expression<Func<T, bool>> funcWhere = null;
            //funcWhere = funcWhere.And(c => c.Name.Equals(title));
            funcWhere = funcWhere.And(expression1);
            base.ViewBag.ImageTitle = title;
            #region 排序
            //Expression<Func<T, int>> funOrderby = c => c.Id;
            Expression<Func<T, int>> funOrderby = expression2;
            #endregion

            var imageList = _imageService.Query(funcWhere);
            int index = pageIndex ?? 1;
            int pageSize = 1;
            PageResult<T> imageTitleList = _imageService.QueryPage(funcWhere, pageSize, index, funOrderby, true);
            //Session["Image"] = imageTitleList;
            Session["Image"] = imageTitleList.DataList.First();
            StaticPagedList<T> pageList = new StaticPagedList<T>(imageTitleList.DataList, index, pageSize, imageTitleList.TotalCount);
            return View(typeof(T).Name, pageList);
        }
        public ActionResult Rentiyishu(string title,int? pageIndex)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                PageResult<Rentiyishu> iTitleList = new PageResult<Rentiyishu>();
                List<Rentiyishu> rentiyishus = new List<Rentiyishu>() { new Rentiyishu(), new Rentiyishu() };
                iTitleList.DataList = rentiyishus;
                StaticPagedList<Rentiyishu> pList = new StaticPagedList<Rentiyishu>(iTitleList.DataList, 1, 1, 2);
                return View("Rentiyishu",pList);
            }

            Expression<Func<Rentiyishu, bool>> funcWhere = null;
            funcWhere = funcWhere.And(c => c.Name.Equals(title));
            base.ViewBag.ImageTitle = title;
            #region 排序
            Expression<Func<Rentiyishu, int>> funOrderby = c => c.Id;
            #endregion

            var imageList = _imageService.Query(funcWhere);
            int index = pageIndex??1;
            int pageSize = 1;
            PageResult<Rentiyishu>  imageTitleList = _imageService.QueryPage(funcWhere, pageSize, index, funOrderby, true);
            //Session["Image"] = imageTitleList;
            Session["Image"] = imageTitleList.DataList.First().Url;
            StaticPagedList<Rentiyishu> pageList = new StaticPagedList<Rentiyishu>(imageTitleList.DataList, index, pageSize, imageTitleList.TotalCount);
            return View("Rentiyishu",pageList);
        }
        public ActionResult Zhenrenxiu(string title, int? pageIndex)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                PageResult<Zhenrenxiu> iTitleList = new PageResult<Zhenrenxiu>();
                List<Zhenrenxiu> rentiyishus = new List<Zhenrenxiu>() { new Zhenrenxiu(), new Zhenrenxiu() };
                iTitleList.DataList = rentiyishus;
                StaticPagedList<Zhenrenxiu> pList = new StaticPagedList<Zhenrenxiu>(iTitleList.DataList, 1, 1, 2);
                return View("Zhenrenxiu", pList);
            }

            Expression<Func<Zhenrenxiu, bool>> funcWhere = null;
            funcWhere = funcWhere.And(c => c.Name.Equals(title));
            base.ViewBag.ImageTitle = title;
            #region 排序
            Expression<Func<Zhenrenxiu, int>> funOrderby = c => c.Id;
            #endregion

            var imageList = _imageService.Query(funcWhere);
            int index = pageIndex ?? 1;
            int pageSize = 1;
            PageResult<Zhenrenxiu> imageTitleList = _imageService.QueryPage(funcWhere, pageSize, index, funOrderby, true);
            //Session["Image"] = imageTitleList;
            Session["Image"] = imageTitleList.DataList.First().Url;
            StaticPagedList<Zhenrenxiu> pageList = new StaticPagedList<Zhenrenxiu>(imageTitleList.DataList, index, pageSize, imageTitleList.TotalCount);
            return View("Zhenrenxiu", pageList);
        }
        public ActionResult Xingganmeinv(string title, int? pageIndex)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                PageResult<Xingganmeinv> iTitleList = new PageResult<Xingganmeinv>();
                List<Xingganmeinv> rentiyishus = new List<Xingganmeinv>() { new Xingganmeinv(), new Xingganmeinv() };
                iTitleList.DataList = rentiyishus;
                StaticPagedList<Xingganmeinv> pList = new StaticPagedList<Xingganmeinv>(iTitleList.DataList, 1, 1, 2);
                return View("Xingganmeinv", pList);
            }

            Expression<Func<Xingganmeinv, bool>> funcWhere = null;
            funcWhere = funcWhere.And(c => c.Name.Equals(title));
            base.ViewBag.ImageTitle = title;
            #region 排序
            Expression<Func<Xingganmeinv, int>> funOrderby = c => c.Id;
            #endregion

            var imageList = _imageService.Query(funcWhere);
            int index = pageIndex ?? 1;
            int pageSize = 1;
            PageResult<Xingganmeinv> imageTitleList = _imageService.QueryPage(funcWhere, pageSize, index, funOrderby, true);
            //Session["Image"] = imageTitleList;
            Session["Image"] = imageTitleList.DataList.First().BinaryData;
            StaticPagedList<Xingganmeinv> pageList = new StaticPagedList<Xingganmeinv>(imageTitleList.DataList, index, pageSize, imageTitleList.TotalCount);
            return View("Xingganmeinv", pageList);
        }
        public ActionResult Xingganmote(string title, int? pageIndex)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                PageResult<Xingganmote> iTitleList = new PageResult<Xingganmote>();
                List<Xingganmote> rentiyishus = new List<Xingganmote>() { new Xingganmote(), new Xingganmote() };
                iTitleList.DataList = rentiyishus;
                StaticPagedList<Xingganmote> pList = new StaticPagedList<Xingganmote>(iTitleList.DataList, 1, 1, 2);
                return View("Xingganmote", pList);
            }

            Expression<Func<Xingganmote, bool>> funcWhere = null;
            funcWhere = funcWhere.And(c => c.Name.Equals(title));
            base.ViewBag.ImageTitle = title;
            #region 排序
            Expression<Func<Xingganmote, int>> funOrderby = c => c.Id;
            #endregion

            var imageList = _imageService.Query(funcWhere);
            int index = pageIndex ?? 1;
            int pageSize = 1;
            PageResult<Xingganmote> imageTitleList = _imageService.QueryPage(funcWhere, pageSize, index, funOrderby, true);
            //Session["Image"] = imageTitleList;
            Session["Image"] = imageTitleList.DataList.First().BinaryData;
            StaticPagedList<Xingganmote> pageList = new StaticPagedList<Xingganmote>(imageTitleList.DataList, index, pageSize, imageTitleList.TotalCount);
            return View("Xingganmote", pageList);
        }
        public ActionResult QuanTuWang(string title, int? pageIndex)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                PageResult<QuanTuWang> iTitleList = new PageResult<QuanTuWang>();
                List<QuanTuWang> rentiyishus = new List<QuanTuWang>() { new QuanTuWang(), new QuanTuWang() };
                iTitleList.DataList = rentiyishus;
                StaticPagedList<QuanTuWang> pList = new StaticPagedList<QuanTuWang>(iTitleList.DataList, 1, 1, 2);
                return View("QuanTuWang", pList);
            }

            Expression<Func<QuanTuWang, bool>> funcWhere = null;
            funcWhere = funcWhere.And(c => c.Name.Equals(title));
            base.ViewBag.ImageTitle = title;
            #region 排序
            Expression<Func<QuanTuWang, int>> funOrderby = c => c.Id;
            #endregion

            var imageList = _imageService.Query(funcWhere);
            int index = pageIndex ?? 1;
            int pageSize = 1;
            PageResult<QuanTuWang> imageTitleList = _imageService.QueryPage(funcWhere, pageSize, index, funOrderby, true);
            //Session["Image"] = imageTitleList;
            Session["Image"] = imageTitleList.DataList.First().ImgSrc;
            ViewBag.Category = imageTitleList.DataList.First().Category;
            StaticPagedList<QuanTuWang> pageList = new StaticPagedList<QuanTuWang>(imageTitleList.DataList, index, pageSize, imageTitleList.TotalCount);
            return View("QuanTuWang", pageList);
        }
        public FileContentResult GetImage(int? pageIndex)
        {
            logger.Info($"{typeof(FileContentResult).Name } 运行。。。");
            int index = pageIndex ?? 1;
            //PageResult<Rentiyishu> imageTitleList = (PageResult<Rentiyishu>)Session["Image"];
            WebClient webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData((string)Session["Image"]);//(byte[])Session["Image"];
            webClient.Dispose();
            if (imageBytes == null)
            {
                imageBytes = ImageHelper.ImageToBinary($"{AppDomain.CurrentDomain.BaseDirectory}/Src/404-1.jpg");
                return new FileContentResult(imageBytes, "image/png");
            }
            //imageBytes = imageTitleList.DataList.First().BinaryData;
            return new FileContentResult(imageBytes, "image/png");
        }
    }
}