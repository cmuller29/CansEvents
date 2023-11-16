using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CansInnov.Domain.Common
{
    public abstract class EntityWithId
    {
        public Guid Id { get; set; }
    }
}