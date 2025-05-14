using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace Stockino3.Presentation.Converters
{
    public class PEGRatioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string peg)
            {
                return EvaluatePEGRatio(peg);
            }

            if (value is decimal decimalPeg)
            {
                return EvaluatePEGRatio(decimalPeg.ToString(CultureInfo.InvariantCulture));
            }

            if (value is double doublePeg)
            {
                return EvaluatePEGRatio(doublePeg.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // Konverze zpět obvykle není potřeba, ale můžete ji implementovat, pokud je to nutné
            throw new NotImplementedException();
        }

        private string EvaluatePEGRatio(string peg)
        {
            if (decimal.TryParse(peg, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                if (value < 1)
                {
                    return "Výborná hodnota (podhodnocená akcie)";
                }

                if (value < 2)
                {
                    return "Dobrá hodnota (přiměřené ocenění)";
                }

                if (value < 3)
                {
                    return "Mírně vysoká hodnota";
                }

                return "Vysoká hodnota (potenciálně nadhodnocená)";
            }

            return "Neznámé";
        }
    }
}
