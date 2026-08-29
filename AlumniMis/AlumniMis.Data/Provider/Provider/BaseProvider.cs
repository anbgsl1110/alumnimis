using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;

namespace AlumniMis.Data.Provider.Provider
{
    /// <summary>
    /// 数据服务基本抽象类
    /// </summary>
    public abstract class BaseProvider
    {
        /// <summary>
        /// 根据主键id获取数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="id"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Select<T>(T t, long id)
        {
            using (var con = DbFactory.GetNewConnection())
            {
                return con.Query<T>($"SELECT * FROM {GetObjectName(t)} WHERE Id = {id};").SingleOrDefault();
            }
        }

        /// <summary>
        /// 分页查询列表记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Select<T>(T t, long pageIndex, long pageSize)
        {
            using (var con = DbFactory.GetNewConnection())
            {
                return con.Query<T>(
                    $"SELECT * FROM {GetObjectName(t)} WHERE Id > 0 ORDER BY Id DESC LIMIT {pageIndex},{pageSize};");
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public void Insert<T>(T t)
        {
            using (var con = DbFactory.GetNewConnection())
            {
                string sql = $@"CALL {GetObjectName(t)}_Insert({GetObjectPropertyString(t)})";
                con.Execute(sql, GetObjectParameters(t));
            }
        }
        
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public int InsertWithIdentity<T>(T t)
        {
            using (var con = DbFactory.GetNewConnection())
            {
                string sql = $@"CALL {GetObjectName(t)}_Insert({GetObjectPropertyString(t)})";
                var result = con.Query<int>(sql, GetObjectParameters(t)).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 根据Id删除数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="id"></param>
        public void Delete<T>(T t, long id)
        {
            using (var con = DbFactory.GetNewConnection())
            {
                string sql = $@"CALL {GetObjectName(t)}_Delete(@Aid)";
                con.Execute(sql, new {Aid = id});
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public void Update<T>(T t)
        {
            using (var con = DbFactory.GetNewConnection())
            {
                string sql = $@"CALL {GetObjectName(t)}_Update(@Aid,{GetObjectPropertyString(t)})";
                con.Execute(sql, GetObjectParameters(t));
            }
        }

        /// <summary>
        /// 列表上分页条件拼接
        /// </summary>
        /// <param name="parameters">请求参数</param>
        /// <returns></returns>
        protected virtual string GetQueryListPagingCondition(IDictionary<string, object> parameters)
        {
            #region 增加分页条件

            var sbPaging = new StringBuilder();

            if (parameters.Keys.Contains("PageSize") && parameters.Keys.Contains("PageIndex"))
            {
                sbPaging.Append(" limit ");
                var pageIndex = (int)parameters["PageIndex"];
                var pageSize = (int)parameters["PageSize"];
                if (parameters.Keys.Contains("PageIndex"))
                {
                    sbPaging.Append(" @PageOffset,");
                    parameters.Add("PageOffset", (pageIndex - 1) * pageSize);
                }

                sbPaging.Append(" @PageSize");
            }

            return sbPaging.ToString();

            #endregion
        }

        #region 私有方法

        /// <summary>
        /// 获取对象属性值参数集合（用于执行存储过程）
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private IDictionary<string, object> GetObjectParameters<T>(T t)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            Type type = t.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                //解决对自动生成的存储过程调用时以主键Id传参会出错的问题
                parameters.Add(propertyInfo.Name.Equals("Id") ? @"Aid" : propertyInfo.Name,
                    propertyInfo.GetValue(t, null));
            }
            return parameters;
        }

        /// <summary>
        /// 获取对象属性值字符串拼接（用于执行存储过程）
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private string GetObjectPropertyString<T>(T t)
        {
            StringBuilder str = new StringBuilder();
            Type type = t.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                str.Append(",@" + propertyInfo.Name);
            }
            return str.ToString().Substring(5);
        }

        /// <summary>
        /// 获取对象名称（用于执行存储过程）
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private string GetObjectName<T>(T t)
        {
            Type type = t.GetType();
            return type.Name;
        }

        #endregion
    }
}