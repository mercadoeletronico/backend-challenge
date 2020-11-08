using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class ApprovedOrderWithSmallerQuantityRule : IRule
    {
        private readonly Order _order;

        private readonly OrderStatus _orderStatus;

        public ApprovedOrderWithSmallerQuantityRule(Order order, OrderStatus orderStatus)
        {
            _order = order;

            _orderStatus = orderStatus;
        }

        public string Validate()
            => _orderStatus.Status == Status.APROVADO &&
               _orderStatus.ApprovedQuantity < (_order?.CalculateTotalOrderItemQuantity() ?? 0)
                ? Status.APROVADO_QTD_A_MENOR.ToString()
                : string.Empty;
    }
}
