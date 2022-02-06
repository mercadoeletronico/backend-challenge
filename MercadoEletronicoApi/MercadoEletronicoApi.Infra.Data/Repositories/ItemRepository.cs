using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Domain.Interfaces;
using MercadoEletronicoApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly MercadoEletronicoDbContext _context;

        public ItemRepository(MercadoEletronicoDbContext context)
        {
            _context = context;
        }


        public async Task<IList<Item>> GetAsync()
        {
            var itens = await _context.Itens.ToListAsync();

            return itens;
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            var item = await _context.Itens.FirstOrDefaultAsync(i => i.Id == id);

            return item;
        }

        public Task<IEnumerable<Item>> GetItemsByIdPedidoAsync(int pedidoId)
        {
            //Todo: implementar.
            throw new NotImplementedException();
        }

        public async Task<Item> CreateAsync(Item item)
        {
            _context.Itens.Add(item);
            await _context.SaveChangesAsync();
            
            return item;
        }

        public async Task<Item> UpdateAsync(Item item)
        {
            _context.Itens.Update(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<Item> RemoveAsync(Item item)
        {
            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }
      
    }

}
