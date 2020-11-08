using System.Collections.Generic;
using System.Threading.Tasks;

using BackendChallenge.Application.UseCases;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace BackendChallenge.AcceptanceTests.UseCases
{
    [TestClass]
    public class RemoverPedidoTest : AcceptanceTestBase
    {
        [DataTestMethod]
        [DataRow("{ 'pedido':'123456' }")]
        [ExpectedException(typeof(KeyNotFoundException))]
        public async Task Quando_Remover_Pedido_Deve_Nao_Encontrar_Pedido(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<RemoverPedido>(json);

            // Act
            await SendAsync(command);

            // Assert
            await SendAsync(new ProcurarPedido { Pedido = command.Pedido });
        }
    }
}
