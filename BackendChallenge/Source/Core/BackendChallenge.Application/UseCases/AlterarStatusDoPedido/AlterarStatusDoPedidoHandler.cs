using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BackendChallenge.Application.Extensions;
using BackendChallenge.Application.Validators;
using BackendChallenge.Entities;
using BackendChallenge.Ports.Adapters.Database;
using BackendChallenge.Ports.Application.BusinessRules;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class AlterarStatusDoPedidoHandler : IRequestHandler<AlterarStatusDoPedido, StatusDoPedido>
    {
        private readonly IDataStoreUnitOfWork _unitOfWork;

        public AlterarStatusDoPedidoHandler(IDataStoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StatusDoPedido> Handle(AlterarStatusDoPedido request, CancellationToken cancellationToken)
        {
            OrderStatus orderStatus = AlterarStatusDoPedido.ConvertTo(request);

            Order order = _unitOfWork.Orders.Get().FirstOrDefault(f => f.Number == request.Pedido);

            IEnumerable<IRule> rules = new List<IRule>()
            {
                new InvalidOrderNumberRule(orderStatus),
                new DisapprovedOrderRule(orderStatus),
                new ApprovedOrderRule(order, orderStatus),
                new ApprovedOrderWithLargerQuantityRule(order, orderStatus),
                new ApprovedOrderWithHigherValueRule(order, orderStatus),
                new ApprovedOrderWithSmallerQuantityRule(order, orderStatus),
                new ApprovedOrderWithLowerValueRule(order, orderStatus)
            };

            return await Task.FromResult(new StatusDoPedido
            {
                Pedido = request.Pedido.AsNumberOrZero().ToString(),
                Status = ValidateRules(rules).ToList()
            });

            static IEnumerable<string> ValidateRules(IEnumerable<IRule> rules)
            {
                foreach (var rule in rules)
                {
                    var message = rule.Validate();

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        yield return message;
                    }
                }
            }
        }
    }
}
