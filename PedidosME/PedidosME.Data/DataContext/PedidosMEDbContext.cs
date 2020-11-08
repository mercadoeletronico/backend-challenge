using Microsoft.EntityFrameworkCore;
using PedidosME.Data.DataBaseSeed;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Data.DataContext
{
    public class PedidosMEDbContext : DbContext
    {
        public DbSet<Pedido> Pedidos {get;set;}
        public DbSet<ItemPedido> ItemPedido { get; set; }

        public PedidosMEDbContext(DbContextOptions options) : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidosMEDbContext).Assembly);
            modelBuilder.SeedProduto();
            
        }
    }
}
