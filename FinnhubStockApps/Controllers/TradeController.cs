using FinnhubStockApps.Clients;
using FinnhubStockApps.Models;
using FinnhubStockApps.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts;

namespace FinnhubStockApps.Controllers
{
    [Route("[controller]")]
    public class TradeController : Controller
    {
        private readonly IFinnhubClient _finnhubClient;
        private readonly TradingOptions _tradingOptions;
        private readonly IConfiguration _configuration;


        public TradeController(IFinnhubClient finnhubClient,
                               IConfiguration configuration,
                               IOptions<TradingOptions> tradingOptions)
        {
            _finnhubClient = finnhubClient;
            _tradingOptions = tradingOptions.Value;
            _configuration = configuration;
        }

        [Route("/")]
        [Route("[action]")]
        [Route("~/[controller]")]
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(_tradingOptions.DefaultStockSymbol))
            {
                _tradingOptions.DefaultStockSymbol = "MSFT";
            }

            Dictionary<string, object>? responseStockPrice = await _finnhubClient.GetStockPriceQuote(_tradingOptions.DefaultStockSymbol);            
            Dictionary<string, object>? responseCompanyProfile = await _finnhubClient.GetCompanyProfile2(_tradingOptions.DefaultStockSymbol);            

            StockTrade stockTrade = new()
            {
                StockSymbol = _tradingOptions.DefaultStockSymbol,
            };

            if (responseStockPrice != null && responseCompanyProfile != null)
            {
                stockTrade = new()
                {
                    StockSymbol = responseCompanyProfile["ticker"].ToString(),
                    Price = Convert.ToDouble(responseStockPrice["c"].ToString()),
                    StockName = responseCompanyProfile["name"].ToString(),
                };
            }

            ViewBag.FinnhubToken = _configuration["FinnhubToken"];

            return View(stockTrade);
        }
    }
}
