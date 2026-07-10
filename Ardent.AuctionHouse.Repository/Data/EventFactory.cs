using Ardent.AuctionHouse.Domain.Models;

namespace Ardent.AuctionHouse.Repository.Data;

public class EventFactory
{
    public static Task<IEnumerable<Event>> RetrieveEvents(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult<IEnumerable<Event>>(new List<Event>
        {
            new() {
                Id = Guid.NewGuid(),
                Name = "Art Auction 2026",
                Date = new DateTime(2024, 5, 15),
                Location = "New York City",
                Showings = ["July 10, 2026", "August 12, 2026"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Antique Auction 2026",
                Date = new DateTime(2024, 6, 20),
                Location = "Los Angeles",
                Showings = ["July 15, 2026", "September 18, 2026"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Modern Art Auction 2026",
                Date = new DateTime(2024, 7, 10),
                Location = "Chicago",
                Showings = ["October 5, 2026", "December 1, 2026"]
            }
        });
    }

    public static Task<Event> RetrieveEventById(Guid eventId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(new Event
        {
            Id = eventId,
            Name = "Modern Art Auction 2026",
            Date = new DateTime(2024, 7, 10),
            Location = "Chicago",
            Showings = ["October 5, 2026", "December 1, 2026"]
        });
    }
}
