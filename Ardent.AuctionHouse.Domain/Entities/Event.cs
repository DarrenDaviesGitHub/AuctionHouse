namespace Ardent.AuctionHouse.Domain.Entities;

public class Event
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime Date { get; set; } 
    public required string Location { get; set; }
    public ICollection<string> Showings { get; set; } = [];
}