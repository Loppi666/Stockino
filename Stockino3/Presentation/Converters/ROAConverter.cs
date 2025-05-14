using System.Globalization;
using Microsoft.UI.Xaml.Data;

namespace Stockino3.Presentation.Converters
{
    public class ROAConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string roa)
            {
                return EvaluateROA(roa);
            }

            if (value is decimal decimalRoa)
            {
                return EvaluateROA(decimalRoa.ToString(CultureInfo.InvariantCulture));
            }

            if (value is double doubleRoa)
            {
                return EvaluateROA(doubleRoa.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private string EvaluateROA(string roa)
        {
            if (decimal.TryParse(roa, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                if (value > 15)
                {
                    return "Vynikající návratnost aktiv";
                }

                if (value > 10)
                {
                    return "Velmi dobrá návratnost aktiv";
                }

                if (value > 5)
                {
                    return "Dobrá návratnost aktiv";
                }

                if (value > 0)
                {
                    return "Nízká návratnost aktiv";
                }

                return "Záporná návratnost aktiv";
            }

            return "Neznámé";
        }
    }
}
