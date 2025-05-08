using System.Globalization;
using Microsoft.UI.Xaml.Data;
namespace Stockino3.Presentation.Converters
{
    public class EVToEBITDAConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string evEbitda)
            {
                return EvaluateEVToEBITDA(evEbitda);
            }
            else if (value is decimal decimalEvEbitda)
            {
                return EvaluateEVToEBITDA(decimalEvEbitda.ToString(CultureInfo.InvariantCulture));
            }
            else if (value is double doubleEvEbitda)
            {
                return EvaluateEVToEBITDA(doubleEvEbitda.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        private string EvaluateEVToEBITDA(string evEbitda)
        {
            if (decimal.TryParse(evEbitda, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                if (value < 8)
                    return "Potenciálně podhodnocená";

                if (value < 12)
                    return "Přiměřené ocenění";

                if (value < 16)
                    return "Mírně vyšší ocenění";

                return "Vysoké ocenění";
            }

            return "Neznámé";
        }
    }
}
