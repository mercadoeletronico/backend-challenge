using MercadoEletronico.Challenge.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MercadoEletronico.Challenge.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
