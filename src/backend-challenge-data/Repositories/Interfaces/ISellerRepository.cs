using backend_challenge_datatypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge_data.Repositories.Interfaces
{
    public interface ISellerRepository
        : IBaseRepository
    {
        Task<IEnumerable<ViewSellerFullData>> GetViewSellerFullData();
        Task<Seller> GetByIdAsync(Guid id);
        Task<Seller> GetByPersonIdAsync(Guid personId);
        Task<Seller> GetByCodeAsync(string code);
    }
}
