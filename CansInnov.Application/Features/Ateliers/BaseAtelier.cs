using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Persistence.Models;

namespace CansInnov.Application.Features.Ateliers
{
    public class BaseAtelier
    {
        public Guid id { get; set; }
        public Guid EventId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public TypeAtelier Type { get; set; }
        public string NomIntervenant { get; set; }
        public string Lieu { get; set; }
        public string LienReunion { get; set; } = string.Empty;
        public int NbParticipantMax { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }
}