using System;
using System.Globalization;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Windows.UI;
using Microsoft.UI;
using SkiaSharp;
using Stockino3.Presentation.Services;

namespace Stockino3.Presentation.Converters
{
    public class NeedleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double doubleValue = 0;
            
            if (value is string stringValue)
            {
                double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue);
            }
            else if (value is double directDouble)
            {
                doubleValue = directDouble;
            }
            else if (value is decimal decimalValue)
            {
                doubleValue = (double)decimalValue;
            }
            else
            {
                return new SolidColorBrush(Colors.Gray);
            }
            
            string paramStr = parameter?.ToString()?.ToLowerInvariant() ?? "pe";
            
            SKColor skColor = paramStr switch
            {
                "pe" => NeedleColorService.GetNeedleColor(doubleValue),
                "peg" => NeedleColorService.GetPegNeedleColor(doubleValue),
                "roe" => NeedleColorService.GetRoeNeedleColor(doubleValue),
                "margin" => NeedleColorService.GetMarginNeedleColor(doubleValue),
                "profitmargin" => NeedleColorService.GetMarginNeedleColor(doubleValue),
                "dividend" => NeedleColorService.GetDividendNeedleColor(doubleValue),
                "dividendyield" => NeedleColorService.GetDividendNeedleColor(doubleValue),
                "roa" => NeedleColorService.GetRoaNeedleColor(doubleValue),
                "operatingmargin" => NeedleColorService.GetOperatingMarginNeedleColor(doubleValue),
                "pricetosales" => NeedleColorService.GetPriceToSalesNeedleColor(doubleValue),
                "pricetoSalesRatiottm" => NeedleColorService.GetPriceToSalesNeedleColor(doubleValue),
                "p/s" => NeedleColorService.GetPriceToSalesNeedleColor(doubleValue),
                "ps" => NeedleColorService.GetPriceToSalesNeedleColor(doubleValue),
                "evtoebitda" => NeedleColorService.GetEVToEBITDANeedleColor(doubleValue),
                "ev/ebitda" => NeedleColorService.GetEVToEBITDANeedleColor(doubleValue),
                "evebitda" => NeedleColorService.GetEVToEBITDANeedleColor(doubleValue),
                "ev" => NeedleColorService.GetEVToEBITDANeedleColor(doubleValue),
                "beta" => NeedleColorService.GetBetaNeedleColor(doubleValue),
                "debt" => NeedleColorService.GetDebtNeedleColor(doubleValue),
                "currentratio" => NeedleColorService.GetCurrentRatioNeedleColor(doubleValue),
                _ => SKColors.Gray
            };
            
            // Převést SKColor na Windows.UI.Color a vytvořit SolidColorBrush
            return new SolidColorBrush(Color.FromArgb(skColor.Alpha, skColor.Red, skColor.Green, skColor.Blue));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
