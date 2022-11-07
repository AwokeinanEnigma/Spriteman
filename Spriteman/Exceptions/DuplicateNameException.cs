using System;

namespace Spriteman.Exceptions
{
    public class DuplicateNameException : Exception
    {
        public override string Message => this.message;
        public DuplicateNameException()
        {
            this.message = "Multiple sprite definitions cannot have the same name.";
        }
        public DuplicateNameException(string message) : base(message)
        {
            this.message = message;
        }
        public DuplicateNameException(string message, Exception inner) : base(message, inner)
        {
            this.message = message;
        }
        private readonly string message;
    }
}
