using Ardent.AuctionHouse.Domain.Entities;

namespace Ardent.AuctionHouse.Repository.Interfaces;

public interface IEventsRepository
{
    Task Add(Event newEvent, CancellationToken cancellationToken);
    Task AddRange(IEnumerable<Event> events, CancellationToken cancellationToken);
    Task<IEnumerable<Event>> Get(CancellationToken cancellationToken);
    Task<Event?> GetById(Guid eventId, CancellationToken cancellationToken);
}