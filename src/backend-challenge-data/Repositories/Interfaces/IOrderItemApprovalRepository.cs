using backend_challenge_domain_datatypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge_data.Repositories.Interfaces
{
    public interface IOrderItemApprovalRepository
        : IBaseRepository
    {
        Task<OrderItemApproval> GetByIdAsync(Guid id);

        Task<IEnumerable<OrderItemApproval>> GetByOrderItemIdAsync(Guid id);

        Task<IEnumerable<OrderItemApproval>> GetByOrderIdAsync(Guid id);
    }
}
