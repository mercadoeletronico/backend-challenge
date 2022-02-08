using AutoMapper;
using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Application.Interfaces;
using MercadoEletronicoApi.Domain.Entities;
using MercadoEletronicoApi.Domain.Exceptions;
using MercadoEletronicoApi.Domain.Interfaces;
using System.Collections.Generic;
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

        public async Task<IList<PedidoDTO>> GetOrderAsync()
        {
            var pedidos = await _pedidoRepository.GetAsync();

            return _mapper.Map<List<PedidoDTO>>(pedidos);
        }

        public async Task<PedidoDTO> GetOrderByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);

            NotFoundPedidoException.When(pedido is null);

            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<PedidoDTO> GetOrderByOrderCodeAsync(string codPedido)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(codPedido);

            NotFoundPedidoException.When(pedido is null);

            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<PedidoDTO> CreateOrderAsync(PedidoDTO pedidoDTO)
        {
            var existingOrder = await _pedidoRepository.GetOrderByOrderCodeAsync(pedidoDTO.CodPedido);

            OrderAlreadyExistsException.When(existingOrder is not null);
            
            var pedido = _mapper.Map<Pedido>(pedidoDTO);

            await _pedidoRepository.CreateAsync(pedido);

            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<PedidoDTO> UpdateOrderAsync(PedidoDTO pedidoDTO)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(pedidoDTO.CodPedido);  

            NotFoundPedidoException.When(pedido == null);

            pedido.Items = _mapper.Map<List<Item>>(pedidoDTO.Items);

            await _pedidoRepository.UpdateAsync(pedido);

            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<PedidoDTO> RemoveOrderAsync(string codPedido)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(codPedido);

            NotFoundPedidoException.When(pedido is null);

            await _pedidoRepository.RemoveAsync(pedido);

            NotDeletedOrderException.When(pedido is null);

            return _mapper.Map<PedidoDTO>(pedido);
        }

    }

}
