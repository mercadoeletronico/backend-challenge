using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using BackendChallenge.Adapters.Database;
using BackendChallenge.Application.UseCases;
using BackendChallenge.Entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace BackendChallenge.AcceptanceTests.UseCases
{
    [TestClass]
    public class AltearStatusDoPedidoTest : AcceptanceTestBase
    {
        [TestInitialize]
        public void DataSeed()
        {
            var context = (DataStoreContext)_provider.GetService(typeof(DataStoreContext));

            DataSeeder.SeedOrders(context);
        }

        [DataTestMethod]
        [DataRow("{ 'status':'APROVADO', 'itensAprovados': 3, 'valorAprovado': 20, 'pedido':'123456-N' }")]
        public async Task Quando_Codigo_Peido_Nao_Numerico_Deve_Retornar_Codigo_Pedido_Invalido(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<AlterarStatusDoPedido>(json);

            // Act
            var result = await SendAsync(command);

            // Assert
            Assert.AreEqual("123456", result.Pedido);
            Assert.IsTrue(result.Status.Contains(Status.CODIGO_PEDIDO_INVALIDO.ToString()));
        }

        [DataTestMethod]
        [DataRow("{ 'status':'REPROVADO', 'itensAprovados': 0, 'valorAprovado': 0, 'pedido':'123456' }")]
        public async Task Quando_Reprovado_Deve_Retornar_Reprovado(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<AlterarStatusDoPedido>(json);

            // Act
            var result = await SendAsync(command);

            // Assert
            Assert.IsTrue(result.Status.Contains(Status.REPROVADO.ToString()));
        }

        [DataTestMethod]
        [DataRow("{ 'status':'APROVADO', 'itensAprovados': 3, 'valorAprovado': 10, 'pedido':'123456' }")]
        public async Task Quando_Aprovado_Qtd_Igual_Valor_Menor_Deve_Retornar_Aprovado_Valor_A_Menor(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<AlterarStatusDoPedido>(json);

            // Act
            var result = await SendAsync(command);

            // Assert
            Assert.IsTrue(result.Status.Contains(Status.APROVADO_VALOR_A_MENOR.ToString()));
        }

        [DataTestMethod]
        [DataRow("{ 'status':'APROVADO', 'itensAprovados': 2, 'valorAprovado': 20, 'pedido':'123456' }")]
        public async Task Quando_Aprovado_Qtd_Menor_Valor_Igual_Deve_Retornar_Aprovado_Qtd_A_Menor(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<AlterarStatusDoPedido>(json);

            // Act
            var result = await SendAsync(command);

            // Assert
            Assert.IsTrue(result.Status.Contains(Status.APROVADO_QTD_A_MENOR.ToString()));
        }

        [DataTestMethod]
        [DataRow("{ 'status':'APROVADO', 'itensAprovados': 3, 'valorAprovado': 20, 'pedido':'123456' }")]
        public async Task Quando_Aprovado_Qtd_Igual_Valor_Igual_Deve_Retornar_Aprovado(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<AlterarStatusDoPedido>(json);

            // Act
            var result = await SendAsync(command);

            // Assert
            Assert.IsTrue(result.Status.Contains(Status.APROVADO.ToString()));
            Debug.AutoFlush = true;
            Debug.Print("Passei por aqui ¬");
            Debug.Print(string.Join(',', result.Status));
        }

        [DataTestMethod]
        [DataRow("{ 'status':'APROVADO', 'itensAprovados': 4, 'valorAprovado': 21, 'pedido':'123456' }")]
        public async Task Quando_Aprovado_Qtd_Maior_Valor_Maior_Deve_Retornar_Aprovado_Qtd_A_Maior_Aprovado_Valor_A_Maior(string json)
        {
            // Arrange
            var command = JsonConvert.DeserializeObject<AlterarStatusDoPedido>(json);

            // Act
            var result = await SendAsync(command);

            // Assert
            Assert.IsTrue(result.Status.Contains(Status.APROVADO_QTD_A_MAIOR.ToString()));
            Assert.IsTrue(result.Status.Contains(Status.APROVADO_VALOR_A_MAIOR.ToString()));
            Debug.AutoFlush = true;
            Debug.Print(string.Join(',', result.Status));
        }
    }
}
