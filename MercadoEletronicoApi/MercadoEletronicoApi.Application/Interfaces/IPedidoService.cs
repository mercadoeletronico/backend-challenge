using MercadoEletronicoApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IList<OrderDTO>> GetOrderAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task<OrderDTO> GetOrderByOrderCodeAsync(string codPedido);
        Task<OrderDTO> CreateOrderAsync(OrderDTO pedido);
        Task<OrderDTO> UpdateOrderAsync(OrderDTO pedido);
        Task<OrderDTO> RemoveOrderAsync(string codPedido);
    }
}
