using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Controllers;
using Api.Models.Request;
using AutoFixture;
using Domain.CommandHandler;
using Domain.Commands;
using Domain.Entities;
using Domain.Notifications;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Tests.Customization;
using Xunit;
using models =Api.Models.Request;
namespace Tests.UI.Controllers
{
    public class PedidosControllerTest
    {
        public IFixture Fixture { get; set; }
        public PedidosControllerTest()
        {
            this.Fixture = new Fixture()
                                   .Customize(new ControllerCustomization())
                                   .Customize(new AutoPopulatedNSubstitutePropertiesCustomization());

        }

        [Fact]
        public void CadastrarPedidoComSucesso()
        {
            var command = new PedidoCommand("123456", new List<PedidoItens> { new PedidoItens { Descricao = "AB", PrecoUnitario = 1, Quantidade = 2 } });

            var request = new PedidosRequest { Itens = new List<ItensPedido> { new ItensPedido { Descricao = "AB", PrecoUnitario = 1, Qtd = 2 } }, Pedido = "123456" };
            var handler = Substitute.For<CommandHandler<PedidoCommand, bool>>();
            handler.Handle(command).Returns(true);
            Fixture.Register(() => handler);

            var controller = Fixture.Build<PedidosController>().OmitAutoProperties().Create();
            var response = controller.CadastrarPedido(request).Result as CreatedResult;
            Assert.Null(response);

        }

        [Fact]
        public void AtualizarPedidoComSucesso()
        {
            var command = new PedidoCommand("123456", new List<PedidoItens> { new PedidoItens { Descricao = "AB", PrecoUnitario = 1, Quantidade = 2 } });

            var request = new PedidosRequest { Itens = new List<ItensPedido> { new ItensPedido { Descricao = "AB", PrecoUnitario = 1, Qtd = 2 } }, Pedido = "123456" };
            var handler = Substitute.For<CommandHandler<PedidoCommand, bool>>();
            handler.Handle(command).Returns(true);
            Fixture.Register(() => handler);

            var controller = Fixture.Build<PedidosController>().OmitAutoProperties().Create();
            var response = controller.AtualizarPedido(request).Result as OkResult;
            Assert.Null(response);

        }

        [Fact]
        public async void ListarPedidoComSucesso()
        {
            var pedidoList = new List<Pedido>{
                new Pedido{
                    NumeroPedido = "123456",
                    PedidoItens = new List<PedidoItens>{
                        new PedidoItens{
                        Descricao = "ab",
                        PrecoUnitario =1,
                        Quantidade =2
                    }
                    }
                }
            };
            var pedidoQuery = Substitute.For<IPedidoQuery>();
            pedidoQuery.ListarPedido().Returns(pedidoList);

            Fixture.Register(() => pedidoQuery);

            var controller = Fixture.Build<PedidosController>().OmitAutoProperties().Create();
            var response = controller.ListarPedido();

            Assert.NotNull(response.Result);

        }

        [Fact]
        public void RemoverPedidoComSucesso()
        {
            var pedidoQuery = Substitute.For<IPedidoQuery>();
            pedidoQuery.RemoverPedido("1234");

            Fixture.Register(() => pedidoQuery);

            var controller = Fixture.Build<PedidosController>().OmitAutoProperties().Create();
            var response = controller.RemoverPedido("1234");

            Assert.NotNull(response.Result);

        }
        [Fact]
        public void VerifcarStatusPedidoComSucesso()
        {
            var pedido = new models.StatusPedido{
                    ItensAprovados = 2,
                    Pedido = "123456",
                    Status = "APROVADO",
                    ValorAprovado =1
            };
            var pedidoQuery = Substitute.For<IPedidoQuery>();
            pedidoQuery.VerificarStatusPedido("1234",1,2,"APROVADO");

            Fixture.Register(() => pedidoQuery);

            var controller = Fixture.Build<PedidosController>().OmitAutoProperties().Create();
            var response = controller.VerificarPedido(pedido);

            Assert.NotNull(response.Result);

        }
    }
}