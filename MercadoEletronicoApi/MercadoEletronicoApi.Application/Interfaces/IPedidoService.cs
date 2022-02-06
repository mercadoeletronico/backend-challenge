using MercadoEletronicoApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<IList<PedidoDTO>> GetPedidosAsync();
        Task<PedidoDTO> GetPedidoByIdAsync(int id);

        Task<PedidoDTO> CreatePedidoAsync(PedidoDTO pedido);
        Task<PedidoDTO> UpdatePedidoAsync(PedidoDTO pedido);
        Task<PedidoDTO> RemovePedidoAsync(int id);
    }
}
