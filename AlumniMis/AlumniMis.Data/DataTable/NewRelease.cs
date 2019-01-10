using System;

namespace AlumniMis.Data.DataTable
{
    /// <summary>
    /// 新闻发布
    /// </summary>
    public class NewRelease
    {
        /// <summary>
        /// 新闻发布Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 新闻编号
        /// </summary>
        public string Nnum { get; set; }

        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Ntit { get; set; }

        /// <summary>
        /// 新闻作者
        /// </summary>
        public string Nauthor { get; set; }

        /// <summary>
        /// 新闻发布时间
        /// </summary>
        public DateTime Ntime { get; set; }

        /// <summary>
        /// 新闻标签
        /// </summary>
        public string Ntag { get; set; }

        /// <summary>
        /// 新闻类型
        /// </summary>
        public string Ntype { get; set; }

        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Ncontent { get; set; }
    }
}