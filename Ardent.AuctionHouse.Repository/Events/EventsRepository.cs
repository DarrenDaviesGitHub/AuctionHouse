using Ardent.AuctionHouse.Domain.Entities;
using Ardent.AuctionHouse.Repository.Context;
using Ardent.AuctionHouse.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ardent.AuctionHouse.Repository.Events;

public class EventsRepository(AuctionHouseDbContext context) : IEventsRepository
{
    public async Task Add(Event newEvent, CancellationToken cancellationToken)
    {
        await context.Events.AddAsync(newEvent, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRange(IEnumerable<Event> events, CancellationToken cancellationToken)
    {
        const int chunkSize = 1000;

        foreach (var batch in events.Chunk(chunkSize))
        {
            await context.Events.AddRangeAsync(batch, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            context.ChangeTracker.Clear();
        }
    }

    public async Task<IEnumerable<Event>> Get(CancellationToken cancellationToken)
        => await context.Events
        .AsNoTracking()
        .ToListAsync(cancellationToken);

    public async Task<Event?> GetById(Guid eventId, CancellationToken cancellationToken) 
        => await context.Events
        .AsNoTracking()
        .FirstOrDefaultAsync(e => e.Id == eventId, cancellationToken);
}