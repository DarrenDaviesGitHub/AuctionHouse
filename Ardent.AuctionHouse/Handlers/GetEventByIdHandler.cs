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
        using var activity = Telemetry.Telemetry.ActivitySource.StartActivity(nameof(GetEventByIdHandler));

        activity?.SetTag("operation.name", nameof(GetEventByIdHandler));

        var result = await eventsRepository.RetrieveEventById(request.EventId, cancellationToken);

        activity?.SetTag("operation.result.auctioneventexists", result is not null);

        return EventMapping.MapDto(result);
    }
}
