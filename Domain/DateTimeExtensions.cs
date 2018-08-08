using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class DateTimeExtensions
    {
        public static string ToTimestamp(this DateTime time) {

            return time.ToString("yyyyMMddHHmmssffff");

        }
    }
}
