using Microsoft.EntityFrameworkCore;
using Me.Api.Models;

namespace Me.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }
    }
}

