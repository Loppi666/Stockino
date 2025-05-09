using System;
using Microsoft.UI.Xaml.Data;

namespace Stockino3.Presentation.Converters
{
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            System.Diagnostics.Debug.WriteLine($"NullToBoolConverter: value={value}");
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

