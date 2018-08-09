using System;

namespace Domain
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// convert datetime to timestamp string format.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToTimestamp(this DateTime time) {

            return time.ToString("yyyyMMddHHmmssffff");

        }
    }
}
