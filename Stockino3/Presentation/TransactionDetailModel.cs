using System.Globalization;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.VisualElements;
using Newtonsoft.Json;
using Skender.Stock.Indicators;
using SkiaSharp;
using Stockino3.Presentation.Services;
using ISeries = LiveChartsCore.ISeries;

namespace Stockino3.Presentation;

public partial record TransactionDetailModel(TransactionViewModel Transaction) 
{
    private const string ApiKey = "9E71JJDSQDAD5CZR";
    private const string Interval = "daily"; // lze upravit

    // ChartData je Feed (MVUX property)
    public IFeed<ChartDataModel> ChartData => Feed.Async(async ct => await LoadChartData(ct));

    public IFeed<GaugesData> GaugeFeed => Feed.Async(async ct => await LoadPiesData(ct));

    private async Task<GaugesData> LoadPiesData(CancellationToken ct)
    {
        var data = await GetCompanyOverview(Transaction.Ticker);
        var epsGague = CreateEpsGauge(data.EPS);
        var peGauge = CreatePeGauge(data.PERatio);
        var pegGauge = CreatePegGauge(data.PEGRatio);
        var roeGauge = CreateRoeGauge(data.ReturnOnEquityTTM);
        var profitMarginGauge = CreateProfitMarginGauge(data.ProfitMargin);
        var roaGauge = CreateRoaGauge(data.ReturnOnAssetsTTM);
        var operatingMarginGauge = CreateOperatingMarginGauge(data.OperatingMarginTTM);
        var dividendYieldGauge = CreateDividendYieldGauge(data.DividendYield);
        var priceToSalesGauge = CreatePriceToSalesGauge(data.PriceToSalesRatioTTM);
        var evToEbitdaGauge = CreateEVToEBITDAGauge(data.EVToEBITDA);
        var betaGauge = CreateBetaGauge(data.Beta);

        var result = new EvaluationResult();

        bool Parse(string? input, out decimal val) =>
            decimal.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out val);

        if (Parse(data.PERatio, out decimal pe))
        {
            EvaluatePERatio(pe, result);
        }

        if (Parse(data.PEGRatio, out decimal peg))
        {
            EvaluatePEGRatio(peg, result);
        }

        if (Parse(data.ReturnOnEquityTTM, out decimal roe))
        {
            EvaluateROE(roe, result);
        }

        if (Parse(data.ProfitMargin, out decimal pm))
        {
            EvaluateProfitMargin(pm, result);
        }

        if (Parse(data.DividendYield, out decimal dy))
        {
            EvaluateDividendYield(dy, result);
        }

        if (Parse(data.PriceToSalesRatioTTM, out decimal ps))
        {
            EvaluatePriceToSales(ps, result);
        }

        if (Parse(data.EVToEBITDA, out decimal evEbitda))
        {
            EvaluateEVToEBITDA(evEbitda, result);
        }

        if (Parse(data.Beta, out decimal beta))
        {
            EvaluateBeta(beta, result);
        }

        // 🆕 Nové metody
        if (Parse(data.ReturnOnAssetsTTM, out decimal roa))
        {
            EvaluateROA(roa, result);
        }

        if (Parse(data.OperatingMarginTTM, out decimal om))
        {
            EvaluateOperatingMargin(om, result);
        }

        if (Parse(data.MovingAverage50Day, out decimal ma50) && Parse(data.MovingAverage200Day, out decimal ma200))
        {
            EvaluateMovingAverageCross(ma50, ma200, result);
        }

        if (Parse(data.ForwardPE, out decimal fpe))
        {
            EvaluateForwardPE(fpe, result);
        }

        if (Parse(data.PriceToBookRatio, out decimal pb))
        {
            EvaluatePriceToBook(pb, result);
        }

        if (Parse(data.QuarterlyRevenueGrowthYOY, out decimal revGrowth))
        {
            EvaluateRevenueGrowth(revGrowth, result);
        }

        if (Parse(data.QuarterlyEarningsGrowthYOY, out decimal earnGrowth))
        {
            EvaluateEarningsGrowth(earnGrowth, result);
        }

        if (Parse(data.DividendPerShare, out decimal dps) && Parse(data.EPS, out decimal eps))
        {
            EvaluatePayoutRatio(dps, eps, result);
        }

        if (Parse(data.AnalystTargetPrice, out decimal target) && Parse(data.MovingAverage50Day, out decimal current))
        {
            EvaluateTargetPriceVsCurrent(target, current, result);
        }

        // Výpis výsledků
        Console.WriteLine($"\n📊 Výsledky analýzy pro {data.Symbol}:\n");

        Console.WriteLine("✅ Silné stránky:");

        foreach (string p in result.Positives)
        {
            Console.WriteLine("• " + p);
        }

        Console.WriteLine("\n⚠️ Rizika:");

        foreach (string i in result.Issues)
        {
            Console.WriteLine("• " + i);
        }

        Console.WriteLine("\n📘 Vysvětlení:");

        foreach (string e in result.Explanations)
        {
            Console.WriteLine("• " + e);
        }

        return new GaugesData(peGauge, epsGague, pegGauge, roeGauge, profitMarginGauge, roaGauge, operatingMarginGauge, dividendYieldGauge,
                              priceToSalesGauge, evToEbitdaGauge, betaGauge, result.Score, result.GetSummary());
    }

    private async Task<ChartDataModel> LoadChartData(CancellationToken ct)
    {
        // Načti historii a uprav na max 400 dní
        var history = (await GetDailyPrices(Transaction.Ticker)).ToList();

        // Výpočet SMA, výsledkem je kolekce s hodnotami a datem
        var sma50Arr = history.GetSma(50).ToList();
        var sma200Arr = history.GetSma(200).ToList();

        // Připrav data pro časovou osu
        var dates = history.Select(x => x.Date).ToArray();

        // Zarovnej SMA na délku ceny: tam kde není SMA, použij double.NaN
        double[] PadLeftWithNaN(int padCount, IEnumerable<double?> values)
            => Enumerable.Repeat(double.NaN, padCount).Concat(values.Select(v => v ?? 0)).ToArray();

        double[] priceSeries = history.Select(x => (double)x.Close).ToArray();
        double[] sma50Series = PadLeftWithNaN(history.Count - sma50Arr.Count, sma50Arr.Select(x => x.Sma));
        double[] sma200Series = PadLeftWithNaN(history.Count - sma200Arr.Count, sma200Arr.Select(x => x.Sma));

        // Najdi Golden/Death Cross body pouze tam, kde jsou hodnoty vypočtené (HasValue)
        var goldenPoints = new List<ObservablePoint>();
        var deathPoints = new List<ObservablePoint>();

        for (int i = 1; i < history.Count; i++)
        {
            // Musí být platné SMA hodnoty pro oba body
            if ((i < sma50Series.Length) && (i < sma200Series.Length) &&
                !double.IsNaN(sma50Series[i - 1]) && !double.IsNaN(sma200Series[i - 1]) &&
                !double.IsNaN(sma50Series[i]) && !double.IsNaN(sma200Series[i]))
            {
                if ((sma50Series[i - 1] < sma200Series[i - 1]) && (sma50Series[i] > sma200Series[i]))
                {
                    goldenPoints.Add(new ObservablePoint(dates[i].Ticks, sma50Series[i]));
                }

                if ((sma50Series[i - 1] > sma200Series[i - 1]) && (sma50Series[i] < sma200Series[i]))
                {
                    deathPoints.Add(new ObservablePoint(dates[i].Ticks, sma50Series[i]));
                }
            }
        }

        // Připrav řady s časovou osou (X = DateTime.Ticks)
        var priceLine = new LineSeries<ObservablePoint>
        {
            Name = "Cena",
            Values = history.Select((x, idx) => new ObservablePoint(x.Date.Ticks, (double)x.Close)).ToArray(),
            GeometrySize = 0,
            Stroke = new SolidColorPaint(SKColors.DarkMagenta, 2),
            Fill = new SolidColorPaint(new SKColor(0, 0, 0, 0))
        };

        var sma50Line = new LineSeries<ObservablePoint>
        {
            Name = "SMA50",
            Values = dates.Zip(sma50Series, (dt, val) => new ObservablePoint(dt.Ticks, val)).ToArray(),
            GeometrySize = 0,
            Stroke = new SolidColorPaint(SKColors.DodgerBlue, 2),
            Fill = new SolidColorPaint(new SKColor(0, 0, 0, 0))
        };

        var sma200Line = new LineSeries<ObservablePoint>
        {
            Name = "SMA200",
            Values = dates.Zip(sma200Series, (dt, val) => new ObservablePoint(dt.Ticks, val)).ToArray(),
            GeometrySize = 0,
            Stroke = new SolidColorPaint(SKColors.Orange, 2),
            Fill = new SolidColorPaint(new SKColor(0, 0, 0, 0))
        };

        var goldenSeries = new ScatterSeries<ObservablePoint>
        {
            Name = "Golden Cross",
            Values = goldenPoints,
            GeometrySize = 15,
            Fill = new SolidColorPaint(SKColors.Gold),
            Stroke = new SolidColorPaint(SKColors.DarkGoldenrod, 2)
        };

        var deathSeries = new ScatterSeries<ObservablePoint>
        {
            Name = "Death Cross",
            Values = deathPoints,
            GeometrySize = 15,
            Fill = new SolidColorPaint(SKColors.Red),
            Stroke = new SolidColorPaint(SKColors.DarkRed, 2)
        };

        var series = new ISeries[] { priceLine, sma50Line, sma200Line, goldenSeries, deathSeries };

        // Osa X jako časová (DateTime), formátuj labely z ticks
        var axis = new Axis
        {
            Labeler = value =>
            {
                try
                {
                    return new DateTime((long)value).ToString("yyyy-MM-dd");
                }
                catch
                {
                    return "";
                }
            },
            LabelsRotation = 75,
            TextSize = 12
        };

        var xAxes = new[] { axis };

        var yAxes = new[]
        {
            new Axis
            {
                TextSize = 12
            }
        };

        return new ChartDataModel(series, xAxes, yAxes);
    }

    public async Task Main()
    {
        var history = await GetDailyPrices(Transaction.Ticker);

        var sma50 = history.GetSma(50).ToArray();
        var sma200 = history.GetSma(200).ToArray();

        for (int i = 1; i < sma200.Length; i++)
        {
            var today50 = sma50[i];
            var yesterday50 = sma50[i - 1];
            var today200 = sma200[i];
            var yesterday200 = sma200[i - 1];

            if ((yesterday50.Sma < yesterday200.Sma) && (today50.Sma > today200.Sma))
            {
                Console.WriteLine($"Golden Cross: {today50.Date:yyyy-MM-dd}");
            }

            if ((yesterday50.Sma > yesterday200.Sma) && (today50.Sma < today200.Sma))
            {
                Console.WriteLine($"Death Cross: {today50.Date:yyyy-MM-dd}");
            }
        }
    }

    private static async Task<List<Quote>> GetDailyPrices(string symbol)
    {
        using HttpClient client = new();
        string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={symbol}&outputsize=full&apikey={ApiKey}";

        string jsonResponse = await client.GetStringAsync(url);
        var data = JsonConvert.DeserializeObject<AlphaVantageResponse>(jsonResponse);

        var quotes = data.TimeSeriesDaily
                         .Select(entry => new Quote
                          {
                              Date = DateTime.Parse(entry.Key),
                              Close = decimal.Parse(entry.Value.AdjustedClose, CultureInfo.InvariantCulture)
                          })
                         .OrderBy(q => q.Date)
                         .ToList();

        quotes.Sort((a, b) => a.Date.CompareTo(b.Date));

        return quotes;
    }

    private static async Task<OverviewData> GetCompanyOverview(string symbol)
    {
        using var client = new HttpClient();
        string url = $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={symbol}&apikey={ApiKey}";

        string response = await client.GetStringAsync(url);

        return JsonConvert.DeserializeObject<OverviewData>(response);
    }

    public class GaugeData
    {
        public IEnumerable<ISeries> Series { get; set; }
        public IEnumerable<VisualElement> VisualElements { get; set; }
        public NeedleVisual Needle { get; set; }
        public double Value { get; set; }
    }

    public record GaugesData(
        GaugeData PeGauge,
        GaugeData EpsGauge,
        GaugeData PegGauge,
        GaugeData RoeGauge,
        GaugeData ProfitMarginGauge,
        GaugeData RoaGauge,
        GaugeData OperatingMarginGauge,
        GaugeData DividendYieldGauge,
        GaugeData PriceToSalesGauge,
        GaugeData EVToEBITDAGauge,
        GaugeData BetaGauge,
        double SummaryScore,
        string SummaryDescription);

    public GaugeData CreatePeGauge(string peRatio)
    {
        double.TryParse(peRatio, NumberStyles.Any, CultureInfo.InvariantCulture, out double pe);

        var Series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(10, s => SetStyle(s, SKColors.LimeGreen)),
                                                              new GaugeItem(10, s => SetStyle(s, SKColors.Goldenrod)),
                                                              new GaugeItem(20, s => SetStyle(s, SKColors.Tomato)));

        var needle = new NeedleVisual
        {
            Value = pe > 40
                ? 40
                : pe,
            Fill = new SolidColorPaint(NeedleColorService.GetNeedleColor(pe), 3)
        };

        var VisualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = Series,
            VisualElements = VisualElements,
            Needle = needle,
            Value = pe
        };
    }

    private void SetStyle(PieSeries<ObservableValue> s, SKColor color)
    {
        s.OuterRadiusOffset = 120;
        s.MaxRadialColumnWidth = 20;
        s.CornerRadius = 0;
        s.Fill = new SolidColorPaint(color);
    }

    // Metoda GetNeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreateEpsGauge(string eps)
    {
        double.TryParse(eps, NumberStyles.Any, CultureInfo.InvariantCulture, out double epsDecimal);

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(5, s => SetStyle(s, SKColors.Tomato)), // Ztrátové/nízké EPS
                                                              new GaugeItem(2, s => SetStyle(s, SKColors.Goldenrod)), // Solidní EPS
                                                              new GaugeItem(3, s => SetStyle(s, SKColors.LightGreen)), // Velmi dobré EPS
                                                              new GaugeItem(10, s => SetStyle(s, SKColors.Aquamarine)) // Výborné EPS
                                                             );

        var needle = new NeedleVisual
        {
            Value = epsDecimal,
            Fill = new SolidColorPaint(SKColors.Gold, 2)
        };

        var VisualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => value.ToString("N1"),
                LabelsSize = 16,
                LabelsOuterOffset = 15,
                OuterOffset = 65,
                TicksLength = 20,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = VisualElements,
            Needle = needle,
            Value = epsDecimal
        };
    }

    public GaugeData CreatePegGauge(string pegRatio)
    {
        double.TryParse(pegRatio, NumberStyles.Any, CultureInfo.InvariantCulture, out double peg);

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(0.8, s => SetStyle(s, SKColors.LimeGreen)), // Podhodnocená akcie
                                                              new GaugeItem(0.4, s => SetStyle(s, SKColors.Goldenrod)), // Férově oceněná
                                                              new GaugeItem(0.8, s => SetStyle(s, SKColors.Orange)), // Mírně drahá
                                                              new GaugeItem(2, s => SetStyle(s, SKColors.Tomato)) // Drahá akcie
                                                             );

        var needle = new NeedleVisual
        {
            Value = peg > 4
                ? 4
                : peg,
            Fill = new SolidColorPaint(NeedleColorService.GetPegNeedleColor(peg), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => value.ToString("N1"),
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = peg
        };
    }

    // Metoda GetPegNeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreateRoeGauge(string roeValue)
    {
        double.TryParse(roeValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double roe);

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(10, s => SetStyle(s, SKColors.Tomato)), // Slabá efektivita
                                                              new GaugeItem(5, s => SetStyle(s, SKColors.Orange)), // Přijatelná efektivita
                                                              new GaugeItem(15, s => SetStyle(s, SKColors.LightGreen)), // Velmi dobrá efektivita
                                                              new GaugeItem(30, s => SetStyle(s, SKColors.LimeGreen)) // Výjimečná výkonnost
                                                             );

        var needle = new NeedleVisual
        {
            Value = roe > 60
                ? 60
                : roe,
            Fill = new SolidColorPaint(NeedleColorService.GetRoeNeedleColor(roe), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => $"{value}%",
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = roe
        };
    }

    // Metoda GetRoeNeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreateProfitMarginGauge(string marginValue)
    {
        double.TryParse(marginValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double margin);
        margin *= 100; // Převedeme na procenta pro lepší vizualizaci

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(5, s => SetStyle(s, SKColors.Tomato)), // Slabá rentabilita
                                                              new GaugeItem(10, s => SetStyle(s, SKColors.Orange)), // Průměrná ziskovost
                                                              new GaugeItem(10, s => SetStyle(s, SKColors.Goldenrod)), // Velmi dobrá
                                                              new GaugeItem(25, s => SetStyle(s, SKColors.LimeGreen)) // Vynikající ziskovost
                                                             );

        var needle = new NeedleVisual
        {
            Value = margin > 50
                ? 50
                : margin,
            Fill = new SolidColorPaint(NeedleColorService.GetMarginNeedleColor(margin), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => $"{value}%",
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = margin
        };
    }

    // Metoda GetMarginNeedleColor byla přesunuta do NeedleColorService

    // Metoda GetDebtNeedleColor byla přesunuta do NeedleColorService

    // Metoda GetCurrentRatioNeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreateDividendYieldGauge(string dyValue)
    {
        double.TryParse(dyValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double dy);
        dy *= 100; // Převedeme na procenta pro lepší vizualizaci

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(1, s => SetStyle(s, SKColors.Tomato)), // Slabý výnos
                                                              new GaugeItem(2, s => SetStyle(s, SKColors.Orange)), // Skromná dividenda
                                                              new GaugeItem(3, s => SetStyle(s, SKColors.Goldenrod)), // Solidní příjem
                                                              new GaugeItem(6, s => SetStyle(s, SKColors.LimeGreen)) // Velmi atraktivní
                                                             );

        var needle = new NeedleVisual
        {
            Value = dy > 12
                ? 12
                : dy,
            Fill = new SolidColorPaint(NeedleColorService.GetDividendNeedleColor(dy), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => $"{value}%",
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = dy
        };
    }

    // Metoda GetDividendNeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreateRoaGauge(string roaValue)
    {
        double.TryParse(roaValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double roa);

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(5, s => SetStyle(s, SKColors.Tomato)), // Slabé využití aktiv
                                                              new GaugeItem(5, s => SetStyle(s, SKColors.Orange)), // Průměrná efektivita
                                                              new GaugeItem(5, s => SetStyle(s, SKColors.Goldenrod)), // Dobrá efektivita
                                                              new GaugeItem(15, s => SetStyle(s, SKColors.LimeGreen)) // Výborná efektivita aktiv
                                                             );

        var needle = new NeedleVisual
        {
            Value = roa > 30
                ? 30
                : roa,
            Fill = new SolidColorPaint(NeedleColorService.GetRoaNeedleColor(roa), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => $"{value}%",
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = roa
        };
    }

    // Metoda GetRoaNeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreateOperatingMarginGauge(string opMarginValue)
    {
        double.TryParse(opMarginValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double opMargin);
        opMargin *= 100; // Převedeme na procenta pro lepší vizualizaci

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(10, s => SetStyle(s, SKColors.Tomato)), // Slabá provozní ziskovost
                                                              new GaugeItem(10, s => SetStyle(s, SKColors.Orange)), // Průměrná efektivita
                                                              new GaugeItem(10, s => SetStyle(s, SKColors.Goldenrod)), // Velmi dobrá efektivita
                                                              new GaugeItem(20, s => SetStyle(s, SKColors.LimeGreen)) // Výjimečně efektivní provoz
                                                             );

        var needle = new NeedleVisual
        {
            Value = opMargin > 50
                ? 50
                : opMargin,
            Fill = new SolidColorPaint(NeedleColorService.GetOperatingMarginNeedleColor(opMargin), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => $"{value}%",
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = opMargin
        };
    }

    // Metoda GetOperatingMarginNeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreatePriceToSalesGauge(string psValue)
    {
        double.TryParse(psValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double ps);

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(2, s => SetStyle(s, SKColors.LimeGreen)), // Velmi atraktivní ocenění
                                                              new GaugeItem(2, s => SetStyle(s, SKColors.Goldenrod)), // Rozumná valuace
                                                              new GaugeItem(4, s => SetStyle(s, SKColors.Orange)), // Spíš dražší
                                                              new GaugeItem(8, s => SetStyle(s, SKColors.Tomato)) // Velmi nadhodnocená
                                                             );

        var needle = new NeedleVisual
        {
            Value = ps > 16
                ? 16
                : ps,
            Fill = new SolidColorPaint(NeedleColorService.GetPriceToSalesNeedleColor(ps), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => value.ToString("N1"),
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = ps
        };
    }

    // Metoda GetPriceToSalesNeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreateEVToEBITDAGauge(string evEbitdaValue)
    {
        double.TryParse(evEbitdaValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double evEbitda);

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(8, s => SetStyle(s, SKColors.LimeGreen)), // Velmi dobré ocenění
                                                              new GaugeItem(4, s => SetStyle(s, SKColors.Goldenrod)), // Příznivé
                                                              new GaugeItem(4, s => SetStyle(s, SKColors.Orange)), // Dražší ocenění
                                                              new GaugeItem(10, s => SetStyle(s, SKColors.Tomato)) // Příliš vysoké ocenění
                                                             );

        var needle = new NeedleVisual
        {
            Value = evEbitda > 26
                ? 26
                : evEbitda,
            Fill = new SolidColorPaint(NeedleColorService.GetEVToEBITDANeedleColor(evEbitda), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => value.ToString("N1"),
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = evEbitda
        };
    }

    // Metoda GetEVToEBITDANeedleColor byla přesunuta do NeedleColorService

    public GaugeData CreateBetaGauge(string betaValue)
    {
        double.TryParse(betaValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double beta);

        var series = GaugeGenerator.BuildAngularGaugeSections(new GaugeItem(0.8, s => SetStyle(s, SKColors.LimeGreen)), // Velmi stabilní akcie
                                                              new GaugeItem(0.2, s => SetStyle(s, SKColors.Goldenrod)), // Mírná volatilita
                                                              new GaugeItem(0.2, s => SetStyle(s, SKColors.Orange)), // Odpovídá trhu
                                                              new GaugeItem(1.0, s => SetStyle(s, SKColors.Tomato)) // Zvýšená rizikovost
                                                             );

        var needle = new NeedleVisual
        {
            Value = beta > 2.2
                ? 2.2
                : beta,
            Fill = new SolidColorPaint(NeedleColorService.GetBetaNeedleColor(beta), 2)
        };

        var visualElements = new VisualElement[]
        {
            new AngularTicksVisual
            {
                Labeler = value => value.ToString("N1"),
                LabelsSize = 14,
                LabelsOuterOffset = 15,
                OuterOffset = 70,
                TicksLength = 10,
                LabelsPaint = new SolidColorPaint(SKColors.Yellow)
            },
            needle
        };

        return new GaugeData
        {
            Series = series,
            VisualElements = visualElements,
            Needle = needle,
            Value = beta
        };
    }

    // Metoda GetBetaNeedleColor byla přesunuta do NeedleColorService

    public static int ScoreLevel(int level)
    {
        return level switch
        {
            1 => 1,
            2 => 2,
            3 => 3,
            4 => 4,
            _ => 0
        };
    }

    public static int WeightedScore(int level, double weight = 1.0) => (int)(ScoreLevel(level) * weight);

    public static void EvaluatePERatio(decimal pe, EvaluationResult result)
    {
        result.Explanations.Add("➡ P/E ukazuje, kolik investor platí za 1 dolar zisku. Nižší = levnější akcie.");
        double weight = 1.2;

        if (pe < 10)
        {
            result.Positives.Add("P/E < 10 – velmi levná akcie.");
            result.Score += WeightedScore(4, weight);
        }
        else if (pe < 15)
        {
            result.Positives.Add("P/E mezi 10–15 – rozumná valuace.");
            result.Score += WeightedScore(3, weight);
        }
        else if (pe < 25)
        {
            result.Explanations.Add("P/E mezi 15–25 – spíš dražší, ale přijatelné.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("P/E > 25 – výrazně nadhodnocená.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluatePEGRatio(decimal peg, EvaluationResult result)
    {
        result.Explanations.Add("➡ PEG bere v úvahu růst zisků – PEG < 1 znamená podhodnocenou růstovou akcii.");
        double weight = 1.4;

        if (peg < 0.8m)
        {
            result.Positives.Add("PEG < 0.8 – podhodnocená růstová akcie.");
            result.Score += WeightedScore(4, weight);
        }
        else if (peg < 1.2m)
        {
            result.Positives.Add("PEG mezi 0.8–1.2 – férově oceněná.");
            result.Score += WeightedScore(3, weight);
        }
        else if (peg < 2)
        {
            result.Explanations.Add("PEG mezi 1.2–2 – mírně drahá.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("PEG > 2 – růst za příliš vysokou cenu.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateROE(decimal roe, EvaluationResult result)
    {
        result.Explanations.Add("➡ ROE měří, jak efektivně firma zhodnocuje kapitál akcionářů.");
        double weight = 1.6;

        if (roe > 30)
        {
            result.Positives.Add("ROE > 30 % – výjimečně výkonná firma.");
            result.Score += WeightedScore(4, weight);
        }
        else if (roe > 15)
        {
            result.Positives.Add("ROE mezi 15–30 % – velmi dobrá efektivita.");
            result.Score += WeightedScore(3, weight);
        }
        else if (roe > 10)
        {
            result.Explanations.Add("ROE mezi 10–15 % – přijatelná efektivita.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("ROE < 10 % – slabá schopnost zhodnotit kapitál.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateProfitMargin(decimal margin, EvaluationResult result)
    {
        result.Explanations.Add("➡ Marže ukazuje, kolik firma vydělá z tržeb – vyšší je lepší.");
        double weight = 1.0;

        if (margin > 0.25m)
        {
            result.Positives.Add("Marže > 25 % – vynikající ziskovost.");
            result.Score += WeightedScore(4, weight);
        }
        else if (margin > 0.15m)
        {
            result.Positives.Add("Marže mezi 15–25 % – velmi dobrá.");
            result.Score += WeightedScore(3, weight);
        }
        else if (margin > 0.05m)
        {
            result.Explanations.Add("Marže mezi 5–15 % – průměrná ziskovost.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("Marže < 5 % – slabá rentabilita.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateDividendYield(decimal dy, EvaluationResult result)
    {
        result.Explanations.Add("➡ Výnos dividendy – pasivní příjem pro investory.");
        double weight = 0.8;

        if (dy > 0.06m)
        {
            result.Positives.Add("Dividenda > 6 % – velmi atraktivní.");
            result.Score += WeightedScore(4, weight);
        }
        else if (dy > 0.03m)
        {
            result.Positives.Add("Dividenda mezi 3–6 % – solidní příjem.");
            result.Score += WeightedScore(3, weight);
        }
        else if (dy > 0.01m)
        {
            result.Explanations.Add("Dividenda mezi 1–3 % – skromná.");
            result.Score += WeightedScore(2, weight);
        }
        else if (dy > 0)
        {
            result.Issues.Add("Dividenda < 1 % – slabý výnos.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateMovingAverageCross(decimal ma50, decimal ma200, EvaluationResult result)
    {
        result.Explanations.Add("➡ Křížení klouzavých průměrů signalizuje změnu trendu (Golden/Death cross).");
        double weight = 1.0;

        if (ma50 > (ma200 * 1.02m))
        {
            result.Positives.Add("Golden Cross – 50 MA nad 200 MA, silný růstový signál.");
            result.Score += WeightedScore(4, weight);
        }
        else if (ma50 > ma200)
        {
            result.Positives.Add("50 MA mírně nad 200 MA – pozitivní trend.");
            result.Score += WeightedScore(3, weight);
        }
        else if ((Math.Abs(ma50 - ma200) / ma200) < 0.02m)
        {
            result.Explanations.Add("50 MA ≈ 200 MA – neutrální fáze.");
            result.Score += WeightedScore(2, weight);
        }
        else if (ma50 < ma200)
        {
            result.Issues.Add("50 MA pod 200 MA – negativní technický signál.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluatePriceToSales(decimal ps, EvaluationResult result)
    {
        result.Explanations.Add("➡ P/S (Price to Sales) poměr ukazuje, kolik investor platí za 1 dolar tržeb. Nižší = levnější.");
        double weight = 1.0;

        if (ps < 2)
        {
            result.Positives.Add("P/S < 2 – velmi atraktivní ocenění vůči tržbám.");
            result.Score += WeightedScore(4, weight);
        }
        else if (ps < 4)
        {
            result.Positives.Add("P/S mezi 2–4 – rozumná valuace.");
            result.Score += WeightedScore(3, weight);
        }
        else if (ps < 8)
        {
            result.Explanations.Add("P/S mezi 4–8 – spíš dražší.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("P/S > 8 – velmi nadhodnocená vůči tržbám.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateEVToEBITDA(decimal evEbitda, EvaluationResult result)
    {
        result.Explanations.Add("➡ EV/EBITDA ukazuje celkové ocenění firmy vůči provoznímu zisku. Nižší = levnější.");
        double weight = 1.2;

        if (evEbitda < 8)
        {
            result.Positives.Add("EV/EBITDA < 8 – velmi dobré ocenění.");
            result.Score += WeightedScore(4, weight);
        }
        else if (evEbitda < 12)
        {
            result.Positives.Add("EV/EBITDA mezi 8–12 – příznivé.");
            result.Score += WeightedScore(3, weight);
        }
        else if (evEbitda < 16)
        {
            result.Explanations.Add("EV/EBITDA mezi 12–16 – dražší ocenění.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("EV/EBITDA > 16 – příliš vysoké ocenění firmy.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateBeta(decimal beta, EvaluationResult result)
    {
        result.Explanations.Add("➡ Beta ukazuje volatilitu vůči trhu. <1 = stabilnější než trh, >1 = rizikovější.");
        double weight = 1.0;

        if (beta < 0.8m)
        {
            result.Positives.Add("Beta < 0.8 – velmi stabilní akcie.");
            result.Score += WeightedScore(4, weight);
        }
        else if (beta < 1)
        {
            result.Positives.Add("Beta mezi 0.8–1 – mírná volatilita.");
            result.Score += WeightedScore(3, weight);
        }
        else if (beta < 1.2m)
        {
            result.Explanations.Add("Beta mezi 1–1.2 – odpovídá trhu.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("Beta > 1.2 – zvýšená rizikovost.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateROA(decimal roa, EvaluationResult result)
    {
        result.Explanations.Add("➡ ROA (Return on Assets) ukazuje, jak efektivně firma využívá svá aktiva ke generování zisku.");
        double weight = 1.3;

        if (roa > 15)
        {
            result.Positives.Add("ROA > 15 % – výborná efektivita aktiv.");
            result.Score += WeightedScore(4, weight);
        }
        else if (roa > 10)
        {
            result.Positives.Add("ROA mezi 10–15 % – zdravá úroveň.");
            result.Score += WeightedScore(3, weight);
        }
        else if (roa > 5)
        {
            result.Explanations.Add("ROA mezi 5–10 % – průměrná efektivita.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("ROA < 5 % – slabé využití aktiv.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateOperatingMargin(decimal opMargin, EvaluationResult result)
    {
        result.Explanations.Add("➡ Provozní marže ukazuje, kolik zůstane z tržeb po odečtení provozních nákladů. Vyšší = zdravější provoz.");
        double weight = 1.2;

        if (opMargin > 0.3m)
        {
            result.Positives.Add("Provozní marže > 30 % – výjimečně efektivní provoz.");
            result.Score += WeightedScore(4, weight);
        }
        else if (opMargin > 0.2m)
        {
            result.Positives.Add("Provozní marže mezi 20–30 % – velmi dobrá efektivita.");
            result.Score += WeightedScore(3, weight);
        }
        else if (opMargin > 0.1m)
        {
            result.Explanations.Add("Provozní marže mezi 10–20 % – průměr.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("Provozní marže < 10 % – firma má malý prostor na pokrytí nákladů.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateForwardPE(decimal fpe, EvaluationResult result)
    {
        result.Explanations.Add("➡ Forward P/E ukazuje ocenění firmy vůči očekávanému zisku.");
        double weight = 1.1;

        if (fpe < 10)
        {
            result.Positives.Add("Forward P/E < 10 – velmi nízké budoucí ocenění.");
            result.Score += WeightedScore(4, weight);
        }
        else if (fpe < 15)
        {
            result.Positives.Add("Forward P/E mezi 10–15 – férové budoucí ocenění.");
            result.Score += WeightedScore(3, weight);
        }
        else if (fpe < 25)
        {
            result.Explanations.Add("Forward P/E mezi 15–25 – vyšší očekávání.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("Forward P/E > 25 – velmi vysoké budoucí ocenění.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluatePriceToBook(decimal pb, EvaluationResult result)
    {
        result.Explanations.Add("➡ P/B (Price to Book) ukazuje, kolik investor platí za účetní hodnotu firmy.");
        double weight = 1.1;

        if (pb < 1)
        {
            result.Positives.Add("P/B < 1 – firma je pod účetní hodnotou (možná podhodnocená).");
            result.Score += WeightedScore(4, weight);
        }
        else if (pb < 3)
        {
            result.Positives.Add("P/B mezi 1–3 – rozumná valuace.");
            result.Score += WeightedScore(3, weight);
        }
        else if (pb < 6)
        {
            result.Explanations.Add("P/B mezi 3–6 – spíše dražší.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("P/B > 6 – vysoké ocenění vůči účetní hodnotě.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateRevenueGrowth(decimal growth, EvaluationResult result)
    {
        result.Explanations.Add("➡ Růst tržeb ukazuje tempo expanze firmy meziročně.");
        double weight = 1.5;

        if (growth > 0.2m)
        {
            result.Positives.Add("Růst tržeb > 20 % – silná expanze.");
            result.Score += WeightedScore(4, weight);
        }
        else if (growth > 0.1m)
        {
            result.Positives.Add("Růst tržeb mezi 10–20 % – solidní růst.");
            result.Score += WeightedScore(3, weight);
        }
        else if (growth > 0.01m)
        {
            result.Explanations.Add("Růst tržeb mezi 1–10 % – mírné zlepšení.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("Růst tržeb < 1 % – stagnace nebo pokles.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateEarningsGrowth(decimal growth, EvaluationResult result)
    {
        result.Explanations.Add("➡ Růst zisku meziročně ukazuje výkonnost jádra podnikání.");
        double weight = 1.6;

        if (growth > 0.3m)
        {
            result.Positives.Add("Zisk roste > 30 % – výborný vývoj.");
            result.Score += WeightedScore(4, weight);
        }
        else if (growth > 0.1m)
        {
            result.Positives.Add("Zisk roste mezi 10–30 % – velmi dobré.");
            result.Score += WeightedScore(3, weight);
        }
        else if (growth > 0.01m)
        {
            result.Explanations.Add("Zisk roste mezi 1–10 % – pomalý růst.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("Zisk stagnuje nebo klesá.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluatePayoutRatio(decimal dividendPerShare, decimal eps, EvaluationResult result)
    {
        double weight = 1.0;

        if (eps <= 0)
        {
            result.Issues.Add("Záporný nebo nulový zisk na akcii – nelze vypočítat payout ratio.");
            result.Score += WeightedScore(1, weight);

            return;
        }

        decimal payout = dividendPerShare / eps;
        result.Explanations.Add($"➡ Výplatní poměr (payout ratio): {payout:P0} – poměr dividendy k zisku.");

        if (payout < 0.3m)
        {
            result.Positives.Add("Payout ratio < 30 % – zdravá výplata dividendy.");
            result.Score += WeightedScore(4, weight);
        }
        else if (payout < 0.6m)
        {
            result.Positives.Add("Payout ratio mezi 30–60 % – udržitelná úroveň.");
            result.Score += WeightedScore(3, weight);
        }
        else if (payout < 0.9m)
        {
            result.Explanations.Add("Payout ratio mezi 60–90 % – zvýšené riziko snížení.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("Payout ratio > 90 % – vysoké riziko snížení dividendy.");
            result.Score += WeightedScore(1, weight);
        }
    }

    public static void EvaluateTargetPriceVsCurrent(decimal targetPrice, decimal currentPrice, EvaluationResult result)
    {
        double weight = 1.2;

        if ((currentPrice <= 0) || (targetPrice <= 0))
        {
            return;
        }

        decimal upside = (targetPrice - currentPrice) / currentPrice;
        result.Explanations.Add($"➡ Potenciál růstu: {upside:P1} na základě cílové ceny.");

        if (upside > 0.3m)
        {
            result.Positives.Add("Potenciál růstu > 30 % – silný analytický sentiment.");
            result.Score += WeightedScore(4, weight);
        }
        else if (upside > 0.15m)
        {
            result.Positives.Add("Potenciál růstu mezi 15–30 % – pozitivní očekávání.");
            result.Score += WeightedScore(3, weight);
        }
        else if (upside > 0.05m)
        {
            result.Explanations.Add("Potenciál růstu mezi 5–15 % – mírný prostor.");
            result.Score += WeightedScore(2, weight);
        }
        else
        {
            result.Issues.Add("Nízký nebo žádný očekávaný růst dle analytiků.");
            result.Score += WeightedScore(1, weight);
        }
    }
}

public class EvaluationResult
{
    public List<string> Positives { get; set; } = new();
    public List<string> Issues { get; set; } = new();
    public List<string> Explanations { get; set; } = new();
    public double Score { get; set; }

    public string GetSummary()
    {
        string rating = Score switch
        {
            >= 68 => "📈 BUY: Vynikající fundamenty.",
            >= 56 => "✅ BUY: Silné fundamenty.",
            >= 42 => "🟡 HOLD: Smíšené signály.",
            >= 28 => "⚠️ SELL: Slabší fundamenty.",
            _ => "📉 SELL: Velmi rizikové."
        };

        return rating;
    }
}

public class AlphaVantageResponse
{
    [JsonProperty("Meta Data")]
    public MetaData MetaData { get; set; }

    [JsonProperty("Time Series (Daily)")]
    public Dictionary<string, TimeSeriesEntry> TimeSeriesDaily { get; set; }
}

public class MetaData
{
    [JsonProperty("1. Information")]
    public string Information { get; set; }

    [JsonProperty("2. Symbol")]
    public string Symbol { get; set; }

    [JsonProperty("3. Last Refreshed")]
    public string LastRefreshed { get; set; }

    [JsonProperty("4. Output Size")]
    public string OutputSize { get; set; }

    [JsonProperty("5. Time Zone")]
    public string TimeZone { get; set; }
}

public class TimeSeriesEntry
{
    [JsonProperty("1. open")]
    public string Open { get; set; }

    [JsonProperty("2. high")]
    public string High { get; set; }

    [JsonProperty("3. low")]
    public string Low { get; set; }

    [JsonProperty("4. close")]
    public string Close { get; set; }

    [JsonProperty("5. adjusted close")]
    public string AdjustedClose { get; set; }

    [JsonProperty("6. volume")]
    public string Volume { get; set; }

    [JsonProperty("7. dividend amount")]
    public string DividendAmount { get; set; }

    [JsonProperty("8. split coefficient")]
    public string SplitCoefficient { get; set; }
}

public class OverviewData
{
    [JsonProperty("Symbol")]
    public string? Symbol { get; set; }

    [JsonProperty("AssetType")]
    public string? AssetType { get; set; }

    [JsonProperty("Name")]
    public string? Name { get; set; }

    [JsonProperty("Description")]
    public string? Description { get; set; }

    [JsonProperty("CIK")]
    public string? CIK { get; set; }

    [JsonProperty("Exchange")]
    public string? Exchange { get; set; }

    [JsonProperty("Currency")]
    public string? Currency { get; set; }

    [JsonProperty("Country")]
    public string? Country { get; set; }

    [JsonProperty("Sector")]
    public string? Sector { get; set; }

    [JsonProperty("Industry")]
    public string? Industry { get; set; }

    [JsonProperty("Address")]
    public string? Address { get; set; }

    [JsonProperty("OfficialSite")]
    public string? OfficialSite { get; set; }

    [JsonProperty("FiscalYearEnd")]
    public string? FiscalYearEnd { get; set; }

    [JsonProperty("LatestQuarter")]
    public string? LatestQuarter { get; set; }

    [JsonProperty("MarketCapitalization")]
    public string? MarketCapitalization { get; set; }

    [JsonProperty("EBITDA")]
    public string? EBITDA { get; set; }

    [JsonProperty("PERatio")]
    public string? PERatio { get; set; }

    [JsonProperty("PEGRatio")]
    public string? PEGRatio { get; set; }

    [JsonProperty("BookValue")]
    public string? BookValue { get; set; }

    [JsonProperty("DividendPerShare")]
    public string? DividendPerShare { get; set; }

    [JsonProperty("DividendYield")]
    public string? DividendYield { get; set; }

    [JsonProperty("EPS")]
    public string? EPS { get; set; }

    [JsonProperty("RevenuePerShareTTM")]
    public string? RevenuePerShareTTM { get; set; }

    [JsonProperty("ProfitMargin")]
    public string? ProfitMargin { get; set; }

    [JsonProperty("OperatingMarginTTM")]
    public string? OperatingMarginTTM { get; set; }

    [JsonProperty("ReturnOnAssetsTTM")]
    public string? ReturnOnAssetsTTM { get; set; }

    [JsonProperty("ReturnOnEquityTTM")]
    public string? ReturnOnEquityTTM { get; set; }

    [JsonProperty("RevenueTTM")]
    public string? RevenueTTM { get; set; }

    [JsonProperty("GrossProfitTTM")]
    public string? GrossProfitTTM { get; set; }

    [JsonProperty("DilutedEPSTTM")]
    public string? DilutedEPSTTM { get; set; }

    [JsonProperty("QuarterlyEarningsGrowthYOY")]
    public string? QuarterlyEarningsGrowthYOY { get; set; }

    [JsonProperty("QuarterlyRevenueGrowthYOY")]
    public string? QuarterlyRevenueGrowthYOY { get; set; }

    [JsonProperty("AnalystTargetPrice")]
    public string? AnalystTargetPrice { get; set; }

    [JsonProperty("AnalystRatingStrongBuy")]
    public string? AnalystRatingStrongBuy { get; set; }

    [JsonProperty("AnalystRatingBuy")]
    public string? AnalystRatingBuy { get; set; }

    [JsonProperty("AnalystRatingHold")]
    public string? AnalystRatingHold { get; set; }

    [JsonProperty("AnalystRatingSell")]
    public string? AnalystRatingSell { get; set; }

    [JsonProperty("AnalystRatingStrongSell")]
    public string? AnalystRatingStrongSell { get; set; }

    [JsonProperty("TrailingPE")]
    public string? TrailingPE { get; set; }

    [JsonProperty("ForwardPE")]
    public string? ForwardPE { get; set; }

    [JsonProperty("PriceToSalesRatioTTM")]
    public string? PriceToSalesRatioTTM { get; set; }

    [JsonProperty("PriceToBookRatio")]
    public string? PriceToBookRatio { get; set; }

    [JsonProperty("EVToRevenue")]
    public string? EVToRevenue { get; set; }

    [JsonProperty("EVToEBITDA")]
    public string? EVToEBITDA { get; set; }

    [JsonProperty("Beta")]
    public string? Beta { get; set; }

    [JsonProperty("52WeekHigh")]
    public string? WeekHigh52 { get; set; }

    [JsonProperty("52WeekLow")]
    public string? WeekLow52 { get; set; }

    [JsonProperty("50DayMovingAverage")]
    public string? MovingAverage50Day { get; set; }

    [JsonProperty("200DayMovingAverage")]
    public string? MovingAverage200Day { get; set; }

    [JsonProperty("SharesOutstanding")]
    public string? SharesOutstanding { get; set; }

    [JsonProperty("DividendDate")]
    public string? DividendDate { get; set; }

    [JsonProperty("ExDividendDate")]
    public string? ExDividendDate { get; set; }

    [JsonProperty("FreeCashFlowTTM")]
    public string? FreeCashFlowTTM { get; set; }
}

public record ChartDataModel(ISeries[] Series, Axis[] XAxes, Axis[] YAxes);
