using MercadoEletronicoApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Domain.Interfaces 
{
    public interface IItemRepository : IInterfaceBase<Item>
    {
        Task<IEnumerable<Item>> GetItemsByIdPedidoAsync(int pedidoId);
    }

}
