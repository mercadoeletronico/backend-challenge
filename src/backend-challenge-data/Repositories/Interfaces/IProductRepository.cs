using backend_challenge_datatypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge_data.Repositories.Interfaces
{
    public interface IProductRepository
        : IBaseRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> GetByReferenceCodeAsync(string referenceCode);
    }
}
