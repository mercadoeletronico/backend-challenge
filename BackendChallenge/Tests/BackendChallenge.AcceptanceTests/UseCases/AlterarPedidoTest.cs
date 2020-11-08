using System.Linq;
using System.Threading.Tasks;

using BackendChallenge.Application.UseCases;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace BackendChallenge.AcceptanceTests.UseCases
{
    [TestClass]
    public class AlterarPedidoTest : AcceptanceTestBase
    {
        [DataTestMethod]
        [DataRow("{ 'pedido':'123456', 'itens': [ { 'descricao': 'Item A', 'precoUnitario': 10, 'qtd': 1 }, { 'descricao': 'Item B', 'precoUnitario': 5, 'qtd': 2 }, { 'descricao': 'Item C', 'precoUnitario': 1, 'qtd': 15 } ] }")]
        public async Task Quando_Alterar_Pedido_Deve_Refletir_Alteracao(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<AlterarPedido>(json);

            // Act
            await SendAsync(command);

            var pedido = await SendAsync(new ProcurarPedido { Pedido = command.Pedido });

            // Assert
            Assert.AreEqual(command.Pedido, pedido.Pedido);
            Assert.AreEqual(3, pedido.Itens.Count());
        }
    }
}
