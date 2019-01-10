using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AlumniMis.Common.Util
{
    public static class StringExtension
    {
        public static DateTime ToDate(this string str)
        {
            return ToDate(str, DateTime.Now);
        }

        public static DateTime ToDate(this string str, DateTime defalutValue)
        {
            try
            {
                return DateTime.Parse(str);
            }
            catch
            {
                return defalutValue;
            }
        }

        public static string Convert2String(this decimal? d, string defaultValue = "0")
        {
            if (d.HasValue)
            {
                return d.Value.ToString("0.##");
            }
            else
            {
                return defaultValue;
            }
        }

        public static string Convert2String(this decimal d)
        {
            return d.ToString("0.##");
        }

        public static decimal Convert2Decimal(this decimal? d)
        {
            if (d.HasValue)
            {

                return d.Value;
            }
            else
            {
                return 0;
            }
        }

        public static int ToInt(this string str)
        {
            return ToInt(str, 0);
        }

        public static int ToInt(this string str, int defaultValue)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static long ToLong(this string str)
        {
            return ToLong(str, 0);
        }

        public static long ToLong(this string str, long defaultValue)
        {
            try
            {
                return long.Parse(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static long? ToNullableLong(this string str, long? defaultValue = null)
        {
            try
            {
                return long.Parse(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static float? ToNullableFloat(this string str, float? defaultValue = null)
        {
            float res;
            if (float.TryParse(str, out res))
            {
                return res;
            }
            return defaultValue;
        }

        public static float? ToNullableRoundFloat(this string str, float? defaultValue = null)
        {
            float res;
            if (float.TryParse(str, out res))
            {
                return (float)Math.Round(res);
            }
            return defaultValue;
        }
        ///// <summary>
        ///// 不四舍五入，保留两位小数点
        ///// </summary>
        ///// <param name="d"></param>
        ///// <returns></returns>
        //public static string ToThousand(this string  d)
        //{
        //   var nd= d.ToDecimal();
        //   if (nd >= 10000)
        //   {
        //       int nm = (int)(nd / 100);
        //       return ((decimal)nm / 100) + "万";
        //   }
        //   else
        //   {
        //       int nm = (int)(nd * 100);
        //       return (nm / 100).ToString();
        //   }
        //}
        /// <summary>
        /// 不四舍五入，保留两位小数点
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToThousand(this decimal nd)
        {
            if (nd >= 10000 || nd <= -10000)
            {
                int nm = (int)(nd / 100);
                return ((decimal)nm / 100) + "万";
            }
            else
            {
                return nd.ToString("0.00");
                //int nm = (int)(nd * 100);
                //return (nm/100).ToString();
            }
        }
        /// <summary>
        /// 不四舍五入，保留两位小数点
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToPercentage(this decimal nd)
        {
            decimal absND = Math.Abs(nd);

            if (absND >= 0 && absND < (decimal)0.1)
            {
                return "持平";
            }
            else if (absND >= (decimal)0.1 && absND < 1)
            {
                return Math.Round(absND, 1, MidpointRounding.AwayFromZero) + "%";
            }
            else if (absND >= 1 && absND < 100)
            {
                return Math.Round(absND, MidpointRounding.AwayFromZero) + "%";
            }
            else if (absND == 100)
            {
                return "100%";
            }
            else if (absND > 100 && absND <= 1000)
            {
                if (absND > 100 && absND < 105)
                    return "100%";
                else
                    return Math.Round(absND / 100, 1, MidpointRounding.AwayFromZero) + "倍";
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 不四舍五入，保留两位小数点（超出10000会除以10000后返回）
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ToCcur(this decimal d)
        {
            if (d >= 10000)
            {
                int m = (int)((d / 10000) * 100);
                return (decimal)m / 100;
            }
            else
            {
                int n = (int)(d * 100);
                return (decimal)n / 100;
            }
        }
        /// <summary>
        /// 保留两位小数点
        /// </summary>
        /// <returns></returns>
        public static decimal ToCcur2(this decimal d)
        {
            int n = (int)(d * 100);
            return (decimal)n / 100;
        }
        ///// <summary>
        ///// 返回中文四舍五入结果保存两小数（0.00），>=10000,显示万字
        ///// </summary>
        ///// <param name="d"></param>
        ///// <returns></returns>
        //public static string ToChineseString(this decimal d)
        //{
        //    if (d >= 10000)
        //    {
        //        return Math.Round(d / 10000, MidpointRounding.AwayFromZero).ToString("0.00") + "万";
        //    }
        //    else
        //    {
        //        return Math.Round(d, MidpointRounding.AwayFromZero).ToString("0.00") + "元";
        //    }
        //}

        public static decimal ToCcur(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return ToCcur("0", 4);
            }
            else
            {
                return ToCcur(str, 4);
            }
        }

        public static decimal ToCcur(this string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                str = "0";
            }

            return (decimal)(Math.Round(decimal.Parse(str) * (decimal)Math.Pow(10, count))) / (decimal)Math.Pow(10, count);
        }

        public static float ToFloat(this string str, float defaultValue = 0)
        {
            try
            {
                return float.Parse(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal ToDecimal(this string str)
        {
            return ToDecimal(str, 0);
        }
        public static decimal ToDecimal(this string str, decimal defaultValue)
        {
            try
            {
                return decimal.Parse(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool IsMatch(this string s, string pattern)
        {
            if (s == null)
            {
                return false;
            }
            return Regex.IsMatch(s, pattern);
        }

        public static string Match(this string s, string pattern)
        {
            if (s == null)
            {
                return string.Empty;
            }
            return Regex.Match(s, pattern).Value;
        }

        public static string ToCamel(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            return s[0].ToString().ToLower() + s.Substring(1);
        }

        public static string ToPascal(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            return s[0].ToString().ToUpper() + s.Substring(1);
        }

        public static string ReplaceSubString(this string s, int length, string replaceContent)
        {
            return StringHelper.ReplaceSubString(s, length, replaceContent);
        }

        public static string ShortStr(this string s, int lengthLimit, int wordLimit = 0)
        {
            if (wordLimit == 0)
            {
                if (s.Length > lengthLimit)
                {
                    return s.Substring(0, lengthLimit);
                }
                return s;
            }
            else
            {
                string[] ss = s.Split(' ');
                StringBuilder sb = new StringBuilder(ss[0]);
                for (int i = 1; i <= wordLimit && i < ss.Length; i++)
                {
                    if (sb.Length + ss[i].Length + 1 > lengthLimit)
                    {
                        break;
                    }
                    sb.Append(' ').Append(ss[i]);
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Md5加密，获取16位加密结果
        /// </summary>
        /// <param name="oriString"></param>
        /// <returns></returns>
        public static string Md5String(this string oriString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(oriString)), 4, 8);
            t2 = t2.Replace("-", "");
            t2 = t2.ToLower();
            return t2;

            //MD5 m = new MD5CryptoServiceProvider();
            //byte[] bl = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(oriString));
            //m.Clear();
            //string hd5Str = BitConverter.ToString(bl);
            //return hd5Str.Replace("-", string.Empty);
        }

        /// <summary>
        /// Md5加密，获取32位加密结果
        /// </summary>
        /// <param name="oriString"></param>
        /// <returns></returns>
        public static string MD5(this string oriString)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(oriString));

                // Return the hexadecimal string.
                return BitConverter.ToString(data).Replace("-", "").ToLower();
            }
        }

        public static string Md5String(this long token)
        {
            var oriString = string.Format("{0}", token);

            return oriString.Md5String();
        }
        public static string Md5String(this int token)
        {
            var oriString = string.Format("{0}", token);
            return oriString.Md5String();
        }

        public static string NoHtml2(this string htmlString)
        {
            //将换行换成\r\n 不然可能会出现<p>the people</p><p>who are in trouble no matter <p/> =>the peoplewho are in trouble no matter 影响打分
            htmlString = Regex.Replace(htmlString, @"</p>", "\r\n", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"<br />", "\r\n", RegexOptions.IgnoreCase);

            //删除脚本
            htmlString = Regex.Replace(htmlString, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            htmlString = Regex.Replace(htmlString, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            //htmlString = Regex.Replace(htmlString, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"-->", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"<!--.*", "", RegexOptions.IgnoreCase);

            htmlString = Regex.Replace(htmlString, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            return htmlString;
        }

        /// <summary>
        /// textarea输入文本转换成html 主要是换行符 \n转成br
        /// </summary>
        /// <param name="html">文本</param>
        /// <returns>转换后文本</returns>
        public static string ToHtml(this string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }
            html = html.Replace("&", "&amp");
            html = html.Replace("<", "&lt");
            html = html.Replace(">", "&gt");
            //html = html.Replace(" ", "&nbsp");
            html = html.Replace("\n", "<br />");
            return html;
        }

        public static List<long> ToLongList(string[] strArray)
        {
            List<long> longArray = new List<long>();
            foreach (var item in strArray)
            {
                long parse;
                if (long.TryParse(item, out parse)) longArray.Add(parse);
            }
            return longArray;
        }

        public static string ToSqlLike(this string str)
        {
            str = str.Replace("\\", "\\\\");
            str = str.Replace("_", "\\_");
            str = str.Replace("%", "\\%");

            return string.Format("%{0}%", str);
        }
    }

    public class StringHelper
    {
        private static Random rand = new Random();

        public static string ConvertCreateDate(DateTime date)
        {
            string result = string.Empty;

            if (DateTime.Now.Year == date.Year && DateTime.Now.Month == date.Month && (DateTime.Now.Day - date.Day) > 0)
            {
                result = (DateTime.Now.DayOfYear - date.DayOfYear) + "天前";
            }
            else if (DateTime.Now.Year == date.Year && DateTime.Now.Month == date.Month && DateTime.Now.Date == date.Date && (DateTime.Now.Hour - date.Hour) > 0)
            {
                result = (DateTime.Now.Hour - date.Hour) + "小时前";
            }
            else if (DateTime.Now.Year == date.Year && DateTime.Now.Month == date.Month && DateTime.Now.Date == date.Date && DateTime.Now.Hour == date.Hour && (DateTime.Now.Minute - date.Minute) > 0)
            {
                result = (DateTime.Now.Minute - date.Minute) + "分钟前";
            }
            else if (DateTime.Now.Year == date.Year && DateTime.Now.Month == date.Month && DateTime.Now.Date == date.Date && DateTime.Now.Hour == date.Hour && DateTime.Now.Minute == date.Minute & (DateTime.Now.Second - date.Second) >= 0)
            {
                result = (DateTime.Now.Second - date.Second) + "秒前";
            }
            else if (date.Year == DateTime.Now.Year)
            {
                int xmonth = DateTime.Now.Month - date.Month;
                result = xmonth.ToString() + "个月前";
            }
            else
            {
                int xyear = DateTime.Now.Year - date.Year;
                result = xyear.ToString() + "年以前";
            }
            return result;
        }

        public static string ReplaceSubString(string inputString, int length, string replaceContent)
        {
            if (string.IsNullOrEmpty(inputString) || length <= 0)
            {
                return string.Empty;
            }
            int l = inputString.Length;
            #region 计算长度
            int clen = 0;
            while (clen < length && clen < l)
            {
                //每遇到一个中文，则将目标长度减一。
                if ((int)inputString[clen] > 128)
                {
                    length--;
                }
                clen++;
            }
            #endregion
            if (clen < l)
            {
                return inputString.Substring(0, clen) + replaceContent;
            }
            else
            {
                return inputString;
            }
        }

        public static string UrlEncode(string strCode)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(strCode); //默认是System.Text.Encoding.Default.GetBytes(str)
            System.Text.RegularExpressions.Regex regKey = new System.Text.RegularExpressions.Regex("^[A-Za-z0-9]+$");
            for (int i = 0; i < byStr.Length; i++)
            {
                string strBy = Convert.ToChar(byStr[i]).ToString();
                if (regKey.IsMatch(strBy))
                {
                    //是字母或者数字则不进行转换
                    sb.Append(strBy);
                }
                else
                {
                    sb.Append(@"%" + Convert.ToString(byStr[i], 16));
                }
            }
            return (sb.ToString());
        }

        public static string GetRandNum(int minValue = 10000, int maxValue = 99999)
        {
            return rand.Next(minValue, maxValue).ToString();
        }
    }
}