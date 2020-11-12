using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class ApprovedOrderRule : IRule
    {
        public string Validate(Order order)
            => order?.OrderStatus?.Status == Status.APROVADO &&
               order?.OrderStatus?.ApprovedQuantity == (order?.CalculateTotalOrderItemQuantity() ?? 0) &&
               order?.OrderStatus?.ApprovedPrice == (order?.CalculateTotalOrderAmount() ?? 0)
                ? Status.APROVADO.ToString()
                : string.Empty;
    }
}
