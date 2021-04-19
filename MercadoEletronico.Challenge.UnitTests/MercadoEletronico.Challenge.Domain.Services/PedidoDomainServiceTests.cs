using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Models.Enums;
using MercadoEletronico.Challenge.Domain.Models.Requests;
using MercadoEletronico.Challenge.Domain.Services.Implementations;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using MercadoEletronico.Challenge.Util.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MercadoEletronico.Challenge.UnitTests.MercadoEletronico.Challenge.Domain.Services
{
    public class PedidoDomainServiceTests
    {
        [Fact]
        public async Task Aprovar() 
        {
            // Arrange
            const string pedidoId = "ABC";

            var pedido = new Pedido 
            { 
                Id = pedidoId,
                Itens = new List<PedidoItem> 
                {
                    new()
                    { 
                        PedidoId = pedidoId,
                        Id = "1",
                        PrecoUnitario = 10,
                        Qtd = 2
                    },
                    new()
                    {
                        PedidoId = pedidoId,
                        Id = "2",
                        PrecoUnitario = 5,
                        Qtd = 1
                    }
                }
            };
            var repositoryMock = new Mock<IPedidoRepository>();

            var request = new StatusRequest 
            { 
                Pedido = pedidoId,
                Status = StatusAprovacao.Aprovado.GetDescription(),
                ItensAprovados = 3,
                ValorAprovado = 25
            };

            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(pedido);
            var service = new PedidoDomainService(repositoryMock.Object);

            // Act
            var response = await service.AprovarPedido(request);

            // Assert
            Assert.Equal(pedidoId, response.Pedido);
            Assert.Single(response.Status);
            Assert.Contains(response.Status, status => status == StatusAprovacao.Aprovado.GetDescription());
        }
    }
}
