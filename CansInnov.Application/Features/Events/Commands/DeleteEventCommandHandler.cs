using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Application.Exceptions;
using CansInnov.Persistence;
using CansInnov.Persistence.Models;
using MediatR;

namespace CansInnov.Application.Features.Events.Commands
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly CansEventsDbContext _dbContext;

        public DeleteEventCommandHandler(CansEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            Event @event = await _dbContext.Events.FindAsync(new object[] { request.Id }, cancellationToken)
                ?? throw new NotFoundException(nameof(Event), request.Id);

            _dbContext.Events.Remove(@event);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}