using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XMLWorker.Exceptions
{
    [Serializable]
    public class UnknownElementException: XMLWorkerSystemException
    {
        public UnknownElementException()
        {
        }

        public UnknownElementException(string message) : base(message)
        {
        }

        public UnknownElementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownElementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
