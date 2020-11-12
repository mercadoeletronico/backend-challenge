using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class InvalidOrderNumberRule : IRule
    {
        public string Validate(Order order)
            => int.TryParse(order?.OrderStatus?.OrderNumber ?? "", out int _)
                ? string.Empty
                : Status.CODIGO_PEDIDO_INVALIDO.ToString();
    }
}
