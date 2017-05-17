using System;

namespace AlumniMis.Common.Util
{
    /// <summary>
    /// 时间扩展方法
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToStartTime(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToEndTime(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
        /// <summary>
        /// 下一天开始时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToNextDayStartTime(this DateTime date)
        {
            date = date.AddDays(1);
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        /// <summary>
        /// 上一天结束时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToLastDayEndTime(this DateTime date)
        {
            date = date.AddDays(-1);
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
        /// <summary>
        /// DateTime转时间戳
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime date)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 0, 0, 0);
            return Convert.ToInt64((date.ToUniversalTime() - dateStart).TotalMilliseconds);
        } 
    }
}
