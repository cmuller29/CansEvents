using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Persistence;
using CansInnov.Persistence.Models;
using MediatR;

namespace CansInnov.Application.Features.Events.Commands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ValidatorHelper<CreateEventCommandValidator, CreateEventCommand> _validator;

        public CreateEventCommandHandler(CansEventsDbContext dbContext, IMapper mapper,
            ValidatorHelper<CreateEventCommandValidator, CreateEventCommand> validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(command, cancellationToken);

            Event @event = _mapper.Map<Event>(command);
            _dbContext.Events.Add(@event);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}