using System;
using System.Runtime.Serialization;

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
