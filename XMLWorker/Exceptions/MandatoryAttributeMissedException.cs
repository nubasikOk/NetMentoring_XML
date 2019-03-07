using System;
using System.Runtime.Serialization;

namespace XMLWorker.Exceptions
{
    [Serializable]
    public class MandatoryAttributeMissedException : XMLWorkerSystemException
    {
        public MandatoryAttributeMissedException()
        {
        }

        public MandatoryAttributeMissedException(string message) : base(message)
        {
        }

        public MandatoryAttributeMissedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MandatoryAttributeMissedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
