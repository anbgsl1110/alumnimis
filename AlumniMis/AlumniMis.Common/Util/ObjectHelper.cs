using System;
using System.Reflection;

namespace AlumniMis.Common.Util
{
    /// <summary>
    /// 对象相关帮助类
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// 获取对象属性值
        /// </summary>
        /// <param name="t"></param>
        /// <param name="propertyname"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetObjectPropertyValue<T>(T t, string propertyname)
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyname);

            if (property == null) return string.Empty;

            object o = property.GetValue(t, null);

            if (o == null) return string.Empty;

            return o.ToString();
        }

        /// <summary>
        /// 获取对象名称
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetObjectName<T>(T t)
        {
            Type type = t.GetType();
            return type.Name;
        }
    }
}