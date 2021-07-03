using backend_challenge_domain_datatypes.Entities;
using System;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge_data.Repositories.Interfaces
{
    public interface IProductRepository
        : IBaseRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> GetByReferenceCodeAsync(string referenceCode);
    }
}
