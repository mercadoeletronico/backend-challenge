using App.Domain.Entities;
using App.Shared.Commands;
using System.Collections.Generic;

namespace App.Domain.Commands.Inputs
{
    public class AlterPedidosCommand : ICommand
    {
        public int Pedido { get; set; }
        public string Status { get; set; } //EU poderia ter usado um Enum, para ficar mais elegante, mas, devido ao tempo, não pus.
        public decimal ValorAprovado { get; set; }
        public int ItensAprovado { get; set; }
    }

}

