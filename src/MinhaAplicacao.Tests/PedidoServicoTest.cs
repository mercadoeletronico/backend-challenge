using AutoMoqCore;
using Castle.Components.DictionaryAdapter;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao.Negocio.Services;
using System.Threading.Tasks;
using Xunit;

namespace MinhaAplicacao.Tests
{
    public class PedidoServicoTest
    {
        private readonly AutoMoqer _mocker;
        private readonly IPedidoServico _pedidoServico;

        public PedidoServicoTest()
        {
            //var minhaAplicacaoDbContext = new MinhaAplicacaoDbContext(new DbContextOptionsBuilder<MinhaAplicacaoDbContext>().UseSqlServer("DefaultConnection").Options);
            //var unitOfWork = new UnitOfWork(minhaAplicacaoDbContext);
            //var pedidoRepositorio = new PedidoRepositorio(minhaAplicacaoDbContext);
            //this._pedidoServico = new PedidoServico(unitOfWork, pedidoRepositorio);

            this._mocker = new AutoMoqer();
            this._pedidoServico = this._mocker.Create<PedidoServico>();
        }

        [Fact(DisplayName = "#1")]
        public async Task Teste1()
        {
            // Arrange
            var statusPedido = new StatusPedido
            {
                Status = "APROVADO",
                ItensAprovados = 3,
                ValorAprovado = 20,
                Pedido = "123456"
            };

            // Act
            var retorno = await this._pedidoServico.ValidarPedido(statusPedido);

            // Assert
            Assert.Equal(retorno.Status, new EditableList<string> { "APROVADO" });
            //Assert.Equal(retorno, new RetornoStatusPedido { Pedido = "123456", Status = new EditableList<string> { "REPROVADO" } });
            //Assert.Equal(retorno, new RetornoStatusPedido { Pedido = "123456", Status = new EditableList<string> { "APROVADO_QTD_A_MENOR" } });
            //Assert.Equal(retorno, new RetornoStatusPedido { Pedido = "123456", Status = new EditableList<string> { "APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MAIOR" } });
            //Assert.Equal(retorno, new RetornoStatusPedido { Pedido = "123456", Status = new EditableList<string> { "APROVADO_VALOR_A_MENOR" } });
        }

        [Fact(DisplayName = "#2")]
        public async Task Teste2()
        {
            // Arrange
            var statusPedido = new StatusPedido
            {
                Status = "APROVADO",
                ItensAprovados = 3,
                ValorAprovado = 10,
                Pedido = "123456"
            };

            // Act
            var retorno = await this._pedidoServico.ValidarPedido(statusPedido);

            // Assert
            Assert.Equal(retorno.Status, new EditableList<string> { "APROVADO_VALOR_A_MENOR" });
        }

        [Fact(DisplayName = "#3")]
        //[InlineData("APROVADO", 2, 20, "123456")]
        //[InlineData("REPROVADO", 0, 0, "123456")]
        public async Task Teste3()
        {
            // Arrange
            var statusPedido = new StatusPedido
            {
                Status = "APROVADO",
                ItensAprovados = 4,
                ValorAprovado = 21,
                Pedido = "123456"
            };

            // Act
            var retorno = await this._pedidoServico.ValidarPedido(statusPedido);

            // Assert
            Assert.Equal(retorno.Status, new EditableList<string> { "APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MAIOR" });
        }

        [Fact(DisplayName = "#4")]
        //[InlineData("REPROVADO", 0, 0, "123456")]
        public async Task Teste4()
        {
            // Arrange
            var statusPedido = new StatusPedido
            {
                Status = "APROVADO",
                ItensAprovados = 2,
                ValorAprovado = 20,
                Pedido = "123456"
            };

            // Act
            var retorno = await this._pedidoServico.ValidarPedido(statusPedido);

            // Assert
            Assert.Equal(retorno.Status, new EditableList<string> { "APROVADO_QTD_A_MENOR" });
        }

        [Fact(DisplayName = "#5")]
        //[InlineData("REPROVADO", 0, 0, "123456")]
        public async Task Teste5()
        {
            // Arrange
            var statusPedido = new StatusPedido
            {
                Status = "REPROVADO",
                ItensAprovados = 0,
                ValorAprovado = 0,
                Pedido = "123456"
            };

            // Act
            var retorno = await this._pedidoServico.ValidarPedido(statusPedido);

            // Assert
            Assert.Equal(retorno.Status, new EditableList<string> { "REPROVADO" });
        }

        [Fact(DisplayName = "#6")]
        public async Task Teste6()
        {
            // Arrange
            var statusPedido = new StatusPedido
            {
                Status = "APROVADO",
                ItensAprovados = 3,
                ValorAprovado = 20,
                Pedido = "123456-N"
            };

            // Act
            var retorno = await this._pedidoServico.ValidarPedido(statusPedido);

            // Assert
            Assert.Equal(retorno.Status, new EditableList<string> { "CODIGO_PEDIDO_INVALIDO" });
        }
    }
}
