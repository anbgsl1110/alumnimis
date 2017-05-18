using System.Web.Mvc;

namespace AlumniMis.Web.Controllers
{
    /// <summary>
    /// 服务相关控制器
    /// </summary>
    public class ServiceController : Controller
    {
        /// <summary>
        /// 校园卡服务界面
        /// </summary>
        /// <returns></returns>
        public ActionResult CardService()
        {
            return View();
        }
    }
}