using MercadoEletronicoApi.Domain.Entities;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Domain.Interfaces
{
    public interface IPedidoRepository : IInterfaceBase<Pedido>
    {
        Task<Pedido> GetOrderByOrderCodeAsync(string codPedido);
    }

}
