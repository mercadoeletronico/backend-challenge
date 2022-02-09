using System;

namespace MercadoEletronicoApi.Domain.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string error) : base(error)
        {
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new OrderException(error);
        }
    }
}
