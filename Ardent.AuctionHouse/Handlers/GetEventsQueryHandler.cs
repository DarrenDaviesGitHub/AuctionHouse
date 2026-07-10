using Ardent.AuctionHouse.DomainTransferObjects;
using Ardent.AuctionHouse.Queries;
using Ardent.AuctionHouse.Repository.Interfaces;
using MediatR;

namespace Ardent.AuctionHouse.Handlers;

public class GetEventsQueryHandler(IEventsRepository eventsRepository) : IRequestHandler<GetEventsQuery, IEnumerable<EventDto>>
{
    public async Task<IEnumerable<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        var results = await eventsRepository.RetrieveEvents(cancellationToken);
        return Mappings.EventMapping.MapDto(results);
    }
}