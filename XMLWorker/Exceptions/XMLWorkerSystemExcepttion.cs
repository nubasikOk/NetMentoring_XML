using System;
using System.Runtime.Serialization;

namespace XMLWorker.Exceptions
{
    [Serializable]
    public class XMLWorkerSystemException : Exception
    {
        public XMLWorkerSystemException()
        {
        }

        public XMLWorkerSystemException(string message) : base(message)
        {
        }

        public XMLWorkerSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected XMLWorkerSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
