using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Domain.Common;

namespace CansInnov.Domain.Entities
{
    public class Atelier : AuditableEntity
    {
        public Guid EventId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public TypeAtelier Type { get; set; }
        public string NomIntervenant { get; set; }
        public string Lieu { get; set; }
        public string? LienReunion { get; set; }
        public int NbParticipantMax { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public Event Event { get; set; } = default!;
    }
}