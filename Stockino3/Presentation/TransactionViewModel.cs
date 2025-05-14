using Microsoft.UI;

public class TransactionViewModel
{
    public string Description { get; set; }
    public string Date { get; set; }
    public string Reference { get; set; }
    public string Amount { get; set; }
    public string Status { get; set; }
    public SolidColorBrush StatusColor { get; set; }

    public string Volume { get; set; }
    public decimal TaxFreeVolume { get; set; }
    public string TotalAmount { get; set; }
    public decimal TotalAmountDecimal { get; set; }
    public decimal TaxFreeAmount { get; set; }
    public string Ticker { get; set; }

    // Vlastnosti pro zobrazení trendu
    public string TrendSymbol { get; private set; }
    public SolidColorBrush TrendColor { get; private set; }

    // Přidání vlastnosti pro výpočet zisku/ztráty
    private decimal _avgPrice;
    private decimal _currentPrice;

    public decimal AvgPrice
    {
        get => _avgPrice;
        set
        {
            _avgPrice = value;
            CalculateProfit();
        }
    }

    public decimal CurrentPrice
    {
        get => _currentPrice;
        set
        {
            _currentPrice = value;
            CalculateProfit();
        }
    }

    public decimal Profit { get; private set; }

    // Absolutní zisk/ztráta v peněžní hodnotě
    public decimal AbsoluteProfit { get; private set; }

    // Formátovaný absolutní zisk/ztráta
    public string AbsoluteProfitFormatted => AbsoluteProfit != 0
        ? $"{AbsoluteProfit:F2} Kč"
        : "";

    private void CalculateProfit()
    {
        if ((_avgPrice > 0) && (_currentPrice > 0))
        {
            // Výpočet absolutního zisku/ztráty v penězích 
            AbsoluteProfit = (_currentPrice - _avgPrice) * TaxFreeVolume;

            // Výpočet procentuálního zisku/ztráty
            Profit = (_currentPrice - _avgPrice) / _avgPrice * 100;
        }
        else
        {
            AbsoluteProfit = 0;
            Profit = 0;
        }

        // Nastavení vlastností trendu na základě vypočteného zisku/ztráty
        if (Profit > 0)
        {
            // Rostoucí trend - zelený
            TrendColor = new SolidColorBrush(Colors.ForestGreen);
            TrendSymbol = "📈";
        }
        else if (Profit < 0)
        {
            // Klesající trend - červený
            TrendColor = new SolidColorBrush(Colors.Crimson);
            TrendSymbol = "📉";
        }
        else
        {
            // Neutrální trend - šedý
            TrendColor = new SolidColorBrush(Colors.DimGray);
            TrendSymbol = "📊";
        }
    }

    // Přidání vlastnosti pro zobrazení procentuálního zisku/ztráty
    public string ProfitPercentage => Profit != 0
        ? $"{Profit:F2}%"
        : "";
}
