using System.Collections.Generic;
using AlumniMis.Common.Enum;
using AlumniMis.Services.Service.IService;
using Oem.Data.ServiceModel;

namespace AlumniMis.Services.Service.Service
{
    /// <summary>
    /// 校友信息服务
    /// </summary>
    public class AluminiInfoService : BaseService,IAluminiInfoService
    {
        public ServiceResult<ServiceStateEnum, T> Select<T>(T t, long id)
        {
            var result = AlumniInfoProvider.Select(t, id);
            return new ServiceResult<ServiceStateEnum, T> {State = ServiceStateEnum.Success, Data = result};
        }

        public ServiceResult<ServiceStateEnum, IEnumerable<T>> Select<T>(T t, long pageIndex, long pageSize)
        {
            var result = AlumniInfoProvider.Select(t, pageIndex, pageSize);
            return new ServiceResult<ServiceStateEnum, IEnumerable<T>>
            {
                State = ServiceStateEnum.Success,
                Data = result
            };
        }

        public ServiceResult<ServiceStateEnum, IEnumerable<T>> Select<T>(IDictionary<string, object> parameters)
        {
            var result = AlumniInfoProvider.Select<T>(parameters);
            return new ServiceResult<ServiceStateEnum, IEnumerable<T>>
            {
                State = ServiceStateEnum.Success,
                Data = result
            };
        }

        public ServiceResult<ServiceStateEnum> Insert<T>(T t)
        {
            AlumniInfoProvider.Insert(t);
            return new ServiceResult<ServiceStateEnum>();
        }

        public ServiceResult<ServiceStateEnum> Delete<T>(T t, long id)
        {
            AlumniInfoProvider.Delete(t,id);
            return new ServiceResult<ServiceStateEnum>();
        }

        public ServiceResult<ServiceStateEnum> Update<T>(T t)
        {
            AlumniInfoProvider.Update(t);
            return new ServiceResult<ServiceStateEnum>();
        }
    }
}