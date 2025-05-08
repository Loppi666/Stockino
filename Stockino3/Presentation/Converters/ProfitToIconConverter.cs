using Microsoft.UI.Xaml.Data;
using System;

namespace Stockino3.Presentation.Converters
{
    public class ProfitToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal profit)
            {
                if (profit > 0)
                {
                    // Zisk - ikona šipky nahoru
                    return "\uE74A"; // Symbol šipky nahoru z Segoe Fluent Icons
                }
                else if (profit < 0)
                {
                    // Ztráta - ikona šipky dolů
                    return "\uE74B"; // Symbol šipky dolů z Segoe Fluent Icons
                }
            }
            
            // Neutrální - horizontální čára
            return "\uE738"; // Symbol horizontální čáry z Segoe Fluent Icons
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
