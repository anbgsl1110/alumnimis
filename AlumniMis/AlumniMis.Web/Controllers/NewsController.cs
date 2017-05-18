
using System.Linq;
using System.Web.Mvc;
using AlumniMis.Data.DataTable;
using AlumniMis.Services.Service.Service;

namespace AlumniMis.Web.Controllers
{
    public class NewsController : Controller
    {
        /// <summary>
        /// 首页(新闻)
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePage()
        {
            NewReleaseService service = new NewReleaseService();
            var newsListResult = service.Select(new NewRelease(),0,1000).Data.ToList();
            var schoolNews = newsListResult.Where(p => p.Ntype.Equals("校内新闻")).Take(5).ToList();
            ViewBag.SchoolNews = schoolNews;
            var alumniNews = newsListResult.Where(p => p.Ntype.Equals("校友新闻")).Take(5).ToList();
            ViewBag.AlumniNews = alumniNews;
            return View();
        }

        /// <summary>
        /// 新闻详情
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsDetail(long id = 100)
        {
            NewReleaseService service = new NewReleaseService();
            var newsResult = service.Select(new NewRelease(), id).Data;
            if (newsResult == null)
            {
                return Redirect("/Error");
            }
            ViewBag.News = newsResult;
            return View();
        }
    }
}