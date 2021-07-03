using backend_challenge_domain_datatypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge_data.Repositories.Interfaces
{
    public interface IOrderRepository
        : IBaseRepository
    {
        Task<(bool Exists, Order order)> Exists(string login);
        Task<IEnumerable<ViewOrderFullData>> GetViewOrderFullData();
        Task<Order> GetByIdAsync(Guid id);
    }
}
