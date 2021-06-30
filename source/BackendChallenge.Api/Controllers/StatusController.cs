using System.Threading.Tasks;
using BackendChallenge.Api.Interfaces;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Api.Controllers
{
    [ApiController]
    [Route("/api/status")]
    [Produces("application/json")]
    public class StatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;
        public StatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        /// <summary>
        /// Update order status
        /// </summary>
        /// <returns>Order status information</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderStatusResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<OrderStatusResponse> Post([FromBody] OrderStatusRequest orderStatusRequest)
        {
            return await _orderStatusService.UpdateStatus(orderStatusRequest);
        }
    }
}