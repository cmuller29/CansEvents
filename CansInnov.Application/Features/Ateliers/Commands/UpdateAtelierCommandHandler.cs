using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Application.Exceptions;
using CansInnov.Domain.Entities;
using MediatR;

namespace CansInnov.Application.Features.Ateliers.Commands
{
    public class UpdateAtelierCommandHandler : IRequestHandler<UpdateAtelierCommand>
    {
        private readonly IAsyncRepository<Atelier> _repository;
        private readonly IMapper _mapper;

        public UpdateAtelierCommandHandler(IAsyncRepository<Atelier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAtelierCommand request, CancellationToken cancellationToken)
        {
            Atelier atelier = await _repository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Atelier), request.Id);

            _mapper.Map(request, atelier);
            await _repository.UpdateAsync(atelier, cancellationToken);
        }
    }
}