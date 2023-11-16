using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CansInnov.Application.Exceptions
{
    public class CansEventException : Exception
    {
        public CansEventException()
        {
        }

        public CansEventException(string? message) : base(message)
        {
        }

        public CansEventException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CansEventException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}