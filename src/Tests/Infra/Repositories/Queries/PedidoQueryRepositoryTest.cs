using System.Collections.Generic;
using AutoFixture;
using Domain.Commands;
using Domain.Entities;
using Infra.Repositories;
using Infra.Repositories.Queries;
using Tests.Customization;
using Xunit;

namespace Tests.Infra.Repositories.Queries
{
    public class PedidoQueryRepositoryTest
    {
        public IFixture _fixture { get; set; }

        public PedidoQueryRepositoryTest()
        {
            this._fixture = new Fixture().Customize(new AutoPopulatedNSubstitutePropertiesCustomization());

        }


        [Fact]
        public void ListarPedidoSucesso()
        {
             var command = new PedidoCommand("123", new List<PedidoItens>{
                new PedidoItens{
                    Descricao ="qwe",
                    PrecoUnitario=12,
                    Quantidade= 2
                }
            });

            var pedidoCommandRepository = _fixture.Create<PedidoCommandRepository>();

            pedidoCommandRepository.CadastrarPedido(command);

            var pedidoQueryRepository = _fixture.Create<PedidoQueryRepository>();

            pedidoQueryRepository.ListarPedido();
            Assert.False(pedidoQueryRepository.HasNotifications);
        }

         [Fact]
        public void RemoverPedidoSucesso()
        {
             var command = new PedidoCommand("123", new List<PedidoItens>{
                new PedidoItens{
                    Descricao ="qwe",
                    PrecoUnitario=12,
                    Quantidade= 2
                }
            });

            var pedidoCommandRepository = _fixture.Create<PedidoCommandRepository>();

            pedidoCommandRepository.CadastrarPedido(command);

            var pedidoQueryRepository = _fixture.Create<PedidoQueryRepository>();

            pedidoQueryRepository.RemoverPedido("123");
            Assert.False(pedidoQueryRepository.HasNotifications);
        }
         [Fact]
        public void ListarByIDPedidoSucesso()
        {
             var command = new PedidoCommand("123", new List<PedidoItens>{
                new PedidoItens{
                    Descricao ="qwe",
                    PrecoUnitario=12,
                    Quantidade= 2
                }
            });

            var pedidoCommandRepository = _fixture.Create<PedidoCommandRepository>();

            pedidoCommandRepository.CadastrarPedido(command);

            var pedidoQueryRepository = _fixture.Create<PedidoQueryRepository>();

            pedidoQueryRepository.ListarPedidoByID("123");
            Assert.False(pedidoQueryRepository.HasNotifications);
        }
    }
}