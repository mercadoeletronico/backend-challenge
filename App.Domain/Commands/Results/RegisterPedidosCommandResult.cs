using App.Domain.Entities;
using App.Shared.Commands;
using System;
using System.Collections.Generic;

namespace App.Domain.Commands.Results
{
    public class RegisterPedidosCommandResult : ICommandResult
    {
        public RegisterPedidosCommandResult()
        {
            ItensPedido = new List<ItensPedido>();
        }

        public RegisterPedidosCommandResult(int pedido, ICollection<ItensPedido> itensPedido)
        {
            Pedido = pedido;
            ItensPedido = itensPedido;
        }

        public int Pedido { get; set; }
        public ICollection<ItensPedido> ItensPedido { get; set; }
    }
}
