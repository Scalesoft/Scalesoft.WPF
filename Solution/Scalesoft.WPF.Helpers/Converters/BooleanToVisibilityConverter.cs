using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Scalesoft.WPF.Helpers.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
                throw new InvalidOperationException("The target must be a Visibility");

            if (value == null)
                throw new ArgumentNullException();

            var isTrue = (bool) value;
            return isTrue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Conversion back is not supported");
        }
    }
}