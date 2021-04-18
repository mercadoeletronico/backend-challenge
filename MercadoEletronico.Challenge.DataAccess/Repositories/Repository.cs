using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public Task AddAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<T> objs)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByExpressionAsync(Func<T, bool> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<T> objs)
        {
            throw new NotImplementedException();
        }
    }
}
