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

namespace CansInnov.Application.Features.Events.Commands
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> _repository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IAsyncRepository<Event> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event @event = await _repository.GetByIdWithTrackingAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Event), request.Id);

            _mapper.Map(request, @event);
            await _repository.UpdateAsync(@event, cancellationToken);
        }
    }
}