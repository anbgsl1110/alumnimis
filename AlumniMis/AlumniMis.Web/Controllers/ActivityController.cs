using System.Web.Mvc;

namespace AlumniMis.Web.Controllers
{
    /// <summary>
    /// 校友天地控制器
    /// </summary>
    public class ActivityController : Controller
    {
        #region 活动

        /// <summary>
        /// 活动列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityList()
        {
            return View();
        }

        /// <summary>
        /// 活动详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityDetail()
        {
            return View();
        }

        /// <summary>
        /// 活动创建
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityCreate()
        {
            return View();
        }

        #endregion

        #region 话题

        /// <summary>
        /// 话题详情
        /// </summary>
        /// <returns></returns>
        public ActionResult TopicDetail()
        {
            return View();
        }

        /// <summary>
        /// 话题创建
        /// </summary>
        /// <returns></returns>
        public ActionResult TopicCreate()
        {
            return View();
        }

        #endregion

        #region 招聘

        /// <summary>
        /// 招聘列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RecruitList()
        {
            return View();
        }

        /// <summary>
        /// 招聘详情
        /// </summary>
        /// <returns></returns>
        public ActionResult RecruitDetail()
        {
            return View();
        }

        #endregion

    }
}