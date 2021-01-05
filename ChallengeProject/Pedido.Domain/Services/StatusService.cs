using Pedido.Domain.Models;
using Pedido.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Domain.Services
{
    public class StatusService : IStatusService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public StatusService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        
        public async Task<Models.PedidoStatusResponse> MudarSituacaoPedido(PedidoStatusRequest pedidoRequest)
        {
            PedidoStatusResponse statusResponse = null;

            var pedido = await _pedidoRepository.FindByAsync(pedidoRequest.Pedido);

            var validation = new Validators.ValidatorPedido().Validate(pedido);

            if (validation.IsValid)
                pedido.AlterarStatusPedido(pedidoRequest);
            else
                pedido.StatusPedido.Add(Status.CODIGO_PEDIDO_INVALIDO);

            statusResponse = new PedidoStatusResponse().RetornarStatusPedido(pedido);
                           
            
            return statusResponse;

        }
    }
}
