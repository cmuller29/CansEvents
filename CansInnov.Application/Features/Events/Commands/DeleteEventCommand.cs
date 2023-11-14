using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CansInnov.Application.Features.Events.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}