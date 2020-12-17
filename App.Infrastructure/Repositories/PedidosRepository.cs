using App.Domain.Entities;
using App.Domain.Repositories;
using App.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace App.Infrastructure.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly ApplicationContext _context;

        public PedidosRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Save(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Update(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
        }

    }
}
