using App.Domain.Entities;
using App.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Contexts
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItensPedido> ItensPedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-A9IB29C\SQLEXPRESS; Database=medatabase; User Id=sa; Password=senhadatabase;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PedidosMap());
            modelBuilder.ApplyConfiguration(new ItensPedidosMap());

        }

    }

}
