using CansInnov.Application.Features.Ateliers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CansInnov.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AtelierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtelierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAtelier(CreateAtelierCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAtelier(UpdateAtelierCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtelier(Guid id)
        {
            await _mediator.Send(new DeleteAtelierCommand { Id = id });
            return Ok();
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> SubscribreToAtelier(SubscribeToAtelierCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}