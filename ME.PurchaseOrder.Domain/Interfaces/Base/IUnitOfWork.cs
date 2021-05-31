using System.Threading.Tasks;

namespace ME.PurchaseOrder.Domain.Repositories.Base
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}