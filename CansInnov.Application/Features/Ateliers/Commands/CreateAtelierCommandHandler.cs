using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Persistence;
using CansInnov.Persistence.Models;
using MediatR;

namespace CansInnov.Application.Features.Ateliers.Commands
{
    public class CreateAtelierCommandHandler : IRequestHandler<CreateAtelierCommand>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAtelierCommandHandler(CansEventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(CreateAtelierCommand request, CancellationToken cancellationToken)
        {
            Atelier atelier = _mapper.Map<Atelier>(request);
            _dbContext.Atelier.Add(atelier);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}