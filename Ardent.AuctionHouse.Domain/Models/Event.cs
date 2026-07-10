namespace Ardent.AuctionHouse.Domain.Models;

public class Event
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime Date { get; set; } 
    public required string Location { get; set; }
    public IEnumerable<string>? Showings { get; set; }
}