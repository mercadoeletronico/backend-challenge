using ME.Api.Controllers;
using MediatR;
using Moq;
using System;
using Xunit;

namespace ME.Api.Tests
{
    public class UnitTest1
    {
        PedidoController _controller;

        public UnitTest1()
        {
            IMediator mediator;
            _controller = new PedidoController(mediator);
        }


        [Fact]
        public void Test1()
        {

        }
    }
}
