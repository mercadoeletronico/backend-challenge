using ME.PurchaseOrder.API.Requests;
using ME.PurchaseOrder.API.Responses;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.API.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> GetOrderByCodeAsync(string pedido);

        Task<OrderResponse> GetOrderByIdAsync(int id);

        Task<BaseListResponse<OrderSummaryResponse>> GetAll();

        Task<BaseResponse> Create(OrderRequest request);

        Task<BaseResponse> Update(OrderRequest request);

        Task<BaseResponse> Delete(string pedido);

        Task<OrderStatusResponse> UpdateStatusOfOrder(UpdateOrderStatusRequest request);
    }
}