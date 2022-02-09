using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste_me.Models;
using teste_me.Repository;
using teste_me.Repository.Context;

namespace teste_me.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _repository;

        public PedidoController(PedidoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return Ok(await _repository.GetPedidos());
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _repository.GetPedido(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            var pedidoAtualizado = await _repository.UpdatePedido(id, pedido);
            if (pedidoAtualizado == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pedidoAtualizado);
            }

        }

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            if (pedido.Itens.Count ==0)
            {
                return BadRequest("NAO_EXISTEM_ITENS_NO_PEDIDO");
            }
            return await _repository.CreatePedido(pedido);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            bool removerPedido = await _repository.DeletePedido(id);
            if (!removerPedido)
            {
                return NotFound();
            }
            else
            {
                return Ok("pedido removido");
            }

        }

    }
}
