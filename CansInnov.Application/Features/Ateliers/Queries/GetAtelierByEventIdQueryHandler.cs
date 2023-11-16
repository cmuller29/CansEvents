using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Domain.Entities;
using MediatR;

namespace CansInnov.Application.Features.Ateliers.Queries
{
    public class GetAtelierByEventIdQueryHandler : IRequestHandler<GetAtelierByEventIdQuery, List<AtelierDto>>
    {
        private readonly IAsyncRepository<Atelier> _repository;
        private readonly IMapper _mapper;

        public GetAtelierByEventIdQueryHandler(IAsyncRepository<Atelier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AtelierDto>> Handle(GetAtelierByEventIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Atelier> ateliers = await _repository
                .ListAsync(x => x.EventId == request.EventId, cancellationToken);

            return _mapper.Map<List<AtelierDto>>(ateliers);
        }
    }
}