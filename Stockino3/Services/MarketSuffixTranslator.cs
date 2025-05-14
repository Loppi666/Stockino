namespace Stockino3.Services;

public static class MarketSuffixTranslator
{
    // Inicializace slovníku přímo v kódu
    private static readonly Dictionary<string, ExchangeMappingInfo> SuffixMap = new(StringComparer.OrdinalIgnoreCase)
    {
        // === Evropa ===
        { "UK", new ExchangeMappingInfo("London Stock Exchange", "XLON", "LN") }, // Spojené království
        { "DE_XETRA", new ExchangeMappingInfo("Xetra", "XETR", "XE") }, // Německo - Xetra (hlavní)
        { "DE_FRANKFURT", new ExchangeMappingInfo("Frankfurt Stock Exchange (Börse Frankfurt)", "XFRA", "FF") }, // Německo - Frankfurt
        { "DE_STUTTGART", new ExchangeMappingInfo("Stuttgart Stock Exchange (Börse Stuttgart)", "XSTU", "SG") }, // Německo - Stuttgart
        { "FR", new ExchangeMappingInfo("Euronext Paris", "XPAR", "PA") }, // Francie
        { "NL", new ExchangeMappingInfo("Euronext Amsterdam", "XAMS", "AE") }, // Nizozemsko
        { "BE", new ExchangeMappingInfo("Euronext Brussels", "XBRU", "BR") }, // Belgie
        { "PT", new ExchangeMappingInfo("Euronext Lisbon", "XLIS", "LS") }, // Portugalsko
        { "IE", new ExchangeMappingInfo("Euronext Dublin", "XMSM", "ID") }, // Irsko
        { "ES", new ExchangeMappingInfo("Bolsa de Madrid", "XMAD", "SM") }, // Španělsko
        { "IT", new ExchangeMappingInfo("Borsa Italiana (Euronext Milan)", "XMIL", "IM") }, // Itálie
        { "CH", new ExchangeMappingInfo("SIX Swiss Exchange", "XSWX", "VX") }, // Švýcarsko
        { "SE", new ExchangeMappingInfo("Nasdaq Stockholm", "XSTO", "ST") }, // Švédsko
        { "NO", new ExchangeMappingInfo("Oslo Børs (Euronext Oslo)", "XOSL", "OL") }, // Norsko
        { "DK", new ExchangeMappingInfo("Nasdaq Copenhagen", "XCSE", "CO") }, // Dánsko
        { "FI", new ExchangeMappingInfo("Nasdaq Helsinki", "XHEL", "HE") }, // Finsko
        { "PL", new ExchangeMappingInfo("Warsaw Stock Exchange (GPW)", "XWAR", "WA") }, // Polsko
        { "AT", new ExchangeMappingInfo("Wiener Börse (Vienna Stock Exchange)", "XWBO", "VI") }, // Rakousko
        { "GR", new ExchangeMappingInfo("Athens Stock Exchange (ATHEX)", "XATH", "AS") }, // Řecko (OpenFIGI exchCode 'AS')
        { "HU", new ExchangeMappingInfo("Budapest Stock Exchange", "XBUD", "BU") }, // Maďarsko
        { "CZ", new ExchangeMappingInfo("Prague Stock Exchange (PSE)", "XPRA", "PR") }, // Česká republika
        { "LU", new ExchangeMappingInfo("Luxembourg Stock Exchange", "XLUX", "LU") }, // Lucembursko
        { "TR", new ExchangeMappingInfo("Borsa Istanbul", "XIST", "IS") }, // Turecko (OpenFIGI exchCode 'IS')

        // === Severní Amerika ===
        { "US_NYSE", new ExchangeMappingInfo("New York Stock Exchange", "XNYS", "US") }, // USA - NYSE
        { "US_NASDAQ", new ExchangeMappingInfo("NASDAQ Stock Market", "XNAS", "US") }, // USA - NASDAQ
        { "US_AMEX", new ExchangeMappingInfo("NYSE American (AMEX)", "XASE", "US") }, // USA - AMEX
        // { "US", new ExchangeMappingInfo("Generic US (default NASDAQ)", "XNAS", "US") }, // Pokud máte obecný ".US" sufix
        { "CA_TSX", new ExchangeMappingInfo("Toronto Stock Exchange", "XTSE", "CA") }, // Kanada - TSX
        { "CA_TSXV", new ExchangeMappingInfo("TSX Venture Exchange", "XTSX", "CA") }, // Kanada - TSX Venture (MIC je stejný, OpenFIGI 'CA' je obecný)
        { "MX", new ExchangeMappingInfo("Mexican Stock Exchange (BMV)", "XMEX", "MX") }, // Mexiko

        // === Asie a Pacifik ===
        { "AU", new ExchangeMappingInfo("Australian Securities Exchange", "XASX", "AX") }, // Austrálie
        { "NZ", new ExchangeMappingInfo("New Zealand Exchange (NZX)", "XNZE", "NZ") }, // Nový Zéland
        { "JP", new ExchangeMappingInfo("Tokyo Stock Exchange", "XTKS", "TJ") }, // Japonsko (součást XJPX)
        { "HK", new ExchangeMappingInfo("Hong Kong Stock Exchange", "XHKG", "HK") }, // Hongkong
        { "SG", new ExchangeMappingInfo("Singapore Exchange", "XSES", "SI") }, // Singapur
        { "CN_SS", new ExchangeMappingInfo("Shanghai Stock Exchange", "XSHG", "SH") }, // Čína - Šanghaj
        { "CN_SZ", new ExchangeMappingInfo("Shenzhen Stock Exchange", "XSHE", "SZ") }, // Čína - Šen-čen
        { "IN_NSE", new ExchangeMappingInfo("National Stock Exchange of India", "XNSE", "IN") }, // Indie - NSE
        { "IN_BSE", new ExchangeMappingInfo("BSE India (Bombay Stock Exchange)", "XBOM", "IN") }, // Indie - BSE
        { "KR", new ExchangeMappingInfo("Korea Exchange (KRX)", "XKRX", "KO") }, // Jižní Korea
        { "TW", new ExchangeMappingInfo("Taiwan Stock Exchange (TWSE)", "XTAI", "TW") }, // Tchaj-wan
        { "ID", new ExchangeMappingInfo("Indonesia Stock Exchange (IDX)", "XIDX", "JK") }, // Indonésie (OpenFIGI 'JK' pro Jakarta)
        { "TH", new ExchangeMappingInfo("Stock Exchange of Thailand (SET)", "XBKK", "BK") }, // Thajsko (OpenFIGI 'BK' pro Bangkok)
        { "MY", new ExchangeMappingInfo("Bursa Malaysia", "XKLS", "KL") }, // Malajsie (OpenFIGI 'KL' pro Kuala Lumpur)
        { "PH", new ExchangeMappingInfo("Philippine Stock Exchange (PSE)", "XPHS", "PM") }, // Filipíny (OpenFIGI 'PM' pro Manila)

        // === Jižní Amerika ===
        { "BR", new ExchangeMappingInfo("B3 - Brasil Bolsa Balcão", "BVMF", "BZ") }, // Brazílie
        { "AR", new ExchangeMappingInfo("Bolsas y Mercados Argentinos (BYMA)", "XBYM", "BA") }, // Argentina (OpenFIGI 'BA' pro Buenos Aires)
        { "CL", new ExchangeMappingInfo("Santiago Stock Exchange", "XSGO", "CI") }, // Chile (OpenFIGI 'CI')
        { "CO", new ExchangeMappingInfo("Colombia Stock Exchange (BVC)", "XBOG", "CO") }, // Kolumbie (OpenFIGI 'CO')
        { "PE", new ExchangeMappingInfo("Bolsa de Valores de Lima (BVL)", "XLIM", "LM") }, // Peru (OpenFIGI 'LM' pro Lima)

        // === Blízký východ a Afrika ===
        { "ZA", new ExchangeMappingInfo("JSE Limited (Johannesburg)", "XJSE", "JH") }, // Jihoafrická republika
        { "SA", new ExchangeMappingInfo("Saudi Stock Exchange (Tadawul)", "XSAU", "SA") }, // Saudská Arábie
        { "AE_DFM", new ExchangeMappingInfo("Dubai Financial Market (DFM)", "XDFM", "DB") }, // SAE - Dubai (OpenFIGI 'DB')
        { "AE_ADX", new ExchangeMappingInfo("Abu Dhabi Securities Exchange (ADX)", "XADS", "AD") }, // SAE - Abu Dhabi
        { "QA", new ExchangeMappingInfo("Qatar Stock Exchange", "XQAT", "DSMH") }, // Katar (OpenFIGI 'DSMH' pro Doha) - XQAT je MIC, dříve DSM
        { "IL", new ExchangeMappingInfo("Tel Aviv Stock Exchange (TASE)", "XTAE", "TA") }, // Izrael
        { "EG", new ExchangeMappingInfo("Egyptian Exchange (EGX)", "XCAI", "EG") } // Egypt (OpenFIGI 'CA' pro Cairo, ale EG je země) - EG se zdá být OK pro OpenFIGI

        // Doplňte další dle potřeby. Ověřujte MIC kódy a OpenFIGI exchCodes pro přesnost.
        // Pro OpenFIGI exchCode je někdy potřeba trochu hledat nebo testovat,
        // např. na webu OpenFIGI v sekci Symbology nebo testováním s známými instrumenty.
    };

    public static ExchangeMappingInfo GetMappingBySuffix(string suffix)
    {
        if (SuffixMap.TryGetValue(suffix, out var mappingInfo))
        {
            return mappingInfo;
        }

        Console.WriteLine($"Varování: Pro sufix '{suffix}' nebylo nalezeno žádné předdefinované mapování.");

        return null;
    }
}
