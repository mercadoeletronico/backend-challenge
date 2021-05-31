using ME.PurchaseOrder.Domain.Models.Base;
using ME.PurchaseOrder.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.Infra.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly BaseContext _db;
        protected readonly DbSet<T> _dbSet;

        public IUnitOfWork UnitOfWork => _db;

        public Repository(BaseContext baseContext)
        {
            _db = baseContext;
            _dbSet = baseContext.Set<T>();
        }

        public virtual async Task<T> Find(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task<ICollection<T>> Get(Expression<Func<T, bool>> predicate = null)
            => await (predicate is null ? _dbSet.AsNoTracking() : _dbSet.AsNoTracking().Where(predicate)).ToListAsync();

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}