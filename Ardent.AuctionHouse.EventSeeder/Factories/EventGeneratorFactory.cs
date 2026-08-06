using Ardent.AuctionHouse.Domain.Entities;
using Bogus;

namespace Ardent.AuctionHouse.EventSeeder.Factories;

public static class EventGeneratorFactory
{
    public static IEnumerable<Event> Generate(int count)
        => new Faker<Event>()
            .RuleFor(e => e.Id, _ => Guid.NewGuid())
            .RuleFor(e => e.Name, f => f.Commerce.ProductName())
            .RuleFor(e => e.Location, f => f.Address.City())
            .RuleFor(e => e.Date, f => DateTime.SpecifyKind(f.Date.Future(), DateTimeKind.Utc))
            .RuleFor(e => e.Showings, f => Enumerable.Range(0, f.Random.Int(1, 5))
                .Select(_ => f.Lorem.Word())
                .ToList())
            .Generate(count);
}
