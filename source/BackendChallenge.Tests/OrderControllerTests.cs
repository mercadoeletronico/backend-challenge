using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendChallenge.Api.Configurations;
using BackendChallenge.Api.Controllers;
using BackendChallenge.Api.Interfaces;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using BackendChallenge.Api.Services;
using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces;
using BackendChallenge.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BackendChallenge.Tests
{
    public class OrderControllerTests
    {
        private Mock<IOrderRepository> _orderRepository;
        private Mock<IItemRepository> _itemRepository;
        private IMapper _mapper;
        private Mock<IUnitOfWork> _uow;
        private IOrderService _orderService;
        private OrderController _controller;
        private List<Order> _orders { get; set; }

        public OrderControllerTests()
        {
            _orders = OrdersGeneration.Generate();

            _orderRepository = new Mock<IOrderRepository>();
            _orderRepository.Setup(repo => repo.AllAsync())
                .ReturnsAsync(_orders);
            _orderRepository.Setup(repo => repo.FindByIdAsync(1))
                .ReturnsAsync(_orders.First());

            _orderRepository.Setup(repo => repo.FindByIdAsync(2))
                .ReturnsAsync((Order)null);

            _itemRepository = new Mock<IItemRepository>();

            _mapper = AutoMapperConfigurations.GetMapperConfiguration()
                .CreateMapper();

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(uow => uow.CommitAsync())
                .ReturnsAsync(0);

            _orderService = new OrderService(
                _orderRepository.Object,
                _itemRepository.Object,
                _mapper,
                _uow.Object);

            _controller = new OrderController(_orderService);
        }

        #region Get All

        [Fact]
        public async Task GetAll_WhenCalled_ReturnsListOfOrders()
        {
            List<OrderResponse> orderResponse = await _controller.GetAll();
            Assert.True(orderResponse.Count == _orders.Count);
        }

        #endregion

        #region Get

        [Fact]
        public async Task Get_WhenCalledWithOrderId_ReturnsOrder()
        {
            ActionResult<OrderResponse> result = await _controller.Get(1);
            OrderResponse orderResponse = result.Value;
            Assert.True(orderResponse.Pedido == "1");
        }

        [Fact]
        public async Task Get_WhenCalledWithInvalidOrderId_ReturnsNotFound()
        {
            ActionResult<OrderResponse> result = await _controller.Get(2);
            NotFoundResult notFoundResult = (NotFoundResult)result.Result;
            Assert.True(notFoundResult.StatusCode == 404);
        }

        #endregion

        #region Post

        [Fact]
        public async Task Post_WhenCalled_ReturnsNewOrder()
        {
            NewOrderRequest newOrderRequest = new NewOrderRequest();
            newOrderRequest.Items = new List<NewItemRequest>();
            newOrderRequest.Items.Add(new NewItemRequest
            {
                Descricao = "Added new item",
                PrecoUnitario = 10,
                Qtd = 1
            });

            ActionResult<OrderResponse> result = await _controller.Post(newOrderRequest);
            OrderResponse orderResponse = result.Value;
            Assert.True(orderResponse.Items.First().Descricao == newOrderRequest.Items.First().Descricao);
        }

        #endregion

        #region Put

        [Fact]
        public async Task Put_WhenCalledWithOrderId_ReturnsNewOrderInformations()
        {
            NewOrderRequest newOrderRequest = new NewOrderRequest();
            newOrderRequest.Items = new List<NewItemRequest>();
            newOrderRequest.Items.Add(new NewItemRequest
            {
                Descricao = "Added new item",
                PrecoUnitario = 10,
                Qtd = 1
            });

            ActionResult<OrderResponse> result = await _controller.Put(1, newOrderRequest);
            OrderResponse orderResponse = result.Value;
            Assert.True(orderResponse.Items.First().Descricao == newOrderRequest.Items.First().Descricao);
        }

        [Fact]
        public async Task Put_WhenCalledWithInvalidOrderId_ReturnsNotFound()
        {
            NewOrderRequest newOrderRequest = new NewOrderRequest();
            newOrderRequest.Items = new List<NewItemRequest>();
            newOrderRequest.Items.Add(new NewItemRequest
            {
                Descricao = "Added new item",
                PrecoUnitario = 10,
                Qtd = 1
            });

            ActionResult<OrderResponse> result = await _controller.Put(2, newOrderRequest);
            NotFoundResult notFoundResult = (NotFoundResult)result.Result;
            Assert.True(notFoundResult.StatusCode == 404);
        }

        #endregion

        #region Delete

        [Fact]
        public async Task Delete_WhenCalledWithOrderId_ReturnsSuccess()
        {
            OkResult result = (OkResult)await _controller.Delete(1);
            Assert.True(result.StatusCode == 200);
        }

        [Fact]
        public async Task Delete_WhenCalledWithInvalidOrderId_ReturnsNotFound()
        {
            ActionResult<OrderResponse> result = await _controller.Delete(2);
            NotFoundResult notFoundResult = (NotFoundResult)result.Result;
            Assert.True(notFoundResult.StatusCode == 404);
        }

        #endregion
    }
}