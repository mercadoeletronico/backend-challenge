using ME.PurchaseOrder.Domain.Interfaces;
using ME.PurchaseOrder.Domain.Models;
using ME.PurchaseOrder.Infra.Repositories.Base;

namespace ME.PurchaseOrder.Infra.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(BaseContext baseContext) : base(baseContext)
        {
        }
    }
}