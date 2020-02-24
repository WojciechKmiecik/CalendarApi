using System;

namespace CalendarApi.Logic.Helpers
{
    public static class DateTimeHelper
    {
        private static long ToUnixTime(this DateTime dateTime)
        {
            var dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeSeconds();
        }


        // Unix Time --> Local Time
        private static DateTime FromUnixTime(this long unixDateTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.ToUniversalTime();
        }
    }
}
