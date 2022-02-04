using MercadoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MercadoEletronico.DataAccess
{
    public class Context : DbContext
    {
        public Context() : base() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<PedidoItem> PedidoItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().Property(o => o.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<PedidoItem>().Property(o => o.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MercadoEletronicoDB");
        }
    }
}