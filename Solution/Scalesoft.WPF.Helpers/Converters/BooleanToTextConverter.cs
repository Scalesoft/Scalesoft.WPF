using System;
using System.Globalization;
using System.Windows.Data;

namespace Scalesoft.WPF.Helpers.Converters
{
    public class BooleanToTextConverter : IValueConverter
    {
        public BooleanToTextConverter()
        {
            TrueLabel = "Yes";
            FalseLabel = "No";
        }

        public string TrueLabel { get; set; }

        public string FalseLabel { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new ArgumentNullException();

            return (bool) value ? TrueLabel : FalseLabel;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Conversion back is not supported");
        }
    }
}