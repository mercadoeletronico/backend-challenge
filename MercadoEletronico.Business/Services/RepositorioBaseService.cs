using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MercadoEletronico.Business.Services
{
    public abstract class RepositorioBaseService<Contexto, TEntity> : BaseService where Contexto : DbContext where TEntity : class, Domain.Entities.IEntity
    {
        public DataAccess.Context _Context { get; internal set; }

        public RepositorioBaseService(Interfaces.INotificador notificador) : base(notificador)
        {
            _Context = (DataAccess.Context)Activator.CreateInstance(typeof(Contexto));
        }

        protected abstract IIncludableQueryable<TEntity, object> DefaultInclusions(DbSet<TEntity> dbSet);

        public virtual async Task<TEntity> AddAsync(TEntity @object)
        {
            _Context.Add(@object);

            await _Context.SaveChangesAsync();

            return @object;
        }

        public virtual async Task<List<TEntity>> AddRangeAsync(List<TEntity> objects)
        {
            _Context.AddRange(objects);

            await _Context.SaveChangesAsync();

            return objects;
        }

        public virtual async Task DeleteAsync(TEntity @object)
        {
            _Context.Remove(@object);

            await _Context.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(List<TEntity> objects)
        {
            _Context.RemoveRange(objects);

            await _Context.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);

            _Context.Set<TEntity>().Remove(entity);

            await _Context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            IIncludableQueryable<TEntity, object> queryable = DefaultInclusions(_Context.Set<TEntity>());

            return await queryable.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _Context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            IIncludableQueryable<TEntity, object> queryable = DefaultInclusions(_Context.Set<TEntity>());

            return await queryable.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity @object)
        {
            _Context.Update(@object);

            await _Context.SaveChangesAsync();

            return @object;
        }

        public virtual async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> objects)
        {
            _Context.UpdateRange(objects);

            await _Context.SaveChangesAsync();

            return objects;
        }
    }
}