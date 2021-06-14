using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using System.Threading.Tasks;

namespace MinhaAplicacao.Dominio.Interfaces.Services
{
    public interface IPedidoServico : IServicoBase<int, Pedido, IPedidoRepositorio>
    {
        Task<RetornoStatusPedido> ValidarPedido(StatusPedido statusPedido);
    }
}
