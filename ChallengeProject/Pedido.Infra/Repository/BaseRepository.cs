using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Infra.Repository
{
    public class BaseRepository
    {
        protected readonly PedidoDbContext _context;

        public BaseRepository(PedidoDbContext context)
        {
            _context = context;
        }
    }
}
