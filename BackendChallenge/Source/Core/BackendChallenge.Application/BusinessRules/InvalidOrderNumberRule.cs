
using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class InvalidOrderNumberRule : IRule
    {
        private readonly OrderStatus _orderStatus;

        public InvalidOrderNumberRule(OrderStatus orderStatus)
        {
            _orderStatus = orderStatus;
        }

        public string Validate()
            => int.TryParse(_orderStatus.OrderNumber, out int _)
                ? string.Empty
                : Status.CODIGO_PEDIDO_INVALIDO.ToString();
    }
}
