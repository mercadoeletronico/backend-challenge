using MinhaAplicacao.Dominio.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace MinhaAplicacao.Infraestrutura.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MinhaAplicacaoDbContext _contexto;

        public UnitOfWork(MinhaAplicacaoDbContext contexto)
        {
            this._contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public async Task Commit()
        {
            await this._contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._contexto.Dispose();
                }

                this._disposed = true;
            }
        }

        ~UnitOfWork()
        {
            this.Dispose(false);
        }

        private bool _disposed;
    }
}
