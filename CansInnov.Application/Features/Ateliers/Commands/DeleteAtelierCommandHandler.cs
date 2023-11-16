using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Exceptions;
using CansInnov.Persistence.Models;
using CansInnov.Persistence;
using MediatR;

namespace CansInnov.Application.Features.Ateliers.Commands
{
    public class DeleteAtelierCommandHandler : IRequestHandler<DeleteAtelierCommand>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteAtelierCommandHandler(CansEventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(DeleteAtelierCommand request, CancellationToken cancellationToken)
        {
            Atelier atelier = await _dbContext.Ateliers.FindAsync(new object[] { request.Id }, cancellationToken)
                ?? throw new NotFoundException(nameof(Atelier), request.Id);

            _dbContext.Ateliers.Remove(atelier);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}