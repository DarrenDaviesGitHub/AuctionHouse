using Ardent.AuctionHouse.Domain.Models;

namespace Ardent.AuctionHouse.Repository.Interfaces;

public interface IEventsRepository
{
    Task<IEnumerable<Event>> RetrieveEvents(CancellationToken cancellationToken);
    Task<Event> RetrieveEventById(Guid eventId, CancellationToken cancellationToken);
}