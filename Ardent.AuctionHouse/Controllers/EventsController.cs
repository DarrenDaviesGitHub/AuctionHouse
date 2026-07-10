using Ardent.AuctionHouse.Domain.Models;
using Ardent.AuctionHouse.DomainTransferObjects;
using Ardent.AuctionHouse.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ardent.AuctionHouse.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IEnumerable<Event>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EventDto>>> Get(CancellationToken cancellationToken)
    {
        IEnumerable<EventDto> results = await mediator.Send(new GetEventsQuery(), cancellationToken);

        return Ok(results);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType<EventDto>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EventDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        EventDto result = await mediator.Send(new GetEventByIdQuery(id), cancellationToken);

        return result is not null
            ? Ok(result)
            : NotFound();
    }
}