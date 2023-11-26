namespace FinnhubStockApps.Models
{

//    {
//      "country": "US",
//      "currency": "USD",
//      "estimateCurrency": "USD",
//      "exchange": "NASDAQ NMS - GLOBAL MARKET",
//      "finnhubIndustry": "Technology",
//      "ipo": "1980-12-12",
//      "logo": "https://static2.finnhub.io/file/publicdatany/finnhubimage/stock_logo/AAPL.svg",
//      "marketCapitalization": 2954556.25083077,
//      "name": "Apple Inc",
//      "phone": "14089961010.0",
//      "shareOutstanding": 15634.23,
//      "ticker": "AAPL",
//      "weburl": "https://www.apple.com/"
//  }

    public class CompanyProfile
    {
        public string? Country { get; set; }
        public string? Currency { get; set; }
        public string? EstimateCurrency { get; set; }
        public string? Exchange { get; set; }
        public string? FinnnhubIndustry { get; set; }
        public DateTime? IPO { get; set; }
        public string? Logo { get; set; }
        public double? MarketCapitalization { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public double? ShareOutstanding { get; set; }
        public string? Ticker { get; set; }
        public string? WebUrl { get; set; }
        
    }
}
