using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace Stockino3.Presentation.Converters
{
    public class ProfitToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal profit)
            {
                // Zobrazit pouze pokud existuje zisk nebo ztráta (ne nula)
                return profit != 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            
            // Výchozí stav - skrýt
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
