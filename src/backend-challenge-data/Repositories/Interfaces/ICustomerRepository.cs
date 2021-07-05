using backend_challenge_datatypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge_data.Repositories.Interfaces
{
    public interface ICustomerRepository
        : IBaseRepository
    {
        Task<IEnumerable<ViewCustomerFullData>> GetViewCustomerFullData();
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> GetByPersonIdAsync(Guid personId);
        Task<Customer> GetByCodeAsync(string code);
    }
}
