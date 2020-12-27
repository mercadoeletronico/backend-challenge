using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;
namespace Infra.Data.Migrations
{
    [Migration(1)]
    public class CreateTablesMigration : Migration
    {
        public override void Up()
        {
            this.CreateTablePedido();
            this.CreateTableItemPedido();
        }

        private void CreateTablePedido()
        {
            this.Create.Table("Pedido")
                .WithColumn("PedidoId").AsInt64().PrimaryKey().Identity()
                .WithColumn("Codigo").AsString(20).NotNullable();

            this.Insert.IntoTable("Pedido")
                .Row(new { Codigo = "123456" });
            this.Insert.IntoTable("Pedido")
                .Row(new { Codigo = "123456" });
        }

        private void CreateTableItemPedido()
        {
            this.Create.Table("ItemPedido")
                .WithColumn("ItemPedidoId").AsInt64().PrimaryKey().Identity()
                .WithColumn("Descricao").AsString(50).NotNullable()
                .WithColumn("PrecoUnitario").AsDecimal(18, 2).NotNullable()
                .WithColumn("Quantidade").AsInt32().NotNullable()
                .WithColumn("PedidoId").AsInt64().ForeignKey("PedidoFk", "Pedido", "PedidoId");

            this.Insert.IntoTable("ItemPedido")
                .Row(new {  Descricao = "Janela", PrecoUnitario = 1.00D, Quantidade =1, PedidoId = 1});
            this.Insert.IntoTable("ItemPedido")
                  .Row(new { Descricao = "Porta", PrecoUnitario = 17.00D, Quantidade = 1, PedidoId = 1 });
            this.Insert.IntoTable("ItemPedido")
                .Row(new { Descricao = "Tomada", PrecoUnitario = 2.00D, Quantidade = 1, PedidoId = 1 });
        }


        public override void Down()
        {
            this.Delete.Table("Pedido");
            this.Delete.Table("ItemPedido");
        }
    }
}

