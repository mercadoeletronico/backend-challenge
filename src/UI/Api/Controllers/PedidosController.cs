using System.Net;
using System.Threading.Tasks;
using Api.Mapper;
using Api.Models.Request;
using Domain.CommandHandler;
using Domain.Commands;
using Domain.Notifications;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/")]
    public class PedidosController : Controller
    {

        private readonly CommandHandler<PedidoCommand, bool> _cadastrarPedidoCommandHandler;
        private readonly CommandHandler<PedidoCommand, string> _atualizarPedidoCommandHandler;

        private readonly IPedidoQuery _pedidoQuery;

        private readonly NotificationPool _notiificationPool;
        public PedidosController(CommandHandler<PedidoCommand, bool> cadastrarPedidoCommandHandler, NotificationPool notiificationPool, CommandHandler<PedidoCommand, string> atualizarPedidoCommandHandler, IPedidoQuery pedidoQuery)
        {
            _cadastrarPedidoCommandHandler = cadastrarPedidoCommandHandler;
            _notiificationPool = notiificationPool;
            _atualizarPedidoCommandHandler = atualizarPedidoCommandHandler;
            _pedidoQuery = pedidoQuery;
        }


        [HttpPost("pedido")]
        public async Task<IActionResult> CadastrarPedido([FromBody] PedidosRequest request)
        {
            var pedido = await this._cadastrarPedidoCommandHandler.Handle(new PedidoCommand(request.Pedido, CadastrarPedidoItemMapper.Map(request)));

            if (_cadastrarPedidoCommandHandler.HasNotifications)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, _cadastrarPedidoCommandHandler.Notifications);
            }

            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut("pedido")]
        public async Task<IActionResult> AtualizarPedido([FromBody] PedidosRequest request)
        {
            var pedido = await this._atualizarPedidoCommandHandler.Handle(new PedidoCommand(request.Pedido, CadastrarPedidoItemMapper.Map(request)));

            if (_atualizarPedidoCommandHandler.HasNotifications)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, _atualizarPedidoCommandHandler.Notifications);
            }

            return StatusCode((int)HttpStatusCode.OK);
        }
        [HttpGet("pedido")]
        public async Task<IActionResult> ListarPedido()
        {
            var pedido = _pedidoQuery.ListarPedido();
            if (_atualizarPedidoCommandHandler.HasNotifications)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, _atualizarPedidoCommandHandler.Notifications);
            }

            return StatusCode((int)HttpStatusCode.OK, pedido);
        }
        
        [HttpDelete("pedido")]
        public async Task<IActionResult> RemoverPedido([FromQuery] string numeroPedido)
        {
            _pedidoQuery.RemoverPedido(numeroPedido);
            if (_pedidoQuery.HasNotifications)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, _atualizarPedidoCommandHandler.Notifications);
            }

            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPost("status")]
        public async Task<IActionResult> VerificarPedido([FromBody] StatusPedido request)
        {
            var retorno =  _pedidoQuery.VerificarStatusPedido(request.Status,request.ItensAprovados,request.ValorAprovado,request.Pedido);
            if (_pedidoQuery.HasNotifications)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, _atualizarPedidoCommandHandler.Notifications);
            }

            return StatusCode((int)HttpStatusCode.OK, retorno);
        }

    }
}