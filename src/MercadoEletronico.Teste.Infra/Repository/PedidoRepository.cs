using MercadoEletronico.Teste.Domain.Entities;
using MercadoEletronico.Teste.Infra.Context;
using MercadoEletronico.Teste.Infra.Interfaces;

namespace MercadoEletronico.Teste.Infra.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(MeuDbContext context) : base(context)
        {
        }
    }
}
