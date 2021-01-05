using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Domain.Validators
{
    public class NumeroPedidoIsNotNullOrWhiteSpace : ISpecification<Models.Pedido>
    {
        public bool IsSatisfiedBy(Models.Pedido pedido)
        {
            return !string.IsNullOrWhiteSpace(pedido.NumeroPedido);
        }
    }
}
