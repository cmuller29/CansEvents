using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Exceptions;
using CansInnov.Persistence;
using CansInnov.Persistence.Models;
using MediatR;

namespace CansInnov.Application.Features.Events.Commands
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(CansEventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event @event = await _dbContext.Events.FindAsync(new object[] {request.Id}, cancellationToken)
                ?? throw new NotFoundException(nameof(Event), request.Id);

            _mapper.Map(request, @event);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}