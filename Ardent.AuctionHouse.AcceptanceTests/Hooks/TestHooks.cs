using Ardent.AuctionHouse.AcceptanceTests.Context;
using Microsoft.Extensions.Configuration;
using Reqnroll;

namespace Ardent.AuctionHouse.AcceptanceTests.Hooks;

[Binding]
public sealed class TestHooks(ApiScenarioContext context)
{
    private readonly ApiScenarioContext _context = context;
    private readonly IConfiguration _configuration = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

    [BeforeScenario]
    public void Setup()
    {
        var baseUrl = _configuration["ApiSettings:BaseUrl"];

        _context.Client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl!)
        };
    }

    [AfterScenario]
    public void Cleanup()
    {
        _context.Client.Dispose();
    }
}