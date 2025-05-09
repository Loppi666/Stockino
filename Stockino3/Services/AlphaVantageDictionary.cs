public static class AlphaData
{
    public static Dictionary<string, (string Suffix, string Currency)> alphaVantageData =
        new()
        {
            { "3579", (".L", "GBP") }, // SSY FUTURES LTD -  FREIGHT SCREEN
            { "21XX", (".DE", "EUR") }, // 21X
            { "24EX", ("N/A", "UNKNOWN") }, // 24 EXCHANGE
            { "360T", (".DE", "EUR") }, // 360T
            { "3DXE", (".DE", "EUR") }, // 3DXE
            { "360X", (".DE", "EUR") }, // 360X
            { "4AXE", (".JO", "ZAR") }, // 4 AFRICA EXCHANGE (PTY) LTD
            { "A2XX", (".JO", "ZAR") }, // A2X
            { "AACA", (".PA", "EUR") }, // CREDIT AGRICOLE CIB
            { "AAPA", ("N/A", "UNKNOWN") }, // ATHENS EXCHANGE - APA
            { "AATS", ("", "USD") }, // ASSENT ATS
            { "ABAN", (".MC", "EUR") }, // ABANCA
            { "ABFI", ("N/A", "UNKNOWN") }, // ALPHA BANK
            { "ABNA", (".AS", "EUR") }, // ABN AMRO BANK NV
            { "ABNC", (".AS", "EUR") }, // ABN AMRO CLEARING BANK
            { "ABSI", (".CO", "DKK") }, // ALM. BRAND BANK
            { "ACCX", (".L", "GBP") }, // ACCX
            { "ACEX", (".NS", "INR") }, // ACE DERIVATIVES AND COMMODITY EXCHANGE LTD
            { "ACXC", ("N/A", "UNKNOWN") }, // ACX CLEARING CORPORATION LTD.
            { "ACXL", ("N/A", "UNKNOWN") }, // ACX
            { "ADVT", ("", "USD") }, // ADVISE TECHNOLOGIES - APA TRANSPARENCY REPORTING
            { "AFDL", (".L", "GBP") }, // ABIDE FINANCIAL DRSP LIMITED APA
            { "AFET", (".BK", "THB") }, // AGRICULTURAL FUTURES EXCHANGE OF THAILAND
            { "AFEX", ("N/A", "UNKNOWN") }, // AFRINEX LIMITED
            { "AFSA", (".AS", "EUR") }, // AFS - OTF
            { "AFSI", (".AS", "EUR") }, // AFS - OTF - INTEREST RATE DERIVATIVES
            { "AFSL", (".AS", "EUR") }, // AFS - OTF - STRUCTURED PRODUCTS
            { "AFSO", (".AS", "EUR") }, // AFS - OTF - BONDS
            { "AFSX", (".AS", "EUR") }, // AFS - OTF - FX FORWARDS
            { "AFSE", (".AS", "EUR") }, // AFS E-VENUES B.V.
            { "AFTS", (".L", "GBP") }, // ACCESS FINTECH
            { "AGBP", (".MC", "EUR") }, // A AND G BANCA PRIVADA SAU
            { "AILT", ("N/A", "UNKNOWN") }, // ARRACO IRELAND LTD
            { "AIXE", (".SW", "CHF") }, // AIXECUTE
            { "AIXK", ("N/A", "UNKNOWN") }, // ASTANA INTERNATIONAL EXCHANGE LTD
            { "AKIS", (".MI", "EUR") }, // AKIS - BANCO BPM
            { "ALGO", (".L", "GBP") }, // BLOX
            { "ALLT", (".MC", "EUR") }, // ALLT - OTF
            { "ALPX", ("", "USD") }, // ALPHAX US
            { "ALSI", (".CO", "DKK") }, // AKTIESELSKABET ARBEJDERNES LANDSBANK
            { "AMLG", ("", "USD") }, // AMERICAN LEDGER ATS
            { "AMPX", (".L", "GBP") }, // ASSET MATCH PRIVATE EXCHANGE
            { "ANTS", (".L", "GBP") }, // ABBEY NATIONAL TREASURY SERVICES PLC
            { "ANZL", (".L", "GBP") }, // AUSTRALIA AND NEW ZEALAND BANKING GROUP LIMITED - SYSTEMATIC INTERNALISER
            { "ANLP", (".L", "GBP") }, // AUSTRALIA AND NEW ZEALAND BANKING GROUP LIMITED
            { "APAW", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG - APA
            { "APEX", (".SI", "SGD") }, // ASIA PACIFIC EXCHANGE
            { "APCL", (".SI", "SGD") }, // ASIA PACIFIC CLEAR
            { "APXL", (".AX", "AUD") }, // SYDNEY STOCK EXCHANGE LIMITED
            { "AQEU", (".PA", "EUR") }, // AQUIS EXCHANGE EUROPE
            { "AQEA", (".PA", "EUR") }, // AQUIS EXCHANGE EUROPE AUCTION ON DEMAND (AOD)
            { "AQED", (".PA", "EUR") }, // AQUIS EXCHANGE EUROPE NON DISPLAY ORDER BOOK (NDOB)
            { "AQSE", (".L", "GBP") }, // AQUIS STOCK EXCHANGE
            { "AQSD", (".L", "GBP") }, // AQSE MAIN MARKET (NON-EQUITY)
            { "AQSF", (".L", "GBP") }, // AQSE GROWTH MARKET (NON-EQUITY)
            { "AQSG", (".L", "GBP") }, // AQSE GROWTH MARKET (EQUITY)
            { "AQSL", (".L", "GBP") }, // AQSE MAIN MARKET (EQUITY)
            { "AQSN", (".L", "GBP") }, // AQSE TRADING (NON-EQUITY)
            { "AQST", (".L", "GBP") }, // AQSE TRADING (EQUITY)
            { "AQUA", ("", "USD") }, // AQUA EQUITIES L.P.
            { "AQXE", (".L", "GBP") }, // AQUIS EXCHANGE PLC
            { "AQXA", (".L", "GBP") }, // AQUIS EXCHANGE PLC AUCTION ON DEMAND (AOD)
            { "AQXD", (".L", "GBP") }, // AQUIS EXCHANGE PLC AMP NON DISPLAY ORDER BOOK
            { "EIXE", (".L", "GBP") }, // AQUIS EXCHANGE PLC AQUIS - EIX INFRASTRUCTURE BOND MARKET
            { "ARAX", (".L", "GBP") }, // ARRACO GLOBAL MARKETS LTD
            { "ARCH", (".L", "GBP") }, // ARCHAX
            { "ARDA", (".L", "GBP") }, // ARCHAX - DIGITAL ASSETS
            { "AREX", ("N/A", "UNKNOWN") }, // AREX - AUTOMATED RECEIVABLES EXCHANGE
            { "ARIA", (".L", "GBP") }, // ARIAN TRADING FACILITY
            { "ARKX", ("", "USD") }, // ARKONIS
            { "ARTX", ("N/A", "UNKNOWN") }, // ARTEX GLOBAL MARKETS AG
            { "ASEF", ("", "USD") }, // AEGIS SWAP EXECUTION FACILITY
            { "ASEX", ("N/A", "UNKNOWN") }, // ATHENS STOCK EXCHANGE
            { "ENAX", ("N/A", "UNKNOWN") }, // ATHENS EXCHANGE ALTERNATIVE MARKET
            { "EUAX", ("N/A", "UNKNOWN") }, // ATHENS EXCHANGE EUAS MARKET
            { "HOTC", ("N/A", "UNKNOWN") }, // HELLENIC EXCHANGE OTC MARKET
            { "XADE", ("N/A", "UNKNOWN") }, // ATHENS EXCHANGE S.A. DERIVATIVES MARKET
            { "XATH", ("N/A", "UNKNOWN") }, // ATHENS EXCHANGE S.A. CASH MARKET
            { "XIPO", ("N/A", "UNKNOWN") }, // HELEX ELECTRONIC BOOK BUILDING
            { "ATAD", (".PR", "CZK") }, // ATADEL FUNDS
            { "ATDF", ("", "USD") }, // AUTOMATED TRADING DESK FINANCIAL SERVICES, LLC
            { "ATHL", ("N/A", "UNKNOWN") }, // ATHLOS CAPITAL INVESTMENT SERVICES LTD
            { "ATLB", (".L", "GBP") }, // BRAEMAR SECURITIES LTD
            { "BRAE", (".L", "GBP") }, // BRAEMAR SECURITIES LTD - OTF
            { "ATLN", ("N/A", "UNKNOWN") }, // ATONLINE LIMITED
            { "ATSA", (".TO", "CAD") }, // ALPHA VENTURE PLUS
            { "AURB", (".PA", "EUR") }, // AUREL
            { "AURO", (".PA", "EUR") }, // AUREL - OTF
            { "GFPO", (".PA", "EUR") }, // GFI PARIS - OTF
            { "AUTX", (".L", "GBP") }, // AUTILLA
            { "AUTB", (".L", "GBP") }, // AUTILLA - BASE METALS
            { "AUTP", (".L", "GBP") }, // AUTILLA - PRECIOUS METALS
            { "AWBX", (".AX", "AUD") }, // AUSTRALIAN WHEAT BOARD
            { "AWEX", (".AX", "AUD") }, // AUSTRALIAN WOOL EXCHANGE
            { "AXSI", (".HE", "EUR") }, // ALEXANDRIA PANKKIIRILIIKE OYJ
            { "BAAD", (".DE", "EUR") }, // BAADER BANK
            { "BACE", ("N/A", "UNKNOWN") }, // BOLSA DE CEREALES DE BUENOS AIRES
            { "BAIK", (".L", "GBP") }, // BAIKAL
            { "BAIP", (".HK", "HKD") }, // BANK OF AMERICA MERRILL LYNCH EQUITY SWAP - INTERNAL PRICE SOURCE
            { "BACR", (".HK", "HKD") }, // BANK OF AMERICA SECURITIES - CENTRAL RISK
            { "BAEP", (".HK", "HKD") }, // BANK OF AMERICA MERRILL LYNCH EQUITY SWAP - EXTERNAL PRICE SOURCE
            { "BASP", (".HK", "HKD") }, // BANK OF AMERICA SECURITIES EQUITY SWAP - SYNTHETIC PRICE SOURCE
            { "BAJD", (".T", "JPY") }, // BANK OF AMERICA MERRILL LYNCH - JAPAN INSTINCT X
            { "BALT", (".L", "GBP") }, // THE BALTIC EXCHANGE
            { "BLTX", (".L", "GBP") }, // BALTEX - FREIGHT DERIVATIVES MARKET
            { "BAML", ("", "USD") }, // BANK OF AMERICA - MERRILL LYNCH INSTINCT X ATS
            { "MLCO", ("", "USD") }, // BANK OF AMERICA - MERRILL LYNCH OTC
            { "MLVX", ("", "USD") }, // BANK OF AMERICA - MERRILL LYNCH VWAP CROSS
            { "BAMP", ("", "USD") }, // MERR POOL XLN
            { "BAMX", ("", "USD") }, // BANK OF AMERICA - MERRILL LYNCH GCX
            { "BANA", (".L", "GBP") }, // BANK OF AMERICA, NATIONAL ASSOCIATION
            {
                "BASI", (".L", "GBP")
            }, // BANK OF AMERICA, NATIONAL ASSOCIATION - LONDON BRANCH OFFICE - SYSTEMATIC INTERNALISER
            { "BOAL", (".L", "GBP") }, // BANK OF AMERICA, NATIONAL ASSOCIATION - LONDON BRANCH OFFICE
            { "BAPA", (".L", "GBP") }, // BLOOMBERG - APA
            { "BAPE", (".AS", "EUR") }, // BLOOMBERG DATA REPORTING SERVICES B.V. - APA
            { "BAPX", ("N/A", "UNKNOWN") }, // BALTPOOL
            { "BARX", ("", "USD") }, // BARCLAYS ATS
            { "BARD", ("", "USD") }, // BARCLAYS FX - TRADING
            { "BARL", ("", "USD") }, // BARCLAYS LIQUID MARKETS
            { "BBOK", ("", "USD") }, // BARCLAYS SINGLE DEALER PLATFORM
            { "BCDX", ("", "USD") }, // BARCLAYS DIRECT EX ATS
            { "BASE", (".HK", "HKD") }, // BANK OF AMERICA MERRILL LYNCH - SWAP EXECUTIONS
            { "BASX", (".T", "JPY") }, // BANK OF AMERICA MERRILL LYNCH - SIMPLEX BLAST X
            { "BBIE", ("N/A", "UNKNOWN") }, // BARCLAYS BANK IRELAND PLC
            { "BBIS", ("N/A", "UNKNOWN") }, // BARCLAYS BANK IRELAND PLC - SYSTEMATIC INTERNALISER
            { "BBLX", (".SI", "SGD") }, // BONDBLOX EXCHANGE
            { "BBSF", ("", "USD") }, // BLOOMBERG SEF LLC
            { "BBSN", ("", "USD") }, // BLOOMBERG SEF LLC - SECURITY-BASED SWAP EXECUTION FACILITY (SBSEF)
            { "BBSX", (".L", "GBP") }, // BB SECURITIES LTD
            { "BBVA", (".MC", "EUR") }, // BANCO BILBAO VIZCAYA ARGENTARIA S.A
            { "BBVX", (".L", "GBP") }, // BANCO BILBAO VIZCAYA ARGENTARIA S.A. - UK
            { "BCEE", ("N/A", "UNKNOWN") }, // BANQUE ET CAISSE D'EPARGNE DE L'ETAT, LUXEMBOURG - BCEE
            { "BCFS", ("N/A", "UNKNOWN") }, // BOLSA DE COMERCIO DE SANTA FE
            { "XMVL", ("N/A", "UNKNOWN") }, // MERCADO DE VALORES DEL LITORAL S.A.
            { "BCMA", (".MC", "EUR") }, // BANCA MARCH S.A.
            { "BCMM", (".SA", "BRL") }, // BOLSA DE CEREAIS E MERCADORIAS DE MARINGÁ
            { "BCRM", (".L", "GBP") }, // CBOE EUROPE REGULATED MARKETS
            { "BARK", (".L", "GBP") }, // CBOE EUROPE - REGULATED MARKET DARK BOOK
            { "BARO", (".L", "GBP") }, // CBOE EUROPE - REGULATED MARKET OFF BOOK
            { "BART", (".L", "GBP") }, // CBOE EUROPE - REGULATED MARKET INTEGRATED BOOK
            { "BCSC", ("N/A", "UNKNOWN") }, // BROKERCREDITSERVICE (CYPRUS) LIMITED
            { "BCSE", ("N/A", "UNKNOWN") }, // BELARUS CURRENCY AND STOCK EXCHANGE
            { "BCSL", (".L", "GBP") }, // BARCLAYS CAPITAL SECURITIES LIMITED
            { "BCSI", (".L", "GBP") }, // BARCLAYS CAPITAL SECURITIES LIMITED - SYSTEMATIC INTERNALISER
            { "BCXE", (".L", "GBP") }, // CBOE EUROPE EQUITIES
            { "BATD", (".L", "GBP") }, // CBOE EUROPE - BXE DARK ORDER BOOK
            { "BATE", (".L", "GBP") }, // CBOE EUROPE - BXE ORDER BOOKS
            { "BATF", (".L", "GBP") }, // CBOE EUROPE - BXE OFF-BOOK
            { "BATP", (".L", "GBP") }, // CBOE EUROPE - BXE PERIODIC
            { "BOTC", (".L", "GBP") }, // OFF EXCHANGE IDENTIFIER FOR OTC TRADES REPORTED TO CBOE EUROPE
            { "CHID", (".L", "GBP") }, // CBOE EUROPE - CXE DARK ORDER BOOK
            { "CHIO", (".L", "GBP") }, // CBOE EUROPE - CXE OFF-BOOK
            { "CHIX", (".L", "GBP") }, // CBOE EUROPE - CXE ORDER BOOKS
            { "CHIY", (".L", "GBP") }, // BATS CHI-X EUROPE LIMITED - CHI-CLEAR
            { "LISX", (".L", "GBP") }, // CBOE  EUROPE - LIS SERVICE
            { "XWAP", (".L", "GBP") }, // CBOE EUROPE EQUITIES - LONDON
            { "BDPL", ("N/A", "UNKNOWN") }, // BANQUE DEGROOF PETERCAM LUXEMBOURG S.A.
            { "BDSK", ("N/A", "UNKNOWN") }, // DSK BANK EAD
            { "BEAM", ("N/A", "EUR") }, // MTS ASSOCIATED MARKETS
            { "BMTS", ("N/A", "EUR") }, // MTS BELGIUM
            { "MTSD", ("N/A", "EUR") }, // MTS DENMARK
            { "MTSF", ("N/A", "EUR") }, // MTS FINLAND
            { "BEBG", ("N/A", "UNKNOWN") }, // BULGARIAN ENERGY TRADING PLATFORM
            { "BEEX", (".BK", "THB") }, // BOND ELECTRONIC EXCHANGE
            { "BEIS", (".MI", "EUR") }, // BANCA ETICA
            { "BELB", ("N/A", "EUR") }, // BELFIUS BANK NV/SA
            { "BELF", ("N/A", "EUR") }, // BELFIUS BANK NV/SA FIXED INCOME
            { "BESA", ("N/A", "UNKNOWN") }, // BITSTAMP EUROPE
            { "BETP", (".T", "JPY") }, // BLOOMBERG TRADEBOOK JAPAN LIMITED
            { "BETX", (".L", "GBP") }, // BET OTC BILAT COMMODITY DERIVATIVES
            { "BFEX", ("N/A", "UNKNOWN") }, // BAHRAIN FINANCIAL EXCHANGE
            { "BFPT", ("N/A", "UNKNOWN") }, // BANCO FINANTIA S.A.
            { "BFSD", ("N/A", "UNKNOWN") }, // BITSTAMP DERIVATIVES EXCHANGE
            { "BGCA", (".AX", "AUD") }, // BGC PARTNERS (AUSTRALIA) PTY LTD
            { "BGCF", ("", "USD") }, // BGC FINANCIAL INC
            { "BGCD", ("", "USD") }, // BGC DERIVATIVE MARKETS L.P.
            { "FNCS", ("", "USD") }, // FENICS - US TREASURIES
            { "FNFT", ("", "USD") }, // FENICS FUTURES
            { "FNFX", ("", "USD") }, // FENICS FX ECN
            { "FNXB", ("", "USD") }, // FENICS INVITATIONS
            { "BGCI", (".L", "GBP") }, // BGC BROKERS LP
            { "BGCB", (".L", "GBP") }, // BGC BROKERS LP - TRAYPORT
            { "BGCM", (".L", "GBP") }, // BGC BROKERS LP - MTF
            { "BGCO", (".L", "GBP") }, // BGC BROKERS LP - OTF
            { "BGCJ", (".T", "JPY") }, // BGC SHOKEN KAISHA LTD – ETP
            { "BGHX", ("N/A", "UNKNOWN") }, // BALKAN GAS HUB EAD
            { "BGLU", ("N/A", "UNKNOWN") }, // BGL BNP PARIBAS
            { "BGSG", (".SI", "SGD") }, // BGC PARTNERS SINGAPORE RMO
            { "BGSI", (".DE", "EUR") }, // BERENBERG
            { "BGFI", (".DE", "EUR") }, // BERENBERG FIXED INCOME
            { "BGFX", (".DE", "EUR") }, // BERENBERG FX
            { "BGUK", (".L", "GBP") }, // BERENBERG  UK
            { "BGFU", (".L", "GBP") }, // BERENBERG FIXED INCOME UK
            { "BHSF", ("", "USD") }, // CBOE SEF, LLC
            { "BHWA", (".WA", "PLN") }, // BANK HANDLOWY W WARSZAWIE S.A.
            { "BIDS", ("", "USD") }, // BIDS TRADING L.P.
            { "BILT", ("N/A", "UNKNOWN") }, // OFF-EXCHANGE TRANSACTIONS - LISTED AND UNLISTED INSTRUMENTS
            { "BILU", ("N/A", "UNKNOWN") }, // BANQUE INTERNATIONALE A LUXEMBOURG S.A.
            { "BINV", (".DE", "EUR") }, // BOND INVEST
            { "BIVA", (".MX", "MXN") }, // BOLSA INSTITUCIONAL DE VALORES
            { "BJSE", (".SS", "CNY") }, // BEIJING STOCK EXCHANGE
            { "BKBR", ("N/A", "EUR") }, // BNY MELLON S.A./N.V. - BRUSSELS BRANCH
            { "BKBF", ("N/A", "EUR") }, // BNY MELLON S.A./N.V. - BRUSSELS BRANCH - SYSTEMATIC INTERNALISER
            { "BKDM", ("N/A", "UNKNOWN") }, // BNY MELLON MARKETS EUROPE LIMITED
            { "BKKT", ("", "USD") }, // BAKKT
            { "BKLN", (".L", "GBP") }, // THE BANK OF NEW YORK MELLON - LONDON BRANCH
            { "BKLF", (".L", "GBP") }, // THE BANK OF NEW YORK MELLON
            { "BKSK", ("N/A", "UNKNOWN") }, // BKS BANK AG
            { "BLBB", (".DE", "EUR") }, // BAYERNLB
            { "BDEA", (".DE", "EUR") }, // BAYERNLB - IDEAL FX
            { "BLBS", (".DE", "EUR") }, // BAYERNLB - BONDS MARKET
            { "BLEQ", (".DE", "EUR") }, // BAYERNLB - EQUITIES MARKET
            { "BLFX", (".DE", "EUR") }, // BAYERNLB - FX DERIVATIVES MARKET
            { "BLIQ", (".DE", "EUR") }, // BAYERNLB - LIQP BONDS MARKET
            { "BSFX", (".DE", "EUR") }, // BAYERNLB - FX HANDEL
            { "BLEV", (".AX", "AUD") }, // BLOCK EVENT
            { "BLPX", ("N/A", "EUR") }, // BELGIAN POWER EXCHANGE
            { "BLTD", ("", "USD") }, // BLOOMBERG TRADEBOOK LLC
            { "BLUE", ("", "USD") }, // PRO SECURITIES ATS
            { "BLUX", ("N/A", "UNKNOWN") }, // BANQUE DE LUXEMBOURG
            { "BLXA", (".AX", "AUD") }, // INSTINET BLX (AU)
            { "BMCM", (".L", "GBP") }, // BMO CAPITAL MARKETS LIMITED
            { "BMEX", (".MC", "EUR") }, // BME - BOLSAS Y MERCADOS ESPANOLES
            { "BMCL", (".MC", "EUR") }, // BME CLEARING S.A.
            { "BMEA", (".MC", "EUR") }, // BME - APA
            { "DMAD", (".MC", "EUR") }, // BOLSA DE MADRID - DARK MIDPOINT
            { "GROW", (".MC", "EUR") }, // BME GROWTH MARKET
            { "MABX", (".MC", "EUR") }, // BME MTF EQUITY (IIC AND ECR SEGMENTS)
            { "MARF", (".MC", "EUR") }, // MERCADO ALTERNATIVO DE RENTA FIJA (MARF)
            { "MERF", (".MC", "EUR") }, // MERCADO ELECTRONICO DE RENTA FIJA
            { "SBAR", (".MC", "EUR") }, // BOLSA DE BARCELONA RENTA FIJA
            { "SBIL", (".MC", "EUR") }, // BOLSA DE BILBAO RENTA FIJA
            { "SCLE", (".MC", "EUR") }, // BME SCALEUP
            { "SEND", (".MC", "EUR") }, // SEND - SISTEMA ELECTRONICO DE NEGOCIACION DE DEUDA
            { "XBAR", (".MC", "EUR") }, // BOLSA DE BARCELONA
            { "XBIL", (".MC", "EUR") }, // BOLSA DE VALORES DE BILBAO
            { "XDRF", (".MC", "EUR") }, // AIAF - MERCADO DE RENTA FIJA
            { "XLAT", (".MC", "EUR") }, // MERCADO DE VALORES LATINOAMERICANOS (LATIBEX SMN)
            { "XMAD", (".MC", "EUR") }, // BOLSA DE MADRID
            { "XMCE", (".MC", "EUR") }, // MERCADO CONTINUO ESPANOL - CONTINUOUS MARKET
            { "XMEF", (".MC", "EUR") }, // MEFF RENTA FIJA
            { "XMFX", (".MC", "EUR") }, // MEFF FX FINANCIAL DERIVATIVES
            { "XMPW", (".MC", "EUR") }, // MEFF POWER DERIVATIVES
            { "XMRV", (".MC", "EUR") }, // MEFF FINANCIAL DERIVATIVES
            { "XVAL", (".MC", "EUR") }, // BOLSA DE VALENCIA
            { "BMFX", ("N/A", "UNKNOWN") }, // SIBIU MONETARY- FINANCIAL AND COMMODITIES EXCHANGE
            { "BMFA", ("N/A", "UNKNOWN") }, // BMFMS-ATS
            { "BMFM", ("N/A", "UNKNOWN") }, // DERIVATIVES REGULATED MARKET - BMFMS
            { "SBMF", ("N/A", "UNKNOWN") }, // SPOT REGULATED MARKET - BMFMS
            { "BMLB", (".L", "GBP") }, // BANK OF MONTREAL - LONDON BRANCH
            {
                "BMLI", ("N/A", "UNKNOWN")
            }, // BANK OF AMERICA MERRILL LYNCH INTERNATIONAL BANK DESIGNATED ACTIVITY COMPANY
            {
                "BMLS", ("N/A", "UNKNOWN")
            }, // BANK OF AMERICA MERRILL LYNCH INTERNATIONAL BANK DESIGNATED ACTIVITY COMPANY - SYSTEMATIC INTERNALISER
            {
                "BMLX", ("N/A", "UNKNOWN")
            }, // BANK OF AMERICA MERRILL LYNCH INTERNATIONAL BANK DESIGNATED ACTIVITY COMPANY
            {
                "BMSI", ("N/A", "UNKNOWN")
            }, // BANK OF AMERICA MERRILL LYNCH INTERNATIONAL BANK DESIGNATED ACTIVITY COMPANY
            { "BMTF", (".L", "GBP") }, // BLOOMBERG TRADING FACILITY LIMITED
            { "BNDS", ("", "USD") }, // BONDS.COM, INC.
            { "BNLD", (".MI", "EUR") }, // BANCA NAZIONALE DEL LAVORO SPA
            { "BNPA", (".PA", "EUR") }, // BNP PARIBAS ARBITRAGE SNC
            { "BNPC", ("", "USD") }, // BNPP CORTEX ATS
            { "BNPF", ("N/A", "EUR") }, // BNP PARIBAS FORTIS SA/NV
            { "BNPH", ("", "USD") }, // BNPP CORTEX EQUITIES
            { "BNPL", (".L", "GBP") }, // BNP PARIBAS SA LONDON BRANCH
            { "BNPP", (".WA", "PLN") }, // BANK BGZ BNP PARIBAS S.A.
            { "BNPS", (".PA", "EUR") }, // BNP PARIBAS SA
            { "BNPX", (".T", "JPY") }, // BNP PARIBAS ALTERNATIVE TRADING SYSTEM
            { "BNSX", (".TO", "CAD") }, // THE BANK OF NOVA SCOTIA
            { "BNYC", ("", "USD") }, // CONVERGEX
            { "NYFX", ("", "USD") }, // MILLENNIUM
            { "VTEX", ("", "USD") }, // VORTEX
            { "BOAT", (".L", "GBP") }, // CINNOBER BOAT
            { "BOCF", (".DE", "EUR") }, // BANK OF CHINA LIMITED - FRANKFURT BRANCH
            { "BOFS", (".L", "GBP") }, // BANK OF SCOTLAND PLC
            { "BOSC", (".L", "GBP") }, // BONDSCAPE
            { "BOSS", ("", "USD") }, // BRUCE ATS
            { "BOVA", ("N/A", "UNKNOWN") }, // BOLSA DE CORREDORES - BOLSA DE VALORES
            { "BOVM", (".SA", "BRL") }, // BOLSA DE VALORES MINAS-ESPÍRITO SANTO-BRASÍLIA
            { "BPAG", (".DE", "EUR") }, // BANK PICTET & CIE (EUROPE) AG
            { "BPAS", (".MI", "EUR") }, // BANCA PASSADORE
            { "BPKO", (".WA", "PLN") }, // PKO BANK POLSKI S.A.
            { "BPLC", (".L", "GBP") }, // BARCLAYS BANK PLC
            { "BBSI", (".L", "GBP") }, // BARCLAYS BANK PLC - SYSTEMATIC INTERNALISER
            { "BPOL", ("", "USD") }, // BLOOMBERG BPOOL
            { "BPSX", (".PA", "EUR") }, // BNP PARIBAS SECURITIES SERVICES
            { "BPXX", (".L", "GBP") }, // BPX MARKETS LIMITED
            { "BRDE", ("N/A", "UNKNOWN") }, // BRD - GROUPE SOCIETE GENERALE S.A.
            { "BRDL", ("N/A", "UNKNOWN") }, // BRD - GROUPE SOCIETE GENERALE S.A. - LIQUIDITY PROVIDER
            { "BRDS", ("N/A", "UNKNOWN") }, // BRD - GROUPE SOCIETE GENERALE S.A. - SYSTEMATIC INTERNALISER
            { "BREA", (".MI", "EUR") }, // BANCA REALE
            { "BRED", (".PA", "EUR") }, // BRED BANQUE POPULAIRE
            { "BRGA", (".L", "GBP") }, // BRYAN GARNIER AND CO LIMITED
            { "BRIX", (".SA", "BRL") }, // BRAZILIAN ENERGY EXCHANGE
            { "BRNX", (".L", "GBP") }, // BERNSTEIN CROSS (BERN-X)
            { "BSAB", (".MC", "EUR") }, // BANCO DE SABADELL, S.A.
            { "BSEX", ("N/A", "UNKNOWN") }, // BAKU STOCK EXCHANGE
            { "BSLB", (".L", "GBP") }, // BANCO SANTANDER, LONDON BRANCH
            { "BSPL", (".L", "GBP") }, // BNP PARIBAS SECURITIES SERVICES LONDON BRANCH
            { "BSTX", ("", "USD") }, // BOSTON SECURITY TOKEN EXCHANGE LLC
            { "BTAM", (".AS", "EUR") }, // CME AMSTERDAM B.V.
            { "BTQE", (".AS", "EUR") }, // CME AMSTERDAM B.V. - RFQ TRADING PROTOCOL
            { "BTBS", (".SI", "SGD") }, // BLOOMBERG TRADEBOOK SINGAPORE PTE LTD
            { "BTEC", ("", "USD") }, // ICAP ELECTRONIC BROKING (US)
            { "BTEQ", ("", "USD") }, // BROKERTEC AMERICAS LLC - RFQ PLATFORM
            { "ICSU", ("", "USD") }, // ICAP SEF (US)  LLC.
            { "BTEE", (".L", "GBP") }, // BROKERTEC EUROPE LIMITED - ALL MARKETS
            { "BTQG", (".L", "GBP") }, // BROKERTEC EUROPE LIMITED - RFQ TRADING PROTOCOL
            { "EBSM", (".L", "GBP") }, // EBS MTF - CLOB - FOR THE TRADING OF FX PRODUCTS
            { "EBSX", (".L", "GBP") }, // EBS MTF
            { "BTFE", (".AS", "EUR") }, // BLOOMBERG TRADING FACILITY B.V.
            { "BTLX", (".L", "GBP") }, // BTL OTC BILAT COMMODITY DERIVATIVES
            { "BTNL", ("", "USD") }, // BITNOMIAL
            { "BTRL", ("N/A", "UNKNOWN") }, // BANCA TRANSILVANIA S.A.
            { "BVCA", ("N/A", "UNKNOWN") }, // CARACAS STOCK EXCHANGE
            { "XCAR", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES DE CARACAS
            { "BVMF", (".SA", "BRL") }, // B3 S.A. - BRASIL BOLSA BALCAO
            { "CETI", (".SA", "BRL") }, // CETIP S.A. - MERCADOS ORGANIZADOS
            { "BVUR", ("N/A", "UNKNOWN") }, // BOLSA ELECTRONICA DE VALORES DEL URUGUAY
            { "BXDA", (".SW", "CHF") }, // BX DIGITAL
            { "CABK", (".MC", "EUR") }, // CAIXABANK
            { "CABV", (".AS", "EUR") }, // CME AMSTERDAM B.V. - APA
            { "CALH", ("", "USD") }, // CLSA AMERICAS - LIQUIDITY HUB
            { "CAND", (".TO", "CAD") }, // CANDEAL.CA INC
            { "CANX", (".TO", "CAD") }, // CANNEX FINANCIAL EXCHANGE LTS
            { "CAPI", (".MC", "EUR") }, // CAPI - OTF
            { "CMAP", (".MC", "EUR") }, // CAPI - APPROVED PUBLICATION ARRANGEMENT
            { "CAPL", (".WA", "PLN") }, // CREDIT AGRICOLE BANK POLSKA S.A.
            { "CASI", (".ST", "SEK") }, // CARNEGIE INVESTMENT BANK AB
            { "CAST", ("", "USD") }, // FORECASTEX, LLC
            { "CATS", (".DE", "EUR") }, // CATS
            { "CAVD", (".AS", "EUR") }, // CAVENDISH MARKETS B.V.
            { "CAZE", (".L", "GBP") }, // THE CAZENOVE MTF
            { "CBAE", (".AS", "EUR") }, // COMMONWEALTH BANK OF AUSTRALIA (EUROPE) N.V.
            { "CBAL", (".L", "GBP") }, // COMMONWEALTH BANK OF AUSTRALIA - LONDON BRANCH
            { "CBKA", (".DE", "EUR") }, // COMMERZBANK AG
            { "CBKC", (".DE", "EUR") }, // COMMERZBANK  COMMODITY DERIVATIVES
            { "CBKD", (".DE", "EUR") }, // COMMERZBANK EQUITY DERIVATIVES
            { "CBKE", (".DE", "EUR") }, // COMMERZBANK EQUITY
            { "CBKF", (".DE", "EUR") }, // COMMERZBANK COMMANDER
            { "CBKG", (".DE", "EUR") }, // COMMERZBANK FIXED INCOME
            { "CBKS", (".DE", "EUR") }, // COMMERZBANK INTEREST RATE SWAPS
            { "CBMS", (".JO", "ZAR") }, // CBM SARB
            { "CBNL", (".L", "GBP") }, // CITIBANK N.A. LONDON
            { "CBOE", (".SW", "CHF") }, // CBOE FX NDFS
            { "CBSK", ("N/A", "UNKNOWN") }, // CESKOSLOVENSKA OBCHODNA BANKA, A.S.
            { "CCEU", (".L", "GBP") }, // CITADEL CONNECT EUROPE
            { "CCEX", ("N/A", "UNKNOWN") }, // CASPY COMMODITY EXCHANGE
            { "CCFE", ("", "USD") }, // CHICAGO CLIMATE FUTURES EXCHANGE
            { "CCFX", (".SS", "CNY") }, // CHINA FINANCIAL FUTURES EXCHANGE
            { "CCLX", ("N/A", "UNKNOWN") }, // FINESTI S.A.
            { "CCML", (".L", "GBP") }, // CONTINENTAL CAPITAL MARKETS LIMITED - OTF
            { "CCMS", (".SW", "CHF") }, // CONTINENTAL CAPITAL MARKETS S.A.
            { "CCMX", ("", "USD") }, // CARTAX
            { "CCO2", (".L", "GBP") }, // CANTORCO2E.COM LIMITED
            { "CCRM", (".AS", "EUR") }, // CBOE EUROPE REGULATED MARKETS (NL)
            { "BARU", (".AS", "EUR") }, // CBOE EUROPE - REGULATED MARKET DARK BOOK (NL)
            { "BEUO", (".AS", "EUR") }, // CBOE EUROPE - REGULATED MARKET OFF BOOK (NL)
            { "BEUT", (".AS", "EUR") }, // CBOE EUROPE - REGULATED MARKET INTEGRATED BOOK (NL)
            { "CEDX", (".AS", "EUR") }, // CBOE EUROPE DERIVATIVES
            { "CCXE", (".AS", "EUR") }, // CBOE EUROPE EQUITIES - EUROPEAN EQUITIES (NL)
            { "BEUD", (".AS", "EUR") }, // CBOE EUROPE - BXE DARK ORDER BOOK (NL)
            { "BEUE", (".AS", "EUR") }, // CBOE EUROPE - BXE ORDER BOOKS (NL)
            { "BEUF", (".AS", "EUR") }, // CBOE EUROPE - BXE OFF-BOOK (NL)
            { "BEUP", (".AS", "EUR") }, // CBOE EUROPE - DXE PERIODIC (NL)
            { "CAPA", (".AS", "EUR") }, // CBOE EUROPE - APA (NL)
            { "CEUD", (".AS", "EUR") }, // CBOE EUROPE - DXE DARK ORDER BOOK (NL)
            { "CEUE", (".AS", "EUR") }, // CBOE EUROPE - CXE ORDER BOOKS (NL)
            { "CEUO", (".AS", "EUR") }, // CBOE EUROPE - DXE OFF-BOOK (NL)
            { "CEUX", (".AS", "EUR") }, // CBOE EUROPE - DXE ORDER BOOKS (NL)
            { "LISZ", (".AS", "EUR") }, // CBOE EUROPE - LIS SERVICE (NL)
            { "VWAP", (".AS", "EUR") }, // CBOE EUROPE EQUITIES - NL
            { "CDED", ("", "USD") }, // CITADEL SECURITIES
            { "CDEL", ("", "USD") }, // CITADEL SECURITIES ATS
            { "CDNA", ("", "USD") }, // NORTH AMERICAN DERIVATIVES EXCHANGE, INC.
            { "CDSL", (".NS", "INR") }, // CLEARCORP DEALING SYSTEMS (INDIA) LTD.
            { "ASTR", (".NS", "INR") }, // CLEARCORP DEALING SYSTEMS INDIA LIMITED - ASTROID
            { "FXCL", (".NS", "INR") }, // CLEARCORP DEALING SYSTEMS INDIA LIMITED - FX-CLEAR
            { "FXSW", (".NS", "INR") }, // CLEARCORP DEALING SYSTEMS INDIA LIMITED - FX-SWAP
            { "CECA", (".MC", "EUR") }, // CECABANK
            { "CEPL", ("N/A", "UNKNOWN") }, // CITIBANK EUROPE PLC
            { "CEPU", (".L", "GBP") }, // CITIBANK EUROPE PLC - LONDON BRANCH
            { "CFIC", (".L", "GBP") }, // CHINAFICC
            { "CFIF", ("N/A", "UNKNOWN") }, // CREDIT FINANCIER INVEST (CFI) LTD
            { "CFIL", ("N/A", "UNKNOWN") }, // CANTOR FITZGERALD IRELAND LIMITED
            { "CFIM", ("", "USD") }, // CBOE FIXED INCOME MARKETS, LLC
            { "CFTW", (".TW", "TWD") }, // CROSSFINDER TAIWAN
            { "CGIT", (".MI", "EUR") }, // CASSA DI COMPENSAZIONE E GARANZIA SPA
            {
                "CGCM", (".MI", "EUR")
            }, // CASSA DI COMPENSAZIONE E GARANZIA SPA - COLLATERALIZED MONEY MARKET GUARANTEE SERVICE
            { "CGDB", (".MI", "EUR") }, // CASSA DI COMPENSAZIONE E GARANZIA SPA - BONDS CCP SERVICE
            { "CGEB", (".MI", "EUR") }, // CASSA DI COMPENSAZIONE E GARANZIA SPA - EURO BONDS CCP SERVICE
            {
                "CGGD", (".MI", "EUR")
            }, // CASSA DI COMPENSAZIONE E GARANZIA SPA - CCP AGRICULTURAL COMMODITY DERIVATIVES
            { "CGND", (".MI", "EUR") }, // CASSA DI COMPENSAZIONE E GARANZIA SPA - CCP ENERGY DERIVATIVES
            { "CGQD", (".MI", "EUR") }, // CASSA DI COMPENSAZIONE E GARANZIA SPA - CCP EQUITY DERIVATIVES
            { "CGQT", (".MI", "EUR") }, // CASSA DI COMPENSAZIONE E GARANZIA SPA - EQUITY CCP SERVICE
            { "CGTR", (".MI", "EUR") }, // CASSA DI COMPENSAZIONE E GARANZIA SPA - TRIPARTY REPO CCP SERVICE
            { "CGMA", (".AX", "AUD") }, // CITI MATCH AUSTRALIA
            { "CGMD", (".DE", "EUR") }, // CITIGROUP GLOBAL MARKETS EUROPE AG
            { "CGEC", (".DE", "EUR") }, // CITIGROUP GLOBAL MARKETS  EUROPE AG - EMEA LIQUIDITY HUB
            { "CGEE", (".DE", "EUR") }, // CITI MATCH DE CONTRA LIQUIDITY
            { "CGET", (".DE", "EUR") }, // CITIGROUP GLOBAL MARKETS  EUROPE AG - EMEA TRADING
            { "CGMG", (".L", "GBP") }, // CITIGROUP GLOBAL MARKETS EUROPE AG - LONDON BRANCH
            { "CGMH", (".HK", "HKD") }, // CITI MATCH - HK
            { "CGMI", ("", "USD") }, // CITIGROUP GLOBAL MARKETS
            { "CBLC", ("", "USD") }, // CITIBLOC
            { "CICX", ("", "USD") }, // CITI CROSS
            { "CIOI", ("", "USD") }, // CIOI
            { "CORE", ("", "USD") }, // CITIGROUP AGENCY OPTION AND EQUITIES ROUTING ENGINE
            { "LQFI", ("", "USD") }, // CITI LIQUIFI
            { "ONEC", ("", "USD") }, // CITI-ONE
            { "CGML", (".L", "GBP") }, // CITIGROUP GLOBAL MARKETS LIMITED
            { "CGMC", (".L", "GBP") }, // CITIGROUP GLOBAL MARKETS  LIMITED - EMEA LIQUIDITY HUB
            { "CGME", (".L", "GBP") }, // CITI MATCH - GB
            { "CGMT", (".L", "GBP") }, // CITIGROUP GLOBAL MARKETS  LIMITED - EMEA TRADING
            { "CGMU", (".L", "GBP") }, // CITI MATCH GB CONTRA LIQUIDITY
            { "CGMX", (".MX", "MXN") }, // CITI MEXICO RPI (RETAIL PRICE IMPROVEMENT)
            { "CGXS", ("", "USD") }, // ONECHRONOS
            { "CHEV", (".L", "GBP") }, // CA CHEUVREUX
            { "BLNK", (".L", "GBP") }, // BLINK MTF
            { "CHIA", (".AX", "AUD") }, // CBOE AUSTRALIA
            { "CXAB", (".AX", "AUD") }, // CBOE AUSTRALIA - BIDS BLOCK TRADE VENUE
            { "CXAC", (".AX", "AUD") }, // CBOE AUSTRALIA - LIMIT VENUE
            { "CXAE", (".AX", "AUD") }, // CBOE AUSTRALIA - ETFS
            { "CXAF", (".AX", "AUD") }, // CBOE AUSTRALIA MARKET PEG (FARPOINT) VENUE
            { "CXAI", (".AX", "AUD") }, // CBOE AUSTRALIA - BIDS PRICE IMPROVEMENT VENUE
            { "CXAM", (".AX", "AUD") }, // CBOE AUSTRALIA MOC
            { "CXAN", (".AX", "AUD") }, // CBOE AUSTRALIA PRIMARY PEG (NEARPOINT) VENUE
            { "CXAP", (".AX", "AUD") }, // CBOE AUSTRALIA MID-POINT VENUE
            { "CXAQ", (".AX", "AUD") }, // CBOE AUSTRALIA - QUOTED MANAGED FUNDS
            { "CXAR", (".AX", "AUD") }, // CBOE AUSTRALIA - TRANSFERABLE CUSTODY RECEIPT MARKET
            { "CXAV", (".AX", "AUD") }, // CBOE AUSTRALIA VWAP
            { "CXAW", (".AX", "AUD") }, // CBOE AUSTRALIA - WARRANTS
            { "CHIC", (".TO", "CAD") }, // CHI-X CANADA ATS
            { "XCX2", (".TO", "CAD") }, // CX2
            { "CHIE", (".SI", "SGD") }, // CHI-EAST
            { "CHIJ", (".T", "JPY") }, // CBOE JAPAN - ALPHA
            { "CHIS", (".T", "JPY") }, // CBOE JAPAN  - SELECT
            { "CHIV", (".T", "JPY") }, // CBOE JAPAN - MATCH
            { "KAIX", (".T", "JPY") }, // CBOE JAPAN - KAI-X
            { "CIBC", (".L", "GBP") }, // CANADIAN IMPERIAL BANK OF COMMERCE
            { "CIBH", ("N/A", "UNKNOWN") }, // CIB BANK
            { "CIBP", (".L", "GBP") }, // CIBC WORLD MARKETS PLC
            { "CILH", (".T", "JPY") }, // LIQUIDITY HUB JAPAN
            { "CIMD", (".MC", "EUR") }, // CIMD S.V. S.A. - OTF
            { "CIMA", (".MC", "EUR") }, // CIMD S.V. S.A. - APPROVED PUBLICATION ARRANGEMENT
            { "CIMB", (".MC", "EUR") }, // CIMD S.V. S.A. - OTF FOR BONDS
            { "CIME", (".MC", "EUR") }, // CIMD S.V. S.A. - OTF FOR ENERGY DERIVATIVES
            { "CIMV", (".MC", "EUR") }, // CIMD S.V. S.A. - OTF FOR DERIVATIVES
            { "CITX", (".T", "JPY") }, // CITI MATCH - JP
            { "CITD", (".T", "JPY") }, // CITI DARK
            { "CLAU", (".AX", "AUD") }, // CLSA AUSTRALIA - DARK
            { "CLHK", (".HK", "HKD") }, // CLSA HONG KONG - DARK
            { "CLJP", (".T", "JPY") }, // CLSA JAPAN - DARK
            { "CLMX", (".AS", "EUR") }, // CLIMEX
            { "CLPH", ("N/A", "UNKNOWN") }, // CLSA PHILIPPINES - DARK
            { "CLST", ("", "USD") }, // CLEAR STREET
            { "CLTD", (".SI", "SGD") }, // EEX ASIA PTE. LTD.
            { "CLVE", (".L", "GBP") }, // VERTO MTF
            { "CMCI", (".PA", "EUR") }, // CREDIT INDUSTRIEL ET COMMERCIAL
            { "CMCM", (".L", "GBP") }, // CMC MARKETS UK PLC
            { "CMEE", (".L", "GBP") }, // CME  EUROPE
            { "CMEC", (".L", "GBP") }, // CME CLEARING EUROPE
            { "CMED", (".L", "GBP") }, // CME EUROPE - DERIVATIVES
            { "CMET", (".T", "JPY") }, // CLEAR MARKETS JAPAN, INC.
            { "CMMT", (".L", "GBP") }, // CLEAR MARKETS EUROPE LIMITED
            { "CMSF", ("", "USD") }, // CLEAR MARKETS NORTH AMERICA, INC.
            { "CNOD", (".SI", "SGD") }, // CNODE
            { "CNSI", (".OL", "NOK") }, // CARNEGIE AS
            { "COAL", (".PA", "EUR") }, // LA COTE ALPHA
            { "CODA", ("", "USD") }, // CODA MARKETS - MICRO AND BLOCK
            { "COHR", ("", "USD") }, // COMHAR CAPITAL MARKETS, LLC
            { "COMG", ("N/A", "UNKNOWN") }, // COMMERG LTD.
            { "COMM", (".AS", "EUR") }, // COMMERG
            { "CONC", ("N/A", "UNKNOWN") }, // CONCORDE SECURITIES LTD.
            { "COTC", (".TO", "CAD") }, // BMO CAPITAL MARKETS - CAD OTC TRADES
            { "CPGX", ("", "USD") }, // CLEARPOOL EXECUTION SERVICES, LLC
            { "NLAX", ("", "USD") }, // CLEARPOOL EXECUTION SERVICES, LLC - NATURAL LIQUIDITY ALLIANCE
            { "CPTX", (".AS", "EUR") }, // CAPTIN
            { "CRBX", (".SW", "CHF") }, // CLIMATE TRUST
            { "CRDL", (".L", "GBP") }, // COREDEAL MTS
            { "CRED", ("", "USD") }, // CREDIT SUISSE (US)
            { "CAES", ("", "USD") }, // CREDIT SUISSE AES CROSSFINDER
            { "CSCL", ("", "USD") }, // CREDIT SUISSE CLOSEX
            { "CSLP", ("", "USD") }, // CREDIT SUISSE LIGHT POOL
            { "CSVW", ("", "USD") }, // CREDIT SUISSE VWAPX
            { "CREM", (".MI", "EUR") }, // CREDEM BANCA
            { "CRSX", ("N/A", "UNKNOWN") }, // CROSSX TECHNOLOGIES LTD
            { "CRYD", (".ST", "SEK") }, // CRYEX - FX AND DIGITAL CURRENCIES
            { "CRYP", (".L", "GBP") }, // CRYPTO FACILITIES
            { "CRYX", (".ST", "SEK") }, // CRYEX
            { "CSAG", (".SW", "CHF") }, // CREDIT SUISSE AG
            { "CSOT", (".SW", "CHF") }, // CREDIT SUISSE AG - OHS
            { "CSAS", (".PR", "CZK") }, // CESKA SPORITELNA, A.S.
            { "CSAU", (".AX", "AUD") }, // CREDIT SUISSE EQUITIES (AUSTRALIA) LIMITED
            { "CFAU", (".AX", "AUD") }, // CROSSFINDER AUSTRALIA
            { "CSDA", (".DE", "EUR") }, // CREDIT SUISSE AKTIENGESELLSCHAFT
            { "CDSI", (".DE", "EUR") }, // CREDIT SUISSE (DEUTSCHLAND) AG
            { "CSEC", (".L", "GBP") }, // CITADEL SECURITIES FI
            { "CSEU", (".L", "GBP") }, // CREDIT SUISSE (EUROPE)
            { "CSBX", (".L", "GBP") }, // CREDIT SUISSE AES EUROPE BENCHMARK CROSS
            { "CSCF", (".L", "GBP") }, // CREDIT SUISSE AES CROSSFINDER EUROPE
            { "CSFB", (".L", "GBP") }, // CREDIT SUISSE (EUROPE)
            { "SICS", (".L", "GBP") }, // CREDIT SUISSE SECURITIES (EUROPE) LIMITED
            { "CSGI", ("N/A", "UNKNOWN") }, // CITADEL SECURITIES FI - EUROPE
            { "CSHK", (".HK", "HKD") }, // CREDIT SUISSE SECURITIES (HONG KONG) LIMITED
            { "CFHK", (".HK", "HKD") }, // CROSSFINDER HONG KONG
            { "CSIN", (".L", "GBP") }, // CREDIT SUISSE INTERNATIONAL
            { "CSSI", (".L", "GBP") }, // CREDIT SUISSE INTERNATIONAL - SYSTEMATIC INTERNALISER
            { "CSJP", (".T", "JPY") }, // CREDIT SUISSE EQUITIES (JAPAN) LIMITED
            { "CFJP", (".T", "JPY") }, // CROSSFINDER JAPAN
            { "CSLB", (".L", "GBP") }, // CREDIT SUISSE AG - LONDON BRANCH
            { "CSMD", (".MC", "EUR") }, // CREDIT SUISSE BANK (EUROPE), S.A.
            { "SIMD", (".MC", "EUR") }, // CREDIT SUISSE BANK (EUROPE), S.A. - SYSTEMATIC INTERNALISER
            { "CSOB", (".PR", "CZK") }, // ČESKOSLOVENSKÁ OBCHODNÍ BANKA, A.S.
            { "CELP", (".PR", "CZK") }, // ČESKOSLOVENSKÁ OBCHODNÍ BANKA, A.S. - OTHER LIQUIDITY PROVIDER (OLP)
            { "CESI", (".PR", "CZK") }, // ČESKOSLOVENSKÁ OBCHODNÍ BANKA, A.S. - SYSTEMATIC INTERNALISER
            { "CSSX", (".SS", "CNY") }, // CHINA STAINLESS STEEL EXCHANGE
            { "CSZH", (".SW", "CHF") }, // CREDIT SUISSE (CH)
            { "CTCC", (".L", "GBP") }, // CLEARTOKEN CCP LIMITED
            { "CTDD", (".L", "GBP") }, // CLEARTOKEN DEPOSITORY LTD
            { "CTSS", (".L", "GBP") }, // CLEARTOKEN CSD LIMITED
            { "CURX", ("", "USD") }, // CUREX FX
            { "D2XG", (".AS", "EUR") }, // D2X MARKET
            { "D2XC", (".AS", "EUR") }, // D2X – CRYPTO DERIVATIVES
            { "DAIW", (".L", "GBP") }, // DAIWA CAPITAL MARKETS EUROPE LIMITED
            { "DAMP", (".CO", "DKK") }, // GXG MARKETS A/S
            { "DAPA", (".DE", "EUR") }, // DEUTSCHE BOERSE AG - APA SERVICE
            { "DASH", ("", "USD") }, // DASH ATS
            { "DASI", (".CO", "DKK") }, // DANSKE BANK A/S
            { "DAUK", (".L", "GBP") }, // DANSKE BANK A/S - LONDON BRANCH
            { "DAVY", ("N/A", "UNKNOWN") }, // J AND E DAVY - IRISH GOVERNMENT BOND
            { "DBAB", ("", "USD") }, // DEUTSCHE BANK SECURITIES INC.
            { "DBAG", (".DE", "EUR") }, // DEUTSCHE BANK AG
            { "DBES", (".DE", "EUR") }, // DEUTSCHE BANK AG - SYSTEMATIC INTERNALISER
            { "DBLN", (".DE", "EUR") }, // DEUTSCHE BANK AG - LONDON
            { "DBMO", (".DE", "EUR") }, // DEUTSCHE BANK - MANUAL OTC
            { "DBDX", (".DE", "EUR") }, // DEUTSCHE BOERSE DIGITAL EXCHANGE
            { "DBHK", (".HK", "HKD") }, // DEUTSCHE BANK HONG KONG ATS
            { "DBIX", (".L", "GBP") }, // DEUTSCHE BANK AG - LONDON
            { "DBCR", (".L", "GBP") }, // DEUTSCHE BANK - CENTRAL RISK BOOK
            { "DBCX", (".L", "GBP") }, // DEUTSCHE BANK - CLOSE CROSS
            { "DBDC", (".L", "GBP") }, // DEUTSCHE BANK - DIRECT CAPITAL ACCESS
            { "DBSE", (".L", "GBP") }, // DEUTSCHE BANK - SUPERX EU
            { "DBLX", ("N/A", "UNKNOWN") }, // DEUTSCHE BANK LUXEMBOURG S.A.
            { "DBOX", (".DE", "EUR") }, // DEUTSCHE BANK OFF EXCHANGE TRADING
            { "AUTO", (".DE", "EUR") }, // AUTOBAHN FX
            { "DBSX", ("", "USD") }, // DEUTSCHE BANK SUPER X
            { "DBXT", (".PA", "EUR") }, // DBX
            { "DCSX", ("N/A", "UNKNOWN") }, // DUTCH CARIBBEAN SECURITIES EXCHANGE
            { "DDTX", (".MI", "EUR") }, // DEAL DONE TRADING
            { "DEAL", ("", "USD") }, // DCX (DERIVATIVES CURRENCY EXCHANGE)
            { "DEKA", (".DE", "EUR") }, // DEKABANK DEUTSCHE GIROZENTRALE
            { "DEXE", ("N/A", "UNKNOWN") }, // DEX LIMITED
            { "DGCX", ("N/A", "UNKNOWN") }, // DUBAI GOLD AND COMMODITIES EXCHANGE DMCC
            { "DHLX", ("N/A", "UNKNOWN") }, // DEUTSCHE HOLDINGS (LUXEMBOURG) S.A R.L.
            { "DIFX", ("N/A", "UNKNOWN") }, // NASDAQ DUBAI
            { "DKTC", (".CO", "DKK") }, // DANSK OTC
            { "DOTS", (".SW", "CHF") }, // SWISS DOTS BY CATS
            { "DOWG", (".L", "GBP") }, // DOWGATE
            { "KASH", (".L", "GBP") }, // DOWGATE APPA
            { "DOWM", (".MC", "EUR") }, // DOWGATE - MTF (MADRID)
            { "DOWE", (".MC", "EUR") }, // DOWGATE EURO GOVERNMENT BONDS
            { "DRCT", (".T", "JPY") }, // DAIWA DRECT
            { "DRSP", (".L", "GBP") }, // EURONEXT  UK - REPORTING SERVICES
            { "DSMD", ("N/A", "UNKNOWN") }, // QATAR STOCK EXCHANGE
            { "DUMX", ("N/A", "UNKNOWN") }, // GULF MERCANTILE EXCHANGE
            { "DVFX", (".L", "GBP") }, // DIGITAL VEGA
            { "DWFI", ("", "USD") }, // DEALERWEB FIXED INCOME
            { "DWIN", ("", "USD") }, // DRIVEWEALTH INSTITUTIONAL LLC
            { "DZBK", (".DE", "EUR") }, // DZ BANK
            { "EBHU", ("N/A", "UNKNOWN") }, // ERSTE BANK HUNGARY ZRT.
            { "EBSN", (".AS", "EUR") }, // EBS MTF
            { "EBSD", (".AS", "EUR") }, // EBS MTF - RFQ - FOR THE TRADING OF FX PRODUCTS
            { "EBSF", (".AS", "EUR") }, // EBS MTF - FX PRODUCTS - RFQ SEGMENT
            { "EBSI", (".AS", "EUR") }, // EBS MTF - RFQ - FOR ASSET MANAGERS TRADING FX PRODUCTS
            { "IEBS", (".AS", "EUR") }, // EBS MTF - RFQ - FX PRODUCTS FOR ASSET MANAGERS
            { "NEXY", (".AS", "EUR") }, // EBS MTF - RFQ - FOR CORPORATES TRADING FX PRODUCTS
            { "RESE", (".AS", "EUR") }, // EBS MTF - RESET
            { "RESF", (".AS", "EUR") }, // EBS MTF - RESET SEGMENT
            { "EBSS", (".SW", "CHF") }, // EBS SERVICE COMPANY LIMITED - ALL MARKETS
            {
                "EBSC", (".SW", "CHF")
            }, // EBS MARKET- CLOB - FOR THE TRADING OF SPOT FX, PRECIOUS METALS AND OTHER FX PRODUCTS
            { "GLBX", (".SW", "CHF") }, // FX SPOT+
            { "ECAG", (".DE", "EUR") }, // EUREX CLEARING AG
            { "ECGS", (".DE", "EUR") }, // EUREX CLEARING AG - SME
            { "ECAL", (".SI", "SGD") }, // EUREX CLEARING ASIA PTE. LTD.
            { "ECEU", (".AS", "EUR") }, // TRADECHO EU APA
            { "ECHO", (".L", "GBP") }, // LONDON STOCK EXCHANGE - APA
            { "ECSL", (".L", "GBP") }, // ENTERPRISE COMMODITY SERVICES LIMITED
            { "ECXE", (".AS", "EUR") }, // EUROPEAN CLIMATE EXCHANGE
            { "EDGE", ("", "USD") }, // BATS DIRECT EDGE
            { "EDRF", (".PA", "EUR") }, // EDMOND DE ROTHSCHILD  (FRANCE)
            { "EDXM", ("", "USD") }, // EDX MARKETS
            { "EEAL", (".SI", "SGD") }, // EUREX EXCHANGE ASIA PTE. LTD.
            { "EESE", ("N/A", "UNKNOWN") }, // EAST EUROPEAN STOCK EXCHANGE
            { "EESX", (".JO", "ZAR") }, // EQUITY EXPRESS SECURITIES EXCHANGE (EESE)
            { "EFTP", (".DE", "EUR") }, // ENERGIEFINANZ TRADING PLATFORM
            { "EGMT", ("", "USD") }, // EG MARKET TECHNOLOGIES
            { "EGSI", ("N/A", "UNKNOWN") }, // ERSTE GROUP BANK AG
            { "ELXE", (".PA", "EUR") }, // ELIXIUM S.A.
            { "EMBX", (".L", "GBP") }, // EMERGING MARKETS BOND EXCHANGE LIMITED
            { "EMID", (".MI", "EUR") }, // E-MID
            { "EMDR", (".MI", "EUR") }, // E-MID - E-MIDER MARKET
            { "EMIB", (".MI", "EUR") }, // E-MID - BANCA D'ITALIA SHARES TRADING MARKET
            { "EMIR", (".MI", "EUR") }, // E-MID REPO
            { "ENCL", (".L", "GBP") }, // ENCLEAR
            { "ENMS", (".SI", "SGD") }, // EURONEXT MARKETS SINGAPORE PTE. LTD.
            { "EOTC", (".HK", "HKD") }, // E-OTC
            { "EPEX", (".PA", "EUR") }, // EPEX SPOT SE
            { "EQCA", (".TO", "CAD") }, // EQUILEND CANADA CORP.
            { "EQIE", ("N/A", "UNKNOWN") }, // EQUILEND LIMITED
            { "EQSE", ("N/A", "UNKNOWN") }, // EQUILEND LIMITED - SWAPS
            { "EQLD", (".L", "GBP") }, // EQUILEND EUROPE LIMITED
            { "EQSL", (".L", "GBP") }, // EQUILEND EUROPE LIMITED - SWAPS
            { "EQOS", (".SI", "SGD") }, // EQUOS
            { "EQOC", (".SI", "SGD") }, // EQUOS SPOT
            { "EQOD", (".SI", "SGD") }, // EQUOS DERIVATIVES
            { "EQUS", ("", "USD") }, // EQUILEND LLC
            { "ERBX", ("N/A", "UNKNOWN") }, // EUROBANK
            { "ERIS", ("", "USD") }, // CBOE DIGITAL EXCHANGE
            { "ERST", ("N/A", "UNKNOWN") }, // ERSTE BEFEKTETESI ZRT
            { "ESLO", (".PA", "EUR") }, // ENGNSOL
            { "ENSL", (".PA", "EUR") }, // ENGNSOL - OMP
            { "ETOR", ("N/A", "UNKNOWN") }, // ETORO EU
            { "ETPA", (".AS", "EUR") }, // ENERGY TRADING PLATFORM AMSTERDAM
            { "ETSC", ("N/A", "UNKNOWN") }, // ETS EURASIAN TRADING SYSTEM COMMODITY EXCHANGE
            { "EUCC", ("N/A", "UNKNOWN") }, // CITADEL CONNECT EUROPE - EU
            { "EUCH", (".SW", "CHF") }, // EUREX ZURICH
            { "EURM", (".SW", "CHF") }, // EUREX REPO MARKET
            { "EUSC", (".SW", "CHF") }, // EUREX CH SECLEND MARKET
            { "EUSP", (".SW", "CHF") }, // EUREX OTC SPOT MARKET
            { "EUFN", ("N/A", "UNKNOWN") }, // EURO-FINANCE AD
            { "EUWA", (".DE", "EUR") }, // EUWAX AG
            { "EVOL", (".L", "GBP") }, // EVOLUTION MARKETS
            { "EWSM", ("N/A", "UNKNOWN") }, // EUROPEAN WHOLESALE SECURITIES MARKET
            { "EXEU", (".L", "GBP") }, // EXANE BNP PARIBAS
            { "EXBO", (".L", "GBP") }, // EXANE BNP PARIBAS - BID-OFFER CROSSING
            { "EXCP", (".L", "GBP") }, // EXANE BNP PARIBAS - CLOSING PRICE
            { "EXDC", (".L", "GBP") }, // EXANE BNP PARIBAS - DIRECT CAPITAL ACCESS
            { "EXLP", (".L", "GBP") }, // EXANE BNP PARIBAS - LIQUIDITY PROVISION
            { "EXMP", (".L", "GBP") }, // EXANE BNP PARIBAS - MID POINT
            { "EXOR", (".L", "GBP") }, // EXANE BNP PARIBAS - CHILD ORDER CROSSING
            { "EXSI", (".L", "GBP") }, // EXANE BNP PARIBAS - GB
            { "EXVP", (".L", "GBP") }, // EXANE BNP PARIBAS - VOLUME PROFILE CROSSING
            { "EXIX", ("", "USD") }, // ELECTRONX
            { "EXOT", (".L", "GBP") }, // EXOTIX CAPITAL  - OTF
            { "EXSE", (".PA", "EUR") }, // EXANE BNP PARIBAS - SYSTEMATIC INTERNALISER
            { "EXSY", (".PA", "EUR") }, // EXANE DERIVATIVES
            { "EXSB", (".PA", "EUR") }, // EXANE DERIVATIVES  CORPORATE BONDS
            { "EXSD", (".PA", "EUR") }, // EXANE DERIVATIVES  OTC DERIVATIVES
            { "EXSF", (".PA", "EUR") }, // EXANE DERIVATIVES  OTHER BONDS
            { "EXSH", (".PA", "EUR") }, // EXANE DERIVATIVES  SHARES
            { "EXSP", (".PA", "EUR") }, // EXANE DERIVATIVES  STRUCTURED PRODUCTS
            { "EXYY", (".PA", "EUR") }, // EXANE DERIVATIVES  CONVERTIBLES
            { "EXTR", (".IS", "TRY") }, // ENERGY EXCHANGE ISTANBUL
            { "XEDA", (".IS", "TRY") }, // ELECTRICITY DAY-AHEAD MARKET
            { "XEID", (".IS", "TRY") }, // ELECTRICITY INTRA-DAY MARKET
            { "FAIR", (".L", "GBP") }, // CANTOR SPREADFAIR
            { "FAST", ("", "USD") }, // EURONEXT FX
            { "FBSI", (".MI", "EUR") }, // FINECO BANK
            { "FGEX", (".HE", "EUR") }, // KAASUPORSSI - FINNISH GAS EXCHANGE
            { "FGML", ("N/A", "UNKNOWN") }, // FINSTREET GLOBAL MARKETS
            { "FICO", ("", "USD") }, // FINANCIALCONTENT
            { "XFCI", ("", "USD") }, // FINANCIALCONTENT - INDEXES
            { "XFDA", ("", "USD") }, // FINANCIALCONTENT - DIGITAL ASSET TRADE REPORTING FACILITY
            { "FICX", (".DE", "EUR") }, // FINANCIAL INFORMATION CONTRIBUTORS EXCHANGE
            { "FINR", ("", "USD") }, // FINRA
            { "FINC", ("", "USD") }, // FINRA/NASDAQ TRF CHICAGO (TRADE REPORTING FACILITY)
            { "FINN", ("", "USD") }, // FINRA/NASDAQ TRF CARTERET (TRADE REPORTING FACILITY)
            { "FINO", ("", "USD") }, // FINRA ORF (TRADE REPORTING FACILITY)
            { "FINY", ("", "USD") }, // FINRA/NYSE TRF (TRADE REPORTING FACILITY)
            { "OOTC", ("", "USD") }, // OTHER OTC
            { "XADF", ("", "USD") }, // FINRA ALTERNATIVE DISPLAY FACILITY (ADF)
            { "FISH", (".OL", "NOK") }, // FISH POOL ASA
            { "FISU", (".L", "GBP") }, // FREIGHT INVESTOR SERVICES LIMITED
            { "FLWX", (".AS", "EUR") }, // FLOW TRADERS
            { "FLTB", (".AS", "EUR") }, // FLOW TRADERS B.V.  BONDS
            { "FLTR", (".AS", "EUR") }, // FLOW TRADERS - SYSTEMATIC INTERNALISER
            { "FMTS", (".PA", "EUR") }, // MTS FRANCE SAS
            { "FMXS", (".SI", "SGD") }, // FMX SECURITIES
            { "FNDF", (".SI", "SGD") }, // FMX NON-DELIVERABLE FORWARDS
            { "FNUK", (".L", "GBP") }, // FINANTIA UK LIMITED
            { "FPWB", ("N/A", "UNKNOWN") }, // FIRSTPLACE WIENER BOERSE
            { "FREX", ("", "USD") }, // COINBASE DERIVATIVES
            { "FRRF", ("N/A", "EUR") }, // FONDS DES RENTES / RENTENFONDS
            { "FRTE", (".L", "GBP") }, // FORTE  - OTF
            { "FSEF", ("", "USD") }, // FTSEF LLC
            { "FSHX", (".OL", "NOK") }, // FISHEX
            { "FTFS", (".PR", "CZK") }, // 42 FINANCIAL SERVICES
            { "FTFM", (".PR", "CZK") }, // 42 FINANCIAL SERVICES - MTF
            { "FTUS", ("", "USD") }, // FLOW TRADERS U.S LLC
            { "FXAL", ("", "USD") }, // FXALL
            { "FXCM", ("", "USD") }, // FXCM
            { "FXGB", (".L", "GBP") }, // FXCM - MTF
            { "FXMT", (".L", "GBP") }, // FXMARKETSPACE LIMITED
            { "FXOP", (".L", "GBP") }, // TRADITION-NEX OTF
            { "G1XX", ("", "USD") }, // G1 EXECUTION SERVICES
            { "G360", (".L", "GBP") }, // G360
            { "GARA", (".PR", "CZK") }, // COINGARAGE
            { "GBOT", ("N/A", "UNKNOWN") }, // BOURSE AFRICA LIMITED
            { "GBSI", ("N/A", "UNKNOWN") }, // GOODBODY STOCKBROKERS UC
            { "GEMX", (".L", "GBP") }, // GEMMA (GILT EDGED MARKET MAKERS’ASSOCIATION)
            { "GETB", ("N/A", "UNKNOWN") }, // LITHUANIAN NATURAL GAS EXCHANGE
            { "GFAM", ("", "USD") }, // GFI SECURITIES LLC - ALL MARKETS
            { "FNIX", ("", "USD") }, // GFI SECURITIES LLC - FENICS DELTA X
            { "LATG", ("", "USD") }, // GFI SECURITIES LLC - CREDITMATCH (LATG)
            { "GFAU", (".AX", "AUD") }, // GFI AUSTRALIA PTY LTD
            { "GFIA", (".L", "GBP") }, // GFI AUCTIONMATCH
            { "GFIB", (".L", "GBP") }, // GFI BROKERS
            { "GFBM", (".L", "GBP") }, // GFI BROKERS - MTF
            { "GFBO", (".L", "GBP") }, // GFI BROKERS - OTF
            { "GFIC", (".L", "GBP") }, // GFI SECURITIES LTD
            { "GFIF", (".L", "GBP") }, // GFI FOREXMATCH
            { "GFIM", (".L", "GBP") }, // GFI MARKETMATCH
            { "GFIN", (".L", "GBP") }, // GFI ENERGYMATCH
            { "GFIR", (".L", "GBP") }, // GFI RATESMATCH
            { "GFSM", (".L", "GBP") }, // GFI SECURITIES LTD - MTF
            { "GFSO", (".L", "GBP") }, // GFI SECURITIES LTD - OTF
            { "XGFI", (".L", "GBP") }, // GFI BASISMATCH
            { "GFKS", (".ST", "SEK") }, // GARANTUM FONDKOMMISSION AB
            { "GFOX", (".L", "GBP") }, // GLOBAL FUTURES AND OPTIONS LTD
            { "GFSG", (".SI", "SGD") }, // GFI SINGAPORE RMO
            { "GIPB", (".PA", "EUR") }, // GOLDMAN SACHS INTERNATIONAL PARIS BRANCH
            { "GSPX", (".PA", "EUR") }, // GOLDMAN SACHS INTERNATIONAL PARIS BRANCH - SYSTEMATIC INTERNALISER
            { "GLLC", ("", "USD") }, // GATE US LLC
            { "GLMX", ("", "USD") }, // GLMX
            { "GLOM", ("N/A", "UNKNOWN") }, // GLOMAX EXCHANGE LTD
            { "GLPS", ("", "USD") }, // ESSEX RADEZ, LLC
            { "GLPX", ("", "USD") }, // ACS EXECUTION SERVICES, LLC
            { "GMEG", (".L", "GBP") }, // GMEX EXCHANGE
            { "XGCX", (".L", "GBP") }, // GLOBAL COMMODITIES EXCHANGE
            { "XGDX", (".L", "GBP") }, // GLOBAL DERIVATIVES EXCHANGE
            { "XGSX", (".L", "GBP") }, // GLOBAL SECURITIES EXCHANGE
            { "XLDX", (".L", "GBP") }, // LONDON DERIVATIVES EXCHANGE
            { "GMES", (".PA", "EUR") }, // GRIFFIN MARKETS EUROPE
            { "GMEO", (".PA", "EUR") }, // GRIFFIN MARKETS EUROPE - OTF
            { "GMEX", (".DE", "EUR") }, // GREENMARKET EXCHANGE
            { "GMGD", ("N/A", "UNKNOWN") }, // GMG DUBAI LIMITED
            { "GMGE", (".AS", "EUR") }, // GMG EUROPE B.V.
            { "GMGL", (".L", "GBP") }, // GMG BROKERS LIMITED
            { "GMTF", (".PA", "EUR") }, // GALAXY
            { "GOTC", ("", "USD") }, // GLOBAL OTC
            { "GOVX", ("", "USD") }, // GOVEX
            { "GPBC", ("N/A", "UNKNOWN") }, // GPB-FINANCIAL SERVICES LTD
            { "GREE", ("", "USD") }, // THE GREEN EXCHANGE
            { "GRIF", (".L", "GBP") }, // GRIFFIN MARKETS LIMITED
            { "GRIO", (".L", "GBP") }, // GRIFFIN MARKETS LIMITED - OTF
            { "GRSE", (".L", "GBP") }, // THE GREEN STOCK EXCHANGE - ACB IMPACT MARKETS
            { "GSAL", (".HK", "HKD") }, // GOLDMAN SACHS (ASIA) LLC
            { "GSPL", (".HK", "HKD") }, // GS PRINCIPAL LIQUIDITY ASIA
            { "GSXH", (".HK", "HKD") }, // GSX HONG KONG
            { "GSXM", (".HK", "HKD") }, // GSX MICRO
            { "SIGH", (".HK", "HKD") }, // SIGMA X HONG KONG
            { "GSBE", (".DE", "EUR") }, // GOLDMAN SACHS BANK EUROPE SE
            { "GSEI", (".DE", "EUR") }, // GOLDMAN SACHS BANK EUROPE SE - SYSTEMATIC INTERNALISER
            { "GSCI", ("N/A", "UNKNOWN") }, // THE GUYANA ASSOCIATION OF SECURITIES COMPANIES AND INTERMEDIARIES INC.
            { "GSCO", ("", "USD") }, // GOLDMAN SACHS AND CO.
            { "SGMT", ("", "USD") }, // SIGMA X2
            { "GSEF", ("", "USD") }, // GFI SWAPS EXCHANGE, LLC
            { "GSBS", ("", "USD") }, // GFI SWAPS EXCHANGE, LLC - SECURITY BASED SWAPS
            { "GSIB", (".L", "GBP") }, // GOLDMAN SACHS INTERNATIONAL BANK
            { "BISI", (".L", "GBP") }, // GOLDMAN SACHS INTERNATIONAL BANK - SYSTEMATIC INTERNALISER
            { "GSIL", (".L", "GBP") }, // GOLDMAN SACHS INTERNATIONAL
            { "GSBX", (".L", "GBP") }, // GOLDMAN SACHS INTERNATIONAL - SIGMA BCN
            { "GSSI", (".L", "GBP") }, // GOLDMAN SACHS INTERNATIONAL - SYSTEMATIC INTERNALISER
            { "GSLO", (".L", "GBP") }, // GALLARDO SECURITIES LIMITED
            { "GSXC", (".SS", "CNY") }, // GSX CHINA
            { "GSXK", (".KS", "KRW") }, // GSX KOREA
            { "GSXL", ("N/A", "UNKNOWN") }, // THE GIBRALTAR STOCK EXCHANGE
            { "GSXN", (".HK", "HKD") }, // GSX NATURAL
            { "GSXT", (".TW", "TWD") }, // GSX TAIWAN
            { "GTCO", ("", "USD") }, // KCG AMERICAS LLC
            { "GTSM", ("", "USD") }, // GTS SECURITIES
            { "GTSX", ("", "USD") }, // GTSX
            { "GTXE", ("N/A", "UNKNOWN") }, // GTX ECN
            { "GTXS", ("", "USD") }, // GTX SEF, LLC
            { "GXGR", (".CO", "DKK") }, // GXG MARKETS A/S
            { "GXGF", (".CO", "DKK") }, // GXG MTF FIRST QUOTE
            { "GXGM", (".CO", "DKK") }, // GXG MTF
            { "GXMA", ("N/A", "UNKNOWN") }, // GX MARKETCENTER
            { "HBFR", (".PA", "EUR") }, // HSBC CONTINENTAL EUROPE
            { "HBPL", (".WA", "PLN") }, // HSBC BANK POLSKA S.A.
            { "HCHC", (".AS", "EUR") }, // ICE CLEAR NETHERLANDS B.V.
            { "HDAT", ("N/A", "UNKNOWN") }, // ELECTRONIC SECONDARY SECURITIES MARKET (HDAT)
            { "HEGX", ("", "USD") }, // NADEX
            { "HELA", (".DE", "EUR") }, // HELABA
            { "HEMO", ("N/A", "UNKNOWN") }, // HENEX S.A.
            { "HEDE", ("N/A", "UNKNOWN") }, // HENEX FINANCIAL ENERGY MARKET - DERIVATIVES MARKET
            { "HESP", ("N/A", "UNKNOWN") }, // HENEX ELECTRICITY SPOT MARKET
            { "HGSP", ("N/A", "UNKNOWN") }, // HENEX GAS SPOT MARKET
            { "HKME", (".HK", "HKD") }, // HONG KONG MERCANTILE EXCHANGE
            { "HMTF", (".MI", "EUR") }, // VORVEL BONDS
            { "HCER", (".MI", "EUR") }, // VORVEL CERTIFICATES
            { "HMOD", (".MI", "EUR") }, // VORVEL EQUITY AUCTION
            { "HRFQ", (".MI", "EUR") }, // VORVEL RFQ
            { "HPCX", (".PA", "EUR") }, // HPC SA
            { "HPCO", (".PA", "EUR") }, // HPC ETRADING
            { "HPCS", (".PA", "EUR") }, // HPC ENERGY TRADING
            { "HPCV", (".PA", "EUR") }, // HPC SA - VOICE OTF
            { "MSSA", (".PA", "EUR") }, // MAREX SPECTRON - OTF
            { "HPPO", ("", "USD") }, // POTAMUS TRADING LLC
            { "HPSX", (".L", "GBP") }, // HPC OTF
            { "HPSO", (".L", "GBP") }, // HPC OTF - UK ETRADING PLATFORM
            { "HREU", ("N/A", "UNKNOWN") }, // HRTEU LIMITED
            { "HRSI", (".L", "GBP") }, // HUDSON RIVER TRADING - SYSTEMATIC INTERNALISER
            { "HRTF", ("", "USD") }, // HUDSON RIVER TRADING (HRT)
            { "HRTX", ("", "USD") }, // HUDSON RIVER TRADING
            { "HSBC", (".L", "GBP") }, // HSBC
            { "HSBT", (".DE", "EUR") }, // HSBC TRINKAUS AND BURKHARDT AG
            { "HSFX", ("", "USD") }, // CBOE FX
            { "HSTC", ("N/A", "UNKNOWN") }, // HANOI STOCK EXCHANGE
            { "XHNF", ("N/A", "UNKNOWN") }, // HANOI STOCK EXCHANGE - DERIVATIVES
            { "XHNX", ("N/A", "UNKNOWN") }, // HANOI STOCK EXCHANGE (UNLISTED PUBLIC COMPANY TRADING PLATFORM)
            { "HSXA", (".HK", "HKD") }, // HSBC-X HONG KONG
            { "HSXE", (".L", "GBP") }, // HSBC-X UNITED KINGDOM
            { "HUDX", ("N/A", "UNKNOWN") }, // HUNGARIAN DERIVATIVE ENERGY EXCHANGE
            { "HUPX", ("N/A", "UNKNOWN") }, // HUNGARIAN POWER EXCHANGE
            { "HWHE", (".OL", "NOK") }, // HWH ENERGIMEGLING
            { "IBAL", (".L", "GBP") }, // ICE BENCHMARK ADMINISTRATION
            { "IBCO", ("", "USD") }, // INTERACTIVE BROKERS CORP
            { "IBER", (".MC", "EUR") }, // IBERCAJA BANCO SA
            { "IBEX", ("N/A", "UNKNOWN") }, // INDEPENDENT BULGARIAN ENERGY EXCHANGE
            { "IBGH", (".MC", "EUR") }, // IBERIAN GAS HUB
            { "IBIS", (".MI", "EUR") }, // INVEST BANCA
            { "IBEQ", (".MI", "EUR") }, // INVEST BANCA - IBIS EQUITY
            { "IBKR", ("", "USD") }, // INTERACTIVE BROKERS LLC
            { "IATS", ("", "USD") }, // IBKR ATS
            { "IEOS", ("", "USD") }, // IBKR EOS ATS
            { "IBSI", ("N/A", "UNKNOWN") }, // INTERACTIVE BROKERS
            { "ICAT", (".L", "GBP") }, // ICAP HYDE TANKER DERIVATIVES LIMITED
            { "ICAP", (".L", "GBP") }, // ICAP EUROPE
            { "ICAH", (".L", "GBP") }, // TRAYPORT
            { "ICEN", (".L", "GBP") }, // ICAP ENERGY
            { "ICSE", (".L", "GBP") }, // ICAP SECURITIES
            { "ICTQ", (".L", "GBP") }, // ICAP TRUEQUOTE
            { "ISDX", (".L", "GBP") }, // ICAP SECURITIES AND DERIVATIVES EXCHANGE LIMITED
            { "PLSX", (".L", "GBP") }, // PLUS STOCK EXCHANGE
            { "WCLK", (".L", "GBP") }, // ICAP WCLK
            { "ICAS", (".OL", "NOK") }, // ICAP ENERGY AS
            { "ICDX", (".JK", "IDR") }, // INDONESIA COMMODITY AND DERIVATIVES EXCHANGE
            { "ICEL", ("", "USD") }, // ISLAND ECN LTD, THE
            { "ICEO", (".L", "GBP") }, // ICAP ENERGY - OTF
            { "IECE", (".L", "GBP") }, // ICAP ENERGY LTD OTF - EUROPEAN COMMODITIES AND ENERGY DERIVATIVES
            { "ICES", ("", "USD") }, // ICE SWAP TRADE LLC
            { "ICEU", (".L", "GBP") }, // INTERCONTINENTAL EXCHANGE - ICE FUTURES EUROPE
            { "ICOT", (".PA", "EUR") }, // ICAP EU - OTF
            { "ICOR", (".PA", "EUR") }, // ICAP EU -  OTF - REGISTRATION
            { "TLCM", (".PA", "EUR") }, // LOUIS CAPITAL MARKETS EU
            { "ICPM", (".L", "GBP") }, // TP ICAP UK MTF
            { "IMCD", (".L", "GBP") }, // ICAP MTF - CREDIT DERIVATIVES
            { "IMCE", (".L", "GBP") }, // TP ICAP UK MTF - CASH EQUITY
            { "IMCM", (".L", "GBP") }, // ICAP MTF - COMMODITIES
            { "IMED", (".L", "GBP") }, // TP ICAP UK MTF - EQUITY DERIVATIVES
            { "IMET", (".L", "GBP") }, // TP ICAP UK MTF - EXCHANGE TRADED PRODUCTS
            { "IMFD", (".L", "GBP") }, // TP ICAP UK MTF - FX DERIVATIVES
            { "IMGB", (".L", "GBP") }, // TP ICAP UK MTF - GOVERNMENT BONDS EXCLUDING GILTS
            { "IMGI", (".L", "GBP") }, // TP ICAP UK MTF - GILTS
            { "IMMM", (".L", "GBP") }, // TP ICAP UK MTF - MONEY MARKET INSTRUMENTS
            { "IMRD", (".L", "GBP") }, // TP ICAP UK MTF - INTEREST RATE DERIVATIVES
            { "IMSB", (".L", "GBP") }, // TP ICAP UK MTF - CORPORATE BONDS AND SECURITIES DEBT
            { "LIQF", (".L", "GBP") }, // TP ICAP UK MTF - LIQUIDNET CORPORATE BONDS AND SECURITIES DEBT
            { "LIQU", (".L", "GBP") }, // TP ICAP UK MTF - LIQUIDNET CASH EQUITY
            { "UKOR", (".L", "GBP") }, // TP ICAP UK MTF - ORDERBOOK
            { "UKRE", (".L", "GBP") }, // TP ICAP UK MTF - REGISTRATION
            { "ICPS", (".SI", "SGD") }, // ICAP SINGAPORE RMO
            { "ICUR", ("N/A", "UNKNOWN") }, // CURRENEX IRELAND MTF
            { "ICXR", ("N/A", "UNKNOWN") }, // CURRENEX IRELAND MTF - RFQ
            { "ICUS", ("", "USD") }, // ICE FUTURES U.S. INC
            { "ICXL", (".NS", "INR") }, // INDIAN COMMODITY EXCHANGE LTD.
            { "IDXM", ("", "USD") }, // IDX MARKETS, LLC
            { "IENG", (".WA", "PLN") }, // INFOENGINE OTC
            { "IEXA", ("", "USD") }, // IEX DAP LLC
            { "IEXG", ("", "USD") }, // INVESTORS EXCHANGE
            { "IEXC", ("", "USD") }, // INVESTORS EXCHANGE - DAX FACILITY
            { "IEXD", ("", "USD") }, // INVESTORS EXCHANGE - DARK
            { "IFAD", ("N/A", "UNKNOWN") }, // ICE FUTURES ABU DHABI
            { "IFBX", ("N/A", "UNKNOWN") }, // IRAN FARA BOURSE
            { "IFCA", (".TO", "CAD") }, // ICE FUTURES CANADA
            { "XWCE", (".TO", "CAD") }, // INTERCONTINENTAL EXCHANGE - ICE FUTURES CANADA
            { "IFEU", (".L", "GBP") }, // ICE FUTURES EUROPE
            { "CXOT", (".L", "GBP") }, // CREDITEX BROKERAGE LLP - OTF
            { "CXRT", (".L", "GBP") }, // CREDITEX BROKERAGE LLP - MTF
            { "IFEN", (".L", "GBP") }, // ICE FUTURES EUROPE - OIL AND REFINED PRODUCTS DIVISION
            { "IFLL", (".L", "GBP") }, // ICE FUTURES EUROPE - FINANCIAL PRODUCTS DIVISION
            { "IFLO", (".L", "GBP") }, // ICE FUTURES EUROPE - EQUITY PRODUCTS DIVISION
            { "IFLX", (".L", "GBP") }, // ICE FUTURES EUROPE - AGRICULTURAL PRODUCTS DIVISION
            { "IFUT", (".L", "GBP") }, // ICE FUTURES EUROPE - EUROPEAN UTILITIES DIVISION
            { "IFLS", (".L", "GBP") }, // SWAPXECUTE
            { "IFSG", (".SI", "SGD") }, // ICE FUTURES SINGAPORE
            { "IFUS", ("", "USD") }, // ICE FUTURES U.S.
            { "IEPA", ("", "USD") }, // INTERCONTINENTAL EXCHANGE
            { "IFED", ("", "USD") }, // ICE FUTURES U.S. ENERGY DIVISION
            { "IMAG", ("", "USD") }, // ICE MARKETS AGRICULTURE
            { "IMBD", ("", "USD") }, // ICE MARKETS BONDS
            { "IMCC", ("", "USD") }, // ICE CREDIT TRADE
            { "IMCG", ("", "USD") }, // CREDITEX LLC
            { "IMCR", ("", "USD") }, // ICE MARKETS CREDIT
            { "IMEN", ("", "USD") }, // ICE MARKETS ENERGY
            { "IMFX", ("", "USD") }, // ICE MARKETS FOREIGN EXCHANGE
            { "IMIR", ("", "USD") }, // ICE MARKETS RATES
            { "TMCC", ("", "USD") }, // ICE TMC
            { "VABD", ("", "USD") }, // ICE BONDPOINT
            { "IFXC", ("N/A", "UNKNOWN") }, // FX CONNECT IRELAND MTF
            { "IFXA", ("N/A", "UNKNOWN") }, // FX CONNECT IRELAND MTF - ALLOCATIONS
            { "IFXR", ("N/A", "UNKNOWN") }, // FX CONNECT IRELAND MTF - RFQ
            { "IGDL", (".L", "GBP") }, // ICAP GLOBAL DERIVATIVES LIMITED
            { "ISWE", (".L", "GBP") }, // ICAP GLOBAL DERIVATIVES LIMITED - ELECTRONIC
            { "ISWV", (".L", "GBP") }, // ICAP GLOBAL DERIVATIVES LIMITED - VOICE
            { "IINX", (".NS", "INR") }, // INDIA INTERNATIONAL EXCHANGE (IFSC) LIMITED
            { "IKBS", (".DE", "EUR") }, // IKB DEUTSCHE INDUSTRIEBANK AG
            { "IMCS", ("", "USD") }, // IMC FINANCIAL MARKETS
            { "IMCT", (".AS", "EUR") }, // IMC
            { "IMEX", ("N/A", "UNKNOWN") }, // IRAN MERCANTILE EXCHANGE
            { "IMMH", (".MI", "EUR") }, // IMMH - INTESA SANPAOLO
            { "IMTF", (".L", "GBP") }, // INTEGRAL MTF
            { "INCR", ("", "USD") }, // INTELLIGENTCROSS
            { "ASMT", ("", "USD") }, // INTELLIGENTCROSS ASPEN MAKER/TAKER
            { "ASPI", ("", "USD") }, // INTELLIGENTCROSS ASPEN INVERTED
            { "ASPN", ("", "USD") }, // INTELLIGENTCROSS ASPEN INTELLIGENT BID/OFFER
            { "IVWP", ("", "USD") }, // INTELLIGENTCROSS - VWAP CROSS
            { "NTRL", ("", "USD") }, // INTELLIGENTCROSS - NATURAL LIQUIDITY CROSS
            { "INFT", (".OL", "NOK") }, // INFRONT MARKETS
            { "FNDS", (".OL", "NOK") }, // INFRONT FUNDS MARKET
            { "IFFX", (".OL", "NOK") }, // INFRONT FX MARKET
            { "QUNT", (".OL", "NOK") }, // INFRONT QUANT
            { "INGB", (".AS", "EUR") }, // ING BANK NV
            { "INGE", (".AS", "EUR") }, // ING BANK NV - SPRINTERS AND EQUITY
            { "INGF", (".AS", "EUR") }, // ING BANK NV - FOREIGN EXCHANGE
            { "INGU", (".L", "GBP") }, // ING BANK NV  - LONDON BRANCH
            { "INGW", (".WA", "PLN") }, // ING BANK SLASKI SA
            { "INTL", ("", "USD") }, // STONEX FINANCIAL INC.
            { "INVE", (".L", "GBP") }, // INVESTEC BANK PLC
            { "IOTF", (".L", "GBP") }, // ICAP UK OTF
            { "ILCM", (".L", "GBP") }, // LOUIS CAPITAL MARKETS UK
            { "IOCD", (".L", "GBP") }, // ICAP UK OTF - CREDIT DERIVATIVES
            { "IOED", (".L", "GBP") }, // ICAP UK OTF - EQUITY DERIVATIVES
            { "IOFB", (".L", "GBP") }, // ICAP SECURITIES OTF - BUTLER FX DERIVATIVES
            { "IOFI", (".L", "GBP") }, // ICAP UK OTF - CORPORATE BONDS AND SECURITISED DEBT
            { "IOFX", (".L", "GBP") }, // ICAP UK OTF - FX DERIVATIVES
            { "IOGB", (".L", "GBP") }, // ICAP UK OTF - GOVERNMENT BONDS EXCLUDING  UK GILTS
            { "IOGI", (".L", "GBP") }, // ICAP UK OTF - GOVERNMENT BONDS - UK GILTS
            { "IOIR", (".L", "GBP") }, // ICAP UK OTF - INTEREST RATE DERIVATIVES
            { "IOMM", (".L", "GBP") }, // ICAP UK OTF - MONEY MARKET INSTRUMENTS
            { "IUOB", (".L", "GBP") }, // ICAP UK OTF - ORDERBOOK
            { "IPNL", (".AS", "EUR") }, // ISWAP EURO MTF
            { "IPSX", (".L", "GBP") }, // IPSX
            { "IPXP", (".L", "GBP") }, // IPSX PRIME
            { "IPXW", (".L", "GBP") }, // IPSX WHOLESALE
            { "ISBA", (".MI", "EUR") }, // BANCA DI ASTI
            { "ISBV", (".MI", "EUR") }, // BIVER BANCA
            { "ISDA", ("", "USD") }, // ISDAFIX
            { "ISEX", (".NS", "INR") }, // INTER-CONNECTED STOCK EXCHANGE OF INDIA LTD
            { "ISSI", (".L", "GBP") }, // ICBC STANDARD BANK
            { "ISWA", (".L", "GBP") }, // ISWAP UK MTF
            { "ISWB", (".L", "GBP") }, // ISWAP UK MTF - TRADE REGISTRATION
            { "ISWC", (".L", "GBP") }, // ISWAP UK MTF ORDER BOOK
            { "ISWR", (".L", "GBP") }, // ISWAP UK MTF TARGETED STREAMING/RFQ
            { "ISWP", (".AS", "EUR") }, // ISWAP EURO MTF
            { "ISWN", (".AS", "EUR") }, // ISWAP EURO MTF - TRADE REGISTRATION
            { "ISWO", (".AS", "EUR") }, // ISWAP EURO MTF - ORDERBOOK
            { "ISWQ", (".AS", "EUR") }, // ISWAP EURO MTF - SEF
            { "ISWT", (".AS", "EUR") }, // ISWAP EURO MTF - TARGETED STREAMING / RFQ
            { "ITGI", ("", "USD") }, // POSIT
            { "ITGL", ("N/A", "UNKNOWN") }, // POSIT MTF
            { "XPAC", ("N/A", "UNKNOWN") }, // POSIT AUCTION
            { "XPOS", ("N/A", "UNKNOWN") }, // POSIT DARK
            { "XRFQ", ("N/A", "UNKNOWN") }, // POSIT RFQ
            { "ITSL", ("N/A", "UNKNOWN") }, // INTERNATIONAL TRADING SYSTEM (ITS)
            { "ITSM", (".MI", "EUR") }, // AIM ITALIA - MERCATO ALTERNATIVO DEL CAPITALE
            { "IVZX", (".TO", "CAD") }, // INVESCO CANADA PTF TRADES
            { "IXSP", (".ME", "RUB") }, // INTERNATIONAL STOCK EXCHANGE SAINT-PETERSBOURG
            { "JADX", (".SI", "SGD") }, // JOINT ASIAN DERIVATIVES EXCHANGE
            { "JATA", (".T", "JPY") }, // JASDAQ TACHIAIGAI (OFF-FLOOR MARKET)
            { "JBSI", (".CO", "DKK") }, // JYSKE BANK
            { "JEFA", (".T", "JPY") }, // JEFFERIES ASIA
            { "JEFE", (".DE", "EUR") }, // JEFFERIES EUROPE
            { "JESI", (".DE", "EUR") }, // JEFFERIES EUROPE - SYSTEMATIC INTERNALISER
            { "JEFX", ("", "USD") }, // JETX
            { "JISI", (".L", "GBP") }, // JEFFERIES INTERNATIONAL
            { "JEFS", (".L", "GBP") }, // JEFFERIES INTERNATIONAL - SYSTEMATIC INTERNALISER
            { "JLEU", (".AS", "EUR") }, // JUMP TRADING EU EQUITY PLATFORM
            { "JLQD", ("", "USD") }, // JUMP TRADING - MULTI-ASSET PLATFORM
            { "JLEQ", ("", "USD") }, // JUMP TRADING - US EQUITY PLATFORM
            { "JLSI", (".L", "GBP") }, // JUMP TRADING
            { "JNSI", (".AS", "EUR") }, // JANE STREET NETHERLANDS B.V.
            { "JNST", ("", "USD") }, // JANE STREET CAPITAL, LLC
            { "JPBX", ("", "USD") }, // JPBX
            { "JPCB", (".L", "GBP") }, // JPMORGAN CHASE BANK N.A. LONDON BRANCH
            { "JPEU", (".DE", "EUR") }, // J.P. MORGAN SE
            { "JPJX", (".L", "GBP") }, // JPJENKINS
            { "JPMI", (".HK", "HKD") }, // JP MORGAN - JPMI MARKET
            { "JPMS", ("", "USD") }, // JPMS, LLC
            { "JPMX", ("", "USD") }, // JPMX
            { "JPSI", (".L", "GBP") }, // J.P. MORGAN SECURITIES PLC
            { "JSEF", ("", "USD") }, // JAVELIN SEF, LLC
            { "JSES", ("", "USD") }, // JANE STREET EXECUTION SERVICES LLC
            { "JSJX", ("", "USD") }, // JANE STREET JX
            { "JSSI", (".L", "GBP") }, // JANE STREET FINANCIAL LTD
            { "JYSI", (".CO", "DKK") }, // DEN JYSKE SPAREKASSE
            { "KABU", (".T", "JPY") }, // KABU.COM PTS
            { "VKAB", (".T", "JPY") }, // KABU.COMPTS-VWAP
            { "KBCB", ("N/A", "EUR") }, // KBC BANK NV  GROUP MARKETS
            { "KBLL", ("N/A", "UNKNOWN") }, // QUINTET PRIVATE BANK (EUROPE) S.A.
            { "KBLC", ("N/A", "UNKNOWN") }, // QUINTET PRIVATE BANK (EUROPE) S.A. - EURO COMMERCIAL PAPERS
            { "KBLS", ("N/A", "UNKNOWN") }, // QUINTET PRIVATE BANK (EUROPE) S.A. - STRUCTURED PRODUCTS
            { "KBLT", ("N/A", "UNKNOWN") }, // QUINTET PRIVATE BANK (EUROPE) S.A. - FX TREASURY DERIVATIVES
            { "KBLM", (".L", "GBP") }, // KYTE BROKING LIMITED
            { "KCCP", ("N/A", "UNKNOWN") }, // KELER CCP
            { "KDPW", (".WA", "PLN") }, // KDPW_CCP
            { "KELR", ("N/A", "UNKNOWN") }, // KELER
            { "KHHU", ("N/A", "UNKNOWN") }, // K AND H BANK ZRT
            { "KLEU", (".L", "GBP") }, // KNIGHT LINK EUROPE
            { "KLSH", ("", "USD") }, // KALSHIEX LLC
            { "KMTS", (".L", "GBP") }, // EUROMTS LINKERS MARKET
            { "KNIG", ("", "USD") }, // KNIGHT
            { "ACKF", ("", "USD") }, // KCG ACKNOWLEDGE FI
            { "KNCM", ("", "USD") }, // KNIGHT CAPITAL MARKETS LLC
            { "KNEM", ("", "USD") }, // KNIGHT EQUITY MARKETS LP
            { "KNLI", ("", "USD") }, // KNIGHT LINK
            { "KNMX", ("", "USD") }, // KNIGHT MATCH ATS
            { "KOCN", (".KS", "KRW") }, // KOREA ECN SECURITIES CO. LTD (ATS)
            { "KOME", (".PR", "CZK") }, // KOMERCNI BANKA, A.S.
            { "KOTF", (".PA", "EUR") }, // OTFLINK
            { "KRME", ("N/A", "UNKNOWN") }, // PAYWARD MENA HOLDINGS LTD.
            { "LAKX", ("", "USD") }, // RBC CAPITAL MARKETS LLC - TRAJECTORY CROSS
            { "LAMP", ("", "USD") }, // LAMPOST CAPITAL
            { "LASF", ("", "USD") }, // LATAM SEF
            { "LASP", (".CO", "DKK") }, // LAN AND SPAR BANK A/S
            { "LAVA", ("", "USD") }, // LAVA TRADING (CITI)
            { "LAFD", ("", "USD") }, // FLOW DARK
            { "LAFL", ("", "USD") }, // LAVAFLOW ECN
            { "LAFX", ("", "USD") }, // LAVAFX
            { "LBBW", (".DE", "EUR") }, // LBBW - LANDESBANK BADEN-WUERTTEMBERG
            { "LBWL", (".DE", "EUR") }, // LBBW - LANDESBANK BADEN-WUERTTEMBERG - LIQUIDITY PROVIDER
            { "LBWS", (".DE", "EUR") }, // LBBW - LANDESBANK BADEN-WUERTTEMBERG - SYSTEMATIC INTERNALISER
            { "LBCM", (".L", "GBP") }, // LLOYDS BANK CORPORATE MARKETS
            { "LBCW", (".DE", "EUR") }, // LLOYDS BANK CORPORATE MARKETS WERTPAPIERHANDELSBANK GMBH
            { "LCHC", (".PA", "EUR") }, // LCH.CLEARNET
            { "LCXE", ("N/A", "UNKNOWN") }, // LCX
            { "LEBV", (".AS", "EUR") }, // LEDGEREDGE B.V.
            { "LEDG", ("", "USD") }, // LEDGER X LLC
            { "FUSD", ("", "USD") }, // FTX US DERIVATIVES
            { "LELE", (".L", "GBP") }, // LEDGEREDGE
            { "LESI", ("", "USD") }, // LEDGEREDGE SECURITIES INC.
            { "LEUE", ("N/A", "UNKNOWN") }, // LIQUIDNET EU LIMITED EQUITY MTF
            { "LEUF", ("N/A", "UNKNOWN") }, // LIQUIDNET EU LIMITED FIXED INCOME MTF
            { "LEVL", ("", "USD") }, // LEVEL ATS
            { "EBXV", ("", "USD") }, // LEVEL ATS - VWAP CROSS
            { "LICA", (".TO", "CAD") }, // LIQUIDNET CANADA ATS
            { "LIGA", (".DE", "EUR") }, // LIGA BANK EG
            { "LIQH", (".L", "GBP") }, // LIQUIDNET H20
            { "LIUS", ("", "USD") }, // LIQUIDNET, INC.
            { "LIFI", ("", "USD") }, // LIQUIDNET, INC. FIXED INCOME ATS
            { "LIUH", ("", "USD") }, // LIQUIDNET, INC. H2O ATS
            { "LLAT", ("N/A", "UNKNOWN") }, // LIECHTENSTEINISCHE LANDESBANK (OSTERREICH) AG
            { "LMAS", (".SI", "SGD") }, // LMAX EXCHANGE SINGAPORE - NDFS
            { "LMAX", (".L", "GBP") }, // LMAX
            { "LMAD", (".L", "GBP") }, // LMAX - DERIVATIVES
            { "LMAE", (".L", "GBP") }, // LMAX - EQUITIES
            { "LMAF", (".L", "GBP") }, // LMAX - FX AND CASH-SETTLED DERIVATIVES
            { "LMAO", (".L", "GBP") }, // LMAX - INDICES/RATES/COMMODITIES
            { "LMEC", (".L", "GBP") }, // LME CLEAR
            { "LMNR", ("N/A", "UNKNOWN") }, // LUMINOR BANK AS
            { "LOTC", (".L", "GBP") }, // OTC MARKET
            { "PLDX", (".L", "GBP") }, // PLUS DERIVATIVES EXCHANGE
            { "LOUI", (".L", "GBP") }, // LOUIS CAPITAL MARKETS UK LLP
            { "LOYD", (".L", "GBP") }, // LLOYDS BANK
            { "LPPM", (".L", "GBP") }, // LONDON PLATINUM AND PALLADIUM MARKET
            { "LPSF", ("", "USD") }, // LPSFX LLC
            { "LQED", ("", "USD") }, // LIQUIDITYEDGE
            { "LSSI", (".DE", "EUR") }, // LANG AND SCHWARZ TRADE CENTER
            { "LTAA", ("", "USD") }, // LUMINEX TRADING AND ANALYTICS LLC
            { "LMNX", ("", "USD") }, // LUMINEX TRADING AND ANALYTICS LLC - ATS
            { "LTSE", ("", "USD") }, // LONG-TERM STOCK EXCHANGE, INC.
            { "LXJP", (".T", "JPY") }, // BARCLAYS LX JAPAN
            { "M2AE", ("N/A", "UNKNOWN") }, // M2 LIMITED
            { "MAEL", (".L", "GBP") }, // MARKETAXESS EUROPE LIMITED
            { "MXLM", (".L", "GBP") }, // MARKETAXESS EUROPE LIMITED - LIVE MARKETS
            { "RFQU", (".L", "GBP") }, // MARKETAXESS EUROPE LIMITED - RFQ - HUB
            { "MAGM", ("", "USD") }, // MAGMA ATS
            { "MAKX", (".L", "GBP") }, // MAKOR SECURITIES LONDON LTD
            { "MALX", ("N/A", "UNKNOWN") }, // MALDIVES STOCK EXCHANGE
            { "MANL", (".AS", "EUR") }, // MARKETAXESS NL B.V.
            { "MXNL", (".AS", "EUR") }, // MARKETAXESS NL B.V. - LIVE MARKETS
            { "RFQN", (".AS", "EUR") }, // MARKETAXESS NL B.V. - RFQ HUB
            { "MAQE", ("N/A", "UNKNOWN") }, // MACQUARIE BANK EUROPE DESIGNATED ACTIVITY COMPANY
            { "MAQH", (".HK", "HKD") }, // MACQUARIE INTERNAL MARKETS (HONG KONG)
            { "MAQI", (".L", "GBP") }, // MACQUARIE BANK INTERNATIONAL LIMITED
            { "MAQJ", (".T", "JPY") }, // MACQUARIE INTERNAL MARKETS (JAPAN)
            { "MAQL", (".L", "GBP") }, // MACQUARIE CAPITAL EUROPE LIMITED
            { "MAQU", (".L", "GBP") }, // MACQUARIE BANK LIMITED, LONDON BRANCH
            { "MAQX", (".AX", "AUD") }, // MACQUARIE INTERNAL MARKETS (AUSTRALIA)
            { "MACB", (".AX", "AUD") }, // MACQUARIE AUSTRALIA BLOCK CROSSING
            { "MASG", (".SI", "SGD") }, // MARKETAXESS SINGAPORE PTE LIMITED
            { "MALM", (".SI", "SGD") }, // MARKETAXESS SINGAPORE PTE LIMITED - LIVE MARKETS
            { "RFQS", (".SI", "SGD") }, // MARKETAXESS SINGAPORE PTE LIMITED - RFQ - HUB
            { "MATX", ("N/A", "UNKNOWN") }, // MATRIX LIMITED
            { "MAXD", (".L", "GBP") }, // MAX MARKETS LIMITED
            { "MBCP", ("N/A", "UNKNOWN") }, // MILLENNIUM BCP
            { "MBPL", (".WA", "PLN") }, // MBANK S.A.
            { "MBUL", ("N/A", "UNKNOWN") }, // MTF SOFIA
            { "GMBG", ("N/A", "UNKNOWN") }, // MTF SOFIA - GROWTH MARKET
            { "MCID", ("N/A", "UNKNOWN") }, // MACQUARIE CAPITAL (IRELAND)
            { "MCUR", (".L", "GBP") }, // CURRENEX MTF
            { "MCXR", (".L", "GBP") }, // CURRENEX MTF - RFQ
            { "MCXS", (".L", "GBP") }, // CURRENEX MTF - STREAMING
            { "MCXX", (".NS", "INR") }, // METROPOLITAN STOCK EXCHANGE OF INDIA LIMITED
            { "MDIP", ("N/A", "UNKNOWN") }, // MEDIP  (MTS PORTUGAL SGMR, SA)
            { "MEAU", (".AX", "AUD") }, // MACQUARIE EXECUTION (AU)
            { "MEHK", (".HK", "HKD") }, // MACQUARIE EXECUTION (HK)
            { "MEMX", ("", "USD") }, // MEMX LLC EQUITIES
            { "MEMD", ("", "USD") }, // MEMX LLC DARK
            { "MEMM", ("", "USD") }, // MEMX LLC RETAIL MIDPOINT
            { "MXOP", ("", "USD") }, // MEMX LLC OPTIONS
            { "MEPX", ("N/A", "UNKNOWN") }, // MONTENEGRIN POWER EXCHANGE
            { "METZ", (".L", "GBP") }, // MET ZURICH
            { "MFGL", (".L", "GBP") }, // MF GLOBAL ENERGY MTF
            { "MFXC", (".L", "GBP") }, // FX CONNECT - MTF
            { "MFXA", (".L", "GBP") }, // FX CONNECT - MTF - ALLOCATIONS
            { "MFXR", (".L", "GBP") }, // FX CONNECT - MTF - RFQ
            { "MHBD", (".DE", "EUR") }, // MIZUHO BANK, LTD. DUESSELDORF BRANCH
            { "MHBE", (".AS", "EUR") }, // MIZUHO BANK EUROPE N.V.
            { "MHBL", (".L", "GBP") }, // MIZUHO BANK, LTD. LONDON BRANCH
            { "MHBP", (".PA", "EUR") }, // MIZUHO BANK LTD. - PARIS BRANCH
            { "MHEU", (".DE", "EUR") }, // MIZUHO SECURITIES EUROPE
            { "MHIP", (".L", "GBP") }, // MIZUHO INTERNATIONAL
            { "MIBG", (".MC", "EUR") }, // MERCADO ORGANIZADO DEL GAS
            { "MDRV", (".MC", "EUR") }, // MIBGAS - DERIVATIVES
            { "MIBL", ("N/A", "UNKNOWN") }, // MITSUBISHI UFJ INVESTOR SERVICES AND BANKING
            { "MIDC", ("N/A", "UNKNOWN") }, // MIDCHAINS
            { "MIHI", ("", "USD") }, // MIAMI INTERNATIONAL HOLDINGS, INC.
            { "EMLD", ("", "USD") }, // MIAX EMERALD, LLC
            { "EPRD", ("", "USD") }, // MIAX PEARL EQUITIES EXCHANGE DARK
            { "EPRL", ("", "USD") }, // MIAX PEARL EQUITIES
            { "MPRL", ("", "USD") }, // MIAX PEARL, LLC
            { "SPHR", ("", "USD") }, // MIAX SAPPHIRE, LLC
            { "XMIO", ("", "USD") }, // MIAMI INTERNATIONAL SECURITIES EXCHANGE
            { "MISX", (".ME", "RUB") }, // MOSCOW EXCHANGE - ALL MARKETS
            { "RTSX", (".ME", "RUB") }, // MOSCOW EXCHANGE - DERIVATIVES MARKET
            { "MIZX", (".T", "JPY") }, // MIZUHO INTERNAL CROSSING
            { "MKAP", ("N/A", "UNKNOWN") }, // MERITKAPITAL
            { "MKTF", (".PA", "EUR") }, // MARKET SECURITIES (FRANCE) SA
            { "MLEX", (".PA", "EUR") }, // BOFA SECURITIES EUROPE
            { "MLER", (".PA", "EUR") }, // BOFA SECURITIES EUROPE - RFQ
            { "MLES", (".PA", "EUR") }, // BOFA SECURITIES EUROPE - SYSTEMATIC INTERNALISER
            { "MLIB", (".L", "GBP") }, // MERRILL LYNCH INTERNATIONAL BANK DESIGNATED ACTIVITY COMPANY
            { "MLIX", (".L", "GBP") }, // MERRILL LYNCH INTERNATIONAL
            { "MLRQ", (".L", "GBP") }, // MERRILL LYNCH INTERNATIONAL - RFQ
            { "MLSI", (".L", "GBP") }, // MERRILL LYNCH INTERNATIONAL - SYSTEMATIC INTERNALISER
            { "MLXN", (".L", "GBP") }, // BANK OF AMERICA - MERRILL LYNCH INSTINCT X - EUROPE
            { "MLAX", (".L", "GBP") }, // BANK OF AMERICA - MERRILL LYNCH AUCTION CROSS
            { "MLEU", (".L", "GBP") }, // BANK OF AMERICA - MERRILL LYNCH OTC - EUROPE
            { "MLVE", (".L", "GBP") }, // BANK OF AMERICA - MERRILL LYNCH VWAP CROSS - EUROPE
            { "MOON", ("", "USD") }, // MOON
            { "MSAL", (".AX", "AUD") }, // MORGAN STANLEY AUSTRALIA SECURITIES LIMITED
            { "MSAX", (".PA", "EUR") }, // MORGAN STANLEY MTF - PERIODIC AUCTION
            { "MSCX", (".PA", "EUR") }, // MORGAN STANLEY MTF - CONTINUOUS CROSS DARK
            { "MSNT", (".PA", "EUR") }, // MORGAN STANLEY MTF - NEGOTIATED TRADE
            { "MSBI", (".L", "GBP") }, // MORGAN STANLEY BANK INTERNATIONAL LIMITED
            { "MBSI", (".L", "GBP") }, // MORGAN STANLEY BANK INTERNATIONAL LIMITED - SYSTEMATIC INTERNALISER
            { "MSCO", ("", "USD") }, // MORGAN STANLEY AND CO. LLC
            { "MSLC", ("", "USD") }, // MS LONG CROSS
            { "MSLP", ("", "USD") }, // MORGAN STANLEY AUTOMATED LIQUIDITY PROVISION
            { "MSPL", ("", "USD") }, // MS POOL
            { "MSRP", ("", "USD") }, // MS RPOOL
            { "MSTC", ("", "USD") }, // MS TRAJECTORY CROSSING ATS
            { "MSTX", ("", "USD") }, // MS TRAJECTORY CROSS
            { "MSDM", (".WA", "PLN") }, // MICHAEL/STROM DOM MAKLERSKI SPOLKA AKCYJNA
            { "MSEL", ("N/A", "UNKNOWN") }, // MAREX SPECTRON EUROPE LIMITED - OTF
            { "MSEU", (".DE", "EUR") }, // MORGAN STANLEY EUROPE S.E.
            { "MESI", (".DE", "EUR") }, // MORGAN STANLEY EUROPE S.E. - SYSTEMATIC INTERNALISER
            { "MSIP", (".L", "GBP") }, // MORGAN STANLEY AND CO. INTERNATIONAL PLC
            { "MSSI", (".L", "GBP") }, // MORGAN STANLEY AND CO. INTERNATIONAL PLC - SYSTEMATIC INTERNALISER
            { "MSMS", (".T", "JPY") }, // MORGAN STANLEY MUFG SECURITIES CO., LTD
            { "EXPA", (".MI", "EUR") }, // EXPANDI MARKET
            { "MTAX", (".MI", "EUR") }, // MTAX
            { "MTSO", (".MI", "EUR") }, // MTS S.P.A.
            { "BOND", (".MI", "EUR") }, // BONDVISION ITALIA
            { "EBMX", (".MI", "EUR") }, // EBM - MTF
            { "MCAD", (".MI", "EUR") }, // MTS CASH DOMESTIC - MTF
            { "MSWP", (".MI", "EUR") }, // MTS INTERDEALER SWAPS MARKET
            { "MTSC", (".MI", "EUR") }, // MTS ITALIA
            { "MTSM", (".MI", "EUR") }, // MTS CORPORATE MARKET
            { "SSOB", (".MI", "EUR") }, // BONDVISION EUROPE MTF
            { "MTSP", (".WA", "PLN") }, // MTS POLAND
            { "MTUS", ("", "USD") }, // MTS MARKETS INTERNATIONAL INC.
            { "BVUS", ("", "USD") }, // BONDVISION US
            { "MTSB", ("", "USD") }, // MTS BONDS.COM
            { "MTXX", ("", "USD") }, // MARKETAXESS CORPORATION
            { "MKAA", ("", "USD") }, // MARKETAXESS ATS
            { "MTXA", ("", "USD") }, // MARKETAXESS CANADA COMPANY
            { "MTXC", ("", "USD") }, // MARKETAXESS CORPORATION SINGLE-NAME CDS CENTRAL LIMIT ORDER
            { "MTXM", ("", "USD") }, // MARKETAXESS CORPORATION MID-X TRADING SYSTEM
            { "MTXS", ("", "USD") }, // MARKETAXESS SEF CORPORATION
            { "MUBE", (".AS", "EUR") }, // MUFG BANK (EUROPE) N.V.
            { "MUBL", (".L", "GBP") }, // MUFG BANK, LTD. - LONDON BRANCH
            { "MUBM", (".MI", "EUR") }, // MUFG BANK, LTD. - MILANO BRANCH
            { "MUBP", (".PA", "EUR") }, // MUFG BANK, LTD. - PARIS BRANCH
            { "MUDX", (".T", "JPY") }, // MITSUBISHI DIAMOND CROSSING
            { "MUFP", (".L", "GBP") }, // MARIANA UFP LLP
            { "MUSE", (".L", "GBP") }, // MUFG SECURITIES EMEA PLC
            { "MUSN", (".AS", "EUR") }, // MUFG SECURITIES (EUROPE) N.V -
            { "MUTI", (".L", "GBP") }, // MITSUBISHI UFJ TRUST INTERNATIONAL LIMITED
            { "MYTR", (".L", "GBP") }, // MYTREASURY
            { "N2EX", (".L", "GBP") }, // N2EX
            { "NABE", (".L", "GBP") }, // NAB EUROPE LIMITED
            { "NABU", (".L", "GBP") }, // NAB EUROPE LIMITED  - FIXED INCOME SECURITIES
            { "NABL", (".L", "GBP") }, // NATIONAL AUSTRALIA BANK
            { "NABA", (".L", "GBP") }, // NATIONAL AUSTRALIA BANK - FX DERIVATIVES AND FIXED INCOME SECURITIES
            { "NABP", (".PA", "EUR") }, // NATIONAL AUSTRALIA BANK EUROPE S.A.
            { "NAMX", (".ME", "RUB") }, // NATIONAL MERCANTILE EXCHANGE
            { "NAPA", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - APA SERVICE
            { "NASB", ("N/A", "UNKNOWN") }, // NASDAQ BALTIC
            { "NASX", ("N/A", "UNKNOWN") }, // NASD OTC MARKET
            { "NATX", (".PA", "EUR") }, // NATIXIS
            { "NBFL", (".L", "GBP") }, // NATIONAL BANK FINANCIAL INC.
            { "NBLX", ("", "USD") }, // NOBLE EXCHANGE
            { "NBOT", (".NS", "INR") }, // NATIONAL BOARD OF TRADE LIMITED
            { "NCEL", ("N/A", "UNKNOWN") }, // PAKISTAN MERCANTILE EXCHANGE
            { "NCME", (".DE", "EUR") }, // SMBC NIKKO CAPITAL MARKETS EUROPE GMBH
            { "NCML", (".L", "GBP") }, // SMBC NIKKO CAPITAL MARKETS LIMITED
            { "NDCM", (".L", "GBP") }, // ICE ENDEX UK OCM GAS SPOT
            { "NDEX", (".AS", "EUR") }, // ICE ENDEX FUTURES
            { "IMCO", (".AS", "EUR") }, // ICE ENDEX OTF FUTURES
            { "IMEQ", (".AS", "EUR") }, // ICE MARKETS EQUITY
            { "NDXS", (".AS", "EUR") }, // ICE ENDEX EUROPEAN GAS SPOT
            { "NECD", (".AX", "AUD") }, // NSX DARK
            { "NEEQ", (".SS", "CNY") }, // NATIONAL EQUITIES EXCHANGE AND QUOTATIONS
            { "NEOE", (".TO", "CAD") }, // CBOE CANADA - NEO-L (MARKET BY ORDER)
            { "MATN", (".TO", "CAD") }, // CBOE CANADA - MATCHNOW
            { "NEOC", (".TO", "CAD") }, // NEO CONNECT
            { "NEOD", (".TO", "CAD") }, // CBOE CANADA - NEO-D (DARK)
            { "NEON", (".TO", "CAD") }, // CBOE CANADA - NEO-N (MARKET BY PRICE)
            { "NESI", (".DE", "EUR") }, // NOMURA FINANCIAL PRODUCTS EUROPE GMBH
            { "NEXO", (".OL", "NOK") }, // NOREXECO ASA
            { "NEXS", (".L", "GBP") }, // NEX SEF
            { "REST", (".L", "GBP") }, // NEX SEF MTF - RESET - RISK MITIGATION SERVICES
            { "NEXX", (".L", "GBP") }, // AQUIS STOCK EXCHANGE
            { "NEXD", (".L", "GBP") }, // AQSE MAIN MARKET (NON-EQUITY)
            { "NEXF", (".L", "GBP") }, // AQSE GROWTH MARKET (NON-EQUITY)
            { "NEXG", (".L", "GBP") }, // AQSE GROWTH MARKET (EQUITY)
            { "NEXL", (".L", "GBP") }, // AQSE MAIN MARKET (EQUITY)
            { "NEXN", (".L", "GBP") }, // AQSE TRADING (NON-EQUITY)
            { "NEXT", (".L", "GBP") }, // AQSE TRADING (EQUITY)
            { "NFSC", ("", "USD") }, // NATIONAL FINANCIAL SERVICES, LLC
            { "NFSA", ("", "USD") }, // FIDELITY CROSSSTREAM
            { "NFSD", ("", "USD") }, // FIDELITY DARK
            { "XSTM", ("", "USD") }, // FIDELITY CROSSSTREAM ATS
            { "NGXC", (".TO", "CAD") }, // NATURAL GAS EXCHANGE
            { "NIBC", (".AS", "EUR") }, // NIBC
            { "NILX", ("N/A", "UNKNOWN") }, // NILE STOCK EXCHANGE
            { "NLBX", (".DE", "EUR") }, // NORDDEUTSCHE LANDESBANK - GIROZENTRALE
            { "NLPX", (".AS", "EUR") }, // APX POWER NL
            { "NMCE", (".NS", "INR") }, // NATIONAL MULTI-COMMODITY EXCHANGE OF INDIA
            { "NMRA", ("", "USD") }, // NOMURA SECURITIES INTERNATIONAL
            { "NMRJ", (".T", "JPY") }, // NOMURA SECURITIES CO LTD
            { "ICHK", (".T", "JPY") }, // NOMURA ICE  - HK
            { "ICKR", (".T", "JPY") }, // NOMURA ICE  - KR
            { "ICSH", (".T", "JPY") }, // NOMURA ICE  - SH
            { "ICSZ", (".T", "JPY") }, // NOMURA ICE  - SZ
            { "ICTW", (".T", "JPY") }, // NOMURA ICE  - TW
            { "NMSX", (".T", "JPY") }, // NOMURA - EXTERNAL CROSSING PLATFORM
            { "NXBX", (".T", "JPY") }, // BLOCKMATCH JAPAN
            { "NXFO", (".T", "JPY") }, // NX FUTURES
            { "NXJP", (".T", "JPY") }, // NX JAPAN
            { "NXSE", (".T", "JPY") }, // NX SELECT JAPAN
            { "NXVW", (".T", "JPY") }, // NX VWAP
            { "NNCS", (".ME", "RUB") }, // REGIONAL EXCHANGE CENTRE - MICEX VOLGA REGION
            { "NODX", ("", "USD") }, // NODAL EXCHANGE
            { "NOFF", (".L", "GBP") }, // NOMURA OTC TRADES
            { "NOPS", (".OL", "NOK") }, // NORD POOL SPOT AS
            { "NORD", (".DE", "EUR") }, // HSH NORDBANK
            { "NORX", (".OL", "NOK") }, // NASDAQ OSLO ASA
            { "BULK", (".OL", "NOK") }, // NASDAQ COMMODITIES - BULK COMMODITY
            { "ELEU", (".OL", "NOK") }, // NASDAQ OSLO ASA - EUROPEAN POWER AND GAS DERIVATIVES
            { "ELNO", (".OL", "NOK") }, // NASDAQ OSLO ASA - NORDIC POWER DERIVATIVES AND EUROPEAN UNION ALLOWANCES
            { "ELSE", (".OL", "NOK") }, // NASDAQ OSLO ASA - SWEDISH ELECTRICITY CERTIFICATE
            { "ELUK", (".OL", "NOK") }, // NASDAQ COMMODITIES - GBP POWER/ENERGY
            { "FREI", (".OL", "NOK") }, // NASDAQ COMMODITIES - FREIGHT COMMODITY
            { "STEE", (".OL", "NOK") }, // NASDAQ COMMODITIES - STEEL COMMODITY
            { "NOSC", (".OL", "NOK") }, // NOS CLEARING ASA
            { "NOSI", (".L", "GBP") }, // NOMURA INTERNATIONAL PLC
            { "NOTC", (".OL", "NOK") }, // NORWEGIAN OVER THE COUNTER MARKET
            { "NOWX", (".PA", "EUR") }, // NOW CP - NEU CP
            { "NPEX", (".AS", "EUR") }, // NPEX
            { "NPGA", (".CO", "DKK") }, // GASPOINT NORDIC A/S
            { "NPMS", ("", "USD") }, // NASDAQ PRIVATE MARKET - SECONDMARKET
            { "NSPO", (".ST", "SEK") }, // NASDAQ SPOT AB
            { "NSSA", (".WA", "PLN") }, // NOBLE SECURITIES S.A.
            { "NSXB", (".AX", "AUD") }, // BENDIGO STOCK EXCHANGE LIMITED
            { "NTUK", (".L", "GBP") }, // NATIXIS LONDON BRANCH
            { "NURO", (".L", "GBP") }, // NASDAQ OMX EUROPE
            { "NOME", (".L", "GBP") }, // NASDAQ OMX EUROPE
            { "NURD", (".L", "GBP") }, // NASDAQ EUROPE (NURO) DARK
            { "XNLX", (".L", "GBP") }, // NASDAQ OMX NLX
            { "NWMS", (".L", "GBP") }, // NATWEST MARKETS PLC
            { "NWNV", (".AS", "EUR") }, // NATWEST MARKETS NV
            { "NXEU", (".L", "GBP") }, // NX
            { "NXTE", (".KS", "KRW") }, // NEXTRADE
            { "NXUS", ("", "USD") }, // NX ATS - CROSSING PLATFORM
            { "NYMX", (".L", "GBP") }, // NYMEX EUROPE LTD.
            { "NYPC", ("", "USD") }, // NEW YORK PORTFOLIO CLEARING
            { "NYSI", (".CO", "DKK") }, // NYKREDIT BANK
            { "OAPA", (".OL", "NOK") }, // OSLO BORS - APA
            { "OBGE", (".L", "GBP") }, // OB GROUP ENERGY LIMITED
            { "OBKL", ("N/A", "UNKNOWN") }, // OBERBANK AG
            { "OCEA", ("", "USD") }, // BLUE OCEAN ALTERNATIVE TRADING SYSTEM
            { "OCFX", ("", "USD") }, // ONECHRONOS FX
            { "OCSI", (".L", "GBP") }, // SOVA CAPITAL
            { "OCTC", ("", "USD") }, // OCTAURA - COLLATERALIZED LOAN OBLIGATION (CLO)
            { "OCTL", ("", "USD") }, // OCTAURA - LOANS
            { "OCXE", (".AS", "EUR") }, // ONECHRONOS MARKETS EUROPE
            { "OCXL", (".L", "GBP") }, // ONECHRONOS MARKETS UK
            { "ODDO", (".PA", "EUR") }, // ODDO BHF
            { "ODOC", (".PA", "EUR") }, // ODDO CONTREPARTIE
            { "ODXE", (".T", "JPY") }, // ODX - OSAKA DIGITAL EXCHANGE
            { "ODST", (".T", "JPY") }, // OSAKA DIGITAL EXCHANGE - START
            { "OFEX", (".L", "GBP") }, // OFEX
            { "OHVO", (".AS", "EUR") }, // OHV OTF
            { "OLBB", (".DE", "EUR") }, // OLDENBURGISCHE LANDESBANK AG FX  HANDEL
            { "OLLC", ("", "USD") }, // OTCEX LLC
            { "OMEL", (".MC", "EUR") }, // OMI POLO ESPANOL S.A. (OMIE)
            { "OMGA", (".TO", "CAD") }, // OMEGA ATS
            { "LYNX", (".TO", "CAD") }, // LYNX ATS
            { "OMIC", ("N/A", "UNKNOWN") }, // THE IBERIAN ENERGY CLEARING HOUSE
            { "OMIP", ("N/A", "UNKNOWN") }, // OMIP - POLO PORTUGUES, S.G.M.R., S.A. / OMIP DERIVATIVES MARKET
            { "ONEX", (".AS", "EUR") }, // ONE TRADING EXCHANGE
            { "ONEP", (".AS", "EUR") }, // ONE TRADING EXCHANGE - PERPETUALS
            { "OPCO", (".HE", "EUR") }, // OP CORPORATE BANK PLC
            { "OPEX", ("N/A", "UNKNOWN") }, // PEX-PRIVATE EXCHANGE
            { "OPMX", ("", "USD") }, // OPTIMX MARKETS, INC
            { "OPRA", ("", "USD") }, // OPTIONS PRICE REPORTING AUTHORITY
            { "OPSI", (".AS", "EUR") }, // OPTIVER V.O.F.
            { "OPTX", (".L", "GBP") }, // OPTAXE MTF
            { "OSDS", (".HK", "HKD") }, // OSL DIGITAL SECURITIES EXCHANGE
            { "OSLC", (".OL", "NOK") }, // SIX X-CLEAR AG
            { "OSSG", (".SI", "SGD") }, // OSL SG EXCHANGES
            { "OTCE", (".L", "GBP") }, // OTCEX
            { "OTCI", ("", "USD") }, // OTC LINK NQB IDQS (INTER-DEALER QUOTATION SYSTEM)
            { "OTCO", ("", "USD") }, // OTC OVERNIGHT
            { "OTCM", ("", "USD") }, // OTC LINK ATS - OTC MARKETS
            { "CAVE", ("", "USD") }, // CAVEAT EMPTOR
            { "EXPM", ("", "USD") }, // EXPERT MARKET
            { "OTCB", ("", "USD") }, // OTCQB MARKETPLACE
            { "OTCQ", ("", "USD") }, // OTCQX MARKETPLACE
            { "PINC", ("", "USD") }, // OTC PINK CURRENT
            { "PINI", ("", "USD") }, // OTC PINK NO INFORMATION
            { "PINL", ("", "USD") }, // OTC PINK LIMITED
            { "PINX", ("", "USD") }, // OTC PINK MARKETPLACE
            { "PSGM", ("", "USD") }, // OTC GREY MARKET
            { "OTCN", ("", "USD") }, // OTC LINK ECN
            { "OTCX", (".NS", "INR") }, // OTC EXCHANGE OF INDIA
            { "OTPB", ("N/A", "UNKNOWN") }, // OTP BANK NYRT
            { "OTPR", ("N/A", "UNKNOWN") }, // OTP BANK ROMANIA SA
            { "OTXB", (".SW", "CHF") }, // BERNER KANTONALBANK OTC-X
            { "OTXT", (".L", "GBP") }, // OTCX TRADING LIMITED UK MTF
            { "OYLD", ("", "USD") }, // OPENYIELD ATS
            { "PARK", (".WA", "PLN") }, // PARKER POLAND SP. ZO.O.
            { "PATF", (".PR", "CZK") }, // PATRIA FINANCE A.S.
            { "PAVE", (".MC", "EUR") }, // ALTERNATIVE PLATFORM FOR SPANISH SECURITIES
            { "PBGR", ("N/A", "UNKNOWN") }, // PIRAEUS BANK
            { "PDEX", ("N/A", "UNKNOWN") }, // PHILIPPINE DEALING AND EXCHANGE CORP
            { "PDQX", ("", "USD") }, // CODA MARKETS
            { "PDQD", ("", "USD") }, // CODA MARKETS ATS DARK
            { "PEEL", (".L", "GBP") }, // PEEL HUNT LLP UK
            { "PHSI", (".L", "GBP") }, // PEEL HUNT SYSTEMATIC INTERNALISER
            { "XPHX", (".L", "GBP") }, // PEEL HUNT CROSSING
            { "XRSP", (".L", "GBP") }, // PEEL HUNT RETAIL
            { "PEPW", (".ST", "SEK") }, // PEPINS - MTF
            { "PEPH", (".ST", "SEK") }, // PEPINS - MTF - HALF-YEAR
            { "PEPM", (".ST", "SEK") }, // PEPINS - MTF - MONTH
            { "PEPQ", (".ST", "SEK") }, // PEPINS - MTF - QUARTER
            { "PEPY", (".ST", "SEK") }, // PEPINS - MTF - YEAR
            { "PFTS", ("N/A", "UNKNOWN") }, // PFTS STOCK EXCHANGE
            { "PFTQ", ("N/A", "UNKNOWN") }, // PFTS QUOTE DRIVEN
            { "PGTP", (".SI", "SGD") }, // PAYWARD GLOBAL TRADING (KRAKEN)
            { "PIEU", (".L", "GBP") }, // ARITAS FINANCIAL LTD
            { "PIPE", ("", "USD") }, // ARITAS SECURITIES LLC
            { "PIPR", ("", "USD") }, // PIPER SANDLER AND CO.
            { "PJCX", ("", "USD") }, // PIPER SANDLER AND CO. - ATS
            { "PIRM", (".L", "GBP") }, // PIRUM
            { "PKOP", (".WA", "PLN") }, // BANK POLSKA KASA OPIEKI S.A.
            { "PMTS", ("N/A", "UNKNOWN") }, // MTS PORTUGAL SGMR, SA
            { "PMXX", ("N/A", "UNKNOWN") }, // PERPETUALS.COM
            { "POSE", (".MC", "EUR") }, // PORTFOLIO STOCK EXCHANGE
            { "POTC", ("N/A", "UNKNOWN") }, // PACIFIC OTC
            { "POTL", (".AX", "AUD") }, // PO TRADE LIQUIDITY
            { "PPEX", (".L", "GBP") }, // PROPERTY PARTNER EXCHANGE
            { "PRSE", ("", "USD") }, // PRAGMA ATS
            { "PTPG", (".WA", "PLN") }, // POLISH TRADING POINT
            { "PULX", ("", "USD") }, // INSTINET BLOCKCROSS ATS
            { "PUMA", ("", "USD") }, // PUMA CAPITAL, LLC
            { "PUMX", ("", "USD") }, // PUMA CAPITAL, LLC - OPTIONS
            { "PUND", ("", "USD") }, // PUNDION LLC
            { "PVBL", ("", "USD") }, // PROVABLE MARKETS
            { "PXIL", (".NS", "INR") }, // POWER EXCHANGE INDIA LTD.
            { "QMTF", ("N/A", "UNKNOWN") }, // QUOTE MTF
            { "XQLX", ("N/A", "UNKNOWN") }, // QLX
            { "QMTS", (".L", "GBP") }, // MTS QUASI GOVERNMENT
            { "QWIX", (".L", "GBP") }, // Q-WIXX PLATFORM
            { "R5FX", (".L", "GBP") }, // R5FX LIMITED
            { "RABL", (".L", "GBP") }, // RABOBANK INTERNATIONAL UK
            { "RABO", (".AS", "EUR") }, // RABOBANK
            { "RAJA", ("", "USD") }, // RAYMOND JAMES
            { "RBCB", ("N/A", "UNKNOWN") }, // RBC INVESTOR SERVICES BANK S.A.
            { "RBSI", ("N/A", "UNKNOWN") }, // RBC INVESTOR SERVICES BANK S.A. - SYSTEMATIC INTERNALISER
            { "RBCC", (".PA", "EUR") }, // RBC - PARIS BRANCH
            { "RBCE", (".L", "GBP") }, // RBC EUROPE LIMITED
            { "RBCG", (".DE", "EUR") }, // RBC CAPITAL MARKETS (EUROPE) GMBH
            { "RBCM", (".L", "GBP") }, // RBC - ROYAL BANK OF CANADA
            { "RBCS", ("", "USD") }, // RBC CAPITAL MARKETS LLC
            { "LAKE", ("", "USD") }, // RBC CAPITAL MARKETS LLC - HOSTED POOL
            { "RBCT", (".L", "GBP") }, // RBC INVESTOR SERVICES TRUST
            { "RTSI", (".L", "GBP") }, // RBC INVESTOR SERVICES TRUST - SYSTEMATIC INTERNALISER
            { "RBHU", ("N/A", "UNKNOWN") }, // RAIFFEISEN BANK (HUNGARY)
            { "RBIV", ("N/A", "UNKNOWN") }, // RAIFFEISEN BANK INTERNATIONAL AG
            { "RBSX", (".L", "GBP") }, // RBS CROSS
            { "RCMA", ("", "USD") }, // RBC CAPITAL MARKETS ARBITRAGE S.A.
            { "RENC", ("N/A", "UNKNOWN") }, // RENAISSANCE SECURITIES (CYPRUS) LIMITED
            { "RFBK", (".PR", "CZK") }, // RAIFFEISENBANK, AS.
            { "RFIM", ("N/A", "UNKNOWN") }, // REAL FORTUNE INVESTMENT L.L.C
            { "RICX", ("", "USD") }, // RIVERCROSS
            { "RICD", ("", "USD") }, // RIVERCROSS DARK
            { "RITS", (".NS", "INR") }, // REFINITIV - FORWARDS MATCHING
            { "RLBO", ("N/A", "UNKNOWN") }, // RAIFFEISENLANDESBANK OBERÖSTERREICH
            { "RMMS", (".JO", "ZAR") }, // RMB MORGAN STANLEY
            { "RMMX", (".JO", "ZAR") }, // RMB MORGAN STANLEY - INVENTORY MANAGER
            { "RMTF", ("N/A", "UNKNOWN") }, // REFINITIV MTF
            {
                "FXFM", ("N/A", "UNKNOWN")
            }, // FINANCIAL AND RISK TRANSACTIONS SERVICES IRELAND LIMITED - FORWARDS MATCHING
            { "FXRQ", ("N/A", "UNKNOWN") }, // FINANCIAL AND RISK TRANSACTIONS SERVICES IRELAND LIMITED - FXALL RFQ MTF
            { "FXRS", ("N/A", "UNKNOWN") }, // FINANCIAL AND RISK TRANSACTIONS SERVICES IRELAND LIMITED - FXALL RFS MTF
            { "ROCO", (".TW", "TWD") }, // TAIPEI EXCHANGE
            { "ROFX", ("N/A", "UNKNOWN") }, // ROSARIO FUTURE EXCHANGE
            { "ROSR", (".SW", "CHF") }, // SIX REPO AG
            { "XREP", (".SW", "CHF") }, // SIX REPO AG - CH REPO MARKET
            { "XROT", (".SW", "CHF") }, // SIX REPO AG - OTC SPOT MARKET
            { "ROTC", ("N/A", "UNKNOWN") }, // RWANDA OTC MARKET
            { "RPDX", (".ME", "RUB") }, // MOSCOW ENERGY EXCHANGE
            { "RR4G", (".AS", "EUR") }, // ROUTE4GAS
            { "RRSI", ("N/A", "UNKNOWN") }, // RAIFFEISEN BANK S.A. (ROMANIA)
            { "RSEX", ("N/A", "UNKNOWN") }, // RWANDA STOCK EXCHANGE
            { "RTSL", (".L", "GBP") }, // REFINITIV TRANSACTIONS SERVICES LIMITED
            { "ECNL", (".L", "GBP") }, // REFINITIV TRANSACTION SERVICES LIMITED - FX SPOT ECN
            { "TRAL", (".L", "GBP") }, // REFINITIV TRANSACTIONS SERVICES LIMITED - FXALL RFQ
            { "TRFW", (".L", "GBP") }, // REFINITIV TRANSACTION SERVICES LIMITED - FORWARDS MATCHING
            { "RTSP", (".SI", "SGD") }, // REFINITIV TRANSACTION SERVICES PTE. LTD
            { "FXSM", (".SI", "SGD") }, // REFINITIV MATCHING NDFS SINGAPORE
            { "RTXF", ("", "USD") }, // RTX FINTECH AND RESEARCH
            { "RULE", (".SW", "CHF") }, // RULEMATCH
            { "RUSX", (".ME", "RUB") }, // NON-PROFIT PARTNERSHIP FOR THE DEVELOPMENT OF FINANCIAL MARKET RTS
            { "RVSA", ("N/A", "UNKNOWN") }, // RAIFFEISENVERBAND SALZBURG
            { "S3FM", (".SW", "CHF") }, // SOCIETY3 FUNDERSMART
            { "SAGE", ("", "USD") }, // SAGETRADER
            { "SANT", (".MC", "EUR") }, // BANCO SANTANDER S.A.
            { "SB1M", (".OL", "NOK") }, // SPAREBANK 1 MARKETS
            { "SBEX", (".L", "GBP") }, // SCOTIABANK
            { "SBIJ", (".T", "JPY") }, // JAPANNEXT - J - MARKET
            { "SBIU", (".T", "JPY") }, // JAPANNEXT - U - MARKET
            { "SBIV", (".T", "JPY") }, // JAPANNEXT - VWAP CROSSING
            { "XSBI", (".T", "JPY") }, // JAPANNEXT - X - MARKET
            { "SBSI", (".CO", "DKK") }, // SYDBANK A/S
            { "SCAG", (".DE", "EUR") }, // STANDARD CHARTERED BANK AG
            { "SCLB", (".DE", "EUR") }, // SCALABLE CAPITAL
            { "SCOT", (".L", "GBP") }, // SCOTTISH STOCK EXCHANGE
            { "SCXO", ("", "USD") }, // SEED CX
            { "SCXA", ("", "USD") }, // SEED DIGITAL SECURITIES MARKET
            { "SCXF", ("", "USD") }, // SEED FUTURES
            { "SCXM", ("", "USD") }, // SEED DIGITAL COMMODITIES MARKET
            { "SCXS", ("", "USD") }, // SEED SEF
            { "ZERO", ("", "USD") }, // ZERO HASH
            { "SEBA", (".DE", "EUR") }, // STIFEL EUROPE BANK AG
            { "SEBL", ("N/A", "UNKNOWN") }, // SEB LITHUANIA
            { "SEBS", (".ST", "SEK") }, // SEB
            { "ENSX", (".ST", "SEK") }, // SEB ENSKILDA
            { "SEBX", (".ST", "SEK") }, // SEB - LIQUIDITY POOL
            { "SECC", ("N/A", "UNKNOWN") }, // SECDEX CLEARING LIMITED
            { "SECD", ("N/A", "UNKNOWN") }, // SECDEX DEPOSITORY LIMITED
            { "SECE", ("N/A", "UNKNOWN") }, // SECDEX EXCHANGE LIMITED
            { "SECF", (".L", "GBP") }, // SECFINEX
            { "SEDC", ("N/A", "UNKNOWN") }, // SECDEX DIGITAL CUSTODIAN LIMITED
            { "SEDR", (".L", "GBP") }, // SEEDRS - SECONDARY MARKET
            { "SELC", (".SA", "BRL") }, // SISTEMA ESPECIAL DE LIQUIDACAO E CUSTODIA DE TITULOS PUBLICOS
            { "SEMX", ("N/A", "UNKNOWN") }, // SEMOPX
            { "SEPE", ("N/A", "UNKNOWN") }, // STOCK EXCHANGE PERSPECTIVA
            { "SFCL", (".L", "GBP") }, // SWISSCANTO FUNDS CENTRE LIMITED
            { "SFMP", (".L", "GBP") }, // FIS SECURITIES FINANCE MATCHING PLATFORM
            { "SFOX", ("", "USD") }, // SFOX
            { "SGAS", ("", "USD") }, // SG AMERICAS SECURITIES, LLC
            { "SGA2", ("", "USD") }, // SG AMERICAS SECURITIES, LLC - SECOND VENUE
            { "SGEX", (".SS", "CNY") }, // SHANGHAI GOLD EXCHANGE
            { "SGMA", ("", "USD") }, // GOLDMAN SACH MTF
            { "SGMU", (".PA", "EUR") }, // SIGMA X EUROPE NON-DISPLAYED BOOK
            { "SGMV", (".PA", "EUR") }, // SIGMA X EUROPE AUCTION BOOK
            { "SGMW", (".PA", "EUR") }, // SIGMA X EUROPE NEGOTIATED TRADE
            { "SGMX", (".L", "GBP") }, // SIGMA X MTF NON-DISPLAYED BOOK
            { "SGMY", (".L", "GBP") }, // SIGMA X MTF - AUCTION BOOK
            { "SGMZ", (".L", "GBP") }, // SIGMA X MTF - NEGOTIATED TRADE
            { "SGOE", (".PA", "EUR") }, // SG OPTION EUROPE
            { "SHAR", (".L", "GBP") }, // ASSET MATCH
            { "SHAW", ("", "USD") }, // D.E. SHAW
            { "SHAD", ("", "USD") }, // D.E. SHAW DARK
            { "SIAB", (".WA", "PLN") }, // ALIOR BANK
            { "SIBC", ("N/A", "UNKNOWN") }, // SIB CYPRUS LTD
            { "SIDX", ("N/A", "UNKNOWN") }, // SCOTIABANK (IRELAND) DESIGNATED ACTIVITY COMPANY
            { "SIFX", (".L", "GBP") }, // SIEGE FX LIMITED
            { "SIGA", (".AX", "AUD") }, // SIGMA X AUSTRALIA
            { "SIGJ", (".T", "JPY") }, // SIGMA X JAPAN
            { "SIGX", ("", "USD") }, // SIGMA X CANADA
            { "SIMV", (".AX", "AUD") }, // SIM VENTURE SECURITIES EXCHANGE
            { "SISI", ("N/A", "UNKNOWN") }, // SUSQUEHANNA INTERNATIONAL SECURITIES LIMITED
            { "SISU", (".L", "GBP") }, // SUSQUEHANNA INTERNATIONAL SECURITIES LIMITED - LONDON BRANCH
            { "SKBB", ("N/A", "UNKNOWN") }, // SKB BANKA D.D. LJUBLJANA
            { "SKSI", (".CO", "DKK") }, // SPAREKASSEN KRONJYLLAND
            { "SKYX", (".L", "GBP") }, // SKYTRA
            { "SLHB", ("N/A", "UNKNOWN") }, // SALZBURGER LANDES-HYPOTHEKENBANK
            { "SLXT", (".L", "GBP") }, // SL-X - SECURITIES LENDING MTF
            { "SMBB", ("N/A", "EUR") }, // SUMITOMO MITSUI BANKING CORPORATION - BRUSSELS BRANCH
            { "SMBC", (".T", "JPY") }, // SMBC NIKKO SNET DARKPOOL
            { "SMBD", (".DE", "EUR") }, // SUMITOMO MITSUI BANKING CORPORATION - DUESSELDORF BRANCH
            { "SMBE", (".L", "GBP") }, // SUMITOMO MITSUI BANKING CORPORATION EUROPE LIMITED
            { "SMBG", (".L", "GBP") }, // SUMITOMO MITSUI BANKING CORPORATION - LONDON BRANCH
            { "SMBP", (".PA", "EUR") }, // SUMITOMO MITSUI BANKING CORPORATION EUROPE LIMITED - PARIS BRANCH
            { "SMEX", (".SI", "SGD") }, // SINGAPORE MERCANTILE EXCHANGE PTE LTD
            { "SMFE", ("", "USD") }, // SMALL EXCHANGE, INC - DESIGNATED CONTRACT MARKET
            { "SMFF", (".DE", "EUR") }, // SMBC BANK EU AG
            { "SNSI", (".CO", "DKK") }, // SPAR NORD BANK
            { "SNUK", (".L", "GBP") }, // SANTANDER UK
            { "SOHO", ("", "USD") }, // TWO SIGMA SECURITIES, LLC
            { "SPAX", ("", "USD") }, // SPECTRAXE
            { "SPBE", (".ME", "RUB") }, // SPB EXCHANGE - ALL MARKETS
            { "SPDX", (".L", "GBP") }, // SPREADEX
            { "SPEC", (".L", "GBP") }, // MAREX SPECTRON INTERNATIONAL LIMITED OTF
            { "SPEX", (".DE", "EUR") }, // SPECTRUM MARKETS
            { "SPIM", (".ME", "RUB") }, // ST. PETERSBURG INTERNATIONAL MERCANTILE EXCHANGE
            { "SPRZ", (".L", "GBP") }, // SPREADZERO
            { "SPTR", (".OL", "NOK") }, // SPAREBANK 1 SMN
            { "SPTX", ("", "USD") }, // SPOT FX
            { "SPXE", ("N/A", "UNKNOWN") }, // SPX
            { "SQUA", (".L", "GBP") }, // SQUARE GLOBAL - OTF
            { "SRPT", ("", "USD") }, // SPEEDROUTE LLC
            { "SSBI", (".DE", "EUR") }, // STATE STREET BANK INTERNATIONAL GMBH
            { "SSBM", (".DE", "EUR") }, // STATE STREET BANK INTERNATIONAL FX
            { "SSBT", (".L", "GBP") }, // STATE STREET BANK AND TRUST COMPANY
            { "SSFX", (".L", "GBP") }, // STATE STREET BANK AND TRUST FX
            { "SSEX", (".L", "GBP") }, // SOCIAL STOCK EXCHANGE
            { "SSIL", (".L", "GBP") }, // STATE STREET BANK INTERNATIONAL FX - LONDON BRANCH
            { "SSTX", ("", "USD") }, // E-EXCHANGE
            { "SSWM", (".DE", "EUR") }, // SSW MARKET MAKING
            { "STAL", (".L", "GBP") }, // SCHNEIDER OTF
            { "STAN", (".L", "GBP") }, // STANDARD CHARTERED
            { "STFL", (".L", "GBP") }, // STIFEL NICOLAUS EUROPE LIMITED
            { "STFU", ("", "USD") }, // STIFEL, NICOLAUS AND COMPANY, INCORPORATED
            { "STFX", ("", "USD") }, // STIFEL, NICOLAUS AND COMPANY, INCORPORATED
            { "STOX", (".SW", "CHF") }, // STOXX LIMITED
            { "XSCU", (".SW", "CHF") }, // STOXX LIMITED - CUSTOMIZED INDICES
            { "XSTV", (".SW", "CHF") }, // STOXX LIMITED - VOLATILITY INDICES
            { "XSTX", (".SW", "CHF") }, // STOXX LIMITED - INDICES
            { "STRM", ("", "USD") }, // PURESTREAM
            { "STSI", (".L", "GBP") }, // SUN TRADING INTERNATIONAL
            { "STXS", (".AS", "EUR") }, // STX FIXED INCOME
            { "SUNB", (".L", "GBP") }, // SUNRISE BROKERS
            { "SUNM", (".L", "GBP") }, // SUNRISE - MTF
            { "SUNO", (".L", "GBP") }, // SUNRISE - OTF
            { "SUNT", ("", "USD") }, // SUN TRADING LLC
            { "SVEX", (".ST", "SEK") }, // SVENSKA HANDELSBANKEN AB - SVEX
            { "SVES", (".ST", "SEK") }, // SVENSKA HANDELSBANKEN AB
            { "SVXI", ("N/A", "UNKNOWN") }, // SAINT VINCENT AND THE GRENADINES SECURITIES EXCHANGE
            { "SWAP", (".L", "GBP") }, // SWAPSTREAM
            { "SWBI", (".ST", "SEK") }, // SWEDBANK
            { "SWEE", ("N/A", "UNKNOWN") }, // SWEDBANK ESTONIA
            { "SWLT", ("N/A", "UNKNOWN") }, // SWEDBANK LITHUANIA
            { "SWLV", ("N/A", "UNKNOWN") }, // SWEDBANK LATVIA
            { "SXSI", (".CO", "DKK") }, // SAXO BANK A/S
            { "SYFX", (".SI", "SGD") }, // SYNOPTION
            { "SYNK", (".MI", "EUR") }, // SYNKRONY EXCHANGE
            { "T212", ("N/A", "UNKNOWN") }, // TRADING 212 LIMITED
            { "TCML", (".L", "GBP") }, // TIDE CM
            { "TDBL", (".L", "GBP") }, // TORONTO DOMINION BANK - LONDON BRANCH
            { "TDGF", ("N/A", "UNKNOWN") }, // TD SECURITIES
            { "TDON", (".PA", "EUR") }, // TRADITION PARIS - TSAF
            { "TDVS", ("N/A", "UNKNOWN") }, // TRADEVILLE
            { "TDXS", (".SW", "CHF") }, // TAURUS TDX
            { "TERA", ("", "USD") }, // RADIAL-X
            { "TERM", (".SI", "SGD") }, // TP ICAP FX HUB
            { "TPSG", (".SI", "SGD") }, // TP ICAP RMO
            { "TEUR", (".MC", "EUR") }, // TRADITION ESPANA OTF
            { "TFEX", (".BK", "THB") }, // THAILAND FUTURES EXCHANGE
            { "TFSA", (".SI", "SGD") }, // TFS GREEN AUSTRALIAN GREEN MARKETS
            { "TFSD", (".HK", "HKD") }, // T.F.S. DERIVATIVES HK LIMITED
            { "TFSU", ("", "USD") }, // TFS GREEN UNITED STATES GREEN MARKETS
            { "TFSV", (".L", "GBP") }, // VOLBROKER
            { "TGAT", (".DE", "EUR") }, // TRADEGATE EXCHANGE
            { "TGSI", (".DE", "EUR") }, // TRADEGATE AG - SYSTEMATIC INTERNALISER
            { "XGAT", (".DE", "EUR") }, // TRADEGATE EXCHANGE - FREIVERKEHR
            { "XGRM", (".DE", "EUR") }, // TRADEGATE EXCHANGE - REGULIERTER MARKT
            { "THEM", ("", "USD") }, // THEMIS TRADING LLC
            { "THRE", ("", "USD") }, // REFINITIV US SEF LLC
            { "FXNM", ("", "USD") }, // REFINITIV MATCHING NDFS SEF
            { "FXPS", ("", "USD") }, // REFINITIV SEF REQUEST FOR STREAM
            { "TICT", (".T", "JPY") }, // TOTAN ICAP CO. LTD
            { "TLAB", (".MI", "EUR") }, // TRADINGLAB
            { "TMCY", ("N/A", "UNKNOWN") }, // TRADING 212 MARKETS LIMITED
            { "TMEU", ("N/A", "UNKNOWN") }, // TRUMID EU MTF
            { "TMEX", (".IS", "TRY") }, // TURKISH MERCANTILE EXCHANGE
            { "EWRM", (".IS", "TRY") }, // TURKISH MERCANTILE EXCHANGE - ELECTRONIC WAREHOUSE RECEIPT MARKET
            { "FTRM", (".IS", "TRY") }, // TURKISH MERCANTILE EXCHANGE - FUTURES MARKET
            { "TMID", ("", "USD") }, // TRUMID ATS
            { "TMUK", (".L", "GBP") }, // TRUMID UK MTF
            { "TMXS", (".TO", "CAD") }, // TMX SELECT
            { "TOCP", (".HK", "HKD") }, // TORA CROSSPOINT
            { "TOMX", (".AS", "EUR") }, // TOM MTF CASH MARKETS
            { "TOMD", (".AS", "EUR") }, // TOM MTF DERIVATIVES MARKET
            { "TOWR", (".AS", "EUR") }, // TOWER RESEARCH CAPITAL EUROPE
            { "PCDS", (".L", "GBP") }, // TULLETT PREBON PLC - PREBON CDS
            { "TPDE", (".DE", "EUR") }, // TULLETT PREBON SECURITIES - FRANKFURT - OTF
            {
                "TSFF", (".DE", "EUR")
            }, // TULLETT PREBON SECURITIES - FRANKFURT - OTF - CORPORATE BONDS AND SECURITISED DEBT
            { "TSFG", (".DE", "EUR") }, // TULLETT PREBON SECURITIES - FRANKFURT - OTF - GOVERNMENT BONDS - EX GILTS
            { "TPEL", (".L", "GBP") }, // TULLETT PREBON (EUROPE) LIMITED
            { "TEFD", (".L", "GBP") }, // TULLETT PREBON EUROPE -  MTF - FX DERIVATIVES
            { "TEMB", (".L", "GBP") }, // TULLETT PREBON EUROPE -  MTF - GOVERNMENT BONDS EXCLUDING UK GILTS
            { "TEMC", (".L", "GBP") }, // TULLETT PREBON EUROPE -  MTF - COMMODITIES AND ENERGY DERIVATIVES
            { "TEMF", (".L", "GBP") }, // TULLETT PREBON EUROPE -  MTF - CORPORATE BONDS AND SECURITISED DEBT
            { "TEMG", (".L", "GBP") }, // TULLETT PREBON EUROPE -  MTF - GOVERNMENT BONDS - UK GILTS
            { "TEMI", (".L", "GBP") }, // TULLETT PREBON EUROPE -  MTF - MONEY MARKETS
            { "TEMR", (".L", "GBP") }, // TULLETT PREBON EUROPE -  MTF - REPOS
            { "TIRD", (".L", "GBP") }, // TULLETT PREBON EUROPE - MTF - INTEREST RATE DERIVATIVES
            { "TPEO", (".L", "GBP") }, // TP ICAP  E AND C OTF
            { "IECL", (".L", "GBP") }, // TP ICAP E. AND C. OTF – ICAP COMMODITIES AND ENERGY DERIVATIVES
            { "PVMF", (".L", "GBP") }, // TP ICAP E. AND C. OTF –  PVM COMMODITIES AND ENERGY DERIVATIVES
            { "TECO", (".L", "GBP") }, // TP ICAP  E AND C OTF - COMMODITY AND ENERGY DERIVATIVES
            { "TEFX", (".L", "GBP") }, // TULLETT PREBON EUROPE - OTF - FX DERIVATIVES
            { "TEGB", (".L", "GBP") }, // TULLETT PREBON EUROPE - OTF - GOVERNMENT BONDS EXCLUDING UK GILTS
            { "TEGI", (".L", "GBP") }, // TULLETT PREBON EUROPE - OTF - GOVERNMENT BONDS - UK GILTS
            { "TEIR", (".L", "GBP") }, // TULLETT PREBON EUROPE - OTF - INTEREST RATE DERIVATIVES
            { "TEMM", (".L", "GBP") }, // TULLETT PREBON EUROPE - OTF - MONEY MARKET INSTRUMENTS
            { "TEOF", (".L", "GBP") }, // TULLETT PREBON EUROPE - OTF - PREBON FX DERIVATIVES
            { "TERE", (".L", "GBP") }, // TULLETT PREBON EUROPE - OTF - REPOS
            { "TPES", (".MC", "EUR") }, // TULLETT PREBON EUROPE - OTF - MADRID
            { "TOMF", (".MC", "EUR") }, // TULLETT PREBON EUROPE - OTF - MADRID - CORPORATE BONDS AND SECURITISED DEBT
            { "TOMG", (".MC", "EUR") }, // TULLETT PREBON EUROPE - OTF - MADRID - GOVERNMENT BONDS - EXCLUDING GILTS
            { "TPEU", (".PA", "EUR") }, // TULLETT PREBON EU OTF
            { "TPER", (".PA", "EUR") }, // TULLETT PREBON EU OTF - REGISTRATION
            { "TPFR", (".PA", "EUR") }, // TULLETT PREBON EUROPE - OTF - PARIS
            { "TEPF", (".PA", "EUR") }, // TULLETT PREBON EUROPE - OTF - PARIS - CORPORATE BONDS AND SECURITISED DEBT
            { "TEPG", (".PA", "EUR") }, // TULLETT PREBON EUROPE - OTF - PARIS - GOVERNMENT BONDS - EXCLUDING GILTS
            { "TEPI", (".PA", "EUR") }, // TULLETT PREBON EUROPE - OTF - PARIS - INTEREST RATE DERIVATIVES
            { "TEPM", (".PA", "EUR") }, // TULLETT PREBON EUROPE - OTF - PARIS - MONEY MARKET INSTRUMENTS
            { "TEPR", (".PA", "EUR") }, // TULLETT PREBON EUROPE - OTF - PARIS - REPOS
            { "TEPX", (".PA", "EUR") }, // TULLETT PREBON EUROPE - OTF - PARIS - FX DERIVATIVES
            { "TPIC", (".PA", "EUR") }, // TP ICAP EU - MTF
            { "LNEQ", (".PA", "EUR") }, // TP ICAP EU - MTF - LIQUIDNET EU EQUITY
            { "LNFI", (".PA", "EUR") }, // TP ICAP EU - MTF - LIQUIDNET EU FIXED INCOME
            { "TPEE", (".PA", "EUR") }, // TP ICAP EU - MTF - EQUITY AND ETF
            { "TPIO", (".PA", "EUR") }, // TP ICAP EU - MTF - ORDERBOOK
            { "TPIR", (".PA", "EUR") }, // TP ICAP EU - MTF - REGISTRATION
            { "TPID", (".L", "GBP") }, // TP ICAP - UK - DIGITAL ASSETS
            { "TPDA", (".L", "GBP") }, // TP ICAP - UK - DIGITAL ASSETS - SPOT
            { "TPIE", (".L", "GBP") }, // THE PROPERTY INVESTMENT EXCHANGE
            { "TPIM", (".L", "GBP") }, // THE PROPERTY INVESTMENT MARKET
            { "TPIS", (".L", "GBP") }, // TULLETT PREBON - INSTITUTIONAL SERVICES - OTF
            {
                "TPLF", (".L", "GBP")
            }, // TULLETT PREBON - INSTITUTIONAL SERVICES - LIQUIDITY CHAIN - OTF - CORPORATE BONDS AND SECURITISED DEBT
            {
                "TPMF", (".L", "GBP")
            }, // TULLETT PREBON - INSTITUTIONAL SERVICES - MIREXA - OTF - CORPORATE BONDS AND SECURITISED DEBT
            { "TPMG", (".L", "GBP") }, // TULLETT PREBON - INSTITUTIONAL SERVICES - MIREXA - OTF - GOVERNMENT BONDS
            {
                "TPSY", (".L", "GBP")
            }, // TULLETT PREBON - INSTITUTIONAL SERVICES - TPSYNREX - OTF - CORPORATE BONDS AND SECURITISED DEBT
            { "TPSE", ("", "USD") }, // TP SEF, INC.
            { "TPSB", ("", "USD") }, // TP ICAP SEF
            { "TPSV", ("", "USD") }, // TPSEF, INC - VOICE
            { "TPSL", (".L", "GBP") }, // TULLETT PREBON SECURITIES - MTF
            { "TSMB", (".L", "GBP") }, // TULLETT PREBON SECURITIES - MTF - CORPORATE BONDS AND SECURITISED DEBT
            { "TSMC", (".L", "GBP") }, // TULLETT PREBON SECURITIES - MTF - CREDIT DERIVATIVES
            { "TSMG", (".L", "GBP") }, // TULLETT PREBON SECURITIES - MTF - GOVERNMENT BONDS EXCLUDING UK GILTS
            { "TSMI", (".L", "GBP") }, // TULLETT PREBON SECURITIES - MTF - MONEY MARKET INSTRUMENTS
            { "TSMR", (".L", "GBP") }, // TULLETT PREBON SECURITIES - MTF - REPOS
            { "TSUK", (".L", "GBP") }, // TULLETT PREBON SECURITIES - MTF - GOVERNMENT BONDS - UK GILTS
            { "TPSO", (".L", "GBP") }, // TP UK OTF
            { "TEEG", (".L", "GBP") }, // TULLETT PREBON SECURITIES - OTF - EUROPEAN GOVERNMENT BONDS
            { "TSCB", (".L", "GBP") }, // TP UK OTF - CORPORATE BONDS
            { "TSCD", (".L", "GBP") }, // TP UK OTF - CREDIT DERIVATIVES
            { "TSED", (".L", "GBP") }, // TP UK OTF - EQUITY DERIVATIVES
            { "TSFI", (".L", "GBP") }, // TP UK OTF - CORPORATE BONDS AND SECURITISED DEBT
            { "TSFX", (".L", "GBP") }, // TP UK OTF - FX DERIVATIVES
            { "TSGB", (".L", "GBP") }, // TP UK OTF - GOVERNMENT BONDS EXCLUDING UK GILTS
            { "TSGI", (".L", "GBP") }, // TP UK OTF - GOVERNMENT BONDS - UK GILTS
            { "TSIR", (".L", "GBP") }, // TP UK OTF - INTEREST RATE DERIVATIVES
            { "TSMM", (".L", "GBP") }, // TP UK OTF - MONEY MARKET INSTRUMENTS
            { "TSRE", (".L", "GBP") }, // TP UK OTF - REPOS
            { "TUOB", (".L", "GBP") }, // TP UK OTF - ORDERBOOK
            { "TQEX", (".AS", "EUR") }, // TURQUOISE EUROPE
            { "TQEA", (".AS", "EUR") }, // TURQUOISE EUROPE - LIT AUCTIONS
            { "TQEB", (".AS", "EUR") }, // TURQUOISE EUROPE - NYLON CASH ORDER BOOK
            { "TQEM", (".AS", "EUR") }, // TURQUOISE EUROPE - DARK
            { "TRAI", ("", "USD") }, // TRAIANA INC
            { "TRAS", (".HK", "HKD") }, // TRADITION ASIA LIMITED
            { "TRAX", (".L", "GBP") }, // MARKETAXESS POST-TRADE LIMITED - APA
            { "TRBX", (".DE", "EUR") }, // TRADE REPUBLIC BANK
            { "TRCK", ("", "USD") }, // TRACK ECN
            { "TRCX", ("", "USD") }, // TOWER RESEARCH CAPITAL TRCX
            { "TRDC", (".SI", "SGD") }, // TFS CURRENCIES PTE LTD
            { "TRDE", (".L", "GBP") }, // TRADITION
            { "DBVX", (".L", "GBP") }, // DBV-X
            { "ELIX", (".L", "GBP") }, // ELIXIUM
            { "EMCH", (".L", "GBP") }, // FINACOR EMATCH
            { "NAVE", (".L", "GBP") }, // NAVESIS-MTF
            { "OILX", (".L", "GBP") }, // OILX
            { "PARX", (".L", "GBP") }, // PARFX
            { "PFXD", (".L", "GBP") }, // PARNDF
            { "TCDS", (".L", "GBP") }, // TRADITION OTF
            { "TCME", (".L", "GBP") }, // TFS CME DIRECT
            { "TFSC", (".L", "GBP") }, // TFS GREEN CARBON CREDIT GLOBAL MARKETS
            { "TFSE", (".L", "GBP") }, // TFS GREEN EUROPEAN GREEN MARKETS
            { "TFSG", (".L", "GBP") }, // TRADITION ENERGY
            { "TFSS", (".L", "GBP") }, // TFS VARIANCE SWAPS SYSTEM
            { "TRDX", (".L", "GBP") }, // TRAD-X
            { "VOLA", (".L", "GBP") }, // TRADITION - VOLATIS
            { "TREU", (".L", "GBP") }, // TRADEWEB EUROPE LIMITED
            { "TREA", (".L", "GBP") }, // TRADEWEB EUROPE LIMITED - APA
            { "TREO", (".L", "GBP") }, // TRADEWEB EUROPE LIMITED - OTF
            { "TRNL", (".AS", "EUR") }, // MARKETAXESS POST-TRADE B.V. - APA
            { "TRPX", ("N/A", "UNKNOWN") }, // MERJ EXCHANGE LIMITED
            { "TRQX", (".L", "GBP") }, // TURQUOISE
            { "TRQA", (".L", "GBP") }, // TURQUOISE LIT AUCTIONS
            { "TRQB", (".L", "GBP") }, // TURQUOISE NYLON CASH ORDER BOOK
            { "TRQC", (".L", "GBP") }, // TURQUOISE NYLON CLEARED CONTRACT
            { "TRQD", (".L", "GBP") }, // TURQUOISE DERIVATIVES MARKET
            { "TRQM", (".L", "GBP") }, // TURQUOISE PLATO
            { "TRQS", (".L", "GBP") }, // TURQUOISE SWAPMATCH
            { "TRSI", (".L", "GBP") }, // TOWER RESEARCH CAPITAL EUROPE LTD
            { "TRUK", (".L", "GBP") }, // TRADING 212 UK LIMITED
            { "TRUX", ("", "USD") }, // TRUEEX LLC
            { "TRU1", ("", "USD") }, // TRUEEX LLC - DESIGNATED CONTRACT MARKET (DMC)
            { "TRU2", ("", "USD") }, // TRUEEX LLC - SEF (SWAP EXECUTION FACILITY)
            { "TRWB", ("", "USD") }, // TRADEWEB LLC
            { "BNDD", ("", "USD") }, // TRADEWEB DIRECT LLC
            { "DWSF", ("", "USD") }, // DW SEF LLC
            { "TRFX", ("", "USD") }, // TRADEWEB FX OPTIONS
            { "TWSF", ("", "USD") }, // TW SEF LLC
            { "TRXE", (".PA", "EUR") }, // TRAD-X EUROPE
            { "TSAD", ("", "USD") }, // TRADITION SECURITIES AND DERIVATIVES INC.
            { "TSAF", (".PA", "EUR") }, // TSAF OTC - OTF
            { "TSBX", ("", "USD") }, // DBOT ATS, LLC
            { "TSEF", ("", "USD") }, // TRADITION SEF
            { "TSBF", ("", "USD") }, // TRADITION SBSEF
            { "TSIG", (".SI", "SGD") }, // TRADITION SINGAPORE PTE. LTD.
            { "TWEU", (".AS", "EUR") }, // TRADEWEB EU BV
            { "TWEA", (".AS", "EUR") }, // TRADEWEB EU BV - APA
            { "TWEM", (".AS", "EUR") }, // TRADEWEB EU BV - MTF
            { "TWEO", (".AS", "EUR") }, // TRADEWEB EU BV - OTF
            { "TWGP", (".L", "GBP") }, // TRADEWEB EUROPE LIMITED - GLOBAL TRADING PLATFORM
            { "TWHK", (".HK", "HKD") }, // TRADEWEB EUROPE LIMITED - HONG KONG
            { "TWJP", (".T", "JPY") }, // TRADEWEB JAPAN KK - PTS
            { "TWJT", (".T", "JPY") }, // TRADEWEB JAPAN KK - ETP
            { "TWSG", (".SI", "SGD") }, // TRADEWEB EUROPE LIMITED - SINGAPORE
            { "U360", ("", "USD") }, // 360 TRADING NETWORKS INC.
            { "UBCZ", (".PR", "CZK") }, // UNICREDIT BANK CZECH REPUBLIC AND SLOVAKIA, A.S.
            { "UBEC", ("", "USD") }, // UNIVERSAL BARTER EXCHANGE CREDIT UNION
            { "UBIM", (".MI", "EUR") }, // UBI BANCA
            { "UBIN", (".L", "GBP") }, // UNION BANK OF INDIA UK LTD
            { "UBIS", (".MI", "EUR") }, // UNIPOL BANCA S.P.A.
            { "UBSA", ("", "USD") }, // UBS ATS
            { "UBSP", ("", "USD") }, // UBS PIN (UBS PRICE IMPROVEMENT NETWORK)
            { "XPIN", ("", "USD") }, // UBS PIN (UBS PRICE IMPROVEMENT NETWORK)
            { "UBSB", (".L", "GBP") }, // UBS AG LONDON BRANCH - TRADING
            { "UBSY", (".L", "GBP") }, // UBS AG LONDON BRANCH
            { "UBSD", (".DE", "EUR") }, // UBS EUROPE SE
            { "UBSG", (".SW", "CHF") }, // UBS TRADING
            { "UBSC", (".SW", "CHF") }, // UBS PIN-FX
            { "UBSF", (".SW", "CHF") }, // UBS FX
            { "UBSL", (".DE", "EUR") }, // UBS EUROPE SE - TRADING
            { "UBSE", (".L", "GBP") }, // UBS PIN (EMEA)
            { "UBSI", (".DE", "EUR") }, // UBS EUROPE SE
            { "UBSS", ("", "USD") }, // UBS SECURITIES LLC
            { "UBST", (".SW", "CHF") }, // UBS TRADING
            { "UBSX", (".HK", "HKD") }, // UBS CROSS
            { "UCBA", ("N/A", "UNKNOWN") }, // UNICREDIT BANK AUSTRIA AG
            { "UCBG", ("N/A", "UNKNOWN") }, // UNICREDIT BULBANK AD
            { "UCDE", (".DE", "EUR") }, // UNICREDIT BANK AG
            { "UCHU", ("N/A", "UNKNOWN") }, // UNICREDIT BANK HUNGARY ZRT.
            { "UCIT", (".MI", "EUR") }, // UNICREDIT SPA
            { "UFEX", ("N/A", "UNKNOWN") }, // UFEX
            { "UGEN", (".L", "GBP") }, // UNITEDBLOCKTRADE
            { "UICE", ("N/A", "UNKNOWN") }, // UKRAINIAN INTERBANK CURRENCY EXCHANGE
            { "UKCA", (".L", "GBP") }, // CREDIT AGRICOLE CIB UK BRANCH
            { "UKEX", ("N/A", "UNKNOWN") }, // UKRAINIAN EXCHANGE
            { "UKPX", (".L", "GBP") }, // EPEX SPOT
            { "ULTX", ("N/A", "UNKNOWN") }, // ALT XCHANGE (U)
            { "UMTS", (".L", "GBP") }, // MTS CEDULAS MARKET
            { "UNGB", (".L", "GBP") }, // UNICREDIT BANK AG - LONDON BRANCH - UK
            { "URCE", (".ME", "RUB") }, // REGIONAL EXCHANGE CENTRE - MICEX URAL
            { "USEF", ("", "USD") }, // 360 TRADING NETWORKS INC.
            { "UTSL", (".T", "JPY") }, // UEDA TRADITION SECURITIES LTD.
            { "VAGL", (".L", "GBP") }, // VIRTUAL AUCTION GLOBAL LIMITED
            { "VAGM", (".L", "GBP") }, // VIRTUAL AUCTION GLOBAL MARKETS - MTF
            { "VAMS", (".MC", "EUR") }, // VAMOS
            { "VAVO", (".AS", "EUR") }, // BITVAVO
            { "VCMO", (".L", "GBP") }, // VANTAGE CAPITAL MARKETS LLP - OTF
            { "VEGA", (".L", "GBP") }, // VEGA-CHI
            { "VERT", ("", "USD") }, // VERTICAL
            { "VFCM", ("", "USD") }, // VIRTU FINANCIAL CAPITAL MARKETS LLC
            { "VFEX", ("N/A", "UNKNOWN") }, // VICTORIA FALLS STOCK EXCHANGE
            { "VFGB", (".L", "GBP") }, // VIRTU FINANCIAL IRELAND LIMITED (LONDON BRANCH)
            { "VFIL", ("N/A", "UNKNOWN") }, // VIRTU FINANCIAL IRELAND LIMITED
            { "VFSI", ("N/A", "UNKNOWN") }, // VIRTU FINANCIAL IRELAND LIMITED - SYSTEMATIC INTERNALISER
            { "VFXO", ("N/A", "UNKNOWN") }, // VIRTU FINANCIAL IRELAND LIMITED - OTC
            { "VFUK", (".L", "GBP") }, // VIRTU FINANCIAL IRELAND LIMITED (LONDON BRANCH)
            { "VIRT", ("", "USD") }, // VIRTU FINANCIAL BD
            { "VIUK", (".L", "GBP") }, // POSIT UK
            { "XPAL", (".L", "GBP") }, // POSIT AUCTION UK
            { "XPOL", (".L", "GBP") }, // POSIT DARK UK
            { "VLEX", (".SW", "CHF") }, // VONTOBEL LIQUIDITY EXTENDER
            { "VMEX", ("N/A", "UNKNOWN") }, // VENOMEX LIMITED
            { "ABXX", ("N/A", "UNKNOWN") }, // VENOMEX LIMITED (EX. YOSHI MARKETS)
            { "VMFX", ("N/A", "UNKNOWN") }, // THE FAROESE SECURITIES MARKET
            { "VONT", (".DE", "EUR") }, // BANK VONTOBEL EUROPE AG
            { "VTBC", (".L", "GBP") }, // VTB CAPITAL PLC
            { "VUBA", ("N/A", "UNKNOWN") }, // VSEOBECNA UVEROVA BANKA, AS
            { "VUSA", ("", "USD") }, // VIRTU AMERICAS LLC
            { "VALX", ("", "USD") }, // VIRTU CLIENT MARKET MAKING
            { "VCRS", ("", "USD") }, // VIRTU MATCHIT - CONDITIONAL ROOM
            { "VFMI", ("", "USD") }, // VIRTU MATCHIT - MAIN CROSSING SESSION
            { "VWDX", (".DE", "EUR") }, // VWD TRANSACTIONSOLUTIONS AG
            { "VTLS", (".DE", "EUR") }, // TRADELINK
            { "VTPS", (".DE", "EUR") }, // TRADEPLUS
            { "VWDA", (".DE", "EUR") }, // VWD - APA SERVICE
            { "WBKP", (".WA", "PLN") }, // BANK ZACHODNI WBK S.A.
            { "WEED", ("", "USD") }, // WEEDEN AND CO MARKETS
            { "XWEE", ("", "USD") }, // WEEDEN ATS
            { "WELN", (".L", "GBP") }, // WEL
            { "WELS", ("", "USD") }, // WELLS FARGO SECURITIES, LLC - EQUITIES
            { "WFLP", ("", "USD") }, // WELLS FARGO SECURITIES, LLC - EQUITIES - LIQUIDITY PROVIDERS
            { "WELX", ("", "USD") }, // WELLS FARGO LIQUIDITY CROSS ATS
            { "WFLB", (".L", "GBP") }, // WELLS FARGO BANK NA - LONDON BRANCH
            { "WFSE", (".PA", "EUR") }, // WELLS FARGO SECURITIES EUROPE, S.A.
            { "WINS", (".L", "GBP") }, // WINTERFLOOD SECURITIES LIMITED - ELECTRONIC PLATFORM
            { "WINX", (".L", "GBP") }, // WINTERFLOOD SECURITIES LIMITED - MANUAL TRADING
            { "WMFS", (".L", "GBP") }, // WEMATCH
            { "WMSW", (".L", "GBP") }, // WEMATCH - SWAPS
            { "WMUS", ("", "USD") }, // WEMATCH US
            { "WTRS", ("", "USD") }, // WEMATCH US - SWAPS
            { "WOOD", (".PR", "CZK") }, // WOOD AND COMPANY FINANCIAL SERVICES, A.S.
            { "WSAG", ("", "USD") }, // WALL STREET ACCESS
            { "VNDM", ("", "USD") }, // WALL STREET ACCESS NYC - VNDM
            { "WABR", ("", "USD") }, // WALL STREET ACCESS NYC
            { "WSIL", (".L", "GBP") }, // WELLS FARGO SECURITIES INTERNATIONAL
            { "WSIN", (".L", "GBP") }, // WESTPAC BANKING CORPORATION
            { "XA1X", ("N/A", "UNKNOWN") }, // A1
            { "XABC", (".ST", "SEK") }, // ABG SUNDAL COLLIER AB
            { "XABG", (".OL", "NOK") }, // ABG SUNDAL COLLIER ASA
            { "XABJ", ("N/A", "UNKNOWN") }, // BOURSE DES VALEURS ABIDJAN
            { "XABX", (".SI", "SGD") }, // ABAXX EXCHANGE
            { "XACE", (".AS", "EUR") }, // AMSTERDAM COMMODITY EXCHANGE
            { "XADS", ("N/A", "UNKNOWN") }, // ABU DHABI SECURITIES EXCHANGE
            { "XAEX", (".AS", "EUR") }, // AEX-AGRICULTURAL FUTURES EXCHANGE
            { "XAFR", (".PA", "EUR") }, // ALTERNATIVA FRANCE
            { "XAFX", ("N/A", "UNKNOWN") }, // AFRICAN STOCK EXCHANGE
            { "XALB", (".TO", "CAD") }, // ALBERTA STOCK EXCHANGE, THE
            { "XALG", ("N/A", "UNKNOWN") }, // ALGIERS STOCK EXCHANGE
            { "XALS", ("N/A", "UNKNOWN") }, // ALBANIA SECURITIES EXCHANGE
            { "XALT", (".L", "GBP") }, // ALTEX - ATS
            { "XAMM", ("N/A", "UNKNOWN") }, // AMMAN STOCK EXCHANGE
            { "AMNL", ("N/A", "UNKNOWN") }, // AMMAN STOCK EXCHANGE - NON-LISTED SECURITIES MARKET
            { "XAMS", (".AS", "EUR") }, // EURONEXT - EURONEXT AMSTERDAM
            { "ALXA", (".AS", "EUR") }, // EURONEXT - ALTERNEXT AMSTERDAM
            { "DAMS", (".AS", "EUR") }, // EURONEXT AMSTERDAM – DARK BOOK FACILITY
            { "TNLA", (".AS", "EUR") }, // EURONEXT - TRADED BUT NOT LISTED AMSTERDAM
            { "XAMC", (".AS", "EUR") }, // EURONEXT AMSTERDAM – MULTI-CURRENCY TRADING
            { "XEUC", (".AS", "EUR") }, // EURONEXT COM, COMMODITIES FUTURES AND OPTIONS
            { "XEUE", (".AS", "EUR") }, // EURONEXT EQF, EQUITIES AND INDICES DERIVATIVES
            { "XEUI", (".AS", "EUR") }, // EURONEXT IRF, INTEREST RATE FUTURE AND OPTIONS
            { "XHFT", (".AS", "EUR") }, // ARCA EUROPE
            { "XAND", (".SI", "SGD") }, // ASIANEXT DERIVATIVES
            { "XANM", (".SI", "SGD") }, // ASIANEXT TOKEN MARKETPLACE
            { "XANS", (".SI", "SGD") }, // ASIANEXT CRYPTO SPOT
            { "XANT", ("N/A", "EUR") }, // BEURS VAN ANTWERPEN (ANTWERP STOCK EXCHANGE)
            { "XAOM", (".AX", "AUD") }, // AUSTRALIAN OPTIONS MARKET
            { "XAPI", (".ME", "RUB") }, // REGIONAL EXCHANGE CENTRE - MICEX FAR EAST
            { "XAQS", ("", "USD") }, // AUTOMATED EQUITY FINANCE MARKETS
            { "XARC", ("", "USD") }, // THE ARCHIPELAGO ECN
            { "XARM", ("N/A", "UNKNOWN") }, // ARMENIA SECURITIES EXCHANGE
            { "XASX", (".AX", "AUD") }, // ASX - ALL MARKETS
            { "ASXB", (".AX", "AUD") }, // ASX BOOKBUILD
            { "ASXC", (".AX", "AUD") }, // ASX - CENTRE POINT
            { "ASXP", (".AX", "AUD") }, // ASX - PUREMATCH
            { "ASXT", (".AX", "AUD") }, // ASX TRADEMATCH
            { "ASXV", (".AX", "AUD") }, // ASX - VOLUMEMATCH
            { "NZFX", (".AX", "AUD") }, // ASX - NEW ZEALAND FUTURES AND OPTIONS
            { "XSFE", (".AX", "AUD") }, // ASX - TRADE24
            { "XATS", (".TO", "CAD") }, // ALPHA EXCHANGE
            { "ADRK", (".TO", "CAD") }, // ALPHA DRK
            { "XATX", (".TO", "CAD") }, // ALPHA-X
            { "XAUK", (".NZ", "NZD") }, // NEW ZEALAND STOCK EXCHANGE - AUCKLAND
            { "XAZX", ("", "USD") }, // ARIZONA STOCK EXCHANGE
            { "XBAA", ("N/A", "UNKNOWN") }, // BAHAMAS INTERNATIONAL SECURITIES EXCHANGE
            { "XBAB", ("N/A", "UNKNOWN") }, // BARBADOS STOCK EXCHANGE
            { "BAJM", ("N/A", "UNKNOWN") }, // BARBADOS STOCK EXCHANGE - JUNIOR MARKET
            { "XBIS", ("N/A", "UNKNOWN") }, // BARBADOS STOCK EXCHANGE - INTERNATIONAL SECURITIES MARKET
            { "XBAH", ("N/A", "UNKNOWN") }, // BAHRAIN BOURSE
            { "XBAN", (".NS", "INR") }, // BANGALORE STOCK EXCHANGE LTD
            { "XBAV", (".MC", "EUR") }, // MERCHBOLSA AGENCIA DE VALORES, S.A.
            { "XBBF", (".SA", "BRL") }, // BOLSA BRASILIERA DE FUTUROS
            { "XBBJ", (".JK", "IDR") }, // JAKARTA FUTURES EXCHANGE (BURSA BERJANGKA JAKARTA)
            { "XBBK", (".TO", "CAD") }, // PERIMETER FINANCIAL CORP. - BLOCKBOOK ATS
            { "XBCC", ("N/A", "UNKNOWN") }, // BOLSA DE COMERCIO DE CORDOBA
            { "MVCX", ("N/A", "UNKNOWN") }, // MERCADO DE VALORES DE CORDOBA S.A.
            { "XBCE", ("N/A", "UNKNOWN") }, // BUDAPEST COMMODITY EXCHANGE
            { "XBCL", ("N/A", "UNKNOWN") }, // LA BOLSA ELECTRONICA DE CHILE
            { "XBCM", ("N/A", "UNKNOWN") }, // BOLSA DE COMERCIO DE MENDOZA S.A.
            { "XBCX", ("N/A", "UNKNOWN") }, // MERCADO DE VALORES DE MENDOZA S.A.
            { "XBCV", ("N/A", "UNKNOWN") }, // BOLSA CENTROAMERICANA DE VALORES S.A.
            { "XBDA", ("N/A", "UNKNOWN") }, // BERMUDA STOCK EXCHANGE LTD
            { "XBDV", ("N/A", "UNKNOWN") }, // BOLSA DE DIVIDA E VALORES DE ANGOLA (BODIVA) - ANGOLA SECURITIES EXCHANGE
            { "XBEL", ("N/A", "UNKNOWN") }, // BELGRADE STOCK EXCHANGE
            { "XBER", (".DE", "EUR") }, // BOERSE BERLIN
            { "BERA", (".DE", "EUR") }, // BOERSE BERLIN - REGULIERTER MARKT
            { "BERB", (".DE", "EUR") }, // BOERSE BERLIN - FREIVERKEHR
            { "BERC", (".DE", "EUR") }, // BOERSE BERLIN - BERLIN SECOND REGULATED MARKET
            { "EQTA", (".DE", "EUR") }, // BOERSE BERLIN EQUIDUCT TRADING - REGULIERTER MARKT
            { "EQTB", (".DE", "EUR") }, // BOERSE BERLIN EQUIDUCT TRADING - BERLIN SECOND REGULATED MARKET
            { "EQTC", (".DE", "EUR") }, // BOERSE BERLIN EQUIDUCT TRADING - FREIVERKEHR
            { "EQTD", (".DE", "EUR") }, // BOERSE BERLIN EQUIDUCT TRADING - OTC
            { "XEQT", (".DE", "EUR") }, // BOERSE BERLIN EQUIDUCT TRADING
            { "ZOBX", (".DE", "EUR") }, // ZOBEX
            { "XBEY", ("N/A", "UNKNOWN") }, // BOURSE DE BEYROUTH - BEIRUT STOCK EXCHANGE
            { "XBFO", ("N/A", "EUR") }, // BELGIAN FUTURES AND OPTIONS EXCHANGE
            { "XBKK", (".BK", "THB") }, // STOCK EXCHANGE OF THAILAND
            { "XBKF", (".BK", "THB") }, // STOCK EXCHANGE OF THAILAND - FOREIGN BOARD
            { "XMAI", (".BK", "THB") }, // MARKET FOR ALTERNATIVE INVESTMENT
            { "XBLB", ("N/A", "UNKNOWN") }, // BANJA LUKA STOCK EXCHANGE
            { "BLBF", ("N/A", "UNKNOWN") }, // BANJA LUKA STOCK EXCHANGE - FREE MARKET
            { "XBLN", (".PA", "EUR") }, // BLUENEXT
            { "XBMF", (".SA", "BRL") }, // BOLSA DE MERCADORIAS E FUTUROS
            { "XBMK", ("", "USD") }, // BONDMART
            { "XBNV", ("N/A", "UNKNOWN") }, // BOLSA NACIONAL DE VALORES, S.A.
            { "XBOG", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES DE COLOMBIA
            { "XBOL", ("N/A", "UNKNOWN") }, // BOLSA BOLIVIANA DE VALORES S.A.
            { "XBOM", (".NS", "INR") }, // BSE LTD
            { "BSME", (".NS", "INR") }, // BSE SME
            { "XBOT", ("N/A", "UNKNOWN") }, // BOTSWANA STOCK EXCHANGE
            { "BOTE", ("N/A", "UNKNOWN") }, // BOTSWANA STOCK EXCHANGE - EXCHANGE TRADED FUNDS (ETF)
            { "BOTV", ("N/A", "UNKNOWN") }, // BOTSWANA STOCK EXCHANGE - VENTURE CAPITAL
            { "XBOX", ("", "USD") }, // BOX OPTIONS EXCHANGE
            { "XBRA", ("N/A", "UNKNOWN") }, // BRATISLAVA STOCK EXCHANGE
            { "EBRA", ("N/A", "UNKNOWN") }, // BRATISLAVA STOCK EXCHANGE - MTF
            { "XBRE", (".DE", "EUR") }, // BREMER WERTPAPIERBOERSE
            { "XBRM", ("N/A", "UNKNOWN") }, // ROMANIAN  COMMODITIES EXCHANGE
            { "BRMF", ("N/A", "UNKNOWN") }, // ROMANIAN  COMMODITIES EXCHANGE - BRM-SMT
            { "EMCE", ("N/A", "UNKNOWN") }, // ROMANIAN  COMMODITIES EXCHANGE - OTF
            { "XBRN", (".SW", "CHF") }, // BX SWISS AG
            { "EQWB", (".SW", "CHF") }, // BX WORLDCAPS
            { "XBRU", ("N/A", "EUR") }, // EURONEXT - EURONEXT BRUSSELS
            { "ALXB", ("N/A", "EUR") }, // EURONEXT GROWTH BRUSSELS
            { "DBRU", ("N/A", "EUR") }, // EURONEXT BRUSSELS – DARK BOOK FACILITY
            { "ENXB", ("N/A", "EUR") }, // EURONEXT - EASY NEXT
            { "MLXB", ("N/A", "EUR") }, // EURONEXT ACCESS BRUSSELS
            { "TNLB", ("N/A", "EUR") }, // EURONEXT - TRADING FACILITY BRUSSELS
            { "TNLK", ("N/A", "EUR") }, // EURONEXT BLOCKS
            { "VPXB", ("N/A", "EUR") }, // EURONEXT - VENTES PUBLIQUES BRUSSELS
            { "XBRD", ("N/A", "EUR") }, // EURONEXT - EURONEXT BRUSSELS - DERIVATIVES
            { "XBRV", ("N/A", "UNKNOWN") }, // BOURSE REGIONALE DES VALEURS MOBILIERES
            { "XBRY", (".WA", "PLN") }, // XBERRY
            { "XBSE", ("N/A", "UNKNOWN") }, // SPOT REGULATED MARKET - BVB
            { "XBSD", ("N/A", "UNKNOWN") }, // DERIVATIVES REGULATED MARKET - BVB
            { "XCAN", ("N/A", "UNKNOWN") }, // CAN - ATS
            { "XMTI", ("N/A", "UNKNOWN") }, // BVB MTS INTERNATIONAL
            { "XNRG", ("N/A", "UNKNOWN") }, // BVB ENERGY DERIVATIVES
            { "XRAS", ("N/A", "UNKNOWN") }, // RASDAQ
            { "XBSP", (".SA", "BRL") }, // BOLSA DE VALORES DE SAO PAULO
            { "XBTF", ("", "USD") }, // BROKERTEC FUTURES EXCHANGE
            { "XBUD", ("N/A", "UNKNOWN") }, // BUDAPEST STOCK EXCHANGE
            { "BETA", ("N/A", "UNKNOWN") }, // BETA MARKET
            { "XBND", ("N/A", "UNKNOWN") }, // BUDAPEST STOCK EXCHANGE - XBOND
            { "XTND", ("N/A", "UNKNOWN") }, // XTEND
            { "XBUE", ("N/A", "UNKNOWN") }, // BOLSA DE COMERCIO DE BUENOS AIRES
            { "XMEV", ("N/A", "UNKNOWN") }, // MERCADO DE VALORES DE BUENOS AIRES S.A.
            { "XBUL", ("N/A", "UNKNOWN") }, // BULGARIAN STOCK EXCHANGE
            { "ABUL", ("N/A", "UNKNOWN") }, // BULGARIAN STOCK EXCHANGE - ALTERNATIVE MARKET
            { "GBUL", ("N/A", "UNKNOWN") }, // BULGARIAN STOCK EXCHANGE - SME GROWTH MARKET BEAM
            { "IBUL", ("N/A", "UNKNOWN") }, // BULGARIAN STOCK EXCHANGE - INTERNATIONAL INSTRUMENTS
            { "JBUL", ("N/A", "UNKNOWN") }, // BULGARIAN STOCK EXCHANGE - INTERNATIONAL MTF
            { "LBUL", ("N/A", "UNKNOWN") }, // BULGARIAN STOCK EXCHANGE - SBL
            { "PBUL", ("N/A", "UNKNOWN") }, // BULGARIAN STOCK EXCHANGE - APA
            { "ZBUL", ("N/A", "UNKNOWN") }, // BULGARIAN STOCK EXCHANGE - MAIN MARKET
            { "XBVC", ("N/A", "UNKNOWN") }, // CAPE VERDE STOCK EXCHANGE
            { "XBVM", ("N/A", "UNKNOWN") }, // MOZAMBIQUE STOCK  EXCHANGE
            { "XBVP", (".SA", "BRL") }, // BOLSA DE VALORES DO PARANA
            { "XBVR", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES DE LA REPUBLICA DOMINICANA SA.
            { "NBXO", ("", "USD") }, // NASDAQ OMX BX OPTIONS
            { "XCAI", ("N/A", "UNKNOWN") }, // EGYPTIAN EXCHANGE
            { "XCAL", (".NS", "INR") }, // CALCUTTA STOCK EXCHANGE
            { "XCAS", ("N/A", "UNKNOWN") }, // CASABLANCA STOCK EXCHANGE
            { "XCAY", ("N/A", "UNKNOWN") }, // CAYMAN ISLANDS STOCK EXCHANGE
            { "XCBO", ("", "USD") }, // CBOE GLOBAL MARKETS INC.
            { "BATO", ("", "USD") }, // CBOE BZX OPTIONS EXCHANGE
            { "BATS", ("", "USD") }, // CBOE BZX U.S. EQUITIES EXCHANGE
            { "BATY", ("", "USD") }, // CBOE BYX U.S. EQUITIES EXCHANGE
            { "BYXD", ("", "USD") }, // CBOE BYX U.S. EQUITIES EXCHANGE DARK
            { "BZXD", ("", "USD") }, // CBOE BZX U.S. EQUITIES EXCHANGE DARK
            { "C2OX", ("", "USD") }, // CBOE C2 OPTIONS EXCHANGE
            { "CBSX", ("", "USD") }, // CBOE STOCK EXCHANGE
            { "CONE", ("", "USD") }, // CBOE OPTIONS EXCHANGE
            { "CTWO", ("", "USD") }, // CBOE C2 OPTIONS EXCHANGE
            { "EDDP", ("", "USD") }, // CBOE EDGX U.S. EQUITIES EXCHANGE DARK
            { "EDGA", ("", "USD") }, // CBOE EDGA U.S. EQUITIES EXCHANGE
            { "EDGD", ("", "USD") }, // CBOE EDGA U.S. EQUITIES EXCHANGE DARK
            { "EDGO", ("", "USD") }, // CBOE EDGX OPTIONS EXCHANGE
            { "EDGX", ("", "USD") }, // CBOE EDGX U.S. EQUITIES EXCHANGE
            { "XCBD", ("", "USD") }, // CBOE DIGITAL EXCHANGE
            { "XCBF", ("", "USD") }, // CBOE FUTURES EXCHANGE
            { "XCBT", ("", "USD") }, // CHICAGO BOARD OF TRADE
            { "FCBT", ("", "USD") }, // CHICAGO BOARD OF TRADE (FLOOR)
            { "XKBT", ("", "USD") }, // KANSAS CITY BOARD OF TRADE
            { "XCCE", (".T", "JPY") }, // CHUBU COMMODITY EXCHANGE
            { "XCCX", ("", "USD") }, // CHICAGO CLIMATE EXCHANGE, INC
            { "XCDE", ("N/A", "UNKNOWN") }, // BAXTER FINANCIAL SERVICES
            { "XCET", ("N/A", "UNKNOWN") }, // UZBEK COMMODITY EXCHANGE
            { "XCFE", (".SS", "CNY") }, // CHINA FOREIGN EXCHANGE TRADE SYSTEM
            { "CFBC", (".SS", "CNY") }, // CHINA FOREIGN EXCHANGE TRADE SYSTEM - SHANGHAI - HONG KONG BOND CONNECT
            { "XCFF", ("", "USD") }, // CANTOR FINANCIAL FUTURES EXCHANGE
            { "XCGS", (".HK", "HKD") }, // CHINESE GOLD AND SILVER EXCHANGE SOCIETY
            { "XCHG", ("N/A", "UNKNOWN") }, // CHITTAGONG STOCK EXCHANGE LTD.
            { "XCIE", ("N/A", "UNKNOWN") }, // THE INTERNATIONAL STOCK EXCHANGE
            { "XCME", ("", "USD") }, // CHICAGO MERCANTILE EXCHANGE
            { "CBTS", ("", "USD") }, // CME SWAPS MARKETS (CBOT)
            { "CECS", ("", "USD") }, // CME SWAPS MARKETS (COMEX)
            { "CMES", ("", "USD") }, // CME SWAPS MARKETS (CME)
            { "FCME", ("", "USD") }, // CHICAGO MERCANTILE EXCHANGE (FLOOR)
            { "NYMS", ("", "USD") }, // CME SWAPS MARKETS (NYMEX)
            { "XIMM", ("", "USD") }, // INTERNATIONAL MONETARY MARKET
            { "XIOM", ("", "USD") }, // INDEX AND OPTIONS MARKET
            { "XCNF", ("N/A", "UNKNOWN") }, // BOLSA DE COMERCIO CONFEDERADA S.A.
            { "XCNQ", (".TO", "CAD") }, // CANADIAN SECURITIES EXCHANGE
            { "CSE2", (".TO", "CAD") }, // CANADIAN SECURITIES EXCHANGE - CSE2
            { "PURE", (".TO", "CAD") }, // CANADIAN SECURITIES EXCHANGE - PURE
            { "XCOL", ("N/A", "UNKNOWN") }, // COLOMBO STOCK EXCHANGE
            { "XCOR", (".L", "GBP") }, // ICMA
            { "XCRC", ("", "USD") }, // CHICAGO RICE AND COTTON EXCHANGE
            { "XCRO", ("N/A", "UNKNOWN") }, // CROATIAN POWER EXCHANGE
            { "XCSC", ("", "USD") }, // NEW YORK COCOA, COFFEE AND SUGAR EXCHANGE
            { "XCSE", (".CO", "DKK") }, // NASDAQ COPENHAGEN A/S
            { "DCSE", (".CO", "DKK") }, // NASDAQ COPENHAGEN A/S - NORDIC@MID
            { "DNDK", (".CO", "DKK") }, // FIRST NORTH DENMARK - NORDIC@MID
            { "DSME", (".CO", "DKK") }, // FIRST NORTH DENMARK -SME GROWTH MARKET
            { "FNDK", (".CO", "DKK") }, // FIRST NORTH DENMARK
            { "MCSE", (".CO", "DKK") }, // NASDAQ COPENHAGEN A/S - AUCTION ON DEMAND
            { "MNDK", (".CO", "DKK") }, // FIRST NORTH DENMARK - AUCTION ON DEMAND
            { "PCSE", (".CO", "DKK") }, // NASDAQ COPENHAGEN A/S - PURESTREAM
            { "XFND", (".CO", "DKK") }, // FIRST NORTH DENMARK
            { "XCSX", ("N/A", "UNKNOWN") }, // CAMBODIA SECURITIES EXCHANGE
            { "XCUE", ("N/A", "UNKNOWN") }, // UZBEKISTAN REPUBLICAN CURRENCY EXCHANGE
            { "XCUR", ("", "USD") }, // CURRENEX
            { "LCUR", ("", "USD") }, // CURRENEX LDFX
            { "XCVD", ("N/A", "UNKNOWN") }, // CEVALDOM - OTC MARKET
            { "XCXD", (".TO", "CAD") }, // NASDAQ CXD
            { "XCYS", ("N/A", "UNKNOWN") }, // CYPRUS STOCK EXCHANGE
            { "XCYO", ("N/A", "UNKNOWN") }, // CYPRUS STOCK EXCHANGE - OTC
            { "XECM", ("N/A", "UNKNOWN") }, // MTF - CYPRUS EXCHANGE
            { "XMME", ("N/A", "UNKNOWN") }, // CYPRUS STOCK EXCHANGE - SMES
            { "XDAR", ("N/A", "UNKNOWN") }, // DAR ES  SALAAM STOCK EXCHANGE
            { "XDCE", (".SS", "CNY") }, // DALIAN COMMODITY EXCHANGE
            { "XDES", (".NS", "INR") }, // DELHI STOCK EXCHANGE
            { "XDFB", ("N/A", "UNKNOWN") }, // JOINT-STOCK COMPANY “STOCK EXCHANGE INNEX”
            { "XDFM", ("N/A", "UNKNOWN") }, // DUBAI FINANCIAL MARKET
            { "XDHA", ("N/A", "UNKNOWN") }, // DHAKA STOCK EXCHANGE LTD
            { "XDNB", (".OL", "NOK") }, // DNB BANK ASA
            { "XDPA", (".MC", "EUR") }, // CADE - MERCADO DE DEUDA PUBLICA ANOTADA
            { "XDSE", ("N/A", "UNKNOWN") }, // DAMASCUS SECURITIES EXCHANGE
            { "XDSX", ("N/A", "UNKNOWN") }, // DOUALA STOCK EXCHANGE
            { "XDTB", (".DE", "EUR") }, // DTB DEUTSCHE TERMINBOERSE GMBH
            { "XDUB", ("N/A", "UNKNOWN") }, // IRISH STOCK EXCHANGE - ALL MARKET
            { "DDUB", ("N/A", "UNKNOWN") }, // EURONEXT DUBLIN– DARK BOOK FACILITY
            { "EDBT", ("N/A", "UNKNOWN") }, // EURONEXT DUBLIN - TRADED BONDS
            { "EDGL", ("N/A", "UNKNOWN") }, // GLOBAL EXCHANGE MARKET - TRADED BONDS
            { "XACD", ("N/A", "UNKNOWN") }, // EURONEXT ACCESS DUBLIN
            { "XASM", ("N/A", "UNKNOWN") }, // IRISH STOCK EXCHANGE - GLOBAL EXCHANGE MARKET
            { "XATL", ("N/A", "UNKNOWN") }, // ATLANTIC SECURITIES MARKET
            { "XESM", ("N/A", "UNKNOWN") }, // EURONEXT GROWTH DUBLIN
            { "XEYE", ("N/A", "UNKNOWN") }, // IRISH STOCK EXCHANGE  - GLOBAL EXCHANGE MARKET
            { "XIEX", ("N/A", "UNKNOWN") }, // IRISH STOCK EXCHANGE - ENTERPRISE SECURITIES MARKET
            { "XMSM", ("N/A", "UNKNOWN") }, // EURONEXT DUBLIN
            { "XDUS", (".DE", "EUR") }, // BOERSE DUESSELDORF
            { "DUSA", (".DE", "EUR") }, // BOERSE DUESSELDORF - REGULIERTER MARKT
            { "DUSB", (".DE", "EUR") }, // BOERSE DUESSELDORF - FREIVERKEHR
            { "DUSC", (".DE", "EUR") }, // BOERSE DUESSELDORF - QUOTRIX - REGULIERTER MARKT
            { "DUSD", (".DE", "EUR") }, // BOERSE DUESSELDORF - QUOTRIX MTF
            { "XQTX", (".DE", "EUR") }, // BOERSE DUESSELDORF - QUOTRIX
            { "XDWZ", (".DE", "EUR") }, // DEUTSCHE BOERSE AG, FRANKFURT AM MAIN
            { "XEBI", ("N/A", "UNKNOWN") }, // ENERGY BROKING IRELAND GAS TRADING PLATFORM
            { "XEBS", (".L", "GBP") }, // EBS UK MULTILATERAL TRADING FACILITY
            { "EBSO", (".L", "GBP") }, // EBS UK MTF - TAILORED ORDER BOOKS
            { "XECB", (".DE", "EUR") }, // ECB EXCHANGE RATES
            { "XECC", (".DE", "EUR") }, // EUROPEAN COMMODITY CLEARING AG
            { "XECS", ("N/A", "UNKNOWN") }, // EASTERN CARIBBEAN SECURITIES EXCHANGE
            { "XEDX", (".L", "GBP") }, // EDX LONDON LIMITED
            { "XEEE", (".DE", "EUR") }, // EUROPEAN ENERGY EXCHANGE
            { "XEEO", (".DE", "EUR") }, // EUROPEAN ENERGY EXCHANGE - NON-MTF MARKET
            { "XEER", (".DE", "EUR") }, // EUROPEAN ENERGY EXCHANGE - REGULATED MARKET
            { "XPOT", (".DE", "EUR") }, // EUROPEAN ENERGY EXCHANGE - OTF GAS MARKET
            { "XPSF", (".DE", "EUR") }, // EUROPEAN ENERGY EXCHANGE - REGULATED GAS MARKET
            { "XELX", ("", "USD") }, // ELX
            { "XEMD", (".MX", "MXN") }, // MERCADO MEXICANO DE DERIVADOS
            { "XEMS", (".AS", "EUR") }, // EMS EXCHANGE
            { "XEAS", ("N/A", "EUR") }, // EQUIDUCT
            { "XETI", (".DE", "EUR") }, // XETRA INTERNATIONAL MARKET
            { "XETC", (".DE", "EUR") }, // XETRA INTERNATIONAL MARKET - REGULATED MARKET
            { "XETD", (".DE", "EUR") }, // XETRA INTERNATIONAL MARKET - OPEN MARKET
            { "XETR", (".DE", "EUR") }, // XETRA
            { "XEMA", (".DE", "EUR") }, // XETRA MIDPOINT REGULATED MARKET
            { "XEMB", (".DE", "EUR") }, // XETRA MIDPOINT OPEN MARKET
            { "XEMI", (".DE", "EUR") }, // XETRA MIDPOINT SCALE
            { "XETA", (".DE", "EUR") }, // XETRA - REGULIERTER MARKT
            { "XETB", (".DE", "EUR") }, // XETRA - FREIVERKEHR
            { "XETE", (".DE", "EUR") }, // XETRA - NON-FINANCIAL INSTRUMENTS
            { "XETS", (".DE", "EUR") }, // XETRA - SCALE
            { "XETU", (".DE", "EUR") }, // XETRA - REGULIERTERMARKT - OFF-BOOK
            { "XETV", (".DE", "EUR") }, // XETRA - FREIVERKEHR - OFF-BOOK
            { "XETW", (".DE", "EUR") }, // XETRA - SCALE - OFF-BOOK
            { "XETX", (".DE", "EUR") }, // XETRA - NON-FINANCIAL INSTRUMENTS - OFF-BOOK
            { "XEUB", (".DE", "EUR") }, // EUREX BONDS
            { "XEUP", (".DE", "EUR") }, // EUREX REPO GMBH
            { "XEHQ", (".DE", "EUR") }, // EUREX REPO - HQLA MARKET
            { "XERE", (".DE", "EUR") }, // EUREX REPO - FUNDING AND FINANCING PRODUCTS
            { "XERT", (".DE", "EUR") }, // EUREX REPO - TRIPARTY
            { "XEUM", (".DE", "EUR") }, // EUREX REPO SECLEND MARKET
            { "XEUR", (".DE", "EUR") }, // EUREX DEUTSCHLAND
            { "XEUS", ("", "USD") }, // US FUTURES EXCHANGE
            { "XFCM", (".MC", "EUR") }, // MERCADO DE FUTUROS Y OPCIONES SOBRE CITRICOS
            { "XFEX", (".AX", "AUD") }, // FEX GLOBAL
            { "XFFE", (".T", "JPY") }, // FUKUOKA FUTURES EXCHANGE
            { "XFKA", (".T", "JPY") }, // FUKUOKA STOCK EXCHANGE
            { "XFMN", (".PA", "EUR") }, // SOCIETE DU NOUVEAU MARCHE
            { "XFNX", ("N/A", "UNKNOWN") }, // FINEX (NEW YORK AND DUBLIN)
            { "XFOM", (".HE", "EUR") }, // FINNISH OPTIONS MARKET
            { "XFRA", (".DE", "EUR") }, // DEUTSCHE BOERSE AG
            { "FRAA", (".DE", "EUR") }, // BOERSE FRANKFURT - REGULIERTER MARKT
            { "FRAB", (".DE", "EUR") }, // BOERSE FRANKFURT - FREIVERKEHR
            { "FRAD", (".DE", "EUR") }, // DEUTSCHE BOERSE MID-POINT CROSS
            { "FRAS", (".DE", "EUR") }, // BOERSE FRANKFURT - SCALE
            { "FRAU", (".DE", "EUR") }, // BOERSE FRANKFURT - REGULIERTERMARKT - OFF-BOOK
            { "FRAV", (".DE", "EUR") }, // BOERSE FRANKFURT - FREIVERKEHR - OFF-BOOK
            { "FRAW", (".DE", "EUR") }, // BOERSE FRANKFURT - SCALE - OFF-BOOK
            { "XDBC", (".DE", "EUR") }, // DEUTSCHE BOERSE AG - CUSTOMIZED INDICES
            { "XDBV", (".DE", "EUR") }, // DEUTSCHE BOERSE AG - VOLATILITY INDICES
            { "XDBX", (".DE", "EUR") }, // DEUTSCHE BOERSE AG - INDICES
            { "XNEW", (".DE", "EUR") }, // NEWEX
            { "XFTA", (".AS", "EUR") }, // FINANCIELE TERMIJNMARKET AMSTERDAM
            { "XFTX", ("N/A", "UNKNOWN") }, // FTX
            { "XGAI", ("N/A", "UNKNOWN") }, // GAMI ASSET INVESTMENT L.L.C
            { "XGAS", ("N/A", "UNKNOWN") }, // CENTRAL EASTERN EUROPEAN GAS EXCHANGE LTD
            { "XGCL", (".L", "GBP") }, // GLOBAL COAL LIMITED
            { "XGGI", ("N/A", "UNKNOWN") }, // GAMI GLOBAL INVESTMENT L.L.C
            { "XGHA", ("N/A", "UNKNOWN") }, // GHANA STOCK EXCHANGE
            { "XGME", (".MI", "EUR") }, // GESTORE MERCATO ELETTRICO - ITALIAN POWER EXCHANGE
            { "XGMX", ("", "USD") }, // GLOBALCLEAR MERCANTILE EXCHANGE
            { "XGSE", ("N/A", "UNKNOWN") }, // GEORGIA STOCK EXCHANGE
            { "XGTG", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES NACIONAL SA
            { "XGUA", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES DE GUAYAQUIL
            { "XHAM", (".DE", "EUR") }, // HANSEATISCHE WERTPAPIERBOERSE HAMBURG
            { "HAMA", (".DE", "EUR") }, // BOERSE HAMBURG - REGULIERTER MARKT
            { "HAMB", (".DE", "EUR") }, // BOERSE HAMBURG - FREIVERKEHR
            { "HAML", (".DE", "EUR") }, // BOERSE HAMBURG - LANG AND SCHWARZ EXCHANGE
            { "HAMM", (".DE", "EUR") }, // BOERSE HAMBURG - LANG AND SCHWARZ EXCHANGE - REGULIERTER MARKT
            { "HAMN", (".DE", "EUR") }, // BOERSE HAMBURG - LANG AND SCHWARZ EXCHANGE - FREIVERKEHR
            { "XHAN", (".DE", "EUR") }, // NIEDERSAECHSISCHE BOERSE ZU HANNOVER
            { "HANA", (".DE", "EUR") }, // BOERSE HANNOVER - REGULIERTER MARKT
            { "HANB", (".DE", "EUR") }, // BOERSE HANNOVER - FREIVERKEHR
            { "HANC", (".DE", "EUR") }, // BOERSE HANNOVER - REGULIERTER MARKT - ELECTRONIC TRADING
            { "HAND", (".DE", "EUR") }, // BOERSE HANNOVER - FREIVERKEHR - ELECTRONIC TRADING
            { "HANE", (".DE", "EUR") }, // BOERSE HANNOVER - ELECTRONIC TRADING
            { "XHCE", (".DE", "EUR") }, // RISK MANAGEMENT EXCHANGE
            { "XHEL", (".HE", "EUR") }, // NASDAQ HELSINKI LTD
            { "DHEL", (".HE", "EUR") }, // NASDAQ HELSINKI LTD - NORDIC@MID
            { "DNFI", (".HE", "EUR") }, // FIRST NORTH FINLAND - NORDIC@MID
            { "FNFI", (".HE", "EUR") }, // FIRST NORTH FINLAND
            { "FSME", (".HE", "EUR") }, // FIRST NORTH FINLAND - SME GROWTH MARKET
            { "MHEL", (".HE", "EUR") }, // NASDAQ HELSINKI LTD -  AUCTION ON DEMAND
            { "MNFI", (".HE", "EUR") }, // FIRST NORTH FINLAND - AUCTION ON DEMAND
            { "PEUR", (".HE", "EUR") }, // FIRST NORTH FINLAND - PURESTREAM
            { "PHEL", (".HE", "EUR") }, // NASDAQ HELSINKI - PURESTREAM
            { "XHER", (".T", "JPY") }, // NIPPON NEW MARKET - HERCULES
            { "XHIR", (".T", "JPY") }, // HIROSHIMA STOCK EXCHANGE
            { "XHKF", (".HK", "HKD") }, // HONG KONG FUTURES EXCHANGE LTD.
            { "XHKG", (".HK", "HKD") }, // HONG KONG EXCHANGES AND CLEARING LTD
            { "SHSC", (".HK", "HKD") }, // STOCK EXCHANGE OF HONG KONG LIMITED - SHANGHAI - HONG KONG STOCK CONNECT
            { "SZSC", (".HK", "HKD") }, // STOCK EXCHANGE OF HONG KONG LIMITED - SHENZHEN - HONG KONG STOCK CONNECT
            { "XGEM", (".HK", "HKD") }, // HONG KONG GROWTH ENTERPRISES MARKET
            { "XHON", ("N/A", "UNKNOWN") }, // HONDURIAN STOCK EXCHANGE
            { "XIAB", (".IS", "TRY") }, // ISTANBUL GOLD EXCHANGE
            { "XIBE", ("N/A", "UNKNOWN") }, // BAKU INTERBANK CURRENCY EXCHANGE
            { "XICB", (".SW", "CHF") }, // SIX CORPORATE BONDS AG
            { "XICE", ("N/A", "UNKNOWN") }, // NASDAQ ICELAND HF.
            { "DICE", ("N/A", "UNKNOWN") }, // NASDAQ ICELAND HF. - NORDIC@MID
            { "DNIS", ("N/A", "UNKNOWN") }, // FIRST NORTH ICELAND - NORDIC@MID
            { "FNIS", ("N/A", "UNKNOWN") }, // FIRST NORTH ICELAND
            { "ISEC", ("N/A", "UNKNOWN") }, // FIRST NORTH ICELAND
            { "MICE", ("N/A", "UNKNOWN") }, // NASDAQ ICELAND HF. - AUCTION ON DEMAND
            { "MNIS", ("N/A", "UNKNOWN") }, // FIRST NORTH ICELAND - AUCTION ON DEMAND
            { "XICX", (".TO", "CAD") }, // INSTINET CANADA CROSS
            { "XIDX", (".JK", "IDR") }, // INDONESIA STOCK EXCHANGE
            { "XIEL", (".L", "GBP") }, // INSTINET EUROPE LIMITED
            { "BLOX", (".L", "GBP") }, // BLOCKMATCH  UK DARK
            { "BNTW", (".L", "GBP") }, // BLOCKMATCH UK NT
            { "BRFQ", (".L", "GBP") }, // BLOCKMATCH UK RFQ
            { "IOTC", (".L", "GBP") }, // INSTINET EUROPE LIMITED OTC
            { "XIGG", (".DE", "EUR") }, // BLOCKMATCH EUROPE
            { "EBLX", (".DE", "EUR") }, // BLOCKMATCH EUROPE DARK
            { "ENTW", (".DE", "EUR") }, // BLOCKMATCH EUROPE NT
            { "ERFQ", (".DE", "EUR") }, // BLOCKMATCH EUROPE RFQ
            { "XIHK", (".HK", "HKD") }, // INSTINET PACIFIC LTD
            { "XIJP", (".T", "JPY") }, // INSTINET JAPAN
            { "JASR", (".T", "JPY") }, // JAPANCROSSING
            { "XIMA", (".OL", "NOK") }, // INTERNATIONAL MARTIME EXCHANGE
            { "XIMC", (".NS", "INR") }, // MULTI COMMODITY EXCHANGE OF INDIA LTD.
            { "XIME", (".TW", "TWD") }, // TAIWAN INTERNATIONAL MERCANTILE EXCHANGE
            { "XIMX", ("", "USD") }, // IMX HEALTH - FUTURES
            { "XINS", ("", "USD") }, // INSTINET
            { "BLKX", ("", "USD") }, // INSTINET BLOCKCROSS ATS
            { "IBLX", ("", "USD") }, // INSTINET BLX
            { "ICBX", ("", "USD") }, // INSTINET CBX (US)
            { "ICRO", ("", "USD") }, // INSTINET VWAP CROSS
            { "IIDX", ("", "USD") }, // INSTINET IDX
            { "INCA", ("", "USD") }, // INSTINET DESK CROSS
            { "MOCX", ("", "USD") }, // MOC CROSS
            { "RCBX", ("", "USD") }, // INSTINET RETAIL CBX
            { "XINV", (".DE", "EUR") }, // INVESTRO
            { "XIPE", (".L", "GBP") }, // INTERNATIONAL PETROLEUM EXCHANGE
            { "XIQS", ("N/A", "UNKNOWN") }, // IRAQ STOCK EXCHANGE
            { "XISL", ("N/A", "UNKNOWN") }, // ISLAMABAD STOCK EXCHANGE
            { "XIST", (".IS", "TRY") }, // BORSA ISTANBUL
            { "XDSM", (".IS", "TRY") }, // BORSA ISTANBUL - DEBT SECURITIES MARKET
            { "XEQY", (".IS", "TRY") }, // BORSA ISTANBUL - EQUITY MARKET
            { "XFNO", (".IS", "TRY") }, // BORSA ISTANBUL - FUTURES AND OPTIONS MARKET
            { "XPMS", (".IS", "TRY") }, // BORSA ISTANBUL - PRECIOUS METALS AND DIAMONDS MARKETS
            { "XISX", ("", "USD") }, // INTERNATIONAL SECURITIES EXCHANGE, LLC
            { "GMNI", ("", "USD") }, // ISE GEMINI EXCHANGE
            { "MCRY", ("", "USD") }, // ISE MERCURY, LLC
            { "XISA", ("", "USD") }, // INTERNATIONAL SECURITIES EXCHANGE, LLC -  ALTERNATIVE MARKETS
            { "XISE", ("", "USD") }, // INTERNATIONAL SECURITIES EXCHANGE, LLC - EQUITIES
            { "XTPZ", ("", "USD") }, // INTERNATIONAL  SECURITIES EXCHANGE, LLC - TOPAZ
            { "XJAM", ("N/A", "UNKNOWN") }, // JAMAICA STOCK EXCHANGE
            { "XJAX", (".T", "JPY") }, // JAX
            { "XJKT", (".JK", "IDR") }, // JAKARTA STOCK EXCHANGE
            { "XJNB", (".JK", "IDR") }, // JAKARTA NEGOTIATED BOARD
            { "XJPX", (".T", "JPY") }, // JAPAN EXCHANGE GROUP
            { "XJAS", (".T", "JPY") }, // TOKYO STOCK EXCHANGE JASDAQ
            { "XOSE", (".T", "JPY") }, // OSAKA EXCHANGE
            { "XOSJ", (".T", "JPY") }, // OSAKA EXCHANGE J-NET
            { "XTAM", (".T", "JPY") }, // TOKYO STOCK EXCHANGE-TOKYO PRO MARKET
            { "XTK1", (".T", "JPY") }, // TOKYO STOCK EXCHANGE - TOSTNET-1
            { "XTK2", (".T", "JPY") }, // TOKYO STOCK EXCHANGE - TOSTNET-2
            { "XTK3", (".T", "JPY") }, // TOKYO STOCK EXCHANGE - TOSTNET-3
            { "XTKS", (".T", "JPY") }, // TOKYO STOCK EXCHANGE
            { "XTKT", (".T", "JPY") }, // TOKYO COMMODITY EXCHANGE
            { "XJSE", (".JO", "ZAR") }, // JOHANNESBURG STOCK EXCHANGE
            { "ALTX", (".JO", "ZAR") }, // JSE ALTERNATE EXCHANGE
            { "JSEB", (".JO", "ZAR") }, // JSE BOND ELECTRONIC TRADING PLATFORM
            { "JSER", (".JO", "ZAR") }, // JSE REPO MARKET
            { "XBES", (".JO", "ZAR") }, // JSE CASH BOND MARKET
            { "XSAF", (".JO", "ZAR") }, // JSE EQUITY DERIVATIVES MARKET
            { "XSFA", (".JO", "ZAR") }, // JSE COMMODITY DERIVATIVES MARKET
            { "YLDX", (".JO", "ZAR") }, // JSE INTEREST RATE DERIVATIVES MARKET
            { "ZFXM", (".JO", "ZAR") }, // JSE CURRENCY DERIVATIVES MARKET
            { "XJWY", (".L", "GBP") }, // JIWAY EXCHANGE LTD
            { "XKAC", (".T", "JPY") }, // OSAKA DOJIMA COMMODITY EXCHANGE
            { "XKAR", ("N/A", "UNKNOWN") }, // THE PAKISTAN STOCK EXCHANGE LIMITED
            { "XKAZ", ("N/A", "UNKNOWN") }, // KAZAKHSTAN STOCK EXCHANGE
            { "XKCE", ("N/A", "UNKNOWN") }, // KHOREZM INTERREGION COMMODITY EXCHANGE
            { "XKFB", (".KS", "KRW") }, // KOREA FREEBOARD MARKET
            { "XKGT", (".T", "JPY") }, // KOBE GOMU TORIHIKIJO (RUBBER EXCHANGE)
            { "XKHA", ("N/A", "UNKNOWN") }, // KHARTOUM STOCK EXCHANGE
            { "XKHR", ("N/A", "UNKNOWN") }, // KHARKOV COMMODITY EXCHANGE
            { "XKIE", ("N/A", "UNKNOWN") }, // KIEV UNIVERSAL EXCHANGE
            { "XKIS", ("N/A", "UNKNOWN") }, // KIEV INTERNATIONAL STOCK EXCHANGE
            { "XKKT", (".T", "JPY") }, // KOBE KIITO TORIHIKIJO (RAW SILK EXCHANGE)
            { "XKLS", (".KL", "MYR") }, // BURSA MALAYSIA
            { "MESQ", (".KL", "MYR") }, // ACE MARKET
            { "XKOR", (".KS", "KRW") }, // KOREA STOCK EXCHANGE
            { "XKRX", (".KS", "KRW") }, // KOREA EXCHANGE (STOCK MARKET)
            { "XKCM", (".KS", "KRW") }, // KOREA EXCHANGE COMMODITY MARKET
            { "XKEM", (".KS", "KRW") }, // KOREA EXCHANGE EMISSIONS MARKET
            { "XKFE", (".KS", "KRW") }, // KOREA EXCHANGE (FUTURES MARKET)
            { "XKON", (".KS", "KRW") }, // KOREA NEW EXCHANGE
            { "XKOS", (".KS", "KRW") }, // KOREA EXCHANGE (KOSDAQ)
            { "XKSE", ("N/A", "UNKNOWN") }, // KYRGYZ STOCK EXCHANGE
            { "XKST", (".T", "JPY") }, // KANMON SHOHIN TORIHIKIJO (COMMODITY EXCHANGE)
            { "XKUW", ("N/A", "UNKNOWN") }, // KUWAIT STOCK EXCHANGE
            { "XKYO", (".T", "JPY") }, // KYOTO STOCK EXCHANGE
            { "XLAH", ("N/A", "UNKNOWN") }, // LAHORE STOCK EXCHANGE
            { "XLAO", ("N/A", "UNKNOWN") }, // LAO SECURITIES EXCHANGE
            { "XLBM", (".L", "GBP") }, // LONDON BULLION MARKET
            { "XLCE", (".L", "GBP") }, // LONDON COMMODITY EXCHANGE, THE
            { "XLCH", (".L", "GBP") }, // LCH LTD
            { "BUYN", (".L", "GBP") }, // LCH LTD - BUY IN
            { "CLCH", (".L", "GBP") }, // LCH LTD - CROSS NETTING
            { "XLDN", (".L", "GBP") }, // EURONEXT - EURONEXT LONDON
            { "ENSY", (".L", "GBP") }, // EURONEXT SYNAPSE
            { "TNLL", (".L", "GBP") }, // EURONEXT - TRADING FACILITY LONDON
            { "XLIF", (".L", "GBP") }, // EURONEXT LIFFE
            { "XSMP", (".L", "GBP") }, // EURONEXT BLOCK
            { "XLFX", (".KL", "MYR") }, // LABUAN INTERNATIONAL FINANCIAL EXCHANGE
            { "XLGT", ("N/A", "UNKNOWN") }, // LGT BANK AG
            { "XLIM", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES DE LIMA
            { "XLIS", ("N/A", "UNKNOWN") }, // EURONEXT - EURONEXT LISBON
            { "ALXL", ("N/A", "UNKNOWN") }, // EURONEXT GROWTH LISBON
            { "DLIS", ("N/A", "UNKNOWN") }, // EURONEXT LISBON – DARK BOOK FACILITY
            { "ENXL", ("N/A", "UNKNOWN") }, // EURONEXT ACCESS LISBON
            { "MFOX", ("N/A", "UNKNOWN") }, // EURONEXT - MERCADO DE FUTUROS E OPÇÕES
            { "WQXL", ("N/A", "UNKNOWN") }, // EURONEXT - MARKET WITHOUT QUOTATIONS LISBON
            { "XLIT", ("N/A", "UNKNOWN") }, // AB NASDAQ VILNIUS
            { "FNLT", ("N/A", "UNKNOWN") }, // FIRST NORTH LITHUANIA
            { "XVIA", ("N/A", "UNKNOWN") }, // ALTERNATIVE MARKET-FIRST NORTH LITHUANIA
            { "XLJS", ("N/A", "UNKNOWN") }, // LJUBLJANA STOCK EXCHANGE (SEMI-OFFICIAL MARKET)
            { "XLJU", ("N/A", "UNKNOWN") }, // LJUBLJANA STOCK EXCHANGE (OFFICIAL MARKET)
            { "XLJM", ("N/A", "UNKNOWN") }, // SI ENTER
            { "XLLB", ("N/A", "UNKNOWN") }, // LIECHTENSTEINISCHE LANDESBANK AG
            { "XLME", (".L", "GBP") }, // LONDON METAL EXCHANGE
            { "XLOF", (".KL", "MYR") }, // MALAYSIA DERIVATIVES EXCHANGE BHD
            { "XLON", (".L", "GBP") }, // LONDON STOCK EXCHANGE
            { "AIMX", (".L", "GBP") }, // LONDON STOCK EXCHANGE - AIM MTF
            { "XLOD", (".L", "GBP") }, // LONDON STOCK EXCHANGE - CURVEGLOBAL MARKETS
            { "XLOM", (".L", "GBP") }, // LONDON STOCK EXCHANGE - MTF
            { "XLQC", (".AX", "AUD") }, // LIQUIDITY CUBE PTY LTD
            { "XLSM", ("N/A", "UNKNOWN") }, // LIBYAN STOCK MARKET
            { "XLTO", (".L", "GBP") }, // LONDON TRADED OPTIONS MARKET
            { "XLUS", ("N/A", "UNKNOWN") }, // LUSAKA STOCK EXCHANGE
            { "XLUX", ("N/A", "UNKNOWN") }, // LUXEMBOURG STOCK EXCHANGE
            { "EM3S", ("N/A", "UNKNOWN") }, // EURO MTF 3S
            { "EMTF", ("N/A", "UNKNOWN") }, // EURO MTF
            { "XMAB", ("N/A", "UNKNOWN") }, // MERCADO ABIERTO ELECTRONICO S.A.
            { "XMAC", ("", "USD") }, // MID AMERICA COMMODITY EXCHANGE
            { "XMAE", ("N/A", "UNKNOWN") }, // MACEDONIAN STOCK EXCHANGE
            { "XMAL", ("N/A", "UNKNOWN") }, // MALTA STOCK EXCHANGE
            { "IFSM", ("N/A", "UNKNOWN") }, // INSTITUTIONAL FINANCIAL SECURITIES MARKET
            { "PROS", ("N/A", "UNKNOWN") }, // PROSPECTS
            { "XMAN", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES DE NICARAGUA
            { "XMAP", ("N/A", "UNKNOWN") }, // MAPUTO STOCK  EXCHANGE
            { "XMAU", ("N/A", "UNKNOWN") }, // STOCK EXCHANGE OF MAURITIUS LTD
            { "XMDG", ("N/A", "UNKNOWN") }, // MARCHE INTERBANCAIRE DES DEVISES M.I.D.
            { "XMDS", (".NS", "INR") }, // MADRAS STOCK EXCHANGE
            { "XMER", ("", "USD") }, // MERCHANTS' EXCHANGE
            { "XMEX", (".MX", "MXN") }, // BOLSA MEXICANA DE VALORES (MEXICAN STOCK EXCHANGE)
            { "XMGE", ("", "USD") }, // MIAX FUTURES EXCHANGE, LLC
            { "XMFE", ("", "USD") }, // MIAX FUTURES EXCHANGE - OCC CLEARING
            { "XMIC", (".ME", "RUB") }, // MOSCOW INTERBANK CURRENCY EXCHANGE
            { "XMID", ("", "USD") }, // MIDWEST STOCK EXCHANGE
            { "XMIF", (".MI", "EUR") }, // MERCATO ITALIANO DEI FUTURES
            { "XMIL", (".MI", "EUR") }, // BORSA ITALIANA S.P.A.
            { "ATFX", (".MI", "EUR") }, // ATFUND MTF
            { "BGEM", (".MI", "EUR") }, // BORSA ITALIANA GLOBAL EQUITY MARKET
            { "DMIL", (".MI", "EUR") }, // BORSA ITALIANA - DARK BOOK FACILITY
            { "ETFP", (".MI", "EUR") }, // ELECTRONIC ETF, ETC/ETN AND OPEN-END FUNDS MARKET
            { "ETLX", (".MI", "EUR") }, // EUROTLX
            { "EXGM", (".MI", "EUR") }, // EURONEXT GROWTH MILAN
            { "MACX", (".MI", "EUR") }, // MERCATO ALTERNATIVO DEL CAPITALE
            { "MIVX", (".MI", "EUR") }, // EURONEXT MIV MILAN
            { "MOTX", (".MI", "EUR") }, // ELECTRONIC BOND MARKET
            { "MTAA", (".MI", "EUR") }, // EURONEXT MILAN
            { "MTAH", (".MI", "EUR") }, // BORSA ITALIANA - TRADING AFTER HOURS
            { "SEDX", (".MI", "EUR") }, // SECURITISED DERIVATIVES MARKET
            { "XAIM", (".MI", "EUR") }, // AIM ITALIA - MERCATO ALTERNATIVO DEL CAPITALE
            { "XDMI", (".MI", "EUR") }, // ITALIAN DERIVATIVES MARKET
            { "XMOT", (".MI", "EUR") }, // EURONEXT - ACCESS MILAN
            { "VRXP", (".PA", "EUR") }, // NYSE EURONEXT - COMPARTIMENT DES VALEURS RADIEES PARIS
            { "XMLX", (".L", "GBP") }, // OMLX, THE LONDON SECURITIES AND DERIVATIVES EXCHANGE LIMITED
            { "XMNT", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES DE MONTEVIDEO
            { "XMNX", ("N/A", "UNKNOWN") }, // MONTENEGRO STOCK EXCHANGE
            { "XMOC", (".TO", "CAD") }, // MONTREAL CLIMATE EXCHANGE
            { "XMOD", (".TO", "CAD") }, // THE MONTREAL EXCHANGE / BOURSE DE MONTREAL
            { "XMOL", ("N/A", "UNKNOWN") }, // MOLDOVA STOCK EXCHANGE
            { "XMOO", (".TO", "CAD") }, // MONTREAL EXCHANGE THE / BOURSE DE MONTREAL
            { "XMOS", (".ME", "RUB") }, // CENTRAL COUNTERPARTY CLEARING CENTER MFB - JOINT-STOCK COMPANY
            { "XMSW", ("N/A", "UNKNOWN") }, // MALAWI STOCK EXCHANGE
            { "XMTB", ("N/A", "UNKNOWN") }, // MERCADO A TERMINO DE BUENOS AIRES S.A.
            { "XMTS", (".L", "GBP") }, // EUROMTS LTD
            { "AMTS", (".L", "GBP") }, // MTS NETHERLANDS
            { "BVUK", (".L", "GBP") }, // BONDVISION UK
            { "CMTS", (".L", "GBP") }, // EUROCREDIT MTS
            { "EACM", (".L", "GBP") }, // MTS REPO - AGENCY CASH MANAGEMENT
            { "EMTS", (".L", "GBP") }, // EBM
            { "GMTS", (".L", "GBP") }, // MTS GERMANY
            { "HUNG", (".L", "GBP") }, // MTS HUNGARY
            { "IMTS", (".L", "GBP") }, // MTS IRELAND
            { "LMTS", (".L", "GBP") }, // EUROGLOBALMTS
            { "MCZK", (".L", "GBP") }, // MTS CZECH REPUBLIC
            { "MTSA", (".L", "GBP") }, // MTS AUSTRIA
            { "MTSG", (".L", "GBP") }, // MTS GREECE
            { "MTSS", (".L", "GBP") }, // MTS INTERDEALER SWAPS MARKET
            { "MTSW", (".L", "GBP") }, // MTS SWAP MARKET
            { "NMTS", (".L", "GBP") }, // NEW EUROMTS
            { "PORT", (".L", "GBP") }, // MTS PORTUGAL
            { "PRME", (".L", "GBP") }, // MTS PRIME
            { "RMTS", (".L", "GBP") }, // MTS ISRAEL
            { "SLKK", (".L", "GBP") }, // MTS SLOVAKIA
            { "SMTS", (".L", "GBP") }, // MTS SPAIN
            { "TMTS", (".L", "GBP") }, // EUROBENCHMARK TRES. BILLS
            { "UKGD", (".L", "GBP") }, // MTS UK
            { "USWP", (".L", "GBP") }, // EUROMTS LIMITED
            { "VMTS", (".L", "GBP") }, // MTS SLOVENIA
            { "XMUN", (".DE", "EUR") }, // BOERSE MUENCHEN
            { "MUNA", (".DE", "EUR") }, // BOERSE MUENCHEN - REGULIERTER MARKT
            { "MUNB", (".DE", "EUR") }, // BOERSE MUENCHEN - FREIVERKEHR
            { "MUNC", (".DE", "EUR") }, // BOERSE MUENCHEN - GETTEX - REGULIERTER MARKT
            { "MUND", (".DE", "EUR") }, // BOERSE MUENCHEN - GETTEX - FREIVERKEHR
            { "PLUS", (".DE", "EUR") }, // BOERSE MUENCHEN - FREIVERKHER - PLUS - EUROPE
            { "XMUS", ("N/A", "UNKNOWN") }, // MUSCAT STOCK EXCHANGE
            { "MSXB", ("N/A", "UNKNOWN") }, // MUSCAT STOCK EXCHANGE - BOOK BUILDING
            { "MSXO", ("N/A", "UNKNOWN") }, // MUSCAT STOCK EXCHANGE – NON-LISTED INSTRUMENTS
            { "XNAF", (".MC", "EUR") }, // SISTEMA ELETRÓNICO DE NEGOCIACION DE ACTIVOS FINANCIEROS
            { "XNAI", ("N/A", "UNKNOWN") }, // NAIROBI STOCK EXCHANGE
            { "XNAS", ("", "USD") }, // NASDAQ - ALL MARKETS
            { "BOSD", ("", "USD") }, // NASDAQ OMX BX DARK
            { "ESPD", ("", "USD") }, // NASDAQ OMX ESPEED
            { "MELO", ("", "USD") }, // NASDAQ MIDPOINT-ELO (M-ELO)
            { "NASD", ("", "USD") }, // NSDQ DARK
            { "PSXD", ("", "USD") }, // NASDAQ PSX
            { "XBOS", ("", "USD") }, // NASDAQ OMX BX
            { "XBRT", ("", "USD") }, // BRUT ECN
            { "XBXO", ("", "USD") }, // NASDAQ OMX BX OPTIONS
            { "XNCM", ("", "USD") }, // NASDAQ CAPITAL MARKET
            { "XNDQ", ("", "USD") }, // NASDAQ OPTIONS MARKET
            { "XNFI", ("", "USD") }, // NASDAQ FIXED INCOME TRADING
            { "XNGS", ("", "USD") }, // NASDAQ/NGS (GLOBAL SELECT MARKET)
            { "XNIM", ("", "USD") }, // NASDAQ INTERMARKET
            { "XNMS", ("", "USD") }, // NASDAQ/NMS (GLOBAL MARKET)
            { "XPBT", ("", "USD") }, // NASDAQ OMX FUTURES EXCHANGE
            { "XPHL", ("", "USD") }, // NASDAQ OMX PHLX
            { "XPHO", ("", "USD") }, // PHILADELPHIA OPTIONS EXCHANGE
            { "XPOR", ("", "USD") }, // PORTAL
            { "XPSX", ("", "USD") }, // NASDAQ OMX PSX
            { "XNCD", (".NS", "INR") }, // NATIONAL COMMODITY AND DERIVATIVES EXCHANGE LTD
            { "XNDU", ("N/A", "UNKNOWN") }, // PJSC NATIONAL DEPOSITORY OF UKRAINE
            { "XNEC", (".AX", "AUD") }, // NATIONAL STOCK EXCHANGE OF AUSTRALIA LIMITED
            { "XNEE", (".NZ", "NZD") }, // NEW ZEALAND FUTURES AND OPTIONS EXCHANGE
            { "XNEP", ("N/A", "UNKNOWN") }, // NEPAL STOCK EXCHANGE
            { "XNGM", (".ST", "SEK") }, // NORDIC GROWTH MARKET
            { "NMTF", (".ST", "SEK") }, // NORDIC MTF
            { "NSME", (".ST", "SEK") }, // NORDIC SME
            { "XNDX", (".ST", "SEK") }, // NORDIC DERIVATIVES EXCHANGE
            { "XNMR", (".ST", "SEK") }, // NORDIC MTF REPORTING
            { "XNGO", (".T", "JPY") }, // NAGOYA STOCK EXCHANGE
            { "XNII", (".T", "JPY") }, // NIIGATA STOCK EXCHANGE
            { "THRD", ("", "USD") }, // THIRD MARKET CORPORATION
            { "XNKS", (".T", "JPY") }, // CENTRAL JAPAN COMMODITIES EXCHANGE
            { "XNOM", ("N/A", "UNKNOWN") }, // NOMISMA (LIECHTENSTEIN) AG
            { "XNOR", (".HE", "EUR") }, // NORDEA
            { "XNQL", ("", "USD") }, // NQLX
            { "XNSA", ("N/A", "UNKNOWN") }, // THE NIGERIAN STOCK EXCHANGE
            { "XNSE", (".NS", "INR") }, // NATIONAL STOCK EXCHANGE OF INDIA
            { "INSE", (".NS", "INR") }, // NSE IFSC LIMITED
            { "XNST", (".T", "JPY") }, // NAGOYA SENI TORIHIKIJO (TEXTILE EXCHANGE) - CHUBU COMMODITY EXCHANGE
            { "XNXC", (".AS", "EUR") }, // NXCHANGE
            { "XNXD", (".AS", "EUR") }, // NXCHANGE B.V. MTF
            { "XNYC", ("", "USD") }, // NEW YORK COTTON EXCHANGE
            { "XNYF", ("", "USD") }, // ICE FUTURES U.S. INC
            { "XNYM", ("", "USD") }, // NEW YORK MERCANTILE EXCHANGE
            { "XCEC", ("", "USD") }, // COMMODITIES EXCHANGE CENTER
            { "XNYE", ("", "USD") }, // NEW YORK MERCANTILE EXCHANGE - OTC MARKETS
            { "XNYL", ("", "USD") }, // NEW YORK MERCANTILE EXCHANGE - ENERGY MARKETS
            { "XNYS", ("", "USD") }, // NEW YORK STOCK EXCHANGE, INC.
            { "ALDP", ("", "USD") }, // NYSE ALTERNEXT DARK
            { "AMXO", ("", "USD") }, // NYSE AMEX OPTIONS
            { "ARCD", ("", "USD") }, // ARCA DARK
            { "ARCO", ("", "USD") }, // NYSE ARCA OPTIONS
            { "ARCX", ("", "USD") }, // NYSE ARCA
            { "CISD", ("", "USD") }, // NYSE NATIONAL, INC. - DARK
            { "NYSD", ("", "USD") }, // NYSE DARK
            { "XASE", ("", "USD") }, // NYSE MKT LLC
            { "XCHI", ("", "USD") }, // NYSE CHICAGO, INC.
            { "XCIS", ("", "USD") }, // NYSE NATIONAL, INC.
            { "XNLI", ("", "USD") }, // NYSE LIFFE
            { "XNZE", (".NZ", "NZD") }, // NZX - ALL MARKETS
            { "NZXC", (".NZ", "NZD") }, // NZX CENTRAL
            { "NZXD", (".NZ", "NZD") }, // NZX DERIVATIVES - FUTURES & OPTIONS MARKET
            { "NZXM", (".NZ", "NZD") }, // NZX DARK
            { "XOCH", ("", "USD") }, // ONECHICAGO, LLC
            { "XODE", ("N/A", "UNKNOWN") }, // ODESSA COMMODITY EXCHANGE
            { "XOFF", ("N/A", "UNKNOWN") }, // OFF-EXCHANGE TRANSACTIONS - LISTED INSTRUMENTS
            { "XOME", (".ST", "SEK") }, // OMX NORDIC EXCHANGE STOCKHOLM AB
            { "XOSL", (".OL", "NOK") }, // OSLO BORS
            { "BURG", (".OL", "NOK") }, // BURGUNDY NORDIC MTF
            { "BURM", (".OL", "NOK") }, // BURGUNDY REGULATED MARKET
            { "DOSL", (".OL", "NOK") }, // EURONEXT OSLO – DARK BOOK FACILITY
            { "MERD", (".OL", "NOK") }, // MERKUR MARKET - DARK POOL
            { "MERK", (".OL", "NOK") }, // EURONEXT GROWTH - OSLO
            { "NIBR", (".OL", "NOK") }, // NORWEGIAN INTER BANK OFFERED RATE
            { "XOAA", (".OL", "NOK") }, // OSLO BORS ASA - OSLO AXESS LIT X AUCTIONS
            { "XOAD", (".OL", "NOK") }, // OSLO AXESS NORTH SEA - DARK POOL
            { "XOAM", (".OL", "NOK") }, // NORDIC ALTERNATIVE BOND MARKET
            { "XOAS", (".OL", "NOK") }, // EURONEXT EXPAND OSLO
            { "XOBD", (".OL", "NOK") }, // OSLO BORS - DERIVATIVES MARKET
            { "XOSA", (".OL", "NOK") }, // OSLO BORS - LIT X AUCTIONS
            { "XOSC", (".OL", "NOK") }, // OSLO CONNECT
            { "XOSD", (".OL", "NOK") }, // OSLO BORS NORTH SEA - DARK POOL
            { "XOSM", (".T", "JPY") }, // OSAKA MERCANTILE EXCHANGE
            { "XOST", (".T", "JPY") }, // OSAKA SENI TORIHIKIJO (TEXTILE EXCHANGE)
            { "XOTB", ("N/A", "UNKNOWN") }, // OESTERREICHISCHE TERMIN- UND OPTIONENBOERSE, CLEARING BANK AG
            { "XOTC", ("", "USD") }, // OTCBB
            { "XOTP", ("N/A", "UNKNOWN") }, // OTP BANKA D.D.
            { "XPAE", ("N/A", "UNKNOWN") }, // PALESTINE SECURITIES EXCHANGE
            { "XPAR", (".PA", "EUR") }, // EURONEXT - EURONEXT PARIS
            { "ALXP", (".PA", "EUR") }, // EURONEXT GROWTH PARIS
            { "DPAR", (".PA", "EUR") }, // EURONEXT PARIS – DARK BOOK FACILITY
            { "MTCH", (".PA", "EUR") }, // BONDMATCH
            { "XAPA", (".PA", "EUR") }, // EURONEXT - APA
            { "XBLK", (".PA", "EUR") }, // EURONEXT BLOCK 2
            { "XETF", (".PA", "EUR") }, // EURONEXT ETF ACCESS
            { "XMAT", (".PA", "EUR") }, // EURONEXT PARIS MATIF
            { "XMLI", (".PA", "EUR") }, // EURONEXT ACCESS PARIS
            { "XMON", (".PA", "EUR") }, // EURONEXT PARIS MONEP
            { "XPMC", (".PA", "EUR") }, // EURONEXT PARIS – MULTI-CURRENCY TRADING
            { "XSPM", (".PA", "EUR") }, // EURONEXT STRUCTURED PRODUCTS MTF
            { "XPET", (".ME", "RUB") }, // STOCK EXCHANGE SAINT PETERSBURG
            { "XPHS", ("N/A", "UNKNOWN") }, // PHILIPPINE STOCK EXCHANGE, INC.
            { "XPIC", (".ME", "RUB") }, // SAINT-PETERSBURG CURRENCY EXCHANGE
            { "XPLU", (".L", "GBP") }, // PLUS MARKETS GROUP
            { "XPOM", ("N/A", "UNKNOWN") }, // PNGX MARKETS LIMITED
            { "XPOW", (".PA", "EUR") }, // POWERNEXT
            { "XPRA", (".PR", "CZK") }, // PRAGUE STOCK EXCHANGE
            { "SPAD", (".PR", "CZK") }, // SPAD TRADING
            { "STRT", (".PR", "CZK") }, // PRAGUE STOCK EXCHANGE - START (MTF)
            { "XPRM", (".PR", "CZK") }, // PRAGUE STOCK EXCHANGE - MTF
            { "XPRI", ("N/A", "UNKNOWN") }, // PRIDNEPROVSK COMMODITY EXCHANGE
            { "XPSE", ("", "USD") }, // PACIFIC EXCHANGE
            { "XPST", (".HK", "HKD") }, // POSIT - ASIA PACIFIC
            { "XPTY", ("N/A", "UNKNOWN") }, // LATIN AMERICAN STOCK EXCHANGE, INC.
            { "XPUK", (".L", "GBP") }, // XP INVESTMENTS UK LLP
            { "XPUS", ("", "USD") }, // XP INVESTMENTS US, LLC
            { "XPXE", (".PR", "CZK") }, // POWER EXCHANGE CENTRAL EUROPE
            { "XQUI", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES DE QUITO
            { "XRBM", (".KL", "MYR") }, // RINGGIT BOND MARKET
            { "XRCB", ("N/A", "UNKNOWN") }, // RAIFFEISEN CENTROBANK AG
            { "XRIO", (".SA", "BRL") }, // BOLSA DE VALORES DO RIO DE JANEIRO
            { "XRIS", ("N/A", "UNKNOWN") }, // NASDAQ RIGA AS
            { "FNLV", ("N/A", "UNKNOWN") }, // FIRST NORTH LATVIA
            { "XRMS", ("N/A", "UNKNOWN") }, // SK RM-S (SLOVAK STOCK EXCHANGE)
            { "XRMZ", (".PR", "CZK") }, // RM-SYSTEM CZECH STOCK EXCHANGE
            { "XRMO", (".PR", "CZK") }, // RM-SYSTEM CZECH STOCK EXCHANGE - MTF
            { "XROS", ("N/A", "UNKNOWN") }, // BOLSA DE COMERCIO ROSARIO
            { "XROX", ("N/A", "UNKNOWN") }, // MERCADO DE VALORES DE ROSARIO S.A.
            { "XTUC", ("N/A", "UNKNOWN") }, // NUEVA BOLSA DE COMERCIO DE TUCUMAN S.A.
            { "XROV", (".ME", "RUB") }, // REGIONAL EXCHANGE CENTRE - MICEX SOUTH
            { "XRPM", ("N/A", "UNKNOWN") }, // ROMANIAN POWER MARKET
            { "XRTR", (".DE", "EUR") }, // RTR (REUTERS-REALTIME-DATEN)
            { "XRUS", (".ME", "RUB") }, // INTERNET DIRECT-ACCESS EXCHANGE
            { "XSAM", (".ME", "RUB") }, // SAMARA CURRENCY INTERBANK EXCHANGE
            { "XSAP", (".T", "JPY") }, // SAPPORO SECURITIES EXCHANGE
            { "XSAT", (".ST", "SEK") }, // SPOTLIGHT STOCK MARKET AB
            { "SPDK", (".ST", "SEK") }, // SPOTLIGHT STOCK MARKET DENMARK
            { "SPEU", (".ST", "SEK") }, // SPOTLIGHT STOCK MARKET EUROPE
            { "SPFI", (".ST", "SEK") }, // SPOTLIGHT STOCK MARKET FINLAND
            { "SPNO", (".ST", "SEK") }, // SPOTLIGHT STOCK MARKET NORWAY
            { "XSAU", (".SA", "SAR") }, // SAUDI STOCK EXCHANGE
            { "XSCO", (".DE", "EUR") }, // BOERSE FRANKFURT WARRANTS TECHNICAL
            { "XSC1", (".DE", "EUR") }, // BOERSE FRANKFURT WARRANTS TECHNICAL 1
            { "XSC2", (".DE", "EUR") }, // BOERSE FRANKFURT WARRANTS TECHNICAL 2
            { "XSC3", (".DE", "EUR") }, // BOERSE FRANKFURT WARRANTS TECHNICAL 3
            { "XSEF", ("", "USD") }, // SWAPEX, LLC
            { "XSES", (".SI", "SGD") }, // SINGAPORE EXCHANGE
            { "XSBT", (".SI", "SGD") }, // SINGAPORE EXCHANGE BOND TRADING PTE. LTD
            { "XSCA", (".SI", "SGD") }, // SINGAPORE CATALIST MARKET
            { "XSCE", (".SI", "SGD") }, // SINGAPORE COMMODITY EXCHANGE
            { "XSCL", (".SI", "SGD") }, // SINGAPORE CENTRAL LIMIT ORDER BOOK INTERNATIONAL
            { "XSIM", (".SI", "SGD") }, // SINGAPORE EXCHANGE DERIVATIVES CLEARING LIMITED
            { "XSGA", (".PA", "EUR") }, // SOCIETE GENERALE
            { "XSGB", (".L", "GBP") }, // SOCIETE GENERALE (LONDON BRANCH)
            { "XSGE", (".SS", "CNY") }, // SHANGHAI FUTURES EXCHANGE
            { "XINE", (".SS", "CNY") }, // SHANGHAI INTERNATIONAL ENERGY EXCHANGE
            { "XSGO", ("N/A", "UNKNOWN") }, // SANTIAGO STOCK EXCHANGE
            { "XSHE", (".SS", "CNY") }, // SHENZHEN STOCK EXCHANGE
            { "XSEC", (".SS", "CNY") }, // SHENZHEN STOCK EXCHANGE - SHENZHEN - HONG KONG STOCK CONNECT
            { "XSHG", (".SS", "CNY") }, // SHANGHAI STOCK EXCHANGE
            { "XSSC", (".SS", "CNY") }, // SHANGHAI STOCK EXCHANGE - SHANGHAI - HONG KONG STOCK CONNECT
            { "XSIB", (".ME", "RUB") }, // SIBERIAN EXCHANGE
            { "XSIC", (".ME", "RUB") }, // SIBERIAN INTERBANK CURRENCY EXCHANGE
            { "XSME", (".SS", "CNY") }, // SHENZHEN MERCANTILE EXCHANGE
            { "XSOM", (".SA", "BRL") }, // BOLSA DE VALORES DE SAO PAULO - SOMA
            { "XSOP", ("N/A", "UNKNOWN") }, // BSP REGIONAL ENERGY EXCHANGE - SOUTH POOL
            { "XSPS", ("N/A", "UNKNOWN") }, // SOUTH PACIFIC STOCK EXCHANGE
            { "XSRM", (".MC", "EUR") }, // MERCADO DE FUTUROS DE ACEITE DE OLIVA, S.A.
            { "XSSE", ("N/A", "UNKNOWN") }, // SARAJEVO STOCK EXCHANGE
            { "XSTC", ("N/A", "UNKNOWN") }, // HOCHIMINH STOCK EXCHANGE
            { "XSTE", ("N/A", "UNKNOWN") }, // REPUBLICAN STOCK EXCHANGE
            { "XSTO", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB
            { "CSTO", (".ST", "SEK") }, // NASDAQ CLEARING AB
            { "DKED", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - DANISH EQ DERIVATIVES
            { "DKFI", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - DANISH FI DERIVATIVES
            { "DKOB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - OTC DKK WB EQ DERIVATIVES
            { "DKWB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - DKK WB EQ DERIVATIVES
            { "DNSE", (".ST", "SEK") }, // FIRST NORTH SWEDEN - NORDIC@MID
            { "DOSE", (".ST", "SEK") }, // FIRST NORTH SWEDEN - NORWAY NORDIC@MID
            { "DSTO", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - NORDIC@MID
            { "EBON", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - EUR FI DERIVATIVES
            { "ESTO", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - NORWAY ETF
            { "EUOB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - OTC EUR WB EQ DERIVATIVES
            { "EUWB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - EUR WB EQ DERIVATIVES
            { "FIED", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - FINNISH EQ DERIVATIVES
            { "FNSE", (".ST", "SEK") }, // FIRST NORTH SWEDEN
            { "GBOB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - OTC GBP WB EQ DERIVATIVES
            { "GBWB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - GBP WB EQ DERIVATIVES
            { "MNSE", (".ST", "SEK") }, // FIRST NORTH SWEDEN - AUCTION ON DEMAND
            { "MOSE", (".ST", "SEK") }, // FIRST NORTH SWEDEN - NORWAY AUCTION ON DEMAND
            { "MSTO", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - AUCTION ON DEMAND
            { "NASN", (".ST", "SEK") }, // NASDAQ OMX DERIVATIVES MARKETS
            { "NOCO", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - COMMODITIES
            { "NOED", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - NORWEGIAN EQ DERIVATIVES
            { "NOFI", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - NORWEGIAN FI DERIVATIVES
            { "NOOB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - OTC NOK WB EQ DERIVATIVES
            { "NOWB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - NOK WB EQ DERIVATIVES
            { "ONSE", (".ST", "SEK") }, // FIRST NORTH SWEDEN - NORWAY
            { "PFSE", (".ST", "SEK") }, // FIRST NORTH SWEDEN - PURESTREAM
            { "PNED", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - PAN-NORDIC EQ DERIVATIVES
            { "PSTO", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - PURESTREAM
            { "SEED", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - SWEDISH EQ DERIVATIVES
            { "SEOB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - OTC SEK WB EQ DERIVATIVES
            { "SEWB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - SEK WB EQ DERIVATIVES
            { "SSME", (".ST", "SEK") }, // FIRST NORTH SWEDEN - SME GROWTH MARKET
            { "USOB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - OTC USD WB EQ DERIVATIVES
            { "USWB", (".ST", "SEK") }, // NASDAQ STOCKHOLM AB - USD WB EQ DERIVATIVES
            { "XOPV", (".ST", "SEK") }, // OTC PUBLICATION VENUE
            { "XSTU", (".DE", "EUR") }, // BOERSE STUTTGART
            { "EUWX", (".DE", "EUR") }, // EUWAX
            { "STUA", (".DE", "EUR") }, // BOERSE STUTTGART - REGULIERTER MARKT
            { "STUB", (".DE", "EUR") }, // BOERSE STUTTGART - FREIVERKEHR
            { "STUC", (".DE", "EUR") }, // BOERSE STUTTGART - REGULIERTER MARKT - TECHNICAL PLATFORM 2
            { "STUD", (".DE", "EUR") }, // BOERSE STUTTGART - FREIVERKEHR - TECHNICAL PLATFORM 2
            { "STUE", (".DE", "EUR") }, // BOERSE STUTTGART - REGULIERTER MARKT - TECHNICAL PLATFORM 3
            { "STUF", (".DE", "EUR") }, // BOERSE STUTTGART - FREIVERKEHR - TECHNICAL PLATFORM 3
            { "STUH", (".DE", "EUR") }, // BOERSE STUTTGART - FREIVERKEHR - TECHNICAL PLATFORM 4
            { "XCTS", (".DE", "EUR") }, // BOERSE STUTTGART - TECHNICAL PLATFORM 4
            { "XDEX", (".DE", "EUR") }, // BOERSE STUTTGART - DIGITAL EXCHANGE
            { "XSTF", (".DE", "EUR") }, // BOERSE STUTTGART - TECHNICAL PLATFORM 2
            { "XSTP", (".DE", "EUR") }, // BOERSE STUTTGART - TECHNICAL PLATFORM 3
            { "XSUR", (".JK", "IDR") }, // SURABAYA STOCK EXCHANGE
            { "XSVA", ("N/A", "UNKNOWN") }, // EL SALVADOR STOCK EXCHANGE
            { "XSWA", ("N/A", "UNKNOWN") }, // ESWATINI STOCK EXCHANGE
            { "XSWB", (".L", "GBP") }, // SWX SWISS BLOCK
            { "XSWO", (".SW", "CHF") }, // SWISS OPTIONS AND FINANIAL FUTURES EXCHANGE
            { "XSWX", (".SW", "CHF") }, // SIX SWISS EXCHANGE
            { "XBTR", (".SW", "CHF") }, // SIX SWISS BILATERAL TRADING PLATFORM FOR STRUCTURED OTC PRODUCTS
            { "XDLP", (".SW", "CHF") }, // SIX SWISS EXCHANGE - DEAL POOL - BOOK BUILDING AND ANNOUNCEMENT PLATFORM
            { "XQMH", (".SW", "CHF") }, // SIX SWISS EXCHANGE - STRUCTURED PRODUCTS
            { "XQOD", (".SW", "CHF") }, // SIX SWISS EXCHANGE - ETF QOD
            { "XSDX", (".SW", "CHF") }, // SIX DIGITAL EXCHANGE
            { "XSEB", (".SW", "CHF") }, // SIX SWISS EXCHANGE - EBBO BOOK
            { "XSLS", (".SW", "CHF") }, // SIX SWISS EXCHANGE - SLS
            { "XSWM", (".SW", "CHF") }, // SIX SWISS EXCHANGE - SIX SWISS EXCHANGE AT MIDPOINT
            { "XVTX", (".SW", "CHF") }, // SIX SWISS EXCHANGE - BLUE CHIPS SEGMENT
            { "XTAD", (".TW", "TWD") }, // TAISDAQ
            { "XTAE", ("N/A", "UNKNOWN") }, // TEL AVIV STOCK EXCHANGE
            { "XTAF", (".TW", "TWD") }, // TAIWAN FUTURES EXCHANGE
            { "XTAI", (".TW", "TWD") }, // TAIWAN STOCK EXCHANGE
            { "XTAL", ("N/A", "UNKNOWN") }, // NASDAQ TALLINN AS
            { "FNEE", ("N/A", "UNKNOWN") }, // FIRST NORTH ESTONIA
            { "XTAA", ("N/A", "UNKNOWN") }, // FIRST NORTH ESTONIA
            { "XTAR", ("N/A", "UNKNOWN") }, // TALLINN STOCK EXCHANGE - REGULATED MARKET
            { "XTEH", ("N/A", "UNKNOWN") }, // TEHRAN STOCK EXCHANGE
            { "XTFE", (".TO", "CAD") }, // TORONTO FUTURES EXCHANGE
            { "XTFF", (".T", "JPY") }, // TOKYO FINANCIAL  EXCHANGE
            { "XTFN", (".L", "GBP") }, // TRADEPOINT FINANCIAL NETWORKS PLC
            { "XTIR", ("N/A", "UNKNOWN") }, // TIRANA STOCK EXCHANGE
            { "XTKA", (".T", "JPY") }, // TOYOHASHI KANKEN TORIHIKIJO (DRIED COCOON EXCHANGE) - CHUBU COMMODITY EXCHANGE
            { "XTKO", (".T", "JPY") }, // TOKYO GRAIN EXCHANGE
            { "XTLX", (".MI", "EUR") }, // TLX
            { "XTOE", (".TO", "CAD") }, // TORONTO OPTIONS EXCHANGE
            { "XTRA", (".CO", "DKK") }, // XTRAMARKED
            { "XTRD", ("", "USD") }, // XTRD
            { "XTRN", ("N/A", "UNKNOWN") }, // TRINIDAD AND TOBAGO STOCK EXCHANGE
            { "XTRZ", ("N/A", "UNKNOWN") }, // ZAGREB MONEY AND SHORT TERM SECURITIES MARKET INC
            { "XTSE", (".TO", "CAD") }, // TORONTO STOCK EXCHANGE
            { "XDRK", (".TO", "CAD") }, // TORONTO STOCK EXCHANGE - DRK
            { "XTSX", (".TO", "CAD") }, // TSX VENTURE EXCHANGE
            { "VDRK", (".TO", "CAD") }, // TSX VENTURE EXCHANGE - DRK
            { "XTNX", (".TO", "CAD") }, // TSX VENTURE EXCHANGE - NEX
            { "XTUN", ("N/A", "UNKNOWN") }, // TUNIS STOCK EXCHANGE (BOURSE DE TUNIS)
            { "BTUN", ("N/A", "UNKNOWN") }, // TUNIS STOCK EXCHANGE (BOURSE DE TUNIS) - BONDS MARKET
            { "XTUP", (".L", "GBP") }, // TULLETT PREBON PLC
            { "TBEN", (".L", "GBP") }, // TULLETT PREBON PLC - TP ENERGY
            { "TBLA", (".L", "GBP") }, // TULLETT PREBON PLC - TP TRADEBLADE
            { "TPCD", (".L", "GBP") }, // TULLETT PREBON PLC - TP CREDITDEAL
            { "TPEQ", (".L", "GBP") }, // TULLETT PREBON PLC - TP EQUITYTRADE
            { "TPFD", (".L", "GBP") }, // TULLETT PREBON PLC - TP FORWARDDEAL
            { "TPRE", (".L", "GBP") }, // TULLETT PREBON PLC - TP REPO
            { "TPSD", (".L", "GBP") }, // TULLETT PREBON PLC - TP SWAPDEAL
            { "TPSP", (".L", "GBP") }, // TULLETT PREBON PLC - TP SPOTDEAL
            { "XTPE", (".L", "GBP") }, // TULLETT PREBON PLC - TP ENERGYTRADE
            { "XTUR", (".IS", "TRY") }, // TURKISH DERIVATIVES EXCHANGE
            { "XTXD", ("", "USD") }, // XTX DIRECT
            { "XTXE", (".PA", "EUR") }, // XTX MARKETS SAS
            { "XTXM", (".L", "GBP") }, // XTX MARKETS
            { "XUAX", ("N/A", "UNKNOWN") }, // UKRAINIAN STOCK EXCHANGE
            { "XUBS", (".L", "GBP") }, // AQUIS EXCHANGE PLC - AMP - DARK ORDER BOOK
            { "XUMP", (".L", "GBP") }, // UBS MTF LIMITED - PERIODIC AUCTION ORDER BOOK
            { "XUGA", ("N/A", "UNKNOWN") }, // UGANDA SECURITIES EXCHANGE
            { "XUKR", ("N/A", "UNKNOWN") }, // UKRAINIAN UNIVERSAL COMMODITY EXCHANGE
            { "XULA", ("N/A", "UNKNOWN") }, // MONGOLIAN STOCK EXCHANGE
            { "XUNI", ("N/A", "UNKNOWN") }, // UNIVERSAL BROKER'S EXCHANGE 'TASHKENT'
            { "XUSE", (".NS", "INR") }, // UNITED STOCK EXCHANGE
            { "XVAR", ("N/A", "UNKNOWN") }, // VARAZDIN STOCK EXCHANGE, THE
            { "XVES", ("N/A", "UNKNOWN") }, // VESTIMA
            { "XVLA", (".ME", "RUB") }, // VLADIVOSTOK (RUSSIA) STOCK EXCHANGE
            { "XVPA", ("N/A", "UNKNOWN") }, // BOLSA DE VALORES Y PRODUCTOS DE ASUNCION SA
            { "XVPB", ("N/A", "UNKNOWN") }, // VP BANK AG
            { "XVSE", (".TO", "CAD") }, // VANCOUVER STOCK EXCHANGE
            { "XWAR", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/EQUITIES/MAIN MARKET
            { "BOSP", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/BONDS/CATALYST/BONDSPOT/MTF
            { "CETO", (".WA", "PLN") }, // BONDSPOT S.A.
            { "PLPD", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/POLISH POWER EXCHANGE/REGULATED MARKET
            {
                "PLPO", (".WA", "PLN")
            }, // WARSAW STOCK EXCHANGE/COMMODITIES/POLISH POWER - EXCHANGE/ORGANIZED TRADING FACILITIES
            { "PLPS", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/COMMODITIES/POLISH POWER EXCHANGE/SPOT
            { "PLPX", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/COMMODITIES/POLISH POWER EXCHANGE/ENERGY MARKET
            { "POEE", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/ENERGY MARKET/POEE
            { "RPWC", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/BONDS/CATALYST/BONDSPOT/REGULATED MARKET
            { "TBSA", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/BONDS/TREASURY BOND/BONDSPOT/B2C MARKET/MTF
            { "TBSP", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/BONDS/BONDSPOT/TREASURY BOND MARKET
            { "WBCL", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/BONDS/CATALYST/LISTING
            { "WBLC", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/BONDS/CATALYST/LISTING
            { "WBON", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/ BONDS/CATALYST/MAIN MARKET
            { "WCDE", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/COMMODITY DERIVATIVES
            { "WDER", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/FINANCIAL DERIVATIVES
            { "WETP", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/ ETPS
            { "WGAS", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/COMMODITIES/POLISH POWER EXCHANGE/GAS
            { "WIND", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/INDICES
            { "WIPO", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE - OTHER THAN XOFF OR XXXX
            { "WMTF", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/BONDS/CATALYST/MTF
            { "WOPO", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE - SPO BOOK BUILDING
            { "XGLO", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/ EQUITIES/GLOBAL CONNECT - MTF
            { "XNCO", (".WA", "PLN") }, // WARSAW STOCK EXCHANGE/ EQUITIES/NEW CONNECT - MTF
            { "XWBO", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG
            { "EXAA", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG, AUSTRIAN ENERGY EXCHANGE
            { "WBAH", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG AMTLICHER HANDEL (OFFICIAL MARKET)
            { "WBDM", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG VIENNA MTF (VIENNA MTF)
            { "WBGF", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG GEREGELTER FREIVERKEHR (SECOND REGULATED MARKET)
            { "WBMA", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG MIDPOINT AMTLICHER HANDEL (OFFICIAL MARKET)
            { "XCEG", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG, CEGH GAS EXCHANGE
            { "XVIE", ("N/A", "UNKNOWN") }, // WIENER BOERSE AG, WERTPAPIERBOERSE (SECURITIES EXCHANGE)
            { "XXSC", (".DE", "EUR") }, // FRANKFURT CEF SC
            { "XXXX", ("N/A", "UNKNOWN") }, // NO MARKET (E.G. UNLISTED)
            { "XYIE", (".AX", "AUD") }, // TRADEWEB AUSTRALIA
            { "XYKT", (".T", "JPY") }, // YOKOHAMA COMMODITY EXCHANGE (WRONGLY RENAMED TOKYO GRAIN EXCHANGE SEPT 2006)
            { "XZAG", ("N/A", "UNKNOWN") }, // ZAGREB STOCK EXCHANGE
            { "XZAM", ("N/A", "UNKNOWN") }, // THE ZAGREB STOCK EXCHANGE MTF
            { "XZAP", ("N/A", "UNKNOWN") }, // PROGRESS MARKET
            { "ZAPA", ("N/A", "UNKNOWN") }, // ZAGREB STOCK EXCHANGE - APA
            { "XZCE", (".SS", "CNY") }, // ZHENGZHOU COMMODITY EXCHANGE
            { "XZIM", ("N/A", "UNKNOWN") }, // ZIMBABWE STOCK EXCHANGE
            { "YKNA", ("", "USD") }, // COMHAR CAPITAL MARKETS, LLC - US EQUITIES
            { "ZARX", (".JO", "ZAR") }, // ZAR X
            { "ZKBX", (".SW", "CHF") }, // ZURCHER KANTONALBANK SECURITIES EXCHANGE
            { "KMUX", (".SW", "CHF") }, // ZURCHER KANTONALBANK - EKMU-X
            { "ZODM", (".L", "GBP") }, // ZODIA MARKETS
        };
}
