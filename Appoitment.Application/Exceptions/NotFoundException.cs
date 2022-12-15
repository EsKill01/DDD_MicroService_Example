using System;

namespace Appoitment.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key) : base($"Property\"{name}\"({key}) was nor found.")
        {
        }
    }
}