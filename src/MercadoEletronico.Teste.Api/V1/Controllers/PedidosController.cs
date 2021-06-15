using AutoMapper;
using MercadoEletronico.Teste.Api.Controllers;
using MercadoEletronico.Teste.Api.ViewModels;
using MercadoEletronico.Teste.Application.Interfaces;
using MercadoEletronico.Teste.Domain.Entities;
using MercadoEletronico.Teste.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronico.Teste.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/pedidos")]
    public class PedidosController : MainController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidosController(INotificador notificador,
                                  IPedidoRepository pedidoRepository,
                                  IPedidoService pedidoService,
                                  IMapper mapper) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PedidoViewModel>> ObterPorId(Guid id)
        {
            var pedidoViewModel = await ObterPedido(id);

            if (pedidoViewModel == null) return NotFound();

            return pedidoViewModel;
        }


        [HttpPost]
        public async Task<ActionResult<PedidoViewModel>> Adicionar(PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pedidoService.Adicionar(_mapper.Map<Pedido>(pedidoViewModel));

            return CustomResponse(pedidoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, PedidoViewModel pedidoViewModel)
        {
            if (id != pedidoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var pedidoAtualizacao = await ObterPedido(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pedidoService.Atualizar(_mapper.Map<Pedido>(pedidoAtualizacao));

            return CustomResponse(pedidoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PedidoViewModel>> Excluir(Guid id)
        {
            var pedido = await ObterPedido(id);

            if (pedido == null) return NotFound();

            await _pedidoService.Remover(id);

            return CustomResponse(pedido);
        }

        private async Task<PedidoViewModel> ObterPedido(Guid id)
        {
            return _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPorId(id));
        }

    }
}