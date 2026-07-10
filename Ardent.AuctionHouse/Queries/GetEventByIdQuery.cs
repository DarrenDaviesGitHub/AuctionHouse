using Ardent.AuctionHouse.DomainTransferObjects;
using MediatR;

namespace Ardent.AuctionHouse.Queries;

public record GetEventByIdQuery(Guid EventId) : IRequest<EventDto>;