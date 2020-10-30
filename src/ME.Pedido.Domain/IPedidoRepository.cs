using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ME.Core.Data;

namespace ME.Pedido.Domain
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        bool VerificarSePedidoExiste(string pedidoId);
        Task<Pedido>? ObterPedidoPorId(string pedidoId);
        Task<List<Pedido>> ObterTodos();
        Pedido Adicionar(Pedido pedido);
        Pedido Alterar(Pedido pedido);
        void AlterarStatus(Pedido pedido);
        int Remover(Pedido pedido);

    }
}
