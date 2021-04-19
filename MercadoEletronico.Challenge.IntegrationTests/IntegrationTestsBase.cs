using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MercadoEletronico.Challenge.IntegrationTests
{
    public class IntegrationTestsBase
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTestsBase(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}
