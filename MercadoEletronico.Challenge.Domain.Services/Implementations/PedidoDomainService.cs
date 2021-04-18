using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Services.Interfaces;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;

namespace MercadoEletronico.Challenge.Domain.Services.Implementations
{
    public class PedidoDomainService: DomainService<Pedido>, IPedidoDomainService
    {
        public PedidoDomainService(IPedidoRepository repository) : base(repository) 
        {
        }
    }
}
