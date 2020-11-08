using MercadoEletronico.Utilities.Data;
using Microsoft.EntityFrameworkCore;

namespace PedidosME.Data.Repositories
{
    public class DefaultRepository<T> : GenericRepository<T> where T : class
    {
        public DefaultRepository(DbContext context) : base(context)
        {
            context.Database.EnsureCreated();
        }
    }
}
