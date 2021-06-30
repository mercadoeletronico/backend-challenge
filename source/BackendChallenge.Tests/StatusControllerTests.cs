using System.Linq;
using System.Threading.Tasks;
using BackendChallenge.Api.Controllers;
using BackendChallenge.Api.Interfaces;
using BackendChallenge.Api.Model.Request;
using BackendChallenge.Api.Model.Response;
using BackendChallenge.Api.Services;
using BackendChallenge.Core.Entities;
using BackendChallenge.Core.Interfaces;
using BackendChallenge.Tests.Helpers;
using Moq;
using Xunit;

namespace BackendChallenge.Tests
{
    public class StatusControllerTests
    {
        private Mock<IOrderRepository> _orderRepository;
        private IOrderStatusService _orderStatusService;
        private StatusController _controller;
        private Order _order { get; set; }

        private OrderStatusRequest _request { get; set; }

        public StatusControllerTests()
        {
            _order = OrdersGeneration.Generate(1)
                .First();

            _request = new OrderStatusRequest();
            _request.Status = "APROVADO";
            _request.Pedido = _order.Id.ToString();

            _request.ItensAprovados = 0;
            _request.ValorAprovado = 0;

            foreach (Item item in _order.Items)
            {
                _request.ItensAprovados += item.Quantity;
                _request.ValorAprovado += item.Quantity * item.Price;
            }

            _orderRepository = new Mock<IOrderRepository>();
            _orderRepository.Setup(repo => repo.FindByIdAsync(1))
                .ReturnsAsync(_order);

            _orderRepository.Setup(repo => repo.FindByIdAsync(2))
                .ReturnsAsync((Order)null);

            _orderStatusService = new OrderStatusService(_orderRepository.Object);
            _controller = new StatusController(_orderStatusService);
        }

        [Fact]
        public async Task Post_WhenCalled_ReturnStatus_APROVADO()
        {
            OrderStatusResponse response = await _controller.Post(_request);
            Assert.True(response.Status.First() == "APROVADO");
        }

        [Fact]
        public async Task Post_WhenCalledWithFewerApprovedItems_ReturnStatus_APROVADO_QTD_A_MENOR()
        {
            _request.ItensAprovados--;

            OrderStatusResponse response = await _controller.Post(_request);
            Assert.True(response.Status.First() == "APROVADO_QTD_A_MENOR");
        }

        [Fact]
        public async Task Post_WhenCalledWithHighestAmountOfApprovedItems_ReturnStatus_APROVADO_QTD_A_MAIOR()
        {
            _request.ItensAprovados++;

            OrderStatusResponse response = await _controller.Post(_request);
            Assert.True(response.Status.First() == "APROVADO_QTD_A_MAIOR");
        }

        [Fact]
        public async Task Post_WhenCalledWithLowerTotalOrderValue_ReturnStatus_APROVADO_VALOR_A_MENOR()
        {
            _request.ValorAprovado--;

            OrderStatusResponse response = await _controller.Post(_request);
            Assert.True(response.Status.First() == "APROVADO_VALOR_A_MENOR");
        }

        [Fact]
        public async Task Post_WhenCalledWithHigherTotalOrderValue_ReturnStatus_APROVADO_VALOR_A_MAIOR()
        {
            _request.ValorAprovado++;

            OrderStatusResponse response = await _controller.Post(_request);
            Assert.True(response.Status.First() == "APROVADO_VALOR_A_MAIOR");
        }

        [Fact]
        public async Task Post_WhenCalledWithInvalidOrderId_ReturnStatus_CODIGO_PEDIDO_INVALIDO()
        {
            _request.Pedido = "2";

            OrderStatusResponse response = await _controller.Post(_request);
            Assert.True(response.Status.First() == "CODIGO_PEDIDO_INVALIDO");
        }
    }
}