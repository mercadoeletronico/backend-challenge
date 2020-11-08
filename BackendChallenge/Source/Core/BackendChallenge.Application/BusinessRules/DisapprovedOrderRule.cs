
using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class DisapprovedOrderRule : IRule
    {
        private readonly OrderStatus _orderStatus;

        public DisapprovedOrderRule(OrderStatus orderStatus)
        {
            _orderStatus = orderStatus;
        }

        public string Validate()
        {
            return _orderStatus.Status == Status.REPROVADO 
                ? Status.REPROVADO.ToString()
                : string.Empty;
        }
    }
}
