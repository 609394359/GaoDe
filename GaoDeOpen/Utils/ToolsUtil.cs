/*
* ==============================================================================
*
* FileName: ToolsUtil.cs
* Created: 2026/8/25 14:56:58
* Author: yangqingde
* Description: 
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaoDeOpen.Utils
{
    public class ToolsUtil
    {
        /// <summary>
        /// string 转 DateTime yyyyMMdd HHmmss
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime? DateTimeParse(string dateString)
        {
            return DateTimeParse(dateString, "yyyyMMdd HHmmss", "yyyyMMdd HH:mm:ss", "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// string 转 DateTime yyyyMMdd
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime? DateParse(string dateString)
        {
            return DateTimeParse(dateString, "yyyyMMdd");
        }

        /// <summary>
        /// string 转 DateTime
        /// </summary>
        /// <param name="dateString"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime? DateTimeParse(string dateString, params string[] formats)
        {
            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate;
            }
            return null;
        }

        /// <summary>
        /// string 转 时间 HHmmss
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static TimeSpan? TimeParse(string dateString)
        {
            return TimeParse(dateString, "HHmmss", "HH:mm:ss");
        }

        /// <summary>
        /// string 转 时间
        /// </summary>
        /// <param name="timeString"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static TimeSpan? TimeParse(string timeString, params string[] formats)
        {
            if (DateTime.TryParseExact(timeString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate.TimeOfDay;
            }
            return null;
        }
    }
}
