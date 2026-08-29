using System;
using System.Collections.Generic;
using AlumniMis.Common.Util;
using AlumniMis.Data.DataTable;
using AlumniMis.Data.Provider.IProvider;
using AlumniMis.Data.Provider.Provider;
using Xunit;

namespace AlumniMis.Test.Provider
{
    public class UserProviderTest
    {
        private readonly UserProvider _provider;

        public UserProviderTest()
        {
            _provider = new UserProvider();
        }

        /// <summary>
        /// 查询数据测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void SelectTest()
        {
            var user = _provider.Select(new User(), 4);
            var users = _provider.Select(new User(), 0, 1000);
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {@"PageIndex", 1},
                {@"PageSize", 100}
            };

            var result= _provider.Select<User>(parameters);
            Assert.NotNull(result);
        }

        /// <summary>
        /// 根据Id删除用户
        /// </summary>
        [Fact]
        public void DeleteTest()
        {
            _provider.Delete(new User(), 3);
        }

        /// <summary>
        /// 插入用户数据
        /// </summary>
        [Fact]
        public void InsertTest()
        {
            var user = new User
            {
                UserName = "单元测试",
                Password = "abc123".Md5String(),
                UserType = "admin",
                UserInfoId = 3,
                IsAvailable = true,
                CreateDate = DateTime.Now
            };
            _provider.Insert(user);
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
                UserName = "测试",
                Password = "abc123".Md5String(),
                UserType = "admin",
                UserInfoId = 3,
                IsAvailable = true,
                CreateDate = DateTime.Now
            };
            _provider.Update(user);
        }
    }
}