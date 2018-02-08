using System;

namespace Scalesoft.WPF.Helpers.Utils
{
    public static class DateTimeHelper
    {
        public static string ConvertToLocalText(DateTime dateTime, DateTimeTextFormat format)
        {
            switch (format)
            {
                case DateTimeTextFormat.Date:
                    return dateTime.ToShortDateString();
                case DateTimeTextFormat.Time:
                    return dateTime.ToLocalTime().ToShortTimeString();
                default:
                    var localDateTime = dateTime.ToLocalTime();
                    return $"{localDateTime.ToShortDateString()} {localDateTime.ToShortTimeString()}";
            }
        }
    }
}
