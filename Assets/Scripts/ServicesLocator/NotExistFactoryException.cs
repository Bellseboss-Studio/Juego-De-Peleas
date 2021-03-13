using System;
using System.Runtime.Serialization;

namespace ServiceLocator
{
    [Serializable]
    internal class NotExistFactoryException : Exception
    {
        public NotExistFactoryException()
        {
        }

        public NotExistFactoryException(string message) : base(message)
        {
        }

        public NotExistFactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotExistFactoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}