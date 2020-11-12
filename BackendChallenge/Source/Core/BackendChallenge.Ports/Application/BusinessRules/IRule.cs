using BackendChallenge.Entities;

namespace BackendChallenge.Ports.Application.BusinessRules
{
    public interface IRule
    {
        string Validate(Order order);
    }
}
