using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Contracts.Persistence;
using CansInnov.Domain.Entities;
using MediatR;

namespace CansInnov.Application.Features.Events.Commands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IAsyncRepository<Event> _repository;
        private readonly IMapper _mapper;
        private readonly ValidatorHelper<CreateEventCommandValidator, CreateEventCommand> _validator;

        public CreateEventCommandHandler(IAsyncRepository<Event> repository, IMapper mapper,
            ValidatorHelper<CreateEventCommandValidator, CreateEventCommand> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(command, cancellationToken);

            Event @event = _mapper.Map<Event>(command);
            @event = await _repository.AddAsync(@event, cancellationToken);

            return @event.Id;
        }
    }
}