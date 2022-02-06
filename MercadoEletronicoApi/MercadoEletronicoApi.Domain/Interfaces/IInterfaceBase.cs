using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Domain.Interfaces
{
    public interface IInterfaceBase<TEntity>
    {
        Task<IList<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> RemoveAsync(TEntity entity);
    }
}
