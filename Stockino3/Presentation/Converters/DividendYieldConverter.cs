using System.Globalization;
using Microsoft.UI.Xaml.Data;
namespace Stockino3.Presentation.Converters
{
    public class DividendYieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string yield)
            {
                return EvaluateDividendYield(yield);
            }
            else if (value is decimal decimalYield)
            {
                return EvaluateDividendYield(decimalYield.ToString(CultureInfo.InvariantCulture));
            }
            else if (value is double doubleYield)
            {
                return EvaluateDividendYield(doubleYield.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        private string EvaluateDividendYield(string yield)
        {
            if (decimal.TryParse(yield, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                if (value > 6)
                    return "Velmi vysoký dividendový výnos";

                if (value > 4)
                    return "Vysoký dividendový výnos";

                if (value > 2)
                    return "Průměrný dividendový výnos";

                if (value > 0)
                    return "Nízký dividendový výnos";

                return "Bez dividendy";
            }

            return "Neznámé";
        }
    }
}
