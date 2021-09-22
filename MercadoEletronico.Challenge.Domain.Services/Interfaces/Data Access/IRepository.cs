using MercadoEletronico.Challenge.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access
{
    public interface IRepository<T> where T : IEntity
    {
        Task AddAsync(T obj);
        Task AddRangeAsync(IEnumerable<T> objs);
        Task UpdateAsync(T obj);
        Task UpdateRangeAsync(IEnumerable<T> objs);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(T obj);
        Task DeleteByIdAsync(string id);
    }
}
