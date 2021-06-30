using System.Threading.Tasks;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using BackendChallenge.Core.Entities;

namespace BackendChallenge.Api.Interfaces
{
    public interface IOrderStatusService
    {
        /// <summary>
        /// Update order status
        /// </summary>
        /// <param name="orderStatusRequest"></param>
        /// <returns>Order status response</returns>
        Task<OrderStatusResponse> UpdateStatus(OrderStatusRequest orderStatusRequest);

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Order instance</returns>
        Task<Order> GetOrderByIdAsync(string id);

        /// <summary>
        /// Validate if the order can be approved
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderStatusRequest"></param>
        void ValidateOrderApproval(Order order, OrderStatusRequest orderStatusRequest);
    }
}