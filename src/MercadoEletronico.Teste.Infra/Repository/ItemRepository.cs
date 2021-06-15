using MercadoEletronico.Teste.Domain.Entities;
using MercadoEletronico.Teste.Infra.Context;
using MercadoEletronico.Teste.Infra.Interfaces;

namespace MercadoEletronico.Teste.Infra.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(MeuDbContext context) : base(context)
        {
        }
    }
}
