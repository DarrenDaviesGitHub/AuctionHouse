using Ardent.AuctionHouse.Domain.Models;
using Ardent.AuctionHouse.Repository.Data;
using Ardent.AuctionHouse.Repository.Interfaces;

namespace Ardent.AuctionHouse.Repository.Events;

public class EventsRepository : IEventsRepository
{
    public Task<IEnumerable<Event>> RetrieveEvents(CancellationToken cancellationToken) 
        => EventFactory.RetrieveEvents(cancellationToken);

    public Task<Event> RetrieveEventById(Guid eventId, CancellationToken cancellationToken) 
        => EventFactory.RetrieveEventById(eventId, cancellationToken);
}