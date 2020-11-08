using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class ApprovedOrderRule : IRule
    {
        private readonly Order _order;

        private readonly OrderStatus _orderStatus;

        public ApprovedOrderRule(Order order, OrderStatus orderStatus)
        {
            _order = order;

            _orderStatus = orderStatus;
        }

        public string Validate()
            => _orderStatus.Status == Status.APROVADO &&
               _orderStatus.ApprovedQuantity == (_order?.CalculateTotalOrderItemQuantity() ?? 0) &&
               _orderStatus.ApprovedPrice == (_order?.CalculateTotalOrderAmount() ?? 0)
                ? Status.APROVADO.ToString()
                : string.Empty;
    }
}
