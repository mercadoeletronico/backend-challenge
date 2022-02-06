using MercadoEletronicoApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Application.Interfaces
{
    public interface IItemService
    {
        Task<IList<ItemDTO>> GetItemsAsync();
        Task<ItemDTO> GetItemByIdAsync(int id);

        Task<ItemDTO> CreateItemAsync(ItemDTO pedido);
        Task<ItemDTO> UpdateItemAsync(ItemDTO pedido);
        Task<ItemDTO> RemoveItemAsync(ItemDTO pedido);
    }
}
