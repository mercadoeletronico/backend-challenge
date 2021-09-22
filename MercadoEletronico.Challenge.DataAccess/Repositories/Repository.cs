using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        protected abstract IIncludableQueryable<T, object> DefaultInclusions(DbSet<T> dbSet);

        public virtual async Task AddAsync(T @object)
        {
            _context.Add(@object);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> objects)
        {
            _context.AddRange(objects);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T @object)
        {
            _context.Remove(@object);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var queryable = DefaultInclusions(_context.Set<T>());
            return await queryable.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            var queryable = DefaultInclusions(_context.Set<T>());
            return await queryable.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public virtual async Task UpdateAsync(T @object)
        {
            _context.Update(@object);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<T> objects)
        {
            _context.UpdateRange(objects);
            await _context.SaveChangesAsync();
        }
    }
}
