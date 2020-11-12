using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BackendChallenge.Application.Extensions;
using BackendChallenge.Entities;
using BackendChallenge.Ports.Adapters.Database;
using BackendChallenge.Ports.Application.BusinessRules;

using MediatR;

namespace BackendChallenge.Application.UseCases
{
    public class AlterarStatusDoPedidoHandler : IRequestHandler<AlterarStatusDoPedido, StatusDoPedido>
    {
        private readonly IDataStoreUnitOfWork _unitOfWork;

        private readonly IEnumerable<IRule> _rules;

        public AlterarStatusDoPedidoHandler(IDataStoreUnitOfWork unitOfWork, IEnumerable<IRule> rules)
        {
            _unitOfWork = unitOfWork;

            _rules = rules;
        }

        public async Task<StatusDoPedido> Handle(AlterarStatusDoPedido request, CancellationToken cancellationToken)
        {
            Order order = _unitOfWork.Orders.Get().FirstOrDefault(f => f.Number == request.Pedido);

            if (order != null)
            {
                order.OrderStatus = AlterarStatusDoPedido.ConvertTo(request);
            }

            return await Task.FromResult(new StatusDoPedido
            {
                Pedido = request.Pedido.AsNumberOrZero().ToString(),
                Status = ValidateRules(order).ToList()
            });

            IEnumerable<string> ValidateRules(Order order)
            {
                foreach (var rule in _rules)
                {
                    var message = rule.Validate(order);

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        yield return message;
                    }
                }
            }
        }
    }
}
