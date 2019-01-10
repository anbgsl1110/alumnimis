
using System;
using System.Linq;
using System.Web.Mvc;
using AlumniMis.Common.Enum;
using AlumniMis.Data.DataTable;
using AlumniMis.Services.Service.Service;

namespace AlumniMis.Web.Controllers
{
    /// <summary>
    /// 首页新闻控制器
    /// </summary>
    public class NewsController : BaseController
    {
        /// <summary>
        /// 首页(新闻)
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePage()
        {
            NewReleaseService service = new NewReleaseService();
            var newsListResult = service.Select(new NewRelease(),0,1000).Data.ToList();
            var schoolNews = newsListResult.Where(p => p.Ntype.Equals("母校新闻")).Take(5).ToList();
            ViewBag.SchoolNews = schoolNews;
            var alumniNews = newsListResult.Where(p => p.Ntype.Equals("校友新闻")).Take(5).ToList();
            ViewBag.AlumniNews = alumniNews;
            return View();
        }

        /// <summary>
        /// 新闻详情
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsDetail(long id = 0)
        {
            NewReleaseService service = new NewReleaseService();
            var newsResult = service.Select(new NewRelease(), id).Data;
            if (newsResult == null)
            {
                return RedirectToAction("Error");
            }
            ViewBag.News = newsResult;
            return View();
        }

        /// <summary>
        /// 新闻发布界面
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsPub(long id)
        {
            ViewBag.NewType = "母校新闻";
            if (id == (int)NewsTypeEnum.AlumniNews)
            {
                ViewBag.NewType = "校友新闻";
            }
            return View();
        }

        /// <summary>
        /// 创建新闻
        /// </summary>
        /// <param name="newRelease"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateNews(NewRelease newRelease)
        {
            newRelease.Ntime = DateTime.Now;

            NewReleaseService service = new NewReleaseService();
            var result = service.Insert(newRelease);

            return Json(result);
        }
    }
}