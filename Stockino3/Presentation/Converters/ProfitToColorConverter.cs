using Microsoft.UI;
using Microsoft.UI.Xaml.Data;

namespace Stockino3.Presentation.Converters
{
    public class ProfitToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal profit)
            {
                if (profit > 0)
                {
                    // Zisk - zelená barva
                    return new SolidColorBrush(Colors.ForestGreen);
                }

                if (profit < 0)
                {
                    // Ztráta - červená barva
                    return new SolidColorBrush(Colors.Crimson);
                }
            }

            // Neutrální - šedá barva
            return new SolidColorBrush(Colors.DimGray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
