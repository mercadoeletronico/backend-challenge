using MercadoEletronico.Utilities.Data;
using Microsoft.EntityFrameworkCore;
using PedidosME.Data.DataContext;
using PedidosME.Domain.Entities.PedidoAggregate;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.Data.Repositories
{
    public class PedidoRepository :  GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DbContext context) : base(context)
        {
            context.Database.EnsureCreated();
        }

        public Task<Pedido> AlterarStatusPedidoAsync(string codigoPedido, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        
        public async Task<Pedido> ObterPedidoPorCodigo(string codigoPedido, CancellationToken cancellationToken)
        {

            return await GetAll(
                    noTracking: true,
                    includeProperties: "Itens",
                    filter: p => p.Codigo.Trim().ToLower() == codigoPedido.Trim().ToLower()
                ).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
