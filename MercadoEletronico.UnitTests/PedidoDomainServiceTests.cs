using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Extensions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MercadoEletronico.UnitTests
{
    public class PedidoDomainServiceTests
    {
        [Fact]
        public async Task Aprovar_MustReturnPedidoNotFound()
        {
            // Arrange
            const int idPedido = 1;

            Domain.Entities.Pedido pedido = CreatePedidoMock(idPedido);
            Domain.Requests.PedidoRequest pedidoRequest = CreatePedidoRequestMock(idPedido);

            Domain.Requests.StatusRequest request = new Domain.Requests.StatusRequest
            {
                Pedido = idPedido,
                Status = Domain.Enums.StatusAprovacao.Aprovado.GetDescription(),
                ItensAprovados = 3,
                ValorAprovado = 25
            };

            Mock<Business.Interfaces.INotificador> notificadorMock = new Mock<Business.Interfaces.INotificador>();
            Mock<AutoMapper.IMapper> mapperMock = new Mock<AutoMapper.IMapper>();
            Mock<DataAccess.Context> contextMock = new Mock<DataAccess.Context>();
            Mock<Business.Services.Entities.PedidoService> pedidoServiceMok = new Mock<Business.Services.Entities.PedidoService>();

            pedidoServiceMok.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(pedidoRequest);
            Business.Services.Entities.PedidoService pedidoService = new Business.Services.Entities.PedidoService(notificadorMock.Object, mapperMock.Object);

            // Act
            Domain.Responses.StatusResponse response = await pedidoService.AprovarPedido(request);

            // Assert
            Assert.Equal(idPedido, response.Pedido);
            Assert.Single(response.Status);
            Assert.Contains(response.Status, status => status == Domain.Enums.StatusAprovacao.PedidoInvalido.GetDescription());
        }

        private static Domain.Requests.PedidoRequest CreatePedidoRequestMock(int idPedido)
        {
            return new Domain.Requests.PedidoRequest
            {
                Pedido = idPedido,
                Itens = new List<Domain.Requests.PedidoItemRequest>
                {
                    new()
                    {
                        Id = 1,
                        PrecoUnitario = 10,
                        Qtd = 2
                    },
                    new()
                    {
                        Id = 2,
                        PrecoUnitario = 5,
                        Qtd = 1
                    }
                }
            };
        }

        private static Domain.Entities.Pedido CreatePedidoMock(int idPedido)
        {
            return new Domain.Entities.Pedido
            {
                Id = idPedido,
                Itens = new List<Domain.Entities.PedidoItem>
                {
                    new()
                    {
                        Id = 1,
                        IdPedido = idPedido,
                        PrecoUnitario = 10,
                        Qtd = 2
                    },
                    new()
                    {
                        Id = 2,
                        IdPedido = idPedido,
                        PrecoUnitario = 5,
                        Qtd = 1
                    }
                }
            };
        }
    }
}
