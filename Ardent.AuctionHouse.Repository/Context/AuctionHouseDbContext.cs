using Ardent.AuctionHouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ardent.AuctionHouse.Repository.Context;

public class AuctionHouseDbContext(DbContextOptions<AuctionHouseDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuctionHouseDbContext).Assembly);
    }
}
