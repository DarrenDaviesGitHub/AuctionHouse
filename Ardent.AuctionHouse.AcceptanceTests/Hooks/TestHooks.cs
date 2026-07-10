using Ardent.AuctionHouse.AcceptanceTests.Context;
using Reqnroll;

namespace Ardent.AuctionHouse.AcceptanceTests.Hooks;

[Binding]
public sealed class TestHooks(ApiScenarioContext context)
{
    private readonly ApiScenarioContext _context = context;

    [BeforeScenario]
    public void Setup()
    {
        _context.Client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000")
        };
    }


    [AfterScenario]
    public void Cleanup()
    {
        _context.Client.Dispose();
    }
}