﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Scalesoft.WPF.Helpers.Converters
{
    public class BooleanDisjunctionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Cast<bool>().Any(value => value);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Conversion back is not supported");
        }
    }
}