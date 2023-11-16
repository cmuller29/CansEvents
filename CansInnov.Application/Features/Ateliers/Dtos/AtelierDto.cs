using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CansInnov.Application.Features.Ateliers.Dtos
{
    public class AtelierDto : BaseAtelier
    {
        public List<string> Participants { get; set; }
    }
}