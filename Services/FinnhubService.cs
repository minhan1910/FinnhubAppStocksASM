using ServiceContracts;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly HttpClient _httpClient;
        public FinnhubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri($""),
                Method = HttpMethod.Get,
            };

            return null;
        }

        public Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            throw new NotImplementedException();
        }
    }
}