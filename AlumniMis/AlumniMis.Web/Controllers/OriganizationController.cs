using System.Web.Mvc;
using AlumniMis.Data.DataTable;
using AlumniMis.Services.Service.Service;

namespace AlumniMis.Web.Controllers
{
    public class OriganizationController : Controller
    {
        /// <summary>
        /// 校友组织列表
        /// </summary>
        /// <returns></returns>
        public ActionResult OriganizationList()
        {
            return View();
        }

        /// <summary>
        /// 组织详情界面
        /// </summary>
        /// <returns></returns>
        public ActionResult OriganizationDetail()
        {
            return View();
        }

        /// <summary>
        /// 组织创建界面
        /// </summary>
        /// <returns></returns>
        public ActionResult OrganizationCreate()
        {
            return View();
        }

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateOrganization(AlumniOrgan alumniOrgan)
        {
            NewReleaseService service = new NewReleaseService();
            var result = service.Insert(alumniOrgan);

            return Json(result);
        }

        /// <summary>
        /// 班级列表界面
        /// </summary>
        /// <returns></returns>
        public ActionResult ClassList()
        {
            return View();
        }
    }
}