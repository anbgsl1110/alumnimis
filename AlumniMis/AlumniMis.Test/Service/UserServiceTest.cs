using System;
using System.Collections.Generic;
using AlumniMis.Common.Util;
using AlumniMis.Data.DataTable;
using AlumniMis.Services.Service.Service;
using Xunit;

namespace AlumniMis.Test.Service
{
    /// <summary>
    /// 用户服务单元测试
    /// </summary>
    public class UserServiceTest
    {
        private readonly UserService _service;

        public UserServiceTest()
        {
            _service = new UserService();
        }

        /// <summary>
        /// 查询数据测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void SelectTest()
        {
            var user = _service.Select(new User(), 4);
            var users = _service.Select(new User(), 0, 1000);
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {@"PageIndex", 1},
                {@"PageSize", 100}
            };

            var result= _service.Select<User>(parameters);
            Assert.NotNull(result);
        }

        /// <summary>
        /// 根据Id删除用户
        /// </summary>
        [Fact]
        public void DeleteTest()
        {
            var result = _service.Delete(new User(), 3);
        }

        /// <summary>
        /// 插入用户数据
        /// </summary>
        [Fact]
        public void InsertTest()
        {
            var user = new User
            {
                UserName = "service测试",
                Password = "abc123".Md5String(),
                UserType = "admin",
                UserInfoId = 3,
                IsAvailable = true,
                CreateDate = DateTime.Now
            };
            var result = _service.Insert(user);
        }

        /// <summary>
        /// 更新数据测试
        /// </summary>
        [Fact]
        public void UpdateTest()
        {
            var user = new User
            {
                Id = 5,
                UserName = "service测试",
                Password = "abc123".Md5String(),
                UserType = "admin",
                UserInfoId = 3,
                IsAvailable = true,
                CreateDate = DateTime.Now
            };
            var result = _service.Update(user);
        }
    }
}