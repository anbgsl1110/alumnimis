using System;
using System.Linq;
using System.Web.Mvc;
using AlumniMis.Common.Util;
using AlumniMis.Data.DataTable;
using AlumniMis.Services.Service.Service;
using AlumniMis.Web.Models;

namespace AlumniMis.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Reg(RegRequest req)
        {
            var alumniInfo = req.AlumniInfo;
            alumniInfo.Aenter = DateTime.Now;

            AlumniInfoService alumniInfoService = new AlumniInfoService();
            var result = alumniInfoService.InsertWithIdentity(alumniInfo);
            
            var user = req.User;
            user.CreateDate = DateTime.Now;
            user.Password = user.Password.Md5String();
            user.UserType = "Alumni";
            user.IsAvailable = true;
            user.UserInfoId = result.Data;
            UserService userService = new UserService();
            userService.Insert(user);
            
            return Json(@"注册成功");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(User user)
        {
            UserService userService = new UserService();
            var userlist = userService.Select(user, 0, 1000).Data;
            var result = userlist
                .FirstOrDefault(p => p.UserName.Equals(user.Password.Md5String()) && p.UserName.Equals(user.UserName));
            if (result != null)
            {
                Session["Current_UserId"] = result.Id;
                Session["Current_UserName"] = result.UserName;
                Session["Current_UserType"] = result.UserType;
                return Json(1);
            }
            return Json(0);
        }

        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetCurrentUser()
        {
            var userId = Session["Current_UserId"];
            if (userId != null )
            {
                UserService userService = new UserService();
                var user = userService.Select(new User(), int.Parse(userId.ToString()));
                return Json(user);
            }
            return Json(0);
        }
    }
}