namespace Ardent.AuctionHouse.AcceptanceTests.Models;

public record EventDto(string Name, DateTime Date, string Location, IEnumerable<string> Showings);