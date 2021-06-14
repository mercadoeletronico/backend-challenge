using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao_API.Controllers;
using MinhaAplicacao_API.V1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAplicacao_API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class PedidosController : MinhaAplicacaoController
    {
        private readonly IPedidoServico _pedidoServico;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoServico pedidoServico, IMapper mapper)
        {
            this._pedidoServico = pedidoServico;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoModel>>> ObterTodos()
        {
            var pedidos = await this._pedidoServico.SelecionarTodos(p => p.ItensPedidos);

            if (pedidos == null)
            {
                return NotFound();
            }

            return this.Ok(this._mapper.Map<List<PedidoModel>>(pedidos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> ObterPorId(int id)
        {
            var pedido = await this._pedidoServico.SelecionarPorId(id, p => p.ItensPedidos);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(this._mapper.Map<PedidoModel>(pedido));
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Adicionar(PedidoModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._pedidoServico.Inserir(this._mapper.Map<Pedido>(modelo));

            return Ok(modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, PedidoModel modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var pedido = await this._pedidoServico.SelecionarPorId(modelo.Id, p => p.ItensPedidos);

                if (pedido == null)
                {
                    return NotFound();
                }

                await this._pedidoServico.Alterar(pedido);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this._pedidoServico.Existe(p => p.Id.Equals(id)))
                {
                    return NotFound();
                }

                throw;
            }

            return Ok(modelo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> Excluir(int id)
        {
            var Pedido = await this._pedidoServico.SelecionarPorId(id, p => p.ItensPedidos);

            if (Pedido == null)
            {
                return NotFound();
            }

            await this._pedidoServico.Deletar(Pedido);

            return Ok();
        }
    }
}
