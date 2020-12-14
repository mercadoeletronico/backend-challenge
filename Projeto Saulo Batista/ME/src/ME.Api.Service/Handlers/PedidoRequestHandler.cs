using AutoMapper;
using ME.Api.Models.DataModels;
using ME.Api.Models.View.Pedido;
using ME.Api.Service.Business.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ME.Api.Service.Handlers
{
    public class PedidoRequestHandler : IRequestHandler<PedidoUpdateRequest, IActionResult>,
                                        IRequestHandler<PedidoStatusRequest, IActionResult>,
                                        IRequestHandler<PedidoNewRequest, IActionResult>,
                                        IRequestHandler<PedidoDeleteRequest, IActionResult>,
                                        IRequestHandler<PedidoGetRequest, IActionResult>,
                                        IRequestHandler<PedidoGetAllRequest, IActionResult>
    {


        private readonly IMapper _mapper;
        private readonly IPedidoService _service;

        public PedidoRequestHandler(IPedidoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<IActionResult> Handle(PedidoGetRequest request, CancellationToken cancellationToken)
        {

            return Task.FromResult(_service.Get(request));
        }

        public Task<IActionResult> Handle(PedidoStatusRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.PostStatus(request));
        }

        public Task<IActionResult> Handle(PedidoNewRequest request, CancellationToken cancellationToken)
        {
            Pedido pedido = _mapper.Map<Pedido>(request);
            return Task.FromResult(_service.Post(pedido));
        }

        public Task<IActionResult> Handle(PedidoUpdateRequest request, CancellationToken cancellationToken)
        {
            //UPDATE
            return Task.FromResult(_service.Update(request));
        }

        public Task<IActionResult> Handle(PedidoDeleteRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.Delete(request));
        }

        public Task<IActionResult> Handle(PedidoGetAllRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.Get(request));
        }
    }
}
