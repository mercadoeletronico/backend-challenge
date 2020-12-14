using ME.Api.Models.DataModels;
using ME.Api.Settings.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {

        }


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            MEDataBase eNexoDataBase = MESettings.GetDataBase(MEProjects.Api);
            switch (eNexoDataBase)
            {
                case MEDataBase.SqlLite:
                    optionsBuilder.UseSqlite(MESettings.GetConnectionString(MEProjects.Api));
                    break;

            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);


            model.Entity<Pedido>()
             .ToTable("Pedido");


            model.Entity<ItemPedido>()
             .ToTable("ItemPedido");


            model.Entity<ItemPedido>()
             .HasOne<Pedido>(x => x.Pedido)
             .WithMany(x => x.Itens)
             .HasForeignKey(x => x.PedidoId);


            model.Entity<Pedido>().HasData(
                        new Pedido { Id = 1, NumPedido = "123456" }
                );


            model.Entity<ItemPedido>().HasData(
                      new ItemPedido
                      {
                          Id = 1,
                          Descricao = "Item A",
                          PrecoUnitario = 10,
                          Quantidade = 1,
                          PedidoId = 1
                      }
              );


            model.Entity<ItemPedido>().HasData(
                      new ItemPedido
                      {
                          Id = 2,
                          Descricao = "Item B",
                          PrecoUnitario = 5,
                          Quantidade = 2,
                          PedidoId = 1
                      }
              );
        }


    }
}
