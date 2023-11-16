using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CansInnov.Persistence.Models
{
    public class ParticipantAtelier
    {
        public Guid Id { get; set; }
        public Guid AtelierId { get; set; }
        public string Matricule { get; set; }

        public Atelier Atelier { get; set; }
    }
}