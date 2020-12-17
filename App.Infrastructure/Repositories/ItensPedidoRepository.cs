using App.Domain.Repositories;
using App.Infrastructure.Contexts;

namespace App.Infrastructure.Repositories
{
    public class ItensPedidoRepository : IItensPedidoRepository
    {
        private readonly ApplicationContext _context;

        public ItensPedidoRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
