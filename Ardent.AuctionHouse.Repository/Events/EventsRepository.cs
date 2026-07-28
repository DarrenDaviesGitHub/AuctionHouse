using Ardent.AuctionHouse.Domain.Entities;
using Ardent.AuctionHouse.Repository.Context;
using Ardent.AuctionHouse.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ardent.AuctionHouse.Repository.Events;

public class EventsRepository(AuctionHouseDbContext context) : IEventsRepository
{
    public async Task<IEnumerable<Event>> RetrieveEvents(CancellationToken cancellationToken)
        => await context.Events
        .AsNoTracking()
        .ToListAsync(cancellationToken);

    public async Task<Event?> RetrieveEventById(Guid eventId, CancellationToken cancellationToken) 
        => await context.Events
        .AsNoTracking()
        .FirstOrDefaultAsync(e => e.Id == eventId, cancellationToken);
}