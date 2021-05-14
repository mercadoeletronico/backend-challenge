using System.Collections.Generic;
using System.Net.Http;
using AutoFixture;
using Domain.Commands;
using Domain.Entities;
using Infra.BD;
using Infra.Repositories;
using NSubstitute;
using Tests.Customization;
using Xunit;

namespace Tests.Infra.Repositories
{
    public class PedidoCommandRepositoryTest
    {
        public IFixture _fixture { get; set; }

        public PedidoCommandRepositoryTest()
        {
            this._fixture = new Fixture().Customize(new AutoPopulatedNSubstitutePropertiesCustomization());

        }

        [Fact]
        public void CadastrarPedidoSucesso()
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
            Assert.False(pedidoCommandRepository.HasNotifications);
        }

        [Fact]
        public void AlterarPedidoSucesso()
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
            pedidoCommandRepository.AtualizarPedido(command);
            Assert.False(pedidoCommandRepository.HasNotifications);
        }
      
    }
}