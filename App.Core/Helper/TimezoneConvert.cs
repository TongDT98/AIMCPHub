using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Helper
{
    public static class TimezoneConvert
    {
        public static DateTime GetVietnamTime()
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        }
        public static DateTime GetVietnamTime(DateTime timeutc)
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            return TimeZoneInfo.ConvertTimeFromUtc(timeutc, tz);
        }
        public static string GetVietnamTimeString(string format = "yyyyMMddHHmmss")
        {
            return GetVietnamTime().ToString(format);
        }
        public static string GetVietnamTimeString(DateTime timeutc,string format = "yyyyMMddHHmmss")
        {
            return GetVietnamTime(timeutc).ToString(format);
        }
    }
}
