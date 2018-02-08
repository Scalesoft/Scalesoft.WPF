using System;
using System.Globalization;
using System.Windows.Data;

namespace Scalesoft.WPF.Helpers.Converters
{
    public class UtcDateTimeToLocalDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(DateTime) && targetType != typeof(object))
                throw new InvalidOperationException("The target must be a DateTime");

            if (value == null)
                return null;

            var dateTime = (DateTime) value;
            return dateTime.ToLocalTime();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Conversion back is not supported");
        }
    }
}