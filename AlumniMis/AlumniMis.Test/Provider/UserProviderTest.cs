using System.Collections.Generic;
using AlumniMis.Data.DataTable;
using AlumniMis.Data.Provider.IProvider;
using AlumniMis.Data.Provider.Provider;
using Xunit;

namespace AlumniMis.Test.Provider
{
    public class UserProviderTest
    {
        private readonly IUserProvider _provider;

        public UserProviderTest()
        {
            _provider = new UserProvider();
        }

        /// <summary>
        /// 获取用户列表单元测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void GetUserList()
        {
            List<User> userList = _provider.GetUserList();
            Assert.NotNull(userList);
        }
    }
}