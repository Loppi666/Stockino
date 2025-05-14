namespace Stockino3.Services;

public static class OpenFigiToAlphaVantageMapper
{
    // Klíč: OpenFIGI exchCode (např. "LN", "US", "XE")
    // Hodnota: Alpha Vantage ticker suffix (např. ".L", "", ".DE")
    private static readonly Dictionary<string, string> FigiExchCodeToAlphaVantageSuffixMap = new(StringComparer.OrdinalIgnoreCase)
    {
        // === Evropa ===
        { "LN", ".L" }, // London Stock Exchange (UK)
        { "XE", ".DE" }, // Xetra (Německo)
        { "FF", ".F" }, // Frankfurt Stock Exchange (Německo - Alpha Vantage často používá .F pro Frankfurt, .DE pro Xetra)
        { "SG", ".SG" }, // Stuttgart Stock Exchange (Německo - .SG nebo .DU pro Düsseldorf, ověřit pro Stuttgart) - Alpha Vantage používá .STU pro Stuttgart
        { "PA", ".PA" }, // Euronext Paris (Francie)
        { "AE", ".AS" }, // Euronext Amsterdam (Nizozemsko - Alpha Vantage používá .AS)
        { "BR", ".BR" }, // Euronext Brussels (Belgie)
        { "LS", ".LS" }, // Euronext Lisbon (Portugalsko)
        { "ID", ".IR" }, // Euronext Dublin (Irsko - Alpha Vantage používá .IR)
        { "SM", ".MA" }, // Bolsa de Madrid (Španělsko - Alpha Vantage používá .MA)
        { "IM", ".MI" }, // Borsa Italiana / Euronext Milan (Itálie - Alpha Vantage používá .MI)
        { "VX", ".SW" }, // SIX Swiss Exchange (Švýcarsko - Alpha Vantage používá .SW)
        { "ST", ".ST" }, // Nasdaq Stockholm (Švédsko)
        { "OL", ".OL" }, // Oslo Børs (Norsko)
        { "CO", ".CO" }, // Nasdaq Copenhagen (Dánsko)
        { "HE", ".HE" }, // Nasdaq Helsinki (Finsko)
        { "WA", ".WA" }, // Warsaw Stock Exchange (Polsko - .WA nebo .WAR, .WA je častější)
        { "VI", ".VI" }, // Wiener Börse / Vienna Stock Exchange (Rakousko)
        { "AS", ".AT" }, // Athens Stock Exchange (Řecko - Alpha Vantage používá .AT)
        { "BU", ".BU" }, // Budapest Stock Exchange (Maďarsko)
        { "PR", ".PR" }, // Prague Stock Exchange (Česká republika - .PR nebo .PRA)
        { "LU", ".LU" }, // Luxembourg Stock Exchange
        { "IS", ".IS" }, // Borsa Istanbul (Turecko)

        // === Severní Amerika ===
        // Pro hlavní US burzy Alpha Vantage typicky NEPOUŽÍVÁ sufix pro akcie.
        // Symbol je přímo ticker, např. "IBM", "AAPL".
        // OpenFIGI může vrátit "US" jako obecný exchCode.
        // Pokud víte, že jde o NYSE/NASDAQ akcii, sufix je prázdný.
        { "US", "" }, // Obecný US - pro akcie NYSE/NASDAQ je sufix prázdný. Pro jiné US instrumenty může být sufix potřeba.
        // Toto mapování je zjednodušení. Pokud OpenFIGI vrátí "US", musíte zvážit typ instrumentu.
        { "CA", ".TO" }, // Toronto Stock Exchange (TSX, Kanada). Pro TSX Venture (TSXV) by to bylo .VN
        // OpenFIGI "CA" může být obecné, toto je pro hlavní TSX.

        { "MX", ".MX" }, // Mexican Stock Exchange (Mexiko)

        // === Asie a Pacifik ===
        { "AX", ".AX" }, // Australian Securities Exchange (Austrálie)
        { "NZ", ".NZ" }, // New Zealand Exchange (NZX)
        { "TJ", ".T" }, // Tokyo Stock Exchange (Japonsko - Alpha Vantage používá .T)
        { "HK", ".HK" }, // Hong Kong Stock Exchange
        { "SI", ".SI" }, // Singapore Exchange
        { "SH", ".SS" }, // Shanghai Stock Exchange (Čína - Alpha Vantage používá .SS)
        { "SZ", ".SZ" }, // Shenzhen Stock Exchange (Čína - Alpha Vantage používá .SZ)
        { "IN", ".NS" }, // National Stock Exchange of India (Indie - .NS pro NSE, .BO pro BSE. "IN" z OpenFIGI je obecné)
        // Je lepší mít specifické mapování, pokud víte, zda je to NSE nebo BSE.
        { "KO", ".KS" }, // Korea Exchange (Jižní Korea - Alpha Vantage často používá .KS pro KOSPI)
        { "TW", ".TW" }, // Taiwan Stock Exchange
        { "JK", ".JK" }, // Indonesia Stock Exchange (Jakarta)
        { "BK", ".BK" }, // Stock Exchange of Thailand (Bangkok)
        { "KL", ".KL" }, // Bursa Malaysia (Kuala Lumpur)
        { "PM", ".PM" }, // Philippine Stock Exchange (Manila)

        // === Jižní Amerika ===
        { "BZ", ".SA" }, // B3 - Brasil Bolsa Balcão (Brazílie - Alpha Vantage používá .SA pro Sao Paulo)
        { "CI", ".SN" }, // Santiago Stock Exchange (Chile - Alpha Vantage používá .SN)
        // { "CO", ".CB" }, // Colombia Stock Exchange - Alpha Vantage má pro Kolumbii specifické symboly, nemusí jít o jednoduchý sufix
        { "LM", ".LM" }, // Bolsa de Valores de Lima (Peru)
        { "BA", ".BA" }, // Bolsas y Mercados Argentinos (Argentina)

        // === Blízký východ a Afrika ===
        { "JH", ".JO" }, // JSE Limited (Jihoafrická republika - Alpha Vantage používá .JO pro Johannesburg)
        // { "SA", ".SR" }, // Saudi Stock Exchange (Tadawul - Alpha Vantage .SR, ale OpenFIGI může vracet SA)
        { "DB", ".DU" }, // Dubai Financial Market (SAE - Alpha Vantage často .DU)
        { "AD", ".AE" }, // Abu Dhabi Securities Exchange (SAE - Alpha Vantage někdy .AE) - ověřit!
        // { "DSMH", X },   // Qatar Stock Exchange - Alpha Vantage má omezené pokrytí nebo specifické symboly
        { "TA", ".TA" }, // Tel Aviv Stock Exchange (Izrael - .TA nebo .TLV)
        { "EG", ".CAI" } // Egyptian Exchange (Egypt - Alpha Vantage může používat .CAI pro Káhira) - ověřit!

        // TENTO SEZNAM NENÍ VYČERPÁVAJÍCÍ A MĚL BY BÝT OVĚŘOVÁN A DOPLŇOVÁN!
    };

    public static string GetAlphaVantageSuffix(string openFigiExchCode)
    {
        if (string.IsNullOrWhiteSpace(openFigiExchCode))
        {
            return null; // Nebo prázdný řetězec, pokud je to preferováno pro "bez sufixu"
        }

        if (FigiExchCodeToAlphaVantageSuffixMap.TryGetValue(openFigiExchCode, out string alphaVantageSuffix))
        {
            return alphaVantageSuffix;
        }

        Console.WriteLine($"Varování: Pro OpenFIGI exchCode '{openFigiExchCode}' nebylo nalezeno žádné mapování na Alpha Vantage sufix.");

        return null; // Nebo nějaká výchozí hodnota / chování
    }

    // Metoda pro sestrojení celého Alpha Vantage symbolu
    public static string ConstructAlphaVantageSymbol(string baseTicker, string openFigiExchCode)
    {
        if (string.IsNullOrWhiteSpace(baseTicker))
        {
            return null;
        }

        string suffix = GetAlphaVantageSuffix(openFigiExchCode);

        if (suffix == null)
        {
            // Pokud sufix není nalezen, můžeme zkusit vrátit jen baseTicker (pro případ US trhů, kde je sufix prázdný)
            // Ale je lepší, když mapování pro "US" explicitně vrací ""
            Console.WriteLine($"Nebyl nalezen sufix pro {openFigiExchCode}, zkouším použít base ticker '{baseTicker}' bez sufixu.");

            return baseTicker;
        }

        // Pokud je sufix prázdný řetězec (např. pro US trhy), vrátíme jen baseTicker
        if (suffix == "")
        {
            return baseTicker;
        }

        return $"{baseTicker}{suffix}";
    }
}
