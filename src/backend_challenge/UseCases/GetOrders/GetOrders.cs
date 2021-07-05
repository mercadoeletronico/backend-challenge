using AutoMapper;
using backend_challenge_data.Repositories.Interfaces;
using backend_challenge_datatypes.Entities;
using backend_challenge_datatypes.Responses;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Vrnz2.BaseContracts.DTOs.Base;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge.UseCases.GetOrders
{
    public class GetOrders
    {
        public class Model
        {
            public class Input
                : BaseDTO.Request, IRequest<Output>
            {
            }

            public class Output
                : BaseDTO.Response<List<GetOrderResponse>>
            {
            }
        }

        public class Handler
            : IRequestHandler<Model.Input, Model.Output>
        {
            #region Variables

            private IMapper _mapper;

            private readonly IServiceCollection _serviceColletion;

            #endregion

            #region Constructors

            public Handler(IMapper mapper, IServiceCollection serviceColletion)
            {
                _mapper = mapper;

                _serviceColletion = serviceColletion;
            }

            #endregion

            #region Methods

            public async Task<Model.Output> Handle(Model.Input request, CancellationToken cancellationToken)
            {
                var statusCode = HttpStatusCode.OK;
                List<GetOrderResponse> content = new List<GetOrderResponse>();

                using (var unitOfWork = _serviceColletion.BuildServiceProvider().GetService<IUnitOfWork>())
                {
                    unitOfWork.OpenConnection();

                    var orderRepository = unitOfWork.GetRepository<IOrderRepository>(nameof(Order));
                    var orderItemRepository = unitOfWork.GetRepository<IOrderItemRepository>(nameof(OrderItem));

                    var ordersData = await orderRepository.GetViewOrderFullData();

                    foreach (var viewOrder in ordersData)
                    {
                        var viewOrderItems = await orderItemRepository.GetByViewOrderItemOrderIdAsync(viewOrder.Id);

                        var order = _mapper.Map<GetOrderResponse>(viewOrder);

                        var orderItems = _mapper.Map<List<GetOrderItemResponse>>(viewOrderItems);

                        order.itens = orderItems;

                        content.Add(order);
                    }
                }

                return await Task.FromResult(new Model.Output { Success = true, StatusCode = (int)statusCode, Content = content });
            }

            #endregion
        }
    }
}
