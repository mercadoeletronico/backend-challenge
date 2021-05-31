using ME.PurchaseOrder.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ME.PurchaseOrder.Domain.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<T> Find(int id);

        Task<ICollection<T>> Get(Expression<Func<T, bool>> predicate = null);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}