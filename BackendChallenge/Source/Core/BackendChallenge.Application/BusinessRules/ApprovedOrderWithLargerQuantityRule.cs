using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class ApprovedOrderWithLargerQuantityRule : IRule
    {
        private readonly Order _order;

        private readonly OrderStatus _orderStatus;

        public ApprovedOrderWithLargerQuantityRule(Order order, OrderStatus orderStatus)
        {
            _order = order;

            _orderStatus = orderStatus;
        }

        public string Validate()
            => _orderStatus.Status == Status.APROVADO &&
               _orderStatus.ApprovedQuantity > (_order?.CalculateTotalOrderItemQuantity() ?? 0)
                ? Status.APROVADO_QTD_A_MAIOR.ToString()
                : string.Empty;
    }
}
