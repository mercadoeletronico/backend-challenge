using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MercadoEletronico.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthcheckController : ControllerBase
    {
        // GET: api/<Healthcheck>
        [HttpGet]
        public string Get()
        {
            return "The server is healthy, up and running 🚀";
        }
    }
}
