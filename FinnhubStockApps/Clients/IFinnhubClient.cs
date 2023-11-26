namespace FinnhubStockApps.Clients
{
    public interface IFinnhubClient
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
        Task<Dictionary<string, object>?> GetCompanyProfile2(string stockSymbol);
    }
}
