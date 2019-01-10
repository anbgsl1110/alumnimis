using System.Collections.Generic;
using AlumniMis.Data.Provider.IProvider;
using Dapper;

namespace AlumniMis.Data.Provider.Provider
{
    /// <summary>
    /// 用户数据服务提供类
    /// </summary>
    public class UserProvider : BaseProvider,IUserProvider
    {
        public IEnumerable<T> Select<T>(IDictionary<string, object> parameters)
        {
            using (var con = DbFactory.GetNewConnection())
            {
                return con.Query<T>("SELECT * FROM user limit 0,1000;");
            }
        }
    }
}