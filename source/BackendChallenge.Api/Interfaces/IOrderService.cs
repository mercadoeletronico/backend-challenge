using System.Collections.Generic;
using System.Threading.Tasks;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using BackendChallenge.Core.Entities;

namespace BackendChallenge.Api.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>List of orders response</returns>
        Task<List<OrderResponse>> GetAllAsync();

        /// <summary>
        /// Find order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Order response</returns>
        Task<OrderResponse> FindByIdAsync(int orderId);

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="newOrderRequest"></param>
        /// <returns>Order response</returns>
        Task<OrderResponse> AddAsync(NewOrderRequest newOrderRequest);

        /// <summary>
        /// Update order items
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newOrderRequest"></param>
        /// <returns>Order response</returns>
        Task<OrderResponse> UpdateAsync(int orderId, NewOrderRequest newOrderRequest);

        /// <summary>
        /// Delete order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Deleted order</returns>
        Task<Order> DeleteAsync(int orderId);
    }
}