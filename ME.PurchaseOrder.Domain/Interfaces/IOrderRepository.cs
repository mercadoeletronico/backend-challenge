using ME.PurchaseOrder.Domain.Models;
using ME.PurchaseOrder.Domain.Repositories.Base;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderByCode(string numberOrder);
    }
}