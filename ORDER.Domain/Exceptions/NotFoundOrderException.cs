using System;

namespace ORDER.Domain.Exceptions
{
    public class NotFoundOrderException : Exception
    {
        private const string DefaultMessage = "Order not found";


        public NotFoundOrderException() : this(DefaultMessage)
        {
        }

        public NotFoundOrderException(string message, Exception innerException = null) : base(message ?? DefaultMessage,
            innerException)
        {
        }

        public static void When(bool condition, string message = null, Exception innerException = null)
        {
            if (condition)
                throw new NotFoundOrderException(message, innerException);
        }
    }
}