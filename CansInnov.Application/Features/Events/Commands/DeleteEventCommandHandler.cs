using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Application.Exceptions;
using CansInnov.Domain.Entities;
using MediatR;

namespace CansInnov.Application.Features.Events.Commands
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IAsyncRepository<Event> _repository;

        public DeleteEventCommandHandler(IAsyncRepository<Event> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            Event @event = await _repository.GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Event), request.Id);

            await _repository.DeleteAsync(@event, cancellationToken);
        }
    }
}