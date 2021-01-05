using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Domain.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<Domain.Models.Pedido>> ListAsync();

        Task<Domain.Models.Pedido> FindAsync(string numeroPedido);

        Boolean AddAsync(Domain.Models.Pedido pedido);

        Boolean Update(Domain.Models.Pedido pedido);

        Boolean Remove(Domain.Models.Pedido pedido);
    }
        
}
