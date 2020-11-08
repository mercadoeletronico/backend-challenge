using System.Linq;
using System.Threading.Tasks;

using BackendChallenge.Application.UseCases;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackendChallenge.AcceptanceTests.UseCases
{
    [TestClass]
    public class ListarPedidoTest : AcceptanceTestBase
    {
        [TestMethod]
        public async Task Quando_Listar_Pedidos_Deve_Retornar_Pedidos()
        {
            // Arrange
            var command = new ListarPedidos { };

            // Act
            var pedidos = await SendAsync(command);

            // Assert
            Assert.IsTrue(pedidos.Any());
        }
    }
}
