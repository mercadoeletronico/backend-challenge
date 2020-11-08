using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.Domain.Services
{
    public interface IPedidoServices
    {
        Task<Pedido> ObterPedido(string codigoPedido, CancellationToken cancellationToken);
        Task<StatusPedidoDTO> DefinirStatusPedido(AtualizarStatusDTO atualizarStatusDTO, 
            CancellationToken cancellationToken);
    }
}
