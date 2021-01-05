using Microsoft.EntityFrameworkCore;
using Pedido.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Infra.Repository
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        private readonly PedidoDbContext _pedidoDbContext;

        public PedidoRepository(PedidoDbContext context) : base(context)
        {
            _pedidoDbContext = context;
        }

        public Boolean AddAsync(Domain.Models.Pedido pedido)
        {

            _pedidoDbContext.Add(pedido);
            _pedidoDbContext.SaveChanges();
            return true;

        }

        public async Task<Domain.Models.Pedido> FindByAsync(string numeroPedido)
        {
            return await _context.Pedidos.FindAsync(numeroPedido);
        }


        public async Task<IEnumerable<Domain.Models.Pedido>> ListAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public Boolean Remove(Domain.Models.Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            return true;
        }

        public Boolean Update(Domain.Models.Pedido pedido)
        {

            _context.Pedidos.Update(pedido);
            return true;

        }
    }
}
