﻿using MercadoEletronicoApi.Api.ViewModels;
using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PedidoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<PedidoDTO>> GetPedidos()
        {
            return await _pedidoService.GetOrderAsync();
        }

        [HttpGet("{pedidoId}")]
        [ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<PedidoDTO> GetPedidoById(string pedidoId) 
        {
            return await _pedidoService.GetOrderByOrderCodeAsync(pedidoId);
        } 

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<PedidoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<PedidoDTO> CreatePedido([FromBody] PedidoDTO pedidoDTO)
        {
            return await _pedidoService.CreateOrderAsync(pedidoDTO);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<PedidoDTO> Put([FromBody] PedidoDTO pedido)
        {
            return await _pedidoService.UpdateOrderAsync(pedido);
        }

        [HttpDelete("{pedidoId}")]
        [ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<PedidoDTO> Remove(string pedidoId)
        {
            return await _pedidoService.RemoveOrderAsync(pedidoId);
        }

    }
}
