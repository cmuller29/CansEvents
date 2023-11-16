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

namespace CansInnov.Application.Features.Ateliers.Commands
{
    public class UpdateAtelierCommandHandler : IRequestHandler<UpdateAtelierCommand>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateAtelierCommandHandler(CansEventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAtelierCommand request, CancellationToken cancellationToken)
        {
            Atelier atelier = await _dbContext.Ateliers.FindAsync(new object[] { request.Id }, cancellationToken)
                ?? throw new NotFoundException(nameof(Atelier), request.Id);

            _mapper.Map(request, atelier);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}