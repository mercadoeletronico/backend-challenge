using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Application.Services
{
    public class ItemService : IItemService
    {
        public Task<IList<ItemDTO>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemDTO> GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDTO> CreateItemAsync(ItemDTO pedido)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDTO> UpdateItemAsync(ItemDTO pedido)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDTO> RemoveItemAsync(ItemDTO pedido)
        {
            throw new NotImplementedException();
        }

    }
}
