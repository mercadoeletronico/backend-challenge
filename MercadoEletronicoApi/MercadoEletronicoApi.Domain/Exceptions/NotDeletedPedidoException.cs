using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Domain.Exceptions
{
    public class NotDeletedPedidoException : Exception
    {
        private const string OrderNotDeleted = "PEDIDO_NAO_DELETADO";

        public NotDeletedPedidoException() : this(OrderNotDeleted)
        {
        }

        public NotDeletedPedidoException(string message, Exception innerException = null) : base(message ?? OrderNotDeleted,
            innerException)
        {
        }

        public static void When(bool condition, string message = null, Exception innerException = null)
        {
            if (condition)
                throw new NotDeletedPedidoException(message, innerException);
        }
    }
}
