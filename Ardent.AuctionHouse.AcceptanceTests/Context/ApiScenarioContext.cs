using Ardent.AuctionHouse.AcceptanceTests.Models;

namespace Ardent.AuctionHouse.AcceptanceTests.Context;

public class ApiScenarioContext
{
    public HttpClient Client { get; set; } = default!;

    public HttpResponseMessage Response { get; set; } = default!;

    public EventDto? Event { get; set; }
}