using Ardent.AuctionHouse.Domain.Entities;
using Ardent.AuctionHouse.EventSeeder.Factories;
using Ardent.AuctionHouse.EventSeeder.Interfaces;
using Ardent.AuctionHouse.Repository.Interfaces;

namespace Ardent.AuctionHouse.EventSeeder.Services;

public class EventSeederService(IEventsRepository eventsRepository) : IEventSeeder
{
    public async Task Seed(int count)
    {
        IEnumerable<Event> events = EventGeneratorFactory.Generate(count);
        await eventsRepository.AddRange(events, new CancellationToken());
    }
}
