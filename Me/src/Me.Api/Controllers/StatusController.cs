using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Me.Api.Data;
using Me.Api.Models;


namespace Me.Api.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<StatusPedido>> Post([FromBody] StatusPedido status, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = await context
                .Orders
                    .Include(x => x.Itens)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Pedido == status.Pedido);

            if (order != null)
            {
                status.Status = "CODIGO_PEDIDO_LOCALIZADO";
            }
            else
            {
                status.Status = "CODIGO_PEDIDO_INVALIDO";
            }
            return Ok(new { status.Status });
        }
    }
}