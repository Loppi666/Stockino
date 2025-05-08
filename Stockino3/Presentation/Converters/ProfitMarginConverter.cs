using System.Globalization;
using Microsoft.UI.Xaml.Data;
namespace Stockino3.Presentation.Converters
{
    public class ProfitMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string margin)
            {
                return EvaluateProfitMargin(margin);
            }
            else if (value is decimal decimalMargin)
            {
                return EvaluateProfitMargin(decimalMargin.ToString(CultureInfo.InvariantCulture));
            }
            else if (value is double doubleMargin)
            {
                return EvaluateProfitMargin(doubleMargin.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        private string EvaluateProfitMargin(string margin)
        {
            if (decimal.TryParse(margin, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                if (value > 25)
                    return "Vynikající zisková marže";

                if (value > 15)
                    return "Velmi dobrá zisková marže";

                if (value > 5)
                    return "Průměrná zisková marže";

                if (value > 0)
                    return "Nízká zisková marže";

                return "Záporná zisková marže";
            }

            return "Neznámé";
        }
    }
}
