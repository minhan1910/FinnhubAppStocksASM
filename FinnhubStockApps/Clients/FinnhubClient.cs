using FinnhubStockApps.Constants;
using System.Text.Json;

namespace FinnhubStockApps.Clients
{
    public class FinnhubClient : IFinnhubClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public FinnhubClient(HttpClient httpClient, 
                             IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile2(string stockSymbol)
        {
            string uri = BuildUri(SystemConstants.COMPANY_PROFILE_DOMAIN, stockSymbol);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get,
            };

            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            Stream stream = httpResponseMessage.Content.ReadAsStream();
            StreamReader streamReader = new StreamReader(stream);
            string response = streamReader.ReadToEnd();

            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            if (responseDictionary == null)
            {
                throw new InvalidOperationException("No response from the server");
            }

            if (responseDictionary.ContainsKey("error"))
            {
                throw new InvalidOperationException((string?)responseDictionary["error"]);
            }

            return responseDictionary;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            string uri = BuildUri(SystemConstants.QUOTE_STOCK_DOMAIN, stockSymbol);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get,
            };

            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            Stream stream = httpResponseMessage.Content.ReadAsStream();
            StreamReader streamReader = new StreamReader(stream);
            string response = streamReader.ReadToEnd();

            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            if (responseDictionary == null)
            {
                throw new InvalidOperationException("No response from the server");
            }

            if (responseDictionary.ContainsKey("error"))
            {
                throw new InvalidOperationException((string?)responseDictionary["error"]);
            }

            return responseDictionary;
        }

        private string BuildUri(string path, string stockSymbol)
        {
            return $"https://finnhub.io/api/v1/{path}?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}";
        }
    }
}
