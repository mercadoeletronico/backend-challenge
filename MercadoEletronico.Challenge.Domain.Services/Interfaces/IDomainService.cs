using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Domain.Services.Interfaces
{
    public interface IDomainService<T>
    {
        Task AddAsync(T @object);
        Task AddRangeAsync(IEnumerable<T> objects);
        Task UpdateAsync(T @object);
        Task UpdateRangeAsync(IEnumerable<T> objects);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(T @object);
        Task DeleteByIdAsync(string id);
    }
}
