using SkiaSharp;

namespace Stockino3.Presentation.Services;

public static class NeedleColorService
{
    public static SKColor GetNeedleColor(double pe)
    {
        if (pe < 10)
            return SKColors.LimeGreen;

        if (pe < 20)
            return SKColors.Goldenrod;

        return SKColors.Tomato;
    }
    
    public static SKColor GetPegNeedleColor(double peg)
    {
        if (peg < 0.8) return SKColors.LimeGreen;
        if (peg < 1.2) return SKColors.Goldenrod;
        if (peg < 2) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetRoeNeedleColor(double roe)
    {
        if (roe > 30) return SKColors.LimeGreen;
        if (roe > 15) return SKColors.LightGreen;
        if (roe > 10) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetMarginNeedleColor(double margin)
    {
        if (margin > 25) return SKColors.LimeGreen;
        if (margin > 15) return SKColors.Goldenrod;
        if (margin > 5) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetDebtNeedleColor(double de)
    {
        if (de < 0.3) return SKColors.LimeGreen;
        if (de < 0.7) return SKColors.LightGreen;
        if (de < 1.5) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetCurrentRatioNeedleColor(double cr)
    {
        if (cr > 3) return SKColors.LimeGreen;
        if (cr > 1.5) return SKColors.Goldenrod;
        if (cr >= 1) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetDividendNeedleColor(double dy)
    {
        if (dy > 6) return SKColors.LimeGreen;
        if (dy > 3) return SKColors.Goldenrod;
        if (dy > 1) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetRoaNeedleColor(double roa)
    {
        if (roa > 15) return SKColors.LimeGreen;
        if (roa > 10) return SKColors.Goldenrod;
        if (roa > 5) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetOperatingMarginNeedleColor(double opMargin)
    {
        if (opMargin > 30) return SKColors.LimeGreen;
        if (opMargin > 20) return SKColors.Goldenrod;
        if (opMargin > 10) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetPriceToSalesNeedleColor(double ps)
    {
        if (ps < 2) return SKColors.LimeGreen;
        if (ps < 4) return SKColors.Goldenrod;
        if (ps < 8) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetEVToEBITDANeedleColor(double evEbitda)
    {
        if (evEbitda < 8) return SKColors.LimeGreen;
        if (evEbitda < 12) return SKColors.Goldenrod;
        if (evEbitda < 16) return SKColors.Orange;
        return SKColors.Tomato;
    }
    
    public static SKColor GetBetaNeedleColor(double beta)
    {
        if (beta < 0.8) return SKColors.LimeGreen;
        if (beta < 1.0) return SKColors.Goldenrod;
        if (beta < 1.2) return SKColors.Orange;
        return SKColors.Tomato;
    }
}
