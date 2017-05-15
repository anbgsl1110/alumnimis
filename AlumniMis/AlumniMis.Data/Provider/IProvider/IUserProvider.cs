using System.Collections.Generic;
using AlumniMis.Data.DataTable;

namespace AlumniMis.Data.Provider.IProvider
{
    public interface IUserProvider
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        List<User> GetUserList();

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        User GetUser(long userId);
    }
}