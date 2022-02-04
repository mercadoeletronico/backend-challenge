using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MercadoEletronico.Aplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : BaseController
    {
        private readonly Business.Interfaces.IRepositorioService _RepositorioService;

        public StatusController(Business.Interfaces.INotificador notificador, Business.Interfaces.IRepositorioService repositorioService) : base(notificador)
        {
            _RepositorioService = repositorioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Requests.StatusRequest statusRequest)
        {
            return CustomResponse(await _RepositorioService.Pedido.AprovarPedido(statusRequest));
        }
    }
}
