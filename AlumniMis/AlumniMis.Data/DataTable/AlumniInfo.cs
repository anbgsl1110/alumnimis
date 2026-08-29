using System;

namespace AlumniMis.Data.DataTable
{
    /// <summary>
    /// 校友信息
    /// </summary>
    public class AlumniInfo
    {
        /// <summary>
        /// 校友信息Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 校友编号
        /// </summary>
        public string Anum { get; set; }

        /// <summary>
        /// 校友姓名
        /// </summary>
        public string Aname { get; set; }

        /// <summary>
        /// 校友性别
        /// </summary>
        public string Asex { get; set; }

        /// <summary>
        /// 校友电话
        /// </summary>
        public string Atel { get; set; }

        /// <summary>
        /// 校友班级
        /// </summary>
        public string Aclass { get; set; }

        /// <summary>
        /// 校友院系
        /// </summary>
        public string Acoll { get; set; }

        /// <summary>
        /// 校友入学年份
        /// </summary>
        public DateTime Aenter { get; set; }

        /// <summary>
        /// 校友离校年份
        /// </summary>
        public DateTime Aleave { get; set; }

        /// <summary>
        /// 校友目前所在地址
        /// </summary>
        public string Addres { get; set; }

        /// <summary>
        /// 校友所在公司
        /// </summary>
        public string Acompany { get; set; }

        /// <summary>
        /// 校友担任职位
        /// </summary>
        public string Ajob { get; set; }
    }
}