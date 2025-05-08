using System.Globalization;
using Microsoft.UI.Xaml.Data;
namespace Stockino3.Presentation.Converters
{
    public class BetaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string beta)
            {
                return EvaluateBeta(beta);
            }
            else if (value is decimal decimalBeta)
            {
                return EvaluateBeta(decimalBeta.ToString(CultureInfo.InvariantCulture));
            }
            else if (value is double doubleBeta)
            {
                return EvaluateBeta(doubleBeta.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        private string EvaluateBeta(string beta)
        {
            if (double.TryParse(beta, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                if (value < 0.5)
                    return "Velmi nízká volatilita";

                if (value < 0.8)
                    return "Nízká volatilita";

                if (value < 1.2)
                    return "Průměrná volatilita";

                if (value < 1.5)
                    return "Zvýšená volatilita";

                return "Vysoká volatilita";
            }

            return "Neznámé";
        }
    }
}
