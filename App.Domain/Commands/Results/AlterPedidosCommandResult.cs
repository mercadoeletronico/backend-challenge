using App.Domain.Entities;
using App.Shared.Commands;
using System;
using System.Collections.Generic;

namespace App.Domain.Commands.Results
{
    public class AlterPedidosCommandResult : ICommandResult
    {
        public AlterPedidosCommandResult()
        {
        }

        public AlterPedidosCommandResult(int pedido, string status)
        {
            Pedido = pedido;
            Status = status;
        }

        public int Pedido { get; set; }
        public string Status { get; set; }
    }
}
