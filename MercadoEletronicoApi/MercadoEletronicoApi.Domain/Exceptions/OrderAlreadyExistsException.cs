using System;

namespace MercadoEletronicoApi.Domain.Exceptions
{
    public class OrderAlreadyExistsException : Exception
    {
        private const string OrderCodeAlreadyExists = "Order code already exists.";

        public OrderAlreadyExistsException() : this(OrderCodeAlreadyExists)
        {
        }

        public OrderAlreadyExistsException(string message, Exception innerException = null) : base(message ?? OrderCodeAlreadyExists,
            innerException)
        {
        }

        public static void When(bool condition, string message = null, Exception innerException = null) 
        {
            if (condition)
                throw new OrderAlreadyExistsException(message, innerException);
        }
    }
}
