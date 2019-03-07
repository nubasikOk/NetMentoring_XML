using System;
using System.Runtime.Serialization;


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
