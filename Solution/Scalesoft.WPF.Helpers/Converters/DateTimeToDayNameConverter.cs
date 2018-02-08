using System;
using System.Globalization;
using System.Threading;
using System.Windows.Data;

namespace Scalesoft.WPF.Helpers.Converters
{
    public class DateTimeToDayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new InvalidOperationException("The target must be a string");

            if (value == null)
            {
                return string.Empty;
            }

            var dateTime = (DateTime) value;
            return dateTime.ToString("ddd", Thread.CurrentThread.CurrentUICulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Conversion back is not supported");
        }
    }
}