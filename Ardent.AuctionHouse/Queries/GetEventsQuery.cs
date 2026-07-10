using Ardent.AuctionHouse.DomainTransferObjects;
using MediatR;

namespace Ardent.AuctionHouse.Queries;

public record GetEventsQuery : IRequest<IEnumerable<EventDto>>;