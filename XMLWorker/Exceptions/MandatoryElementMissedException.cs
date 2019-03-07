using System;
using System.Runtime.Serialization;


namespace XMLWorker.Exceptions
{
    public class MandatoryElementMissedException:XMLWorkerSystemException
    {
        public MandatoryElementMissedException()
        {
        }

        public MandatoryElementMissedException(string message) : base(message)
        {
        }

        public MandatoryElementMissedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MandatoryElementMissedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
