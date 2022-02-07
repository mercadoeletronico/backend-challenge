using System;

namespace MercadoEletronicoApi.Domain.Exceptions
{
    public class NotFoundPedidoException : Exception
    {
        private const string InvalidOrderCode = "CODIGO_PEDIDO_INVALIDO";

        public NotFoundPedidoException() : this(InvalidOrderCode)
        {
        }

        public NotFoundPedidoException(string message, Exception innerException = null) : base(message ?? InvalidOrderCode,
            innerException)
        {
        }

        public static void When(bool condition, string message = null, Exception innerException = null)
        {
            if (condition)
                throw new NotFoundPedidoException(message, innerException);
        }

    }
}
