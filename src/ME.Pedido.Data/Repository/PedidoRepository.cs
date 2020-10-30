using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ME.Core.Data;
using ME.Pedido.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ME.Pedido.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MainContext _context;

        public PedidoRepository(MainContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Domain.Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void AlterarStatus(Domain.Pedido pedido)
        {
            var p = _context.Pedidos.Include(u => u.PedidoItems)
                .Single(i => i.PedidoID == pedido.PedidoID); ;
            p.Status = pedido.Status;

            _context.Commit();
        }
        
        public async Task<Domain.Pedido>? ObterPedidoPorId(string pedidoId)
        {
            return await _context.Pedidos.Include(u => u.PedidoItems)
                    .FirstOrDefaultAsync(i => i.PedidoID == pedidoId);
        }

        public async Task<List<Domain.Pedido>> ObterTodos()
        {
            return await _context.Pedidos
                .Include(u => u.PedidoItems)
                .ToListAsync();
        }

        public void Remover(Domain.Pedido pedido)
        {
            _context.Remove(_context.Pedidos.Single(a => a.PedidoID == pedido.PedidoID));
            _context.SaveChanges();
        }
        public async Task<bool> VerificarSePedidoExisteAsync(string pedidoId)
        {
            try
            {
                var p = await _context.Pedidos
                    .FirstOrDefaultAsync(i => i.PedidoID == pedidoId);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
