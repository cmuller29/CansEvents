using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Features.Events.Dtos;
using CansInnov.Persistence;
using CansInnov.Persistence.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CansInnov.Application.Features.Events.Queries
{
    public class GetEventListQueryHandler 
        : IRequestHandler<GetEventListQuery, List<EventDto>>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(CansEventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(
            GetEventListQuery request,
            CancellationToken cancellationToken)
        {
            List<Event> events = await _dbContext.Events.ToListAsync(cancellationToken);
            return _mapper.Map<List<EventDto>>(events);
        }
    }
}