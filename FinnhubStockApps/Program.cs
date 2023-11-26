using FinnhubStockApps.Clients;
using FinnhubStockApps.Options;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));
builder.Services.AddHttpClient<IFinnhubClient, FinnhubClient>(client =>
{
    client.BaseAddress = new Uri("https://finnhub.io/api/v1");
});
builder.Services.AddScoped<IFinnhubService, FinnhubService>();

var app = builder.Build();

app.UseStaticFiles();   
app.UseRouting();
app.MapControllers();

app.Run();
