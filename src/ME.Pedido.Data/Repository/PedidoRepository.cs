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

        
        public Domain.Pedido Adicionar(Domain.Pedido pedido)
        {
            if (!VerificarSePedidoExiste(pedido.PedidoID))
            {
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
                return pedido;
            }

            return null;
        }

        public Domain.Pedido Alterar(Domain.Pedido pedido)
        {
            if (VerificarSePedidoExiste(pedido.PedidoID))
            {
                Remover(pedido);
                Adicionar(pedido);
                return pedido;
            }

            return null;
        }

        public void AlterarStatus(Domain.Pedido pedido)
        {
            var p = _context.Pedidos.Include(u => u.PedidoItems)
                .FirstOrDefaultAsync(i => i.PedidoID == pedido.PedidoID).Result;
            p.Status = pedido.Status;
            _context.SaveChanges();

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

        public int Remover(Domain.Pedido pedido)
        {
            if (VerificarSePedidoExiste(pedido.PedidoID)){
                var p = _context.Pedidos.Include(u => u.PedidoItems).Single(a => a.PedidoID == pedido.PedidoID);
                foreach (var i in p.PedidoItems)
                {
                    var r = _context.Remove(i);
                    //_context.SaveChanges();
                }
                _context.Remove(p);
                return _context.SaveChanges();
            }

            return 0;
        }
        public bool VerificarSePedidoExiste(string pedidoId)
        {
            try
            {
                var p = _context.Pedidos
                    .FirstOrDefaultAsync(i => i.PedidoID == pedidoId).Result;
                return p != null;

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
