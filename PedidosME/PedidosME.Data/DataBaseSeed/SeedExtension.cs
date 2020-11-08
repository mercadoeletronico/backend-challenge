using Microsoft.EntityFrameworkCore;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Data.DataBaseSeed
{
    public static class SeedExtension
    {
        public static ModelBuilder SeedProduto(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pedido>()
                .HasData(
                    Pedido.Criar("987354"),
                    Pedido.Criar("ABCDEF"),
                    Pedido.Criar("123456"));
                
            modelBuilder.Entity<ItemPedido>()
                .HasData(
                ItemPedido.Criar("987354", "Produto 1", 2.5f, 3),
                ItemPedido.Criar("987354", "Produto 2", 3, 2),
                ItemPedido.Criar("987354", "Produto 3", 0.99f, 4.4f),
                ItemPedido.Criar("ABCDEF", "Monitor", 399.99f, 3),
                ItemPedido.Criar("ABCDEF", "Processador", 429.38f, 2),
                ItemPedido.Criar("ABCDEF", "Pasta Isolante", 0.49f, 1.4f),
                ItemPedido.Criar("123456", "Produto 1", 10, 1),
                ItemPedido.Criar("123456", "Produto 2", 5, 1),
                ItemPedido.Criar("123456", "Produto 2", 5, 1)

                );
            return modelBuilder;
        }
    }
}

