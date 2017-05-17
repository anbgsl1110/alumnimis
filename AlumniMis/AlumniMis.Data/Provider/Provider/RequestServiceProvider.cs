using System.Collections.Generic;
using AlumniMis.Data.Provider.IProvider;

namespace AlumniMis.Data.Provider.Provider
{
    /// <summary>
    /// 请求服务数据服务提供接口
    /// </summary>
    public class RequestServiceProvider : BaseProvider,IRequestServiceProvider
    {
        public IEnumerable<T> Select<T>(IDictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}