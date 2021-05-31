using ME.PurchaseOrder.API.Interfaces;
using ME.PurchaseOrder.API.Requests;
using ME.PurchaseOrder.API.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status500InternalServerError)]
    public class StatusController : BaseController
    {
        private readonly IOrderService _orderService;

        public StatusController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Aprova ou reprova o pedido conforme valores informados.
        /// </summary>
        /// <param name="pedido"><sealso cref="UpdateOrderStatusRequest"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateOrderStatusRequest request)
            => await TratarResultadoAsync(async () =>
            {
                var result = await _orderService.UpdateStatusOfOrder(request);

                return new ObjectResult(result) { StatusCode = result.StatusCode };
            });
    }
}