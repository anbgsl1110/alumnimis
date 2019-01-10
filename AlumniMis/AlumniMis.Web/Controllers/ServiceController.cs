using System;
using System.Web.Mvc;
using AlumniMis.Data.DataTable;
using AlumniMis.Services.Service.Service;

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

        /// <summary>
        /// 微信微博
        /// </summary>
        /// <returns></returns>
        public ActionResult WeChatWeBlog()
        {
            return View();
        }

        /// <summary>
        /// 邮箱服务
        /// </summary>
        /// <returns></returns>
        public ActionResult EmailService()
        {
            return View();
        }

        /// <summary>
        /// 母校服务请求
        /// </summary>
        /// <returns></returns>
        public ActionResult SchoolServiceRequest()
        {
            return View();
        }

        /// <summary>
        /// 请求母校服务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveRequestSchoolService(RequestService requestService)
        {
            requestService.ScreateTime = DateTime.Now;

            RequestServiceService  service = new RequestServiceService();
            var result = service.Insert(requestService);

            return Json(result);
        }
    }
}