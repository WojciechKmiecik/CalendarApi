using System;

namespace CalendarApi.Logic.Helpers
{
    public static class DateTimeHelper
    {
        public static ulong ToUnixTime(this DateTime dateTime)
        {
            var dateTimeOffset = new DateTimeOffset(dateTime);
            return  (ulong)dateTimeOffset.ToUnixTimeSeconds();
        }


        // Unix Time --> UTC Time
        public static DateTime FromUnixTime(this ulong unixDateTime)
        {
            // should check overflow here
            return DateTimeOffset.FromUnixTimeSeconds((long)unixDateTime).DateTime.ToUniversalTime();
        }
    }
}
