using System.Collections.Generic;
using ORDER.Infra.Data;
using ORDER.Infra.Repositories;
using ORDER.Tests.MoqSettings;
using NUnit.Framework;
using ORDER.Application.Services;
using ORDER.Domain.Dto;
using ORDER.Domain.Services;

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
                Status = new List<string>(){"APROVADO"}
            };
            // Act

            // Assert



        }
    }
}