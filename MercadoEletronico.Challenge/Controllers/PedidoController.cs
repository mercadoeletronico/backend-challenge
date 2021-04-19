using MercadoEletronico.Challenge.Application.Interfaces;
using MercadoEletronico.Challenge.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : MercadoEletronicoControllerBase
    {
        private readonly IPedidoApplicationService _pedidoAppService;

        public PedidoController(IPedidoApplicationService pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => StructuredResponse(await _pedidoAppService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) 
            => StructuredResponse(await _pedidoAppService.GetByIdAsync(id));
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
            => StructuredResponse(await _pedidoAppService.AddAsync(pedido));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Pedido pedido)
        {
            pedido.Id = id;
            return StructuredResponse(await _pedidoAppService.UpdateAsync(pedido));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
            => StructuredResponse(await _pedidoAppService.DeleteByIdAsync(id));
    }
}
