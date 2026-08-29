using System;

namespace AlumniMis.Data.DataTable
{
    /// <summary>
    /// 校友服务
    /// </summary>
    public class RequestService
    {
        /// <summary>
        /// 校友服务Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 服务编号
        /// </summary>
        public string Snum { get; set; }

        /// <summary>
        /// 服务类型
        /// </summary>
        public string Sname { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Sres { get; set; }

        /// <summary>
        /// 负责人电话号码
        /// </summary>
        public string Stel { get; set; }

        /// <summary>
        /// 申请服务时间
        /// </summary>
        public DateTime SserviceDate { get; set; }

        /// <summary>
        /// 服务申请创建时间
        /// </summary>
        public DateTime ScreateTime { get; set; }

        /// <summary>o
        /// 申请事由
        /// </summary>
        public string Sreason { get; set; }

        /// <summary>
        /// 请求状态
        /// </summary>
        public bool Status { get; set; }
    }
}