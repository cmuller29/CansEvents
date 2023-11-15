using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Application.Features.Ateliers.Queries;
using CansInnov.Application.Features.Events.Commands;
using CansInnov.Application.Features.Events.Dtos;
using CansInnov.Application.Features.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CansInnov.Server.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> GetEventList()
        {
            List<EventDto> events = await _mediator.Send(new GetEventListQuery());
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventCommand createEventCommand)
        {
            await _mediator.Send(createEventCommand);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            await _mediator.Send(new DeleteEventCommand { Id = id });
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetEventDetail(Guid id)
        {
            return Ok();
        }

        [HttpGet("{id}/atelier")]
        public async Task<ActionResult<List<AteliersByEventIdDto>>> GetAtelierByEventId(Guid id)
        {
            List<AteliersByEventIdDto> ateliers = await _mediator.Send(new GetAtelierByEventIdQuery { EventId = id });
            return Ok(ateliers);
        }
    }
}