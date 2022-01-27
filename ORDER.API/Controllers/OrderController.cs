using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ORDER.Application.Dto;

namespace ORDER.API.Controllers
{
    [ApiController]
    [Route("[controller]/api/order")]
    public class OrderController : ControllerBase
    {

        public OrderController()
        {
            
        }
        
        [HttpGet]
        public OrderDto Get()
        {
            return new OrderDto
            {
                OrderId = "123456",
                Items = new List<ItemDto>()
                {
                    new ItemDto
                    {
                        Description = "Item A",
                        UnitPrice = 10,
                        Quantity = 1
                    },
                    new ItemDto
                    {
                        Description = "Item B",
                        UnitPrice = 5,
                        Quantity = 2
                    }
                }
            };
        }

        [HttpPost]
        public OrderDto Post([FromBody] OrderDto order)
        {
            return new OrderDto();
        }
        
        [HttpPut]
        public OrderDto Put([FromBody] OrderDto order)
        {
            return new OrderDto();
        }
        
        [HttpDelete("{orderId}")]
        public OrderDto Delete(string orderId)
        {
            return new OrderDto();
        }
    }
}