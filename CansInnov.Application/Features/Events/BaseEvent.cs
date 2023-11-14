using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CansInnov.Application.Features.Events
{
    public abstract class BaseEvent
    {
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Visuel { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }
}