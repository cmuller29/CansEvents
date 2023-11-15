using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Application.Features.Ateliers.Dtos;
using MediatR;

namespace CansInnov.Application.Features.Ateliers.Queries
{
    public class GetAtelierByEventIdQuery : IRequest<List<AteliersByEventIdDto>>
    {
        public Guid EventId { get; set; }
    }
}