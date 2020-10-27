using Me.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Me.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public async Task<ActionResult<Pedido>> Get()
        {
            return new Pedido();
        }

        [Route("id:int")]
        public async Task<ActionResult<Pedido>> GetById(int id)
        {
            return new Pedido();
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Post([FromBody]Pedido pedido)
        {
            return Ok(pedido);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Pedido>> Put(int id, [FromBody]Pedido pedido)
        {
            if (pedido.Id == id)
            {
                return Ok(pedido);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Pedido>> Delete()
        {
            return Ok();
        }
    }
}