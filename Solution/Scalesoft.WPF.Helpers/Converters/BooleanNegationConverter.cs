using System;
using System.Globalization;
using System.Windows.Data;

namespace Scalesoft.WPF.Helpers.Converters
{
    public class BooleanNegationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new ArgumentNullException();

            var isTrue = (bool)value;
            return !isTrue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}