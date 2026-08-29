using System;

namespace AlumniMis.Data.DataTable
{
    /// <summary>
    /// 活动表
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// 活动Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 活动编号
        /// </summary>
        public string Anum { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string Aname { get; set; }

        /// <summary>
        /// 活动标签
        /// </summary>
        public string Atag { get; set; }

        /// <summary>
        /// 活动发起人
        /// </summary>
        public string Amaster { get; set; }

        /// <summary>
        /// 活动发起人电话
        /// </summary>
        public string Atel { get; set; }

        /// <summary>
        /// 活动发布时间
        /// </summary>
        public DateTime Apub { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime Astart { get; set; }

        /// <summary>
        /// 举办地点
        /// </summary>
        public string Apot { get; set; }

        /// <summary>
        /// 活动备注
        /// </summary>
        public string Aspec { get; set; }
    }
}