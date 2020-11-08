using System.Threading.Tasks;

using BackendChallenge.Application.UseCases;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace BackendChallenge.AcceptanceTests.UseCases
{
    [TestClass]
    public class ProcurarPedidoTest : AcceptanceTestBase
    {
        [DataTestMethod]
        [DataRow("{ 'pedido':'123456' }")]
        public async Task Quando_Procurar_Pedido_Deve_Retornar_Pedido(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<ProcurarPedido>(json);

            // Act
            var pedido = await SendAsync(command);

            // Assert
            Assert.AreEqual(command.Pedido, pedido.Pedido);
        }
    }
}
