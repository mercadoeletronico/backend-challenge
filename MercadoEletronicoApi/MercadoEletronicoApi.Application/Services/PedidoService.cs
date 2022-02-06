using AutoMapper;
using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Application.ExtensionMethods;
using MercadoEletronicoApi.Application.Interfaces;
using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Domain.Exceptions;
using MercadoEletronicoApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<IList<PedidoDTO>> GetPedidosAsync()
        {
            var pedidos = await _pedidoRepository.GetAsync();

            return _mapper.Map<List<PedidoDTO>>(pedidos);
        }

        public async Task<PedidoDTO> GetPedidoByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);

            NotFoundPedidoException.When(pedido is null);

            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<PedidoDTO> CreatePedidoAsync(PedidoDTO pedidoDTO)
        {
            var pedido = pedidoDTO.ToPedido();

            return (await _pedidoRepository.CreateAsync(pedido)).ToPedidoDTO();
        }

        public async Task<PedidoDTO> UpdatePedidoAsync(PedidoDTO pedidoDTO)
        {
            var pedido = pedidoDTO.ToPedido();

            return(await _pedidoRepository.UpdateAsync(pedido)).ToPedidoDTO();
        }

        public async Task<PedidoDTO> RemovePedidoAsync(PedidoDTO pedidoDTO)
        {
            var pedido = pedidoDTO.ToPedido();

            return (await _pedidoRepository.RemoveAsync(pedido)).ToPedidoDTO();
        }

    }

}
