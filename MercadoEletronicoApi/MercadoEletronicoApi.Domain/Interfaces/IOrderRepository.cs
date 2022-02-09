using MercadoEletronicoApi.Domain.Entities;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Domain.Interfaces
{
    public interface IOrderRepository : IInterfaceBase<Order>
    {
        Task<Order> GetOrderByOrderCodeAsync(string codPedido);
    }

}
