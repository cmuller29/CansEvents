using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Domain.Common;

namespace CansInnov.Domain.Entities
{
    public class Event : AuditableEntity
    {
        public string Titre { get; set; }
        public string Description { get; set; }
        public string? Visuel { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public ICollection<Atelier> Ateliers { get; set; } = default!;
    }
}