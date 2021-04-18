using MercadoEletronico.Challenge.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MercadoEletronico.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase 
    {
        [HttpPost]
        public void Post([FromBody] StatusRequest request)
        {
        }
    }
}
