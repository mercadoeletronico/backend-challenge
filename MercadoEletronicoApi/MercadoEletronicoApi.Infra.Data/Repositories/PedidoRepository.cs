using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Domain.Interfaces;
using MercadoEletronicoApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MercadoEletronicoDbContext _context;

        public PedidoRepository(MercadoEletronicoDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Pedido>> GetAsync()
        {
            var pedidos = await _context.Pedidos
                .Include(i => i.Items)
                .ToListAsync();

            return pedidos;
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);

            return pedido;
        }

        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task<Pedido> UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task<Pedido> RemoveAsync(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

    }

}
