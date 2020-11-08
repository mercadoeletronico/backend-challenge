using System.Threading.Tasks;

using BackendChallenge.Application.UseCases;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace BackendChallenge.AcceptanceTests.UseCases
{
    [TestClass]
    public class AdicionarPedidoTest : AcceptanceTestBase
    {
        [DataTestMethod]
        [DataRow("{ 'pedido':'123456', 'itens': [ { 'descricao': 'Item A', 'precoUnitario': 10, 'qtd': 1 }, { 'descricao': 'Item B', 'precoUnitario': 5, 'qtd': 2 } ] }")]
        public async Task Quando_Adicionar_Pedido_Deve_Existir_Pedido(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<AdicionarPedido>(json);

            // Act
            await SendAsync(command);

            var pedido = await SendAsync(new ProcurarPedido { Pedido = command.Pedido });

            // Assert
            Assert.AreEqual(command.Pedido, pedido.Pedido);
        }
    }
}
