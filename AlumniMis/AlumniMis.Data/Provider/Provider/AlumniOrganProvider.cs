using System.Collections.Generic;
using AlumniMis.Data.Provider.IProvider;

namespace AlumniMis.Data.Provider.Provider
{
    /// <summary>
    /// 校友组织数据服务提供类
    /// </summary>
    public class AlumniOrganProvider : BaseProvider,IAlumniOrganProvider
    {
        public IEnumerable<T> Select<T>(IDictionary<string, object> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}