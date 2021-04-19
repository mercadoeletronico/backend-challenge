using MercadoEletronico.Challenge.Application.Interfaces;
using MercadoEletronico.Challenge.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : MercadoEletronicoControllerBase 
    {
        private readonly IPedidoApplicationService _pedidoAppService;

        public StatusController(IPedidoApplicationService pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StatusRequest request)
            => StructuredResponse(await _pedidoAppService.AprovarPedido(request));
    }
}
