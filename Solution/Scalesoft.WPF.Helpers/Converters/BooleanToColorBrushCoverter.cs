using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Scalesoft.WPF.Helpers.Converters
{
    public class BooleanToColorBrushCoverter : IValueConverter
    {
        public Brush TrueBrush { get; set; }

        public Brush FalseBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Brush))
                throw new InvalidOperationException("The target must be a Brush");

            if (value == null || TrueBrush == null || FalseBrush == null)
                throw new ArgumentNullException("Value parameter or any of Brush properties is null", (Exception) null);

            var isTrue = (bool) value;
            return isTrue ? TrueBrush : FalseBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Conversion back is not supported");
        }
    }
}