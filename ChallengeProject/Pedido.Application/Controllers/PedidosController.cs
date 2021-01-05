using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedido.Domain.Models;
using Pedido.Domain.Services;

namespace Pedido.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // GET: api/Pedido/GetAllPedidos
        /// <summary>
        /// Get all pedidos.
        /// </summary>
        /// <remarks>
        [HttpGet]
        [Route("GetAllPedidos")]
        public async Task<IEnumerable<Domain.Models.Pedido>> GetAllPedidos()
        {          
            var pedidos = await _pedidoService.ListAsync();
       
            return pedidos;
        }

        // GET: api/Pedido/GetPedidos
        /// <summary>
        /// Get Pedido By numeroPedido.
        /// </summary>
        /// <remarks>
        [HttpGet]
        [HttpGet("{numeroPedido}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPedidos(string numeroPedido)
        {

            var pedido = _pedidoService.FindAsync(numeroPedido);

            if (pedido == null)
                return NotFound();

            else 
                return Ok(pedido);
        }


        // POST: api/Pedido/PostPedido
        /// <summary>
        /// Creates a Pedido.
        /// </summary>
        /// <remarks>
        [HttpPost]
        public ActionResult<Domain.Models.Pedido> PostPedido(Domain.Models.Pedido pedido)
        {
            if (_pedidoService.AddAsync(pedido))
                return CreatedAtAction(nameof(GetPedidos), new { id = pedido.Id }, pedido);
            else
                return BadRequest();
        }

        // POST: api/Pedido/PutPedido
        /// <summary>
        /// Updates a Pedido.
        /// </summary>
        /// <remarks>
        [HttpPut]
        public ActionResult<Domain.Models.Pedido> PutPedido(Domain.Models.Pedido pedido)
        {
            if (_pedidoService.Update(pedido))
                return CreatedAtAction(nameof(GetPedidos), new { id = pedido.Id }, pedido);
            else
                return BadRequest();

        }

        // POST: api/Pedido/DeletePedido
        /// <summary>
        /// Delete a Pedido.
        /// </summary>
        /// <remarks>
        [HttpDelete]
        public void DeletePedido(Domain.Models.Pedido pedido)
        {
            _pedidoService.Remove(pedido);

        }
    }
}