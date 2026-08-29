namespace AlumniMis.Data.DataTable
{
    /// <summary>
    /// 校友组织
    /// </summary>
    public class AlumniOrgan
    {
        /// <summary>
        /// 校友组织Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 校友组织编号
        /// </summary>
        public string Gnum { get; set; }

        /// <summary>
        /// 校友组织名称
        /// </summary>
        public string Gname { get; set; }

        /// <summary>
        ///校友组织标签
        /// </summary>
        public string Gtag { get; set; }

        /// <summary>
        /// 校友组织负责人
        /// </summary>
        public string GMaster { get; set; }

        /// <summary>
        /// 校友组织联系电话
        /// </summary>
        public string Gtel { get; set; }
    }
}