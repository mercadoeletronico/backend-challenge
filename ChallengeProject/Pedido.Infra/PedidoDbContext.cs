using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Pedido.Infra
{
    public class PedidoDbContext: DbContext
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Models.Pedido> Pedidos { get; set; }

        public DbSet<Domain.Models.ItemPedido> ItemPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Domain.Models.Pedido>().ToTable("Pedidos");
            builder.Entity<Domain.Models.Pedido>().HasKey(p=> p.Id);
            builder.Entity<Domain.Models.Pedido>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Domain.Models.Pedido>().HasMany(p => p.ItemPedidos)
                .WithOne(p => p.Pedido).HasForeignKey(p => p.IdPedido);


            builder.Entity<Domain.Models.ItemPedido>().ToTable("ItemPedidos");
            builder.Entity<Domain.Models.ItemPedido>().HasKey(p => p.Id);
            builder.Entity<Domain.Models.ItemPedido>().Property(p => p.Descricao).IsRequired();
            builder.Entity<Domain.Models.ItemPedido>().Property(p => p.Quantidade).IsRequired();
            builder.Entity<Domain.Models.ItemPedido>().Property(p => p.PrecoUnitario)
                .IsRequired();

        }
    }
}
