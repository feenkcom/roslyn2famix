using System;
using System.Runtime.Serialization;

namespace Fame
{
    [Serializable]
    internal class ClassNotMetadescribedException : Exception
    {
        public ClassNotMetadescribedException()
        {
        }

        public ClassNotMetadescribedException(string message) : base(message)
        {
        }

        public ClassNotMetadescribedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClassNotMetadescribedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}