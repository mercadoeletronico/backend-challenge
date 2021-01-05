using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Domain.Services
{
    public interface IStatusService
    {
        Task<Models.PedidoStatusResponse> MudarSituacaoPedido(Models.PedidoStatusRequest status);
    }
}
