using App.Domain.Entities;
using App.Shared.Commands;
using System.Collections.Generic;

namespace App.Domain.Commands.Inputs
{
    public class RegisterPedidosCommand : ICommand
    {
        public int Pedido { get; set; }
        public ICollection<ItensPedido> Itens { get; set; }
    }

}
