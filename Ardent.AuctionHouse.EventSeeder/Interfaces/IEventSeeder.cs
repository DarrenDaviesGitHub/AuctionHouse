namespace Ardent.AuctionHouse.EventSeeder.Interfaces;

public interface IEventSeeder
{
    Task Seed(int count);
}
