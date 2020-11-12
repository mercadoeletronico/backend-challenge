using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class ApprovedOrderWithLargerQuantityRule : IRule
    {
        public string Validate(Order order)
            => order?.OrderStatus?.Status == Status.APROVADO &&
               order?.OrderStatus?.ApprovedQuantity > (order?.CalculateTotalOrderItemQuantity() ?? 0)
                ? Status.APROVADO_QTD_A_MAIOR.ToString()
                : string.Empty;
    }
}
