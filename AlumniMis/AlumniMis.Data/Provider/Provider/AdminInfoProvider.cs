using System.Collections.Generic;
using AlumniMis.Data.Provider.IProvider;

namespace AlumniMis.Data.Provider.Provider
{
    /// <summary>
    /// 管理员信息数据服务提供类
    /// </summary>
    public class AdminInfoProvider : BaseProvider,IAdminInfoProvider
    {
        public IEnumerable<T> Select<T>(IDictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}