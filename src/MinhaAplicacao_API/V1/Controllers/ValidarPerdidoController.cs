using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao_API.Controllers;
using MinhaAplicacao_API.V1.Models;
using System.Threading.Tasks;

namespace MinhaAplicacao_API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class ValidarPerdidoController : MinhaAplicacaoController
    {
        private readonly IPedidoServico _pedidoServico;
        private readonly IMapper _mapper;

        public ValidarPerdidoController(IPedidoServico pedidoServico, IMapper mapper)
        {
            this._pedidoServico = pedidoServico;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Validar(StatusPedidoModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var retorno = await this._pedidoServico.ValidarPedido(this._mapper.Map<StatusPedido>(modelo));

            if (retorno == null)
            {
                return NotFound();
            }

            return this.Ok(retorno);
        }
    }
}
