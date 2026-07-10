using Ardent.AuctionHouse.DomainTransferObjects;
using Ardent.AuctionHouse.Mappings;
using Ardent.AuctionHouse.Queries;
using Ardent.AuctionHouse.Repository.Interfaces;
using MediatR;

namespace Ardent.AuctionHouse.Handlers;

public class GetEventByIdHandler(IEventsRepository eventsRepository) : IRequestHandler<GetEventByIdQuery, EventDto?>
{
    public async Task<EventDto?> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await eventsRepository.RetrieveEventById(request.EventId, cancellationToken);
        return EventMapping.MapDto(result);
    }
}
