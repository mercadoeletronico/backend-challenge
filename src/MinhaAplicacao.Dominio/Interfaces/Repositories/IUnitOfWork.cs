using System;
using System.Threading.Tasks;

namespace MinhaAplicacao.Dominio.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
