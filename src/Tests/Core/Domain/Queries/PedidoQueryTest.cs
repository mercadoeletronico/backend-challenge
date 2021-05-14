using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using NSubstitute;
using Tests.Customization;
using Xunit;

namespace Tests.Core.Domain.Queries
{
    public class PedidoQueryTest
    {
        public IFixture _fixture { get; set; }

        public PedidoQueryTest()
        {
            this._fixture = new Fixture().Customize(new AutoPopulatedNSubstitutePropertiesCustomization());

        }


        [Fact]
        public void VerificarStatusPedidoComRetornoAprovado()
        {

            var pedidoResponse = new Pedido
            {
                NumeroPedido = "123456",
                PedidoItens = new List<PedidoItens> {
                    new PedidoItens{
                        Descricao = "Item A",
                        PrecoUnitario = 10,
                        Quantidade = 1
                    },
                     new PedidoItens{
                        Descricao = "Item B",
                        PrecoUnitario = 5,
                        Quantidade = 2
                    }
                 }
            };

            var pedidoQueryRepository = Substitute.For<IPedidoQueryRepository>();
            pedidoQueryRepository.ListarPedidoByID(Arg.Any<string>()).Returns(pedidoResponse);

            _fixture.Register(() => pedidoQueryRepository);
            var pedidoQuery = _fixture.Create<PedidoQuey>();
            var response = pedidoQuery.VerificarStatusPedido("APROVADO", 3, 20, "123456");




            Assert.True(response.Status.FirstOrDefault() == "APROVADO");
        }


        [Fact]
        public void VerificarStatusPedidoComRetornoAprovadoValorMenor()
        {

            var pedidoResponse = new Pedido
            {
                NumeroPedido = "123456",
                PedidoItens = new List<PedidoItens> {
                    new PedidoItens{
                        Descricao = "Item A",
                        PrecoUnitario = 10,
                        Quantidade = 1
                    },
                     new PedidoItens{
                        Descricao = "Item B",
                        PrecoUnitario = 5,
                        Quantidade = 2
                    }
                 }
            };

            var pedidoQueryRepository = Substitute.For<IPedidoQueryRepository>();
            pedidoQueryRepository.ListarPedidoByID(Arg.Any<string>()).Returns(pedidoResponse);

            _fixture.Register(() => pedidoQueryRepository);
            var pedidoQuery = _fixture.Create<PedidoQuey>();
            var response = pedidoQuery.VerificarStatusPedido("APROVADO", 3, 10, "123456");




            Assert.True(response.Status.FirstOrDefault() == "APROVADO_VALOR_A_MENOR");
        }
        [Fact]
        public void VerificarStatusPedidoComRetornoAprovadoValorMaiorEQuantidadeMaior()
        {

            var pedidoResponse = new Pedido
            {
                NumeroPedido = "123456",
                PedidoItens = new List<PedidoItens> {
                    new PedidoItens{
                        Descricao = "Item A",
                        PrecoUnitario = 10,
                        Quantidade = 1
                    },
                     new PedidoItens{
                        Descricao = "Item B",
                        PrecoUnitario = 5,
                        Quantidade = 2
                    }
                 }
            };

            var pedidoQueryRepository = Substitute.For<IPedidoQueryRepository>();
            pedidoQueryRepository.ListarPedidoByID(Arg.Any<string>()).Returns(pedidoResponse);

            _fixture.Register(() => pedidoQueryRepository);
            var pedidoQuery = _fixture.Create<PedidoQuey>();
            var response = pedidoQuery.VerificarStatusPedido("APROVADO", 4, 21, "123456");

            Assert.True(response.Status.Contains("APROVADO_VALOR_A_MAIOR") && response.Status.Contains("APROVADO_QTD_A_MAIOR"));
        }

        [Fact]
        public void VerificarStatusPedidoComRetornoAprovadoQtdMenor()
        {

            var pedidoResponse = new Pedido
            {
                NumeroPedido = "123456",
                PedidoItens = new List<PedidoItens> {
                    new PedidoItens{
                        Descricao = "Item A",
                        PrecoUnitario = 10,
                        Quantidade = 1
                    },
                     new PedidoItens{
                        Descricao = "Item B",
                        PrecoUnitario = 5,
                        Quantidade = 2
                    }
                 }
            };

            var pedidoQueryRepository = Substitute.For<IPedidoQueryRepository>();
            pedidoQueryRepository.ListarPedidoByID(Arg.Any<string>()).Returns(pedidoResponse);

            _fixture.Register(() => pedidoQueryRepository);
            var pedidoQuery = _fixture.Create<PedidoQuey>();
            var response = pedidoQuery.VerificarStatusPedido("APROVADO", 2, 20, "123456");

            Assert.True(response.Status.Contains("APROVADO_QTD_A_MENOR"));
        }

        [Fact]
        public void VerificarStatusPedidoComRetornoReprovado()
        {

            var pedidoResponse = new Pedido
            {
                NumeroPedido = "123456",
                PedidoItens = new List<PedidoItens> {
                    new PedidoItens{
                        Descricao = "Item A",
                        PrecoUnitario = 10,
                        Quantidade = 1
                    },
                     new PedidoItens{
                        Descricao = "Item B",
                        PrecoUnitario = 5,
                        Quantidade = 2
                    }
                 }
            };

            var pedidoQueryRepository = Substitute.For<IPedidoQueryRepository>();
            pedidoQueryRepository.ListarPedidoByID(Arg.Any<string>()).Returns(pedidoResponse);

            _fixture.Register(() => pedidoQueryRepository);
            var pedidoQuery = _fixture.Create<PedidoQuey>();
            var response = pedidoQuery.VerificarStatusPedido("REPROVADO", 0, 0, "123456");

            Assert.True(response.Status.Contains("REPROVADO"));
        }

        [Fact]
        public void VerificarStatusPedidoComRetornoCodigoInvalido()
        {

            var pedidoResponse = new Pedido();
            var pedidoQueryRepository = Substitute.For<IPedidoQueryRepository>();
            pedidoQueryRepository.ListarPedidoByID(Arg.Any<string>()).Returns(pedidoResponse);

            _fixture.Register(() => pedidoQueryRepository);
            var pedidoQuery = _fixture.Create<PedidoQuey>();
            var response = pedidoQuery.VerificarStatusPedido("APROVADO", 3, 20, "123456-N");

            Assert.True(response.Status.Contains("CODIGO_PEDIDO_INVALIDO"));
        }
    }
}