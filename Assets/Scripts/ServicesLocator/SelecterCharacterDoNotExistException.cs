using System;
using System.Runtime.Serialization;
namespace ServiceLocator
{
    [Serializable]
    internal class SelecterCharacterDoNotExistException : Exception
    {
        public SelecterCharacterDoNotExistException()
        {
        }

        public SelecterCharacterDoNotExistException(string message) : base(message)
        {
        }

        public SelecterCharacterDoNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SelecterCharacterDoNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}