using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MercadoEletronico.Challenge.UnitTests.MercadoEletronico.Challenge.Domain.Services
{
    public class PedidoDomainService
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

            repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(pedido);

            // Act

            // Assert
        }
    }
}
