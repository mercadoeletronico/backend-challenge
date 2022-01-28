using System;

namespace ORDER.Domain.Exceptions
{
    namespace Handel.ZendeskModule.Exceptions
    {
        public class NotDeletedOrderException : Exception
        {
            private const string DefaultMessage = "PEDIDO_NAO_DELETADO";


            public NotDeletedOrderException() : this(DefaultMessage)
            {
            }

            public NotDeletedOrderException(string message, Exception innerException = null) : base(message ?? DefaultMessage,
                innerException)
            {
            }

            public static void When(bool condition, string message, Exception innerException = null)
            {
                if (condition)
                    throw new NotDeletedOrderException(message, innerException);
            }
        }
    }
}