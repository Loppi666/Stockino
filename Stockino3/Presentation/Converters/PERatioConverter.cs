using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace Stockino3.Presentation.Converters
{
    public class PERatioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string pe)
            {
                return EvaluatePERatio(pe);
            }

            if (value is decimal decimalPe)
            {
                return EvaluatePERatio(decimalPe.ToString(CultureInfo.InvariantCulture));
            }

            if (value is double doublePe)
            {
                return EvaluatePERatio(doublePe.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // Konverze zpět obvykle není potřeba, ale můžete ji implementovat, pokud je to nutné
            throw new NotImplementedException();
        }

        private string EvaluatePERatio(string pe)
        {
            if (decimal.TryParse(pe, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                if (value < 10)
                {
                    return "Velmi nízké (akcie může být podhodnocená)";
                }

                if (value < 20)
                {
                    return "Přiměřené (rozumné ocenění)";
                }

                if (value < 30)
                {
                    return "Mírně vysoké (růstové očekávání)";
                }

                return "Vysoké (pozor na přecenění)";
            }

            return "Neznámé";
        }
    }
}
