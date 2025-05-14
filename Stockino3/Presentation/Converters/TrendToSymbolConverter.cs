using Microsoft.UI.Xaml.Data;

namespace Stockino3.Presentation.Converters
{
    public class TrendToSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return "◆";
            }

            if (value is string trend)
            {
                if (trend.ToLower() == "up")
                {
                    return "▲";
                }

                if (trend.ToLower() == "down")
                {
                    return "▼";
                }

                return "◆";
            }

            if (value is double doubleValue)
            {
                if (doubleValue > 0)
                {
                    return "▲";
                }

                if (doubleValue < 0)
                {
                    return "▼";
                }

                return "◆";
            }

            return "◆";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
