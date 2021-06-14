using MinhaAplicacao.Dominio.Entidades;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhaAplicacao.Dominio.Interfaces.Repositories
{
    public interface IPedidoRepositorio : IRepositorioBase<int, Pedido>
    {
        Task<Pedido> SelecionarPorNumero(string numero, params Expression<Func<Pedido, object>>[] propriedades);
    }
}
