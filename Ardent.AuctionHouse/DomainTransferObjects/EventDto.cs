namespace Ardent.AuctionHouse.DomainTransferObjects;

public record EventDto(string Name, DateTime Date, string Location, IEnumerable<string> Showings);