using MercadoEletronico.Utilities.Data;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.Domain.Entities.PedidoAggregate
{
    public interface IPedidoRepository 
    {
        Task<Pedido> AlterarStatusPedidoAsync(string codigoPedido,CancellationToken cancellationToken);
        Task<Pedido> ObterPedidoPorCodigo(string codigoPedido, CancellationToken cancellationToken);
    }
}
