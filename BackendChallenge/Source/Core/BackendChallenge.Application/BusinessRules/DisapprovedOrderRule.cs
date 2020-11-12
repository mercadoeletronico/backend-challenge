using BackendChallenge.Entities;
using BackendChallenge.Ports.Application.BusinessRules;

namespace BackendChallenge.Application.Validators
{
    public class DisapprovedOrderRule : IRule
    {
        public string Validate(Order order)
        {
            return order?.OrderStatus?.Status == Status.REPROVADO 
                ? Status.REPROVADO.ToString()
                : string.Empty;
        }
    }
}
