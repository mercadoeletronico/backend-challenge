using AutoMapper;
using backend_challenge_data.Repositories.Interfaces;
using backend_challenge_datatypes.Entities;
using backend_challenge_datatypes.Responses;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Vrnz2.BaseContracts.DTOs.Base;
using Vrnz2.Infra.Repository.Interfaces.Base;

namespace backend_challenge.UseCases.AddOrder
{
    public class AddOrder
    {
        public class Model
        {
            public class Input
                : BaseDTO.Request, IRequest<Output>
            {
                public string CodigoComprador { get; set; }
                public string CodigoVendedor { get; set; }

                public List<InputItems> Itens { get; set; }
            }

            public class InputItems
            {
                public string CodigoReferencia { get; set; }
                public decimal Quantidade { get; set; }
            }

            public class Output
                : BaseDTO.Response<GetOrderResponse>
            {
            }
        }

        public class AddOrderValidator 
            : AbstractValidator<Model.Input>
        {
            public AddOrderValidator()
            {
                RuleFor(request => request.CodigoComprador)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Código do Comprador é obrigatório.");

                RuleFor(request => request.CodigoVendedor)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Código do Vendedor é obrigatório.");

                RuleFor(request => request.Itens)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Código do Vendedor é obrigatório.");
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
                GetOrderResponse content = new();
                var result = false;

                var requestValidation = IsValid(request);

                if (requestValidation.Valid)
                {
                    using (var unitOfWork = _serviceColletion.BuildServiceProvider().GetService<IUnitOfWork>())
                    {
                        unitOfWork.OpenConnection();

                        unitOfWork.Begin();

                        try
                        {
                            var customer = await GetCustomer(unitOfWork, request.CodigoComprador);
                            var seller = await GetSeller(unitOfWork, request.CodigoVendedor);

                            var resultAddOrder = await AddOrder(unitOfWork, customer.Id, seller.Id);

                            result = resultAddOrder.Success;

                            if (result)
                            {
                                var orderItems = new List<GetOrderItemResponse>();

                                content.pedido = resultAddOrder.Order.Number;

                                var productRepository = unitOfWork.GetRepository<IProductRepository>(nameof(Product));
                                var priceListRepository = unitOfWork.GetRepository<IPriceListRepository>(nameof(PriceList));
                                var orderItemRepository = unitOfWork.GetRepository<IOrderItemRepository>(nameof(OrderItem));

                                request.Itens.ForEach(item =>
                                {
                                    var product = GetProduct(productRepository, item.CodigoReferencia).GetAwaiter().GetResult();

                                    var productPrice = GetProductPrice(priceListRepository, product.Id, seller.Id).GetAwaiter().GetResult();

                                    result &= AddOrderItem(orderItemRepository, resultAddOrder.Order.Id, product.Id, item.Quantidade, productPrice.UnitaryValue).GetAwaiter().GetResult();

                                    orderItems.Add(new GetOrderItemResponse 
                                    {
                                        codigoProduto = product.ReferenceCode,
                                        descricao = product.Description,
                                        precoUnitario = productPrice.UnitaryValue,
                                        qtd = item.Quantidade
                                    });
                                });

                                content.itens = orderItems;
                            }

                            if (result)
                                unitOfWork.Commit();
                            else
                                unitOfWork.Rollback();
                        }
                        catch (Exception)
                        {
                            unitOfWork.Rollback();

                            throw;
                        }
                    }

                    return await Task.FromResult(new Model.Output { Success = result, StatusCode = (int)statusCode, Message = "Pedido inserido com sucesso", Content = content });
                }
                else 
                {
                    return await Task.FromResult(new Model.Output { Success = result, StatusCode = (int)HttpStatusCode.BadRequest, Message = requestValidation.ErrorMessage, Content = content });
                }
            }

            private (bool Valid, string ErrorMessage) IsValid(Model.Input request)
            {
                var validatorInstance = _serviceColletion.BuildServiceProvider().GetService<IValidator<Model.Input>>();

                var validator = validatorInstance.Validate(request);

                if (validator.IsValid)
                {
                    return (true, string.Empty);
                }
                else 
                {
                    var errorMessage = string.Empty;

                    foreach (var error in validator.Errors)
                        errorMessage = string.Concat(errorMessage, error.ErrorMessage, " - ");

                    return (false, errorMessage);
                }
            }

            private async Task<Customer> GetCustomer(IUnitOfWork unitOfWork, string codigoComprador) 
            {
                var customerRepository = unitOfWork.GetRepository<ICustomerRepository>(nameof(Customer));

                return await customerRepository.GetByCodeAsync(codigoComprador);
            }

            private async Task<Seller> GetSeller(IUnitOfWork unitOfWork, string codigoVendedor)
            {
                var sellerRepository = unitOfWork.GetRepository<ISellerRepository>(nameof(Seller));

                return await sellerRepository.GetByCodeAsync(codigoVendedor);
            }

            private async Task<Product> GetProduct(IProductRepository productRepository, string productReferenceCode)
                => await productRepository.GetByReferenceCodeAsync(productReferenceCode);

            private async Task<PriceList> GetProductPrice(IPriceListRepository priceListRepository, Guid productId, Guid sellerId)
                => await priceListRepository.GetByProductIdSellerIdAsync(productId, sellerId);

            private async Task<(bool Success, Order Order)> AddOrder(IUnitOfWork unitOfWork, Guid customerId, Guid sellerId)
            {
                var orderRepository = unitOfWork.GetRepository<IOrderRepository>(nameof(Order));

                return await orderRepository.InsertAsync(new Order
                {
                    CustomerId = customerId,
                    SellerId = sellerId,
                    Number = OrderNumberGenerator()
                });
            }

            private async Task<bool> AddOrderItem(IOrderItemRepository orderItemRepository, Guid orderId, Guid productId, decimal quantity, decimal unitaryValue)
                => await orderItemRepository.InsertAsync(new OrderItem
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                    UnitaryValue = unitaryValue,
                });

            private string OrderNumberGenerator() 
                => string.Concat(DateTime.UtcNow.ToString("yyyyMMdd"), new Random().Next(0, 999999999));

            #endregion
        }
    }
}
