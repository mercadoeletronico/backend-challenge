using API;
using Core.Helpers;
using Core.Models.Requests.Pedido;
using Core.Models.Responses.Pedido;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class PedidoTest 
    {
        #region properties
        private readonly TestServer _server;
        private readonly HttpClient _client;
        #endregion

        #region constructors
        public PedidoTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        #endregion

        #region
        [Fact]
        public async Task TestGetPedidoAsync()
        {
            // Act
            var response = await _client.GetAsync("/api/pedido");

            // Assert
            response.EnsureSuccessStatusCode();
        }
       
        [Fact]
        public async Task TestPostPedidoAsync()
        {
            // Arrange
            string url = "/api/pedido";
            SavePedidoRequest request = new SavePedidoRequest
            {
               Codigo = "123",
               Itens = new System.Collections.Generic.List<SaveItemRequest>()
            };
            request.Itens.Add(new SaveItemRequest { Descricao = "123", Quantidade = 1, PrecoUnitario = 1 });

            // Act
            var response = await _client.PostAsync(url, ContentHelper.GetStringContent(request));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutPedidoAsync()
        {
            // Arrange
            string url = "/api/pedido";
            SavePedidoRequest requestPost = new SavePedidoRequest
            {
                Codigo = "1234",
                Itens = new System.Collections.Generic.List<SaveItemRequest>()
            };
            requestPost.Itens.Add(new SaveItemRequest { Descricao = "1234", Quantidade = 1, PrecoUnitario = 1 });

            SavePedidoRequest requestPut = new SavePedidoRequest
            {
                Codigo = "1234",
                Itens = new System.Collections.Generic.List<SaveItemRequest>()
            };
            requestPut.Itens.Add(new SaveItemRequest { Descricao = "1111", Quantidade = 5, PrecoUnitario = 5 });

            // Act
            var postResponse = await _client.PostAsync(url, ContentHelper.GetStringContent(requestPost));

            var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<Result<PedidoResponse>>(jsonFromPostResponse);

            var putResponse = await _client.PutAsync(string.Format(url + "/{0}", singleResponse.Value.Pedido), ContentHelper.GetStringContent(requestPut));

            // Assert
            putResponse.EnsureSuccessStatusCode();
            postResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestDeletePedidoAsync()
        {
            // Arrange
            string url = "/api/pedido";
            SavePedidoRequest request = new SavePedidoRequest
            {
                Codigo = "000000",
                Itens = new System.Collections.Generic.List<SaveItemRequest>()
            };
            request.Itens.Add(new SaveItemRequest { Descricao = "1234", Quantidade = 1, PrecoUnitario = 1 });

            // Act
            var postResponse = await _client.PostAsync(url, ContentHelper.GetStringContent(request));
            
            var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();
            var singleResponse = JsonConvert.DeserializeObject<Result<PedidoResponse>>(jsonFromPostResponse);

            var deleteResponse = await _client.DeleteAsync(string.Format(url+"/{0}", singleResponse.Value.Pedido));

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
            postResponse.EnsureSuccessStatusCode();
            
        }
        #endregion
    }
}

