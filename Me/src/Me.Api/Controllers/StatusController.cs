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
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Pedido == status.Pedido);

            if (order != null)
            {
                
            }

            try
            {
                context.StatusPedidos.Add(status);
                await context.SaveChangesAsync();
                return Ok(new { status.Pedido, status.Status });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o Status do Pedido" });
            }
        }
    }
}