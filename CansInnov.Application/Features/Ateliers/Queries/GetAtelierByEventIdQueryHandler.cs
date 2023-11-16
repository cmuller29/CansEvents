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
    public class GetAtelierByEventIdQueryHandler : IRequestHandler<GetAtelierByEventIdQuery, List<AtelierDto>>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAtelierByEventIdQueryHandler(CansEventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<AtelierDto>> Handle(GetAtelierByEventIdQuery request, CancellationToken cancellationToken)
        {
            List<AtelierDto> ateliers = await Task.Run(() =>
            {
                return _dbContext.Ateliers
                    .Include(x => x.Participants)
                    .Where(x => x.EventId == request.EventId)
                    .Select(Selector)
                    .ToList();
            });

            return ateliers;
        }

        private AtelierDto Selector(Atelier atelier)
        {
            AtelierDto atelierDto = _mapper.Map<AtelierDto>(atelier);
            atelierDto.Participants = atelier.Participants.Select(x => x.Matricule).ToList();
            return atelierDto;
        }
    }
}