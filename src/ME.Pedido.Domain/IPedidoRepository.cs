using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ME.Core.Data;

namespace ME.Pedido.Domain
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<bool> VerificarSePedidoExisteAsync(string pedidoId);
        Task<Pedido>? ObterPedidoPorId(string pedidoId);
        Task<List<Pedido>> ObterTodos();
        void Adicionar(Pedido pedido);
        void AlterarStatus(Pedido pedido);
        void Remover(Pedido pedido);

    }
}
