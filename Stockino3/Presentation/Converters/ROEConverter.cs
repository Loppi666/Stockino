using System.Globalization;
using Microsoft.UI.Xaml.Data;
namespace Stockino3.Presentation.Converters
{
    public class ROEConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string roe)
            {
                return EvaluateROE(roe);
            }
            else if (value is decimal decimalRoe)
            {
                return EvaluateROE(decimalRoe.ToString(CultureInfo.InvariantCulture));
            }
            else if (value is double doubleRoe)
            {
                return EvaluateROE(doubleRoe.ToString(CultureInfo.InvariantCulture));
            }

            return "Neznámé";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
        private string EvaluateROE(string roe)
        {
            if (decimal.TryParse(roe, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
            {
                if (value > 25)
                    return "Vynikající návratnost vlastního kapitálu";

                if (value > 15)
                    return "Dobrá návratnost vlastního kapitálu";

                if (value > 10)
                    return "Průměrná návratnost vlastního kapitálu";

                if (value > 0)
                    return "Nízká návratnost vlastního kapitálu";

                return "Záporná návratnost vlastního kapitálu";
            }

            return "Neznámé";
        }
    }
}
