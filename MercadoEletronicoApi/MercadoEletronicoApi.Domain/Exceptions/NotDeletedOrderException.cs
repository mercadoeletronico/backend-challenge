using System;

namespace MercadoEletronicoApi.Domain.Exceptions
{
    public class NotDeletedOrderException : Exception
    {
        private const string OrderNotDeleted = "Order could not be deleted.";

        public NotDeletedOrderException() : this(OrderNotDeleted)
        {
        }

        public NotDeletedOrderException(string message, Exception innerException = null) : base(message ?? OrderNotDeleted,
            innerException)
        {
        }

        public static void When(bool condition, string message = null, Exception innerException = null)
        {
            if (condition)
                throw new NotDeletedOrderException(message, innerException);
        }
    }
}
