using System.Web.Mvc;

namespace AlumniMis.Web.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class BaseController : Controller
    {

        /// <summary>
        /// 错误界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }
    }
}