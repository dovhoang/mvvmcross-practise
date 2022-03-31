using System;
using System.Globalization;
using MvvmCross.Converters;

namespace TipCalc.Droid
{
    public class PlusOneValueConverter : IMvxValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) + 2;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value);
        }
    }
}
