using ME.PurchaseOrder.API.Interfaces;
using ME.PurchaseOrder.API.Requests;
using ME.PurchaseOrder.API.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    public class PedidoController : BaseController
    {
        private readonly IOrderService _orderService;

        public PedidoController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
            => await TratarResultadoAsync(async () =>
            {
                var result = await _orderService.GetAll();

                return new ObjectResult(result) { StatusCode = result.StatusCode };
            });

        [HttpGet("{pedido}")]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCode(string pedido)
            => await TratarResultadoAsync(async () =>
            {
                var result = await _orderService.GetOrderByCodeAsync(pedido);

                return new ObjectResult(result) { StatusCode = result.StatusCode };
            });

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(IEnumerable<OrderSummaryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Find(int id)
            => await TratarResultadoAsync(async () =>
            {
                var result = await _orderService.GetOrderByIdAsync(id);

                return new ObjectResult(result) { StatusCode = result.StatusCode };
            });

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(OrderRequest request)
            => await TratarResultadoAsync(async () =>
            {
                var result = await _orderService.Create(request);

                return new ObjectResult(result) { StatusCode = result.StatusCode };
            });

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(OrderRequest request)
            => await TratarResultadoAsync(async () =>
            {
                var result = await _orderService.Update(request);

                return result.Status?.Any() ?? false
                    ? new ObjectResult(result) { StatusCode = result.StatusCode }
                    : new NoContentResult();
            });

        [HttpDelete("{pedido}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(string pedido)
            => await TratarResultadoAsync(async () =>
            {
                var result = await _orderService.Delete(pedido);

                return result.Status?.Any() ?? false
                    ? new ObjectResult(result) { StatusCode = result.StatusCode }
                    : new NoContentResult();
            });
    }
}