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
    public class OrderService : IOrderService
    {
        private IOrderRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<IList<OrderDTO>> GetOrderAsync()
        {
            var pedidos = await _pedidoRepository.GetAsync();

            return _mapper.Map<List<OrderDTO>>(pedidos);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);

            NotFoundPedidoException.When(pedido is null);

            return _mapper.Map<OrderDTO>(pedido);
        }

        public async Task<OrderDTO> GetOrderByOrderCodeAsync(string codPedido)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(codPedido);

            NotFoundPedidoException.When(pedido is null);

            return _mapper.Map<OrderDTO>(pedido);
        }

        public async Task<OrderDTO> CreateOrderAsync(OrderDTO pedidoDTO)
        {
            var existingOrder = await _pedidoRepository.GetOrderByOrderCodeAsync(pedidoDTO.OrderCode);

            OrderAlreadyExistsException.When(existingOrder is not null);
            
            var pedido = _mapper.Map<Order>(pedidoDTO);

            await _pedidoRepository.CreateAsync(pedido);

            return _mapper.Map<OrderDTO>(pedido);
        }

        public async Task<OrderDTO> UpdateOrderAsync(OrderDTO pedidoDTO)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(pedidoDTO.OrderCode);  

            NotFoundPedidoException.When(pedido == null);

            pedido.Items = _mapper.Map<List<Item>>(pedidoDTO.Items);

            await _pedidoRepository.UpdateAsync(pedido);

            return _mapper.Map<OrderDTO>(pedido);
        }

        public async Task<OrderDTO> RemoveOrderAsync(string codPedido)
        {
            var pedido = await _pedidoRepository.GetOrderByOrderCodeAsync(codPedido);

            NotFoundPedidoException.When(pedido is null);

            await _pedidoRepository.RemoveAsync(pedido);

            NotDeletedOrderException.When(pedido is null);

            return _mapper.Map<OrderDTO>(pedido);
        }

    }

}
