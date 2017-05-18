using System.Web.Mvc;

namespace AlumniMis.Web.Controllers
{
    public class ActivityController : Controller
    {
        /// <summary>
        /// 活动列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityList()
        {
            return View();
        }
    }
}