using Ardent.AuctionHouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Ardent.AuctionHouse.Repository.Configuration;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey("Id");

        builder
            .Property(x => x.Name)
            .HasMaxLength(350)
            .IsRequired();

        builder
            .Property(x => x.Date)
            .IsRequired();

        builder
            .Property(e => e.Showings)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null)!);

        builder.HasData(
            new Event
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Rare Watch Collection Auction",
                Date = new DateTime(2026, 7, 31, 0, 0, 0, DateTimeKind.Utc),
                Location = "London"
            },
            new Event
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Fine Art Auction",
                Date = new DateTime(2026, 8, 18, 0, 0, 0, DateTimeKind.Utc),
                Location = "London"
            },
            new Event
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Classic Car Auction",
                Date = new DateTime(2026, 8, 4, 0, 0, 0, DateTimeKind.Utc),
                Location = "Manchester"
            });
    }
}
