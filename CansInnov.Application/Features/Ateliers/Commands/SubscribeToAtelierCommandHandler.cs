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
using Microsoft.EntityFrameworkCore;

namespace CansInnov.Application.Features.Ateliers.Commands
{
    public class SubscribeToAtelierCommandHandler : IRequestHandler<SubscribeToAtelierCommand>
    {
        private readonly CansEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubscribeToAtelierCommandHandler(CansEventsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(SubscribeToAtelierCommand request, CancellationToken cancellationToken)
        {
            Atelier atelier = await _dbContext.Ateliers
                .Include(x => x.Participants)
                .FirstOrDefaultAsync(x => x.Id == request.AtelierId, cancellationToken)
                ?? throw new NotFoundException(nameof(Atelier), request.AtelierId);

            if (atelier.Participants.Count >= atelier.NbParticipantMax)
            {
                throw new CansEventException("Nombre max de particpant atteint");
            }

            if (atelier.Participants.Any(x => x.Matricule == request.Matricule))
            {
                throw new CansEventException("Participant déjà inscrit");
            }

            atelier.Participants.Add(_mapper.Map<ParticipantAtelier>(request));
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}