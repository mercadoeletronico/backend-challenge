using System;

namespace ORDER.Domain.Exceptions
{
    public class RequestNotValid : Exception
    {
        private const string DefaultMessage = "Request not valid";


        public RequestNotValid() : this(DefaultMessage)
        {
        }

        public RequestNotValid(string message, Exception innerException = null) : base(message ?? DefaultMessage,
            innerException)
        {
        }

        public static void When(bool condition, string message, Exception innerException = null)
        {
            if (condition)
                throw new RequestNotValid(message, innerException);
        }
    }
}