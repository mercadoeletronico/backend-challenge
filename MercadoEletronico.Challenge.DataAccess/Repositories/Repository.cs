using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T @object)
        {
            _context.Add(@object);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> objects)
        {
            _context.AddRange(objects);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T @object)
        {
            _context.Remove(@object);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T @object)
        {
            _context.Update(@object);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> objects)
        {
            _context.UpdateRange(objects);
            await _context.SaveChangesAsync();
        }
    }
}
