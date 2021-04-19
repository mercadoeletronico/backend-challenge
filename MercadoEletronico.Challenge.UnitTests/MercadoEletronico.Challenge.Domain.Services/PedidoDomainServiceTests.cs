using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Models.Enums;
using MercadoEletronico.Challenge.Domain.Models.Requests;
using MercadoEletronico.Challenge.Domain.Services.Implementations;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using MercadoEletronico.Challenge.Util.Extensions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MercadoEletronico.Challenge.UnitTests.MercadoEletronico.Challenge.Domain.Services
{
    public class PedidoDomainServiceTests
    {
        [Fact]
        public async Task Aprovar_MustReturnAprovadoWhenQuantityAndValueMatch() 
        {
            // Arrange
            const string pedidoId = "ABC";

            Pedido pedido = CreatePedidoMock(pedidoId);

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

        [Fact]
        public async Task Aprovar_MustReturnAprovadoValorMenorWhenQuantityMatchesAndValueIsLower()
        {
            // Arrange
            const string pedidoId = "ABC";

            Pedido pedido = CreatePedidoMock(pedidoId);

            var repositoryMock = new Mock<IPedidoRepository>();

            var request = new StatusRequest
            {
                Pedido = pedidoId,
                Status = StatusAprovacao.Aprovado.GetDescription(),
                ItensAprovados = 3,
                ValorAprovado = 23
            };

            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(pedido);
            var service = new PedidoDomainService(repositoryMock.Object);

            // Act
            var response = await service.AprovarPedido(request);

            // Assert
            Assert.Equal(pedidoId, response.Pedido);
            Assert.Single(response.Status);
            Assert.Contains(response.Status, status => status == StatusAprovacao.AprovadoValorMenor.GetDescription());
        }

        [Fact]
        public async Task Aprovar_MustReturnAprovadoValorMaiorWhenQuantityMatchesAndValueIsHigher()
        {
            // Arrange
            const string pedidoId = "ABC";

            Pedido pedido = CreatePedidoMock(pedidoId);

            var repositoryMock = new Mock<IPedidoRepository>();

            var request = new StatusRequest
            {
                Pedido = pedidoId,
                Status = StatusAprovacao.Aprovado.GetDescription(),
                ItensAprovados = 3,
                ValorAprovado = 37
            };

            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(pedido);
            var service = new PedidoDomainService(repositoryMock.Object);

            // Act
            var response = await service.AprovarPedido(request);

            // Assert
            Assert.Equal(pedidoId, response.Pedido);
            Assert.Single(response.Status);
            Assert.Contains(response.Status, status => status == StatusAprovacao.AprovadoValorMaior.GetDescription());
        }

        [Fact]
        public async Task Aprovar_MustReturnAprovadoQuantidadeMenorWhenValueMatchesAndQuantityIsLower()
        {
            // Arrange
            const string pedidoId = "ABC";

            Pedido pedido = CreatePedidoMock(pedidoId);

            var repositoryMock = new Mock<IPedidoRepository>();

            var request = new StatusRequest
            {
                Pedido = pedidoId,
                Status = StatusAprovacao.Aprovado.GetDescription(),
                ItensAprovados = 2,
                ValorAprovado = 25
            };

            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(pedido);
            var service = new PedidoDomainService(repositoryMock.Object);

            // Act
            var response = await service.AprovarPedido(request);

            // Assert
            Assert.Equal(pedidoId, response.Pedido);
            Assert.Single(response.Status);
            Assert.Contains(response.Status, status => status == StatusAprovacao.AprovadoQuantidadeMenor.GetDescription());
        }

        [Fact]
        public async Task Aprovar_MustReturnAprovadoQuantidadeMenorWhenValueMatchesAndQuantityIsHigher()
        {
            // Arrange
            const string pedidoId = "ABC";

            Pedido pedido = CreatePedidoMock(pedidoId);

            var repositoryMock = new Mock<IPedidoRepository>();

            var request = new StatusRequest
            {
                Pedido = pedidoId,
                Status = StatusAprovacao.Aprovado.GetDescription(),
                ItensAprovados = 5,
                ValorAprovado = 25
            };

            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(pedido);
            var service = new PedidoDomainService(repositoryMock.Object);

            // Act
            var response = await service.AprovarPedido(request);

            // Assert
            Assert.Equal(pedidoId, response.Pedido);
            Assert.Single(response.Status);
            Assert.Contains(response.Status, status => status == StatusAprovacao.AprovadoQuantidadeMaior.GetDescription());
        }

        [Fact]
        public async Task Aprovar_MustReturnAprovadoQuantidadeMaiorValorMaiorWhenBothAreHigher()
        {
            // Arrange
            const string pedidoId = "ABC";

            Pedido pedido = CreatePedidoMock(pedidoId);

            var repositoryMock = new Mock<IPedidoRepository>();

            var request = new StatusRequest
            {
                Pedido = pedidoId,
                Status = StatusAprovacao.Aprovado.GetDescription(),
                ItensAprovados = 5,
                ValorAprovado = 30
            };

            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(pedido);
            var service = new PedidoDomainService(repositoryMock.Object);

            // Act
            var response = await service.AprovarPedido(request);

            // Assert
            Assert.Equal(pedidoId, response.Pedido);
            Assert.Equal(2, response.Status.Count);
            Assert.Contains(response.Status, status => status == StatusAprovacao.AprovadoValorMaior.GetDescription());
            Assert.Contains(response.Status, status => status == StatusAprovacao.AprovadoQuantidadeMaior.GetDescription());
        }

        [Fact]
        public async Task Aprovar_MustReturnAprovadoQuantidadeMenorValorMenorWhenBothAreLower()
        {
            // Arrange
            const string pedidoId = "ABC";

            Pedido pedido = CreatePedidoMock(pedidoId);

            var repositoryMock = new Mock<IPedidoRepository>();

            var request = new StatusRequest
            {
                Pedido = pedidoId,
                Status = StatusAprovacao.Aprovado.GetDescription(),
                ItensAprovados = 2,
                ValorAprovado = 11
            };

            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(pedido);
            var service = new PedidoDomainService(repositoryMock.Object);

            // Act
            var response = await service.AprovarPedido(request);

            // Assert
            Assert.Equal(pedidoId, response.Pedido);
            Assert.Equal(2, response.Status.Count);
            Assert.Contains(response.Status, status => status == StatusAprovacao.AprovadoValorMenor.GetDescription());
            Assert.Contains(response.Status, status => status == StatusAprovacao.AprovadoQuantidadeMenor.GetDescription());
        }

        private static Pedido CreatePedidoMock(string pedidoId)
        {
            return new Pedido
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
        }
    }
}
