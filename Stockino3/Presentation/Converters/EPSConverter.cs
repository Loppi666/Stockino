using System;
using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace Stockino3.Presentation.Converters
{
    public class EPSConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string eps)
            {
                return EvaluateEPS(eps);
            }
            else if (value is decimal decimalEps)
            {
                return EvaluateEPS(decimalEps.ToString(CultureInfo.InvariantCulture));
            }
            else if (value is double doubleEps)
            {
                return EvaluateEPS(doubleEps.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // Konverze zpět obvykle není potřeba, ale můžete ji implementovat, pokud je to nutné
            throw new NotImplementedException();
        }

        private string EvaluateEPS(string eps)
        {
            if (decimal.TryParse(eps, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                if (value > 5)
                    return "Velmi dobrý zisk na akcii";

                if (value > 2)
                    return "Solidní ziskovost";

                if (value > 0)
                    return "Nízká ziskovost";

                return "Ztrátová firma";
            }

            return "Neznámé";
        }
    }
}
