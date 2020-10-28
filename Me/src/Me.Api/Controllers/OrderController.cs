using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Me.Api.Data;
using Me.Api.Models;
using System.Collections.Generic;

namespace Me.Api.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public async Task<ActionResult<List<Order>>> Get([FromServices] DataContext context)
        {
            var orders = await context
                .Orders
                    .Include(x => x.Itens)
                    .AsNoTracking()
                    .ToListAsync();

            return Ok(orders);
        }

        [Route("id:int")]
        public async Task<ActionResult<Order>> GetById(int id, [FromServices] DataContext context)
        {
            var order = await context
                .Orders
                    .Include(x => x.Itens)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o pedido" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Order>> Put(int id, [FromBody] Order order, [FromServices] DataContext context)
        {
            if (id != order.Id)
                return NotFound(new { message = "Pedido não encontrado." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Order>(order).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar o pedido." });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Order>> Delete(int id, [FromServices] DataContext context)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
                return NotFound(new { message = "Pedido não encontrado." });

            try
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
                return Ok(new { message = "Pedido removido com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o pedido." });
            }
        }
    }
}