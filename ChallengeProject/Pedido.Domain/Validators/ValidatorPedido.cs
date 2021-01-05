using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Domain.Validators
{
    public class ValidatorPedido: Validator<Models.Pedido>
    {
        public ValidatorPedido()
        {
            Add("NumeroPedidoIsNotNullOrWhiteSpace", new Rule<Models.Pedido>(new NumeroPedidoIsNotNullOrWhiteSpace(), "Numero de pedido invalido"));
            Add("ItensIsNotNullOrEmtpy", new Rule<Models.Pedido>(new ItensIsNotNullOrEmpty(), "Um pedido precisa conter ao menos um item"));
        }
    }
}
