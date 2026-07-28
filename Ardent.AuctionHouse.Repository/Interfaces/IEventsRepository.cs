using Ardent.AuctionHouse.Domain.Entities;

namespace Ardent.AuctionHouse.Repository.Interfaces;

public interface IEventsRepository
{
    Task<IEnumerable<Event>> RetrieveEvents(CancellationToken cancellationToken);
    Task<Event?> RetrieveEventById(Guid eventId, CancellationToken cancellationToken);
}