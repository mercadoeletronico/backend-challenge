using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Infrastructure.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "me_pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_me_pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "me_itenspedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    Qtd = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    CodigoPedido = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_me_itenspedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_me_itenspedido_me_pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "me_pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_me_itenspedido_PedidoId",
                table: "me_itenspedido",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "me_itenspedido");

            migrationBuilder.DropTable(
                name: "me_pedido");
        }
    }
}
