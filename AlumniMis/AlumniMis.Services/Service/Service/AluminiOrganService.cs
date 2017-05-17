using System.Collections.Generic;
using AlumniMis.Common.Enum;
using AlumniMis.Services.Service.IService;
using Oem.Data.ServiceModel;

namespace AlumniMis.Services.Service.Service
{
    /// <summary>
    /// 校友组织服务
    /// </summary>
    public class AluminiOrganService : BaseService,IAlumniOrganService
    {
        public ServiceResult<ServiceStateEnum, T> Select<T>(T t, long id)
        {
            var result = AlumniOrganProvider.Select(t, id);
            return new ServiceResult<ServiceStateEnum, T> {State = ServiceStateEnum.Success, Data = result};
        }

        public ServiceResult<ServiceStateEnum, IEnumerable<T>> Select<T>(T t, long pageIndex, long pageSize)
        {
            var result = AlumniOrganProvider.Select(t, pageIndex, pageSize);
            return new ServiceResult<ServiceStateEnum, IEnumerable<T>>
            {
                State = ServiceStateEnum.Success,
                Data = result
            };
        }

        public ServiceResult<ServiceStateEnum, IEnumerable<T>> Select<T>(IDictionary<string, object> parameters)
        {
            var result = AlumniOrganProvider.Select<T>(parameters);
            return new ServiceResult<ServiceStateEnum, IEnumerable<T>>
            {
                State = ServiceStateEnum.Success,
                Data = result
            };
        }

        public ServiceResult<ServiceStateEnum> Insert<T>(T t)
        {
            AlumniOrganProvider.Insert(t);
            return new ServiceResult<ServiceStateEnum>();
        }

        public ServiceResult<ServiceStateEnum> Delete<T>(T t, long id)
        {
            AlumniOrganProvider.Delete(t,id);
            return new ServiceResult<ServiceStateEnum>();
        }

        public ServiceResult<ServiceStateEnum> Update<T>(T t)
        {
            AlumniOrganProvider.Update(t);
            return new ServiceResult<ServiceStateEnum>();
        }
    }
}