using Ardent.AuctionHouse.DomainTransferObjects;
using Ardent.AuctionHouse.Queries;
using Ardent.AuctionHouse.Repository.Interfaces;
using MediatR;

namespace Ardent.AuctionHouse.Handlers;

public class GetEventsQueryHandler(IEventsRepository eventsRepository) : IRequestHandler<GetEventsQuery, IEnumerable<EventDto>>
{
    public async Task<IEnumerable<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
    {
        using var activity = Telemetry.Telemetry.ActivitySource.StartActivity(nameof(GetEventsQueryHandler));

        activity?.SetTag("operation.name", nameof(GetEventsQueryHandler));

        var results = await eventsRepository.RetrieveEvents(cancellationToken);

        activity?.SetTag("operation.result.auctioneventcount", results.Count());

        return Mappings.EventMapping.MapDto(results);
    }
}