using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Domain.Models.Pedido>> ListAsync();

        Boolean AddAsync(Domain.Models.Pedido pedido);

        Task<Domain.Models.Pedido> FindByAsync(string numeroPedido);

        Boolean Update(Domain.Models.Pedido pedido);
        
        Boolean Remove(Domain.Models.Pedido pedido);
    }
}
