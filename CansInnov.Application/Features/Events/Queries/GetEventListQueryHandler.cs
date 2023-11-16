using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Application.Features.Events.Dtos;
using CansInnov.Domain.Entities;
using MediatR;

namespace CansInnov.Application.Features.Events.Queries
{
    public class GetEventListQueryHandler 
        : IRequestHandler<GetEventListQuery, List<EventDto>>
    {
        private readonly IAsyncRepository<Event> _repository;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IAsyncRepository<Event> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Event> events = await _repository.ListAsync(x => x.DateDebut > DateTime.Now, cancellationToken);
            return _mapper.Map<List<EventDto>>(events.OrderBy(x => x.DateDebut));
        }
    }
}