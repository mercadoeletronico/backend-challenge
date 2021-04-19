using MercadoEletronico.Challenge.Domain.Models.Enums;
using MercadoEletronico.Challenge.Domain.Models.Requests;
using MercadoEletronico.Challenge.Domain.Models.Responses;
using MercadoEletronico.Challenge.Util.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MercadoEletronico.Challenge.IntegrationTests
{
    public class StatusIntegrationTests : IntegrationTestsBase
    {
        public StatusIntegrationTests(WebApplicationFactory<Startup> factory) : base(factory)
        { }

        [Fact]
        public async Task Status_MustReturnPedidoInvalidoWhenPedidoIdIsNotFound()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new StatusRequest
            {
                Pedido = "YYZ",
                Status = StatusAprovacao.Aprovado.GetDescription()
            };

            // Act
            var response = await client.PostAsync("/api/Status", request.ToStringContent());

            var contentStream = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<StatusResponse>(contentStream);

            // Assert
            Assert.Single(deserialized.Status);
            Assert.Contains(deserialized.Status, status => status == StatusAprovacao.PedidoInvalido.GetDescription());
        }

        [Fact]
        public async Task Status_MustReturnBadRequestWhenStatusIsNotProvided()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new StatusRequest
            {
                Pedido = "YYZ",
            };

            // Act
            var response = await client.PostAsync("/api/Status", request.ToStringContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
