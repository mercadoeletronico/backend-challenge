
using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class ApprovedOrderWithLowerValueRule : IRule
    {
        public string Validate(Order order)
            => order?.OrderStatus?.Status == Status.APROVADO &&
               order?.OrderStatus?.ApprovedPrice < (order?.CalculateTotalOrderAmount() ?? 0)
                ? Status.APROVADO_VALOR_A_MENOR.ToString()
                : string.Empty;
    }
}
