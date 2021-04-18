using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;

namespace MercadoEletronico.Challenge.DataAccess.Repositories
{
    public class PedidoRepository: Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DatabaseContext context) 
            : base(context)
        {
        }
    }
}
