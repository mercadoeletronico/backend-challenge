using System.Collections.Generic;
using ORDER.Infra.Data;
using ORDER.Infra.Repositories;
using ORDER.Tests.MoqSettings;
using NUnit.Framework;
using ORDER.Application.Dto;
using ORDER.Application.Services;
using ORDER.Application.Services.Interfaces;
using ORDER.Domain.Exceptions;

namespace ORDER.Tests.Services
{
    public class StatusServiceTest
    {
        private IStatusService _service;
        private Context _context;
        private OrderRepository _repo;

        [SetUp]
        public void Setup()
        {
            _context = FakeContext.GetFakeContext();
            _context.Database.EnsureCreated();
            _repo = new OrderRepository(_context);
            _service = new StatusService(_repo);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }


        [Test]
        public void FirstTest()
        {
            // Arrange
            var request = new StatusRequestDto
            {
                Status = "APROVADO",
                ApprovedItems = 3,
                ApprovedValue = 20,
                OrderId = "123456"
            };
            var response = new StatusResponseDto
            {
                OrderId = "123456",
                Status = new List<string>() {"APROVADO"}
            };
            // Act
            var requestResponse = _service.ApprovedStatus(request);

            // Assert
            Assert.AreEqual(expected: response, requestResponse);
        }

        [Test]
        public void SecondTest()
        {
            // Arrange
            var request = new StatusRequestDto
            {
                Status = "APROVADO",
                ApprovedItems = 3,
                ApprovedValue = 10,
                OrderId = "123456"
            };
            var response = new StatusResponseDto
            {
                OrderId = "123456",
                Status = new List<string>() {"APROVADO_VALOR_A_MENOR"}
            };
            // Act
            var requestResponse = _service.ApprovedStatus(request);

            // Assert
            Assert.AreEqual(expected: response, requestResponse);
        }

        [Test]
        public void ThirdTest()
        {
            // Arrange
            var request = new StatusRequestDto
            {
                Status = "APROVADO",
                ApprovedItems = 4,
                ApprovedValue = 21,
                OrderId = "123456"
            };
            var response = new StatusResponseDto
            {
                OrderId = "123456",
                Status = new List<string>() {"APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MAIOR"}
            };
            // Act
            var requestResponse = _service.ApprovedStatus(request);

            // Assert
            Assert.AreEqual(expected: response, requestResponse);
        }

        [Test]
        public void FourthTest()
        {
            // Arrange
            var request = new StatusRequestDto
            {
                Status = "REPROVADO",
                ApprovedItems = 0,
                ApprovedValue = 0,
                OrderId = "123456"
            };
            var response = new StatusResponseDto
            {
                OrderId = "123456",
                Status = new List<string>() {"REPROVADO"}
            };
            // Act
            var requestResponse = _service.ApprovedStatus(request);

            // Assert
            Assert.AreEqual(expected: response, requestResponse);
        }

        [Test]
        public void FifthTest()
        {
            // Arrange
            var request = new StatusRequestDto
            {
                Status = "REPROVADO",
                ApprovedItems = 0,
                ApprovedValue = 0,
                OrderId = "123456"
            };
            var response = new StatusResponseDto
            {
                OrderId = "123456",
                Status = new List<string>() {"REPROVADO"}
            };
            // Act
            var requestResponse = _service.ApprovedStatus(request);

            // Assert
            Assert.AreEqual(expected: response, requestResponse);
        }

        [Test]
        public void SixthTest()
        {
            // Arrange
            var request = new StatusRequestDto
            {
                Status = "APROVADO",
                ApprovedItems = 3,
                ApprovedValue = 20,
                OrderId = "123456-N"
            };
            // Act
            // Assert
            Assert.Throws<NotFoundOrderException>(() => _service.ApprovedStatus(request));
        }
    }
}