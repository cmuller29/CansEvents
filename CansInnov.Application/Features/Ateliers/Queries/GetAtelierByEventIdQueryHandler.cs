using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Persistence;
using CansInnov.Persistence.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CansInnov.Application.Features.Ateliers.Queries
{
    public class GetAtelierByEventIdQueryHandler : IRequestHandler<GetAtelierByEventIdQuery, List<AteliersByEventIdDto>>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAtelierByEventIdQueryHandler(CansEventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<AteliersByEventIdDto>> Handle(GetAtelierByEventIdQuery request, CancellationToken cancellationToken)
        {
            List<Atelier> ateliers = await _dbContext.Atelier
                .Where(x => x.EventId == request.EventId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<AteliersByEventIdDto>>(ateliers);
        }
    }
}