using System;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;

namespace Stockino3.Presentation.Converters
{
    public class TrendToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return new SolidColorBrush(Colors.Gray);
                
            if (value is string trend)
            {
                if (trend.ToLower() == "up") return new SolidColorBrush(Colors.Green);
                if (trend.ToLower() == "down") return new SolidColorBrush(Colors.Red);
                return new SolidColorBrush(Colors.Gray);
            }
            
            if (value is double doubleValue)
            {
                if (doubleValue > 0) return new SolidColorBrush(Colors.Green);
                if (doubleValue < 0) return new SolidColorBrush(Colors.Red);
                return new SolidColorBrush(Colors.Gray);
            }
            
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
