using Microsoft.AspNetCore.Mvc;

namespace MercadoEletronico.Aplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthcheckController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "The server is healthy";
        }
    }
}