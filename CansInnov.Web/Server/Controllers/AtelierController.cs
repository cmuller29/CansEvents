using CansInnov.Application.Features.Ateliers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}