using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoEletronico.Utilities.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<TEntity> dbSet;



        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByKeysAsync(CancellationToken cancellationToken, params object[] keys)
        {
            return await this.dbSet.FindAsync(keys, cancellationToken);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool noTracking = false, int? take = null)
        {
            IQueryable<TEntity> query = this.dbSet;

            if (noTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (take != null)
                query.Take((int)take);

            if (orderBy != null)
                return orderBy(query);
            else
                return query;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await this.dbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Deleted;
        }
        public async Task<bool> CommitAsync(CancellationToken cancelationToken)
        {
            return await this.dbContext.SaveChangesAsync(cancelationToken) > 0;
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }


    }
}
