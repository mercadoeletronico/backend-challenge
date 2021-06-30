using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BackendChallenge.Api.Interfaces;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces;

namespace BackendChallenge.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        protected readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public OrderService(
            IOrderRepository orderRepository,
            IItemRepository itemRepository,
            IMapper mapper,
            IUnitOfWork uow)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _uow = uow;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>List of orders response</returns>
        public async Task<List<OrderResponse>> GetAllAsync()
        {
            List<Order> orders = await _orderRepository.AllAsync();
            return _mapper.Map<List<OrderResponse>>(orders);
        }

        /// <summary>
        /// Find order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Order response</returns>
        public async Task<OrderResponse> FindByIdAsync(int orderId)
        {
            Order order = await _orderRepository.FindByIdAsync(orderId);

            if (order == null)
            {
                return (OrderResponse)null;
            }

            return _mapper.Map<OrderResponse>(order);
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="newOrderRequest"></param>
        /// <returns>Order response</returns>
        public async Task<OrderResponse> AddAsync(NewOrderRequest newOrderRequest)
        {
            Order order = _mapper.Map<Order>(newOrderRequest);
            _orderRepository.Add(order);
            await _uow.CommitAsync();
            return _mapper.Map<OrderResponse>(order);
        }

        /// <summary>
        /// Update order items
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newOrderRequest"></param>
        /// <returns>Order response</returns>
        public async Task<OrderResponse> UpdateAsync(int orderId, NewOrderRequest newOrderRequest)
        {
            Order order = await _orderRepository.FindByIdAsync(orderId);

            if (order == null)
            {
                return (OrderResponse)null;
            }

            _itemRepository.RemoveMany(order.Items);
            order.Items.Clear();

            foreach (NewItemRequest itemRequest in newOrderRequest.Items)
            {
                Item item = _mapper.Map<Item>(itemRequest);
                item.OrderId = order.Id;
                order.Items.Add(item);
            }

            _itemRepository.AddMany(order.Items);

            await _uow.CommitAsync();

            return _mapper.Map<OrderResponse>(order);
        }

        /// <summary>
        /// Delete order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Deleted order</returns>
        public async Task<Order> DeleteAsync(int orderId)
        {
            Order order = await _orderRepository.FindByIdAsync(orderId);

            if (order == null)
            {
                return order;
            }

            _orderRepository.Remove(order);
            await _uow.CommitAsync();
            return order;
        }
    }
}