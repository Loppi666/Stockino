using System.Globalization;
using Microsoft.UI.Xaml.Data;
namespace Stockino3.Presentation.Converters
{
    public class PriceToSalesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string ps)
            {
                return EvaluatePriceToSales(ps);
            }
            else if (value is decimal decimalPs)
            {
                return EvaluatePriceToSales(decimalPs.ToString(CultureInfo.InvariantCulture));
            }
            else if (value is double doublePs)
            {
                return EvaluatePriceToSales(doublePs.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        private string EvaluatePriceToSales(string ps)
        {
            if (decimal.TryParse(ps, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                if (value < 2)
                    return "Velmi nízké ocenění vůči tržbám";
        
                if (value < 5)
                    return "Přiměřené ocenění vůči tržbám";
        
                if (value < 8)
                    return "Vyšší ocenění vůči tržbám";

                return "Vysoké ocenění vůči tržbám";
            }

            return "Neznámé";
        }
    }
}
