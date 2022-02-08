using MercadoEletronicoApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<IList<PedidoDTO>> GetOrderAsync();
        Task<PedidoDTO> GetOrderByIdAsync(int id);
        Task<PedidoDTO> GetOrderByOrderCodeAsync(string codPedido);
        Task<PedidoDTO> CreateOrderAsync(PedidoDTO pedido);
        Task<PedidoDTO> UpdateOrderAsync(PedidoDTO pedido);
        Task<PedidoDTO> RemoveOrderAsync(string codPedido);
    }
}
