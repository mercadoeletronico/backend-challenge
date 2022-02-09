using MercadoEletronicoApi.Api.ViewModels;
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
        private readonly IOrderService _pedidoService;
        
        public PedidoController(IOrderService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<OrderDTO>> GetPedidos()
        {
            return await _pedidoService.GetOrderAsync();
        }

        [HttpGet("{pedidoId}")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<OrderDTO> GetPedidoById(string pedidoId) 
        {
            return await _pedidoService.GetOrderByOrderCodeAsync(pedidoId);
        } 

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<OrderDTO> CreatePedido([FromBody] OrderDTO pedidoDTO)
        {
            return await _pedidoService.CreateOrderAsync(pedidoDTO);
        }

        [HttpPut]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<OrderDTO> Put([FromBody] OrderDTO pedido)
        {
            return await _pedidoService.UpdateOrderAsync(pedido);
        }

        [HttpDelete("{pedidoId}")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<OrderDTO> Remove(string pedidoId)
        {
            return await _pedidoService.RemoveOrderAsync(pedidoId);
        }

    }
}
