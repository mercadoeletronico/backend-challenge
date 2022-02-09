using Xunit;
using System.Collections.Generic;
using MercadoEletronicoApi.Application.DTOs;
using MercadoEletronicoApi.Application.Interfaces;
using MercadoEletronicoApi.Infra.Data.Context;
using MercadoEletronicoApi.Infra.Data.Repositories;
using MercadoEletronicoApi.Tests.Moq;
using MercadoEletronicoApi.Application.Services;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using MercadoEletronicoApi.Application.Utils;

namespace MercadoEletronicoApi.Tests
{
    public class StatusServiceTest : IDisposable
    {
        private IStatusService _statusService;
        private MercadoEletronicoDbContext _context;
        private OrderRepository _orderRepository;

        public StatusServiceTest()
        {
            _context = FakeContext.GetFakeContext();
            _context.Database.EnsureCreated();
            _orderRepository = new OrderRepository(_context);
            _statusService = new StatusService(_orderRepository);
        }

        #region Tests

        [Fact(DisplayName = "Pedido não localizado no banco de dados - retorna status CODIGO_PEDIDO_INVALIDO")]
        public async Task TestAsyncOne()
        {
            // Arrange
            var statusRequest = new StatusRequestDTO
            {
                Status = "APROVADO",
                ApprovedItens = 2,
                ApprovedValue = 280,
                OrderId = "1346"
            };

            var response = new StatusResponseDTO
            {
                Status = new List<string>() { "CODIGO_PEDIDO_INVALIDO" },
                OrderId = "1346"
            };

            // Act
            var statusResponse = await _statusService.UpdateStatus(statusRequest);

            var responseJson = JsonConvert.SerializeObject(response);
            var statusResponseJson = JsonConvert.SerializeObject(statusResponse);

            // Assert
            Assert.Equal(responseJson, statusResponseJson);
        }

        [Fact(DisplayName = "Status REPROVADO - retorna status REPROVADO")]
        public async Task TestAsyncTwo()
        {
            // Arrange
            var statusRequest = new StatusRequestDTO
            {
                Status = "REPROVADO",
                ApprovedItens = 2,
                ApprovedValue = 280,
                OrderId = "1234"
            };

            var response = new StatusResponseDTO
            {
                Status = new List<string>() { "REPROVADO" },
                OrderId = "1234"
            };

            // Act
            var statusResponse = await _statusService.UpdateStatus(statusRequest);

            var responseJson = JsonConvert.SerializeObject(response);
            var statusResponseJson = JsonConvert.SerializeObject(statusResponse);

            // Assert
            Assert.Equal(responseJson, statusResponseJson);
        }

        [Fact(DisplayName = "Status APROVADO na requisição - mesma quantidade de itens e total entre requisição e pedido - retorna status APROVADO")]
        public async Task TestAsyncThree()
        {
            // Arrange
            var statusRequest = new StatusRequestDTO
            {
                Status = "APROVADO",
                ApprovedItens = 2,
                ApprovedValue = 150,
                OrderId = "1234"
            };

            var response = new StatusResponseDTO
            {
                Status = new List<string>() { "APROVADO" },
                OrderId = "1234"
            };

            // Act
            var statusResponse = await _statusService.UpdateStatus(statusRequest);

            var responseJson = JsonConvert.SerializeObject(response);
            var statusResponseJson = JsonConvert.SerializeObject(statusResponse);

            // Assert
            Assert.Equal(responseJson, statusResponseJson);
        }

        [Fact(DisplayName = "Status aprovado na requisição - valor do pedido menor na requisição - retorna status APROVADO_VALOR_A_MENOR")]
        public async Task TestAsyncFour()
        {
            // Arrange
            var statusRequest = new StatusRequestDTO
            {
                Status = "APROVADO",
                ApprovedItens = 1,
                ApprovedValue = 270,
                OrderId = "5678"
            };

            var response = new StatusResponseDTO
            {
                Status = new List<string>() { "APROVADO", StatusTypes.ApprovedValueLower },
                OrderId = "5678"
            };

            // Act
            var statusResponse = await _statusService.UpdateStatus(statusRequest);

            var responseJson = JsonConvert.SerializeObject(response);
            var statusResponseJson = JsonConvert.SerializeObject(statusResponse);

            // Assert
            Assert.Equal(responseJson, statusResponseJson);
        }

        [Fact(DisplayName = "Status aprovado na requisição - quantidade de itens menor na requisição - retorna status APROVADO_QTD_A_MENOR")]
        public async Task TestAsyncFive()
        {
            // Arrange
            var statusRequest = new StatusRequestDTO
            {
                Status = "APROVADO",
                ApprovedItens = 0,
                ApprovedValue = 280,
                OrderId = "5678"
            };

            var response = new StatusResponseDTO
            {
                Status = new List<string>() { "APROVADO", StatusTypes.ApprovedQuantityLower },
                OrderId = "5678"
            };

            // Act
            var statusResponse = await _statusService.UpdateStatus(statusRequest);

            var responseJson = JsonConvert.SerializeObject(response);
            var statusResponseJson = JsonConvert.SerializeObject(statusResponse);

            // Assert
            Assert.Equal(responseJson, statusResponseJson);
        }

        [Fact(DisplayName = "Status aprovado na requisição - valor do pedido maior na requisição - retorna status APROVADO_VALOR_A_MAIOR")]
        public async Task TestAsyncSix()
        {
            // Arrange
            var statusRequest = new StatusRequestDTO
            {
                Status = "APROVADO",
                ApprovedItens = 1,
                ApprovedValue = 300,
                OrderId = "5678"
            };

            var response = new StatusResponseDTO
            {
                Status = new List<string>() { "APROVADO", StatusTypes.ApprovedValueGreater },
                OrderId = "5678"
            };

            // Act
            var statusResponse = await _statusService.UpdateStatus(statusRequest);

            var responseJson = JsonConvert.SerializeObject(response);
            var statusResponseJson = JsonConvert.SerializeObject(statusResponse);

            // Assert
            Assert.Equal(responseJson, statusResponseJson);
        }

        [Fact(DisplayName = "Status aprovado na requisição - quantidade de itens maior na requisição - retorna status APROVADO e APROVADO_QTD_A_MAIOR")]
        public async Task TestAsyncSeven()
        {
            // Arrange
            var statusRequest = new StatusRequestDTO
            {
                Status = "APROVADO",
                ApprovedItens = 2,
                ApprovedValue = 280,
                OrderId = "5678"
            };

            var response = new StatusResponseDTO
            {
                Status = new List<string>() { "APROVADO", "APROVADO_QTD_A_MAIOR" },
                OrderId = "5678"
            };

            // Act
            var statusResponse = await _statusService.UpdateStatus(statusRequest);

            var responseJson = JsonConvert.SerializeObject(response);
            var statusResponseJson = JsonConvert.SerializeObject(statusResponse);

            // Assert
            Assert.Equal(responseJson, statusResponseJson);
        }

        #endregion

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }

    }
}
