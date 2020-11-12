using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class ApprovedOrderWithHigherValueRule : IRule
    {
        public string Validate(Order order)
            => order?.OrderStatus?.Status == Status.APROVADO &&
               order?.OrderStatus?.ApprovedPrice > (order?.CalculateTotalOrderAmount() ?? 0)
                ? Status.APROVADO_VALOR_A_MAIOR.ToString()
                : string.Empty;
    }
}
