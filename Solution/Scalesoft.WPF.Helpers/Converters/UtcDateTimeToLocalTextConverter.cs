using System;
using System.Globalization;
using System.Windows.Data;
using Scalesoft.WPF.Helpers.Utils;

namespace Scalesoft.WPF.Helpers.Converters
{
    public class UtcDateTimeToLocalTextConverter : IValueConverter
    {
        public DateTimeTextFormat OutputFormat { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string) && targetType != typeof(object))
                throw new InvalidOperationException("The target must be a string");

            if (value == null)
                return string.Empty;

            var dateTime = (DateTime) value;
            return DateTimeHelper.ConvertToLocalText(dateTime, OutputFormat);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Conversion back is not supported");
        }
    }
}