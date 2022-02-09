using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Domain.Interfaces;
using MercadoEletronicoApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MercadoEletronicoDbContext _context;

        public OrderRepository(MercadoEletronicoDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Order>> GetAsync()
        {
            var pedidos = await _context.Pedidos
                .Include(i => i.Items)
                .ToListAsync();

            return pedidos;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);

            return pedido;
        }

        public async Task<Order> GetOrderByOrderCodeAsync(string codPedido) 
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.OrderCode == codPedido);

            return pedido;
        }

        public async Task<Order> CreateAsync(Order pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task<Order> UpdateAsync(Order pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task<Order> RemoveAsync(Order pedido)
        {
            try
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();

                return pedido;

            }
            catch (Exception ex)
            {

                throw;
            }
            

            
        }

    }

}
