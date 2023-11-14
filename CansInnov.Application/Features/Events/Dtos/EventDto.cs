using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CansInnov.Application.Features.Events.Dtos
{
    public class EventDto : BaseEvent
    {
        public Guid Id { get; set; }
    }
}