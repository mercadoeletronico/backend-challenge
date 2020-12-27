using Core.Entities.Pedido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetByCodigoAsync(string codigo);
        Task<IEnumerable<Pedido>> GetAllAsync();
        IEnumerable<Pedido> GetStatusPedido();
        Task<IEnumerable<Pedido>> AddAsync(Pedido entity);
        Task<IEnumerable<Pedido>> UpdateAsync(Pedido entity);
        void DeleteAsync(Pedido entity);
    }
}
