using AutoMapper;
using MediatR;
using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using PedidosME.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PedidosME.Domain.Handlers
{
    public class ConsultarPedidoHandler : IRequestHandler<ConsultarPedidoDTO, PedidoDTO>
    {
        private readonly IPedidoServices pedidoServices;
        private readonly IMapper mapper;

        public ConsultarPedidoHandler(IPedidoServices pedidoServices, IMapper mapper)
        {
            this.pedidoServices = pedidoServices;
            this.mapper = mapper;
        }
        public async Task<PedidoDTO> Handle(ConsultarPedidoDTO request, CancellationToken cancellationToken)
        {
            var pedido = await pedidoServices.ObterPedido(request.CodigoPedido, cancellationToken);
            return mapper.Map<PedidoDTO>(pedido);
         
        }
    }
}
