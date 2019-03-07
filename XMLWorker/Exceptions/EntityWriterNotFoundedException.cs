using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XMLWorker.Exceptions
{
    [Serializable]
    public class EntityWriterNotFoundedException: XMLWorkerSystemException
    {
        public EntityWriterNotFoundedException()
        {
        }

        public EntityWriterNotFoundedException(string message) : base(message)
        {
        }

        public EntityWriterNotFoundedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityWriterNotFoundedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
