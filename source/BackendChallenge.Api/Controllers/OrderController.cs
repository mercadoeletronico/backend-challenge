using System.Collections.Generic;
using System.Threading.Tasks;
using BackendChallenge.Api.Interfaces;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using BackendChallenge.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Api.Controllers
{
    [ApiController]
    [Route("/api/pedido")]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Returns list of orders with items.
        /// </summary>
        /// <returns>List of orders</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderResponse>))]
        public async Task<List<OrderResponse>> GetAll()
        {
            return await _orderService.GetAllAsync();
        }

        /// <summary>
        /// Returns list of orders with items.
        /// </summary>
        /// <returns>List of orders</returns>
        [HttpGet("{pedido}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderResponse>> Get(int pedido)
        {
            OrderResponse response = await _orderService.FindByIdAsync(pedido);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <returns>New order informations</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderResponse>> Post([FromBody] NewOrderRequest newOrderRequest)
        {
            return await _orderService.AddAsync(newOrderRequest);
        }

        /// <summary>
        /// Update order
        /// </summary>
        /// <returns>New order informations</returns>
        [HttpPut("{pedido}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderResponse>> Put(int pedido, [FromBody] NewOrderRequest newOrderRequest)
        {
            OrderResponse response = await _orderService.UpdateAsync(pedido, newOrderRequest);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        /// <summary>
        /// Delete order
        /// </summary>
        [HttpDelete("{pedido}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int pedido)
        {
            Order order = await _orderService.DeleteAsync(pedido);

            if (order == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
