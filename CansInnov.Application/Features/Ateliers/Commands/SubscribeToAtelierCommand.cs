using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CansInnov.Application.Features.Ateliers.Commands
{
    public class SubscribeToAtelierCommand : IRequest
    {
        public Guid AtelierId { get; set; }
        public string Matricule { get; set; }
    }
}