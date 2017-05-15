namespace AlumniMis.Common.Util
{
    /// <summary>
    /// 固定字符串帮助类
    /// </summary>
    public class Constant
    {
        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        public const string DATE_FORMAT = "yyyy-MM-dd";
        /// <summary>
        /// MM-dd"
        /// </summary>
        public const string DATE_MONTHDAY_FORMAT = "MM-dd";
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public const string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// yyyy-MM-dd HH:mm
        /// </summary>
        public const string DATETIME_TOMINUTE_FORMAT = "yyyy-MM-dd HH:mm";
        /// <summary>
        /// 最多保留9位小数，不保留末尾0
        /// </summary>
        public const string CURRENCY_FORMAT = "0.#########";
        /// <summary>
        /// 总是保留两位小数（0.00）
        /// </summary>
        public const string CURRENCY_TWODECIMAL = "0.00";
        /// <summary>
        /// 总是保留两位小数（0.00）
        /// </summary>
        public const string CLASSTIME_FORMAT = "0.00";
        /// <summary>
        /// 金额格式（+##,##.00;-##,##.00;0.00）
        /// </summary>
        public const string AMOUNT_MONEY = "+##,##.00;-##,##.00;0.00";
        /// <summary>
        /// JSM40692-0002
        /// </summary>
        public const string SPH_WECHART_SMS_TEMPID = "JSM40692-0002";
        /// <summary>
        /// /TempExcel
        /// </summary>
        public const string TEMP_EXCEL_PATH = "/TempExcel";
    }
}