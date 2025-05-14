using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace Stockino3.Presentation.Converters
{
    public class OperatingMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string margin)
            {
                return EvaluateOperatingMargin(margin);
            }

            if (value is decimal decimalMargin)
            {
                return EvaluateOperatingMargin(decimalMargin.ToString(CultureInfo.InvariantCulture));
            }

            if (value is double doubleMargin)
            {
                return EvaluateOperatingMargin(doubleMargin.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private string EvaluateOperatingMargin(string margin)
        {
            if (decimal.TryParse(margin, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                if (value > 25)
                {
                    return "Vynikající provozní marže";
                }

                if (value > 15)
                {
                    return "Velmi dobrá provozní marže";
                }

                if (value > 10)
                {
                    return "Dobrá provozní marže";
                }

                if (value > 0)
                {
                    return "Nízká provozní marže";
                }

                return "Záporná provozní marže";
            }

            return "Neznámé";
        }
    }
}
