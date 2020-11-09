using System;
using System.Runtime.Serialization;

[Serializable]
internal class PersonajeElegidoNoExisteException : Exception
{
    public PersonajeElegidoNoExisteException()
    {
    }

    public PersonajeElegidoNoExisteException(string message) : base(message)
    {
    }

    public PersonajeElegidoNoExisteException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected PersonajeElegidoNoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}