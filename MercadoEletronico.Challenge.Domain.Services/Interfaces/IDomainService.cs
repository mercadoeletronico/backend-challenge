using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Domain.Services.Interfaces
{
    public interface IDomainService<T>
    {
        Task AddAsync(T obj);
        Task AddRangeAsync(IEnumerable<T> objs);
        Task UpdateAsync(T obj);
        Task UpdateRangeAsync(IEnumerable<T> objs);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetByExpressionAsync(Func<T, bool> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(T obj);
        Task DeleteByIdAsync(string id);
    }
}
