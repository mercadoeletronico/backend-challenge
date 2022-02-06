using AutoMapper;
using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PedidoDTO>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<PedidoDTO>> GetPedidos()
        {
            return await _pedidoService.GetPedidosAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PedidoDTO> GetPedidoById(int id) 
        {
            return await _pedidoService.GetPedidoByIdAsync(id);
        } 


        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<PedidoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PedidoDTO>> CreateProduct([FromBody] PedidoDTO pedidoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _pedidoService.CreatePedidoAsync(pedidoDTO));
        }

    }
}
