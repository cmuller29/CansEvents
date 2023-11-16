using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Exceptions;
using MediatR;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Domain.Entities;

namespace CansInnov.Application.Features.Ateliers.Commands
{
    public class DeleteAtelierCommandHandler : IRequestHandler<DeleteAtelierCommand>
    {
        private readonly IAsyncRepository<Atelier> _repository;
        private readonly IMapper _mapper;

        public DeleteAtelierCommandHandler(IAsyncRepository<Atelier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteAtelierCommand request, CancellationToken cancellationToken)
        {
            Atelier atelier = await _repository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Atelier), request.Id);

            await _repository.DeleteAsync(atelier, cancellationToken);
        }
    }
}