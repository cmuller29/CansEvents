using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Application.Features.Events.Dtos;
using MediatR;

namespace CansInnov.Application.Features.Events.Queries
{
    public class GetEventListQuery : IRequest<List<EventDto>>
    {
    }
}