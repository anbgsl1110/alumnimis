using System.Collections.Generic;
using AlumniMis.Data.Provider.IProvider;

namespace AlumniMis.Data.Provider.Provider
{
    /// <summary>
    /// 捐赠数据服务提供类
    /// </summary>
    public class DonateProvider : BaseProvider,IDonateProvider
    {
        public IEnumerable<T> Select<T>(IDictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}