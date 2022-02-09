using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_me.Models;
using teste_me.Repository.Context;

namespace teste_me.Repository
{
    public class PedidoRepository : IRepository<Pedido>
    {
        private readonly MEContext _context;
        public PedidoRepository(MEContext context)
        {
            _context = context;
        }
        public async Task<Pedido> GetPedido(int id)
        {
            return await _context.Pedidos.Include(p => p.Itens).Where(p => p.ID == id).FirstOrDefaultAsync();
        }
        public async Task<List<Pedido>> GetPedidos()
        {
            return await _context.Pedidos.Include(p => p.Itens).ToListAsync();
        }
        public async Task<Pedido> UpdatePedido(int pedidoID, Pedido pedido)
        {
            try
            {
                var pedidoCadastrado = await _context.Pedidos.Include(p => p.Itens).Where(p => p.ID == pedidoID).FirstOrDefaultAsync();
                if (pedidoCadastrado != null)
                {
                    pedidoCadastrado.Itens = pedido.Itens;
                    _context.Entry(pedidoCadastrado).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return pedidoCadastrado;

                }
                else
                {
                    return pedido = null;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }
        public async Task<Pedido> CreatePedido(Pedido novoPedido)
        {
            try
            {
                _context.Pedidos.Add(novoPedido);
                await _context.SaveChangesAsync();
                return novoPedido;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeletePedido(int pedidoID)
        {
            try
            {
                var pedido = await _context.Pedidos.FindAsync(pedidoID);
                if (pedido != null)
                {
                    _context.Pedidos.Remove(pedido);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
