using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MercadoEletronico.Aplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : BaseController
    {
        private readonly Business.Interfaces.IRepositorioService _RepositorioService;

        public PedidoController(Business.Interfaces.INotificador notificador, Business.Interfaces.IRepositorioService repositorioService) : base(notificador)
        {
            _RepositorioService = repositorioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CustomResponse(await _RepositorioService.Pedido.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CustomResponse(await _RepositorioService.Pedido.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Requests.PedidoRequest pedido)
        {
            return CustomResponse(await _RepositorioService.Pedido.AddAsync(pedido));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Domain.Requests.PedidoRequest pedido)
        {
            return CustomResponse(await _RepositorioService.Pedido.UpdateAsync(pedido));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RepositorioService.Pedido.DeleteByIdAsync(id);

            return CustomResponse();
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAll()
        {
            await _RepositorioService.Pedido.DeleleAllAsync();

            return CustomResponse();
        }
    }
}
