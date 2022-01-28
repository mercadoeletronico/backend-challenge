using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORDER.API.ViewModels;
using ORDER.Domain.Dto;
using ORDER.Domain.Exceptions;
using ORDER.Domain.Services;

namespace ORDER.API.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService orderService)
        {
            _service = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public List<OrderDto> Get()
        {
            return _service.GetOrders();
        }


        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public OrderDto GetByOrderId(string orderId)
        {
            return _service.GetOrderById(orderId);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public OrderDto Post([FromBody] OrderDto order)
        {
            return _service.CreateOrder(order);
        }

        [HttpPut]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public OrderDto Put([FromBody] OrderDto order)
        {
            return _service.UpdateOrder(order);
        }

        [HttpDelete("{orderId}")]
        [ProducesResponseType(typeof(StatusResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public StatusResponseDto Delete(string orderId)
        {
            var status = _service.DeleteOrder(orderId);

            return new StatusResponseDto()
            {
                OrderId = status.OrderId,
                Status = new List<string>() {"DELETADO"}
            };
        }
    }
}