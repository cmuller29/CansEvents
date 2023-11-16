using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Domain.Entities;
using MediatR;

namespace CansInnov.Application.Features.Ateliers.Commands
{
    public class CreateAtelierCommandHandler : IRequestHandler<CreateAtelierCommand>
    {
        private readonly IAsyncRepository<Atelier> _repository;
        private readonly IMapper _mapper;

        public CreateAtelierCommandHandler(IAsyncRepository<Atelier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAtelierCommand request, CancellationToken cancellationToken)
        {
            Atelier atelier = _mapper.Map<Atelier>(request);
            await _repository.AddAsync(atelier, cancellationToken);
        }
    }
}