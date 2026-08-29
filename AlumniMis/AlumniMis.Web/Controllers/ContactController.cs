using System.Web.Mvc;

namespace AlumniMis.Web.Controllers
{
    /// <summary>
    /// 联系控制器
    /// </summary>
    public class ContactController : BaseController
    {
        /// <summary>
        /// 联系界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }
    }
}