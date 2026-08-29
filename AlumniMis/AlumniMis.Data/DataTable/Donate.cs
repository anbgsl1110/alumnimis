using System;

namespace AlumniMis.Data.DataTable
{
    /// <summary>
    /// 校友捐赠
    /// </summary>
    public class Donate
    {
        /// <summary>
        /// 捐赠Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 捐赠项目编号
        /// </summary>
        public string Dnum { get; set; }

        /// <summary>
        /// 捐赠项目名称
        /// </summary>
        public string Dname { get; set; }

        /// <summary>
        /// 捐赠项目标签
        /// </summary>
        public string Dtag { get; set; }

        /// <summary>
        /// 项目发起时间
        /// </summary>
        public DateTime Dpub { get; set; }

        /// <summary>
        /// 捐赠金额
        /// </summary>
        public long Damount { get; set; }

        /// <summary>
        /// 捐赠理由
        /// </summary>
        public string Dreason { get; set; }

        /// <summary>
        /// 项目发起人
        /// </summary>
        public string Dpuber { get; set; }

        /// <summary>
        /// 项目负责人
        /// </summary>
        public string Dres { get; set; }

        /// <summary>
        /// 负责人电话号码
        /// </summary>
        public string Dtel { get; set; }

        /// <summary>
        /// 完成进度
        /// </summary>
        public int Dstatus { get; set; }

        /// <summary>
        /// 捐赠备注
        /// </summary>
        public string Dremarks { get; set; }
    }
}