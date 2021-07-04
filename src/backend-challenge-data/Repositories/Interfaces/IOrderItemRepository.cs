using backend_challenge_datatypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge_data.Repositories.Interfaces
{
    public interface IOrderItemRepository
        : IBaseRepository
    {        
        Task<OrderItem> GetByIdAsync(Guid id);

        Task<IEnumerable<OrderItem>> GetByOrderIdAsync(Guid orderId);
        Task<IEnumerable<OrderItem>> GetByOrderNumberAsync(string orderNumber);
        Task<IEnumerable<ViewOrderItemFullData>> GetByViewOrderItemOrderIdAsync(Guid orderId);
    }
}
