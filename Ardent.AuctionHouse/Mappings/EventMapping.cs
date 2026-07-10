using Ardent.AuctionHouse.Domain.Models;
using Ardent.AuctionHouse.DomainTransferObjects;

namespace Ardent.AuctionHouse.Mappings;

public class EventMapping
{
    public static IEnumerable<EventDto> MapDto(IEnumerable<Event> original)
        => original is not null
        ? original.Select(e => new EventDto(e.Name, e.Date, e.Location, e.Showings ?? []))
        : [];

    public static EventDto? MapDto(Event original)
        => original is not null 
        ? new EventDto(original.Name, original.Date, original.Location, original.Showings ?? [])
        : null;
}
