using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Models.Requests;
using MercadoEletronico.Challenge.Domain.Models.Responses;
using MercadoEletronico.Challenge.Util;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Application.Interfaces
{
    public interface IPedidoApplicationService : IApplicationService<Pedido>
    {
        Task<Result<StatusResponse>> AprovarPedido(StatusRequest request);
    }
}
