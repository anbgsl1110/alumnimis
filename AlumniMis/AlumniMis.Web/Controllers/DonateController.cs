using System;
using System.Linq;
using System.Web.Mvc;
using AlumniMis.Data.DataTable;
using AlumniMis.Services.Service.Service;

namespace AlumniMis.Web.Controllers
{
    /// <summary>
    /// 捐赠控制器
    /// </summary>
    public class DonateController : BaseController
    {
        /// <summary>
        /// 捐赠列表界面
        /// </summary>
        /// <returns></returns>
        public ActionResult DonateList()
        {
            DonateService service = new DonateService();
            var donateListResult = service.Select(new Donate(),0,1000).Data.ToList();
            var donates = donateListResult.Where(p => p.Id > 0).Take(5).ToList();
            ViewBag.Donates = donates;
            return View();
        }

        /// <summary>
        /// 捐赠详情
        /// </summary>
        /// <returns></returns>
        public ActionResult DonateDetail(long id)
        {
            DonateService service = new DonateService();
            var donateResult = service.Select(new Donate(), id).Data;
            if (donateResult == null)
            {
                return RedirectToAction("Error");
            }
            ViewBag.Donate = donateResult;
            return View();
        }

        /// <summary>
        /// 捐赠创建界面
        /// </summary>
        /// <returns></returns>
        public ActionResult DonateCreate()
        {
            return View();
        }

        /// <summary>
        /// 创建捐赠
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateDonate(Donate donate)
        {
            donate.Dpub = DateTime.Now;

            DonateService service = new DonateService();
            var result = service.Insert(donate);

            return Json(result);
        }

        /// <summary>
        /// 删除捐赠
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteDonate(long id)
        {
            DonateService donateService = new DonateService();
            var result = donateService.Delete(new Donate(), id);

            return Json(result);
        }
    }
}