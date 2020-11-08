
using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class ApprovedOrderWithLowerValueRule : IRule
    {
        private readonly Order _order;

        private readonly OrderStatus _orderStatus;

        public ApprovedOrderWithLowerValueRule(Order order, OrderStatus orderStatus)
        {
            _order = order;

            _orderStatus = orderStatus;
        }

        public string Validate()
            => _orderStatus.Status == Status.APROVADO &&
               _orderStatus.ApprovedPrice < (_order?.CalculateTotalOrderAmount() ?? 0)
                ? Status.APROVADO_VALOR_A_MENOR.ToString()
                : string.Empty;
    }
}
