using MercadoEletronico.Challenge.Domain.Services.Interfaces;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Domain.Services.Implementations
{
    public abstract class DomainService<T> : IDomainService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public DomainService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T @object)
        {
            await _repository.AddAsync(@object);
        }

        public async Task AddRangeAsync(IEnumerable<T> objects)
        {
            await _repository.AddRangeAsync(objects);
        }

        public async Task DeleteAsync(T @object)
        {
            await _repository.DeleteAsync(@object);
        }

        public async Task DeleteByIdAsync(string id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetByExpressionAsync(expression);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T @object)
        {
            await _repository.UpdateAsync(@object);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> objects)
        {
            await _repository.UpdateRangeAsync(objects);
        }
    }
}
