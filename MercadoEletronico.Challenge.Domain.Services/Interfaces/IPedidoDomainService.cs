using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Models.Requests;
using MercadoEletronico.Challenge.Domain.Models.Responses;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Domain.Services.Interfaces
{
    public interface IPedidoDomainService: IDomainService<Pedido>
    {
        Task<StatusResponse> AprovarPedido(StatusRequest request);
    }
}
