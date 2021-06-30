using System.Collections.Generic;
using System.Threading.Tasks;
using BackendChallenge.Api.Exceptions;
using BackendChallenge.Api.Interfaces;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces;

namespace BackendChallenge.Api.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderStatusService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Update order status
        /// </summary>
        /// <param name="orderStatusRequest"></param>
        /// <returns>Order status response</returns>
        public async Task<OrderStatusResponse> UpdateStatus(OrderStatusRequest orderStatusRequest)
        {
            OrderStatusResponse response = new OrderStatusResponse();
            response.Status = new List<string>();

            try
            {
                if (orderStatusRequest.Status.ToUpper() != "APROVADO" && orderStatusRequest.Status.ToUpper() != "REPROVADO")
                {
                    throw new StatusException("STATUS_INVALIDO");
                }

                Order order = await GetOrderByIdAsync(orderStatusRequest.Pedido);

                response.Pedido = orderStatusRequest.Pedido;

                if (orderStatusRequest.Status.ToUpper() == "APROVADO")
                {
                    ValidateOrderApproval(order, orderStatusRequest);

                    response.Status.Add("APROVADO");
                }
                else
                {
                    response.Status.Add("REPROVADO");
                }
            }
            catch (StatusException ex)
            {
                response.Status = ex.GetStatus();
            }

            return response;
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Order instance</returns>
        public async Task<Order> GetOrderByIdAsync(string id)
        {
            int orderId;

            if (!int.TryParse(id, out orderId))
            {
                throw new StatusException("CODIGO_PEDIDO_INVALIDO");
            }

            Order order = await _orderRepository.FindByIdAsync(orderId);

            if (order == null)
            {
                throw new StatusException("CODIGO_PEDIDO_INVALIDO");
            }

            return order;
        }

        /// <summary>
        /// Validate if the order can be approved
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderStatusRequest"></param>
        public void ValidateOrderApproval(Order order, OrderStatusRequest orderStatusRequest)
        {
            int itemsQuantity = 0;
            int orderValue = 0;
            List<string> status = new List<string>();

            foreach (Item item in order.Items)
            {
                itemsQuantity += item.Quantity;
                orderValue += item.Quantity * item.Price;
            }

            if (orderStatusRequest.ItensAprovados > itemsQuantity)
            {
                status.Add("APROVADO_QTD_A_MAIOR");
            }
            else if (orderStatusRequest.ItensAprovados < itemsQuantity)
            {
                status.Add("APROVADO_QTD_A_MENOR");
            }

            if (orderStatusRequest.ValorAprovado > orderValue)
            {
                status.Add("APROVADO_VALOR_A_MAIOR");
            }
            else if (orderStatusRequest.ValorAprovado < orderValue)
            {
                status.Add("APROVADO_VALOR_A_MENOR");
            }

            if (status.Count > 0)
            {
                throw new StatusException(status);
            }
        }
    }
}