using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Domain.Validators
{
    public class ItensIsNotNullOrEmpty : ISpecification<Models.Pedido>
    {
        public bool IsSatisfiedBy(Models.Pedido entity)
        {
            return entity.ItemPedidos?.Count > 0;
        }
    }
}
