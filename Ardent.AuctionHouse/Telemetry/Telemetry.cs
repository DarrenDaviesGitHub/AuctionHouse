using System.Diagnostics;

namespace Ardent.AuctionHouse.Telemetry;

public static class Telemetry
{
    public static ActivitySource ActivitySource => new(nameof(AuctionHouse));
}
