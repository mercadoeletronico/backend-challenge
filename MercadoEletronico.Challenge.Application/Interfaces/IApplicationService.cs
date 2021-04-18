using MercadoEletronico.Challenge.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Application.Interfaces
{
    public interface IApplicationService<T> where T : class
    {
        Task<Result> AddAsync(T @object);
        Task<Result> AddRangeAsync(IEnumerable<T> objects);
        Task<Result> UpdateAsync(T @object);
        Task<Result> UpdateRangeAsync(IEnumerable<T> objects);
        Task<Result<T>> GetByIdAsync(string id);
        Task<Result<IEnumerable<T>>> GetByExpressionAsync(Func<T, bool> expression);
        Task<Result<IEnumerable<T>>> GetAllAsync();
        Task<Result> DeleteAsync(T @object);
        Task<Result> DeleteByIdAsync(string id);
    }
}
