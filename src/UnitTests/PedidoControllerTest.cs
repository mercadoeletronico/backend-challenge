using API.Controllers;
using AutoFixture;
using AutoMapper;
using Core.Enums;
using Core.Helpers;
using Core.Interfaces.Repositories;
using Core.Models.Requests.Pedido;
using Core.Models.Responses.Pedido;
using Core.Queries.ParametrizacaoRegra.Handler;
using Core.Queries.Pedido;
using Cqrs.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnitTests.Data;
using Xunit;

namespace UnitTests
{
    public class PedidoControllerTest
    {
        #region propperties
        private Mock<IMediator> _mediator;
        private Mock<ILogger<PedidoController>> _logger;

        private Mock<IPedidoRepository> _pedidoRepository;
        private Mock<IMapper> _mapper;
        #endregion

        #region constructors
        public PedidoControllerTest()
        {           
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<PedidoController>>();
            _pedidoRepository = new Mock<IPedidoRepository>();
            _mapper = new Mock<IMapper>();
        }
        #endregion

        #region unit tests
        [Fact]
        public void StatusPedido_Success_Result_UT()
        {
            //Arrange
            StatusPedidoRequest request = new StatusPedidoRequest
            {
                ItensAprovados = 3,
                Pedido = "123456",
                Status = "APROVADO",
                ValorAprovado = 20
            };

            var query = new GetStatusPedidoQuery(request);
            _mediator.Setup(x => x.Send(It.IsAny<GetStatusPedidoQuery>(), new CancellationToken())).
                ReturnsAsync(new Result<StatusPedidoResponse> { Value = new StatusPedidoResponse("123456") });
            var pedidoController = new PedidoController(_mediator.Object,_logger.Object);

            //Action
            var result =  pedidoController.GetStatusPedido(request);

            var value = (OkObjectResult)result.Result;

            //Assert
            Assert.IsType< Result<StatusPedidoResponse>>(value.Value);
        }

        [Fact]
        public void Status_Pedido_Reprovado_Result_UT()
        {
            //Arrange
            StatusPedidoRequest request = new StatusPedidoRequest
            {
                ItensAprovados = 3,
                Pedido = "123456",
                Status = "REPROVADO",
                ValorAprovado = 20
            };

            var pedidoRepoTest = new PedidoRepositoryTest();
            Task<IEnumerable<Core.Entities.Pedido.Pedido>> resultPedido = pedidoRepoTest.pedidoRepository.GetByCodigoAsync(request.Pedido);
            _pedidoRepository.Setup(x => x.GetByCodigoAsync(request.Pedido)).Returns(resultPedido);
            GetStatusPedidoQuery getStatusPedidoQuery = new GetStatusPedidoQuery(request);

            //Action
            var handler = new GetStatusPedidoQueryHandler(_pedidoRepository.Object, _mapper.Object);
            var result = handler.Handle(getStatusPedidoQuery, new CancellationToken()).Result;

            //Assert
            Assert.Contains(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.REPROVADO), result.Value.Status);
        }

        [Fact]
        public void Status_Pedido_Codigo_Invalido_Result_UT()
        {
            //Arrange
            StatusPedidoRequest request = new StatusPedidoRequest
            {
                ItensAprovados = 3,
                Pedido = "123456-N",
                Status = "APROVADO",
                ValorAprovado = 20
            };

            var pedidoRepoTest = new PedidoRepositoryTest();
            Task<IEnumerable<Core.Entities.Pedido.Pedido>> resultPedido = pedidoRepoTest.pedidoRepository.GetByCodigoAsync(request.Pedido);
            _pedidoRepository.Setup(x => x.GetByCodigoAsync(request.Pedido)).Returns(resultPedido);
            GetStatusPedidoQuery getStatusPedidoQuery = new GetStatusPedidoQuery(request);

            //Action
            var handler = new GetStatusPedidoQueryHandler(_pedidoRepository.Object, _mapper.Object);
            var result = handler.Handle(getStatusPedidoQuery, new CancellationToken()).Result;

            //Assert
            Assert.Contains(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.CODIGO_PEDIDO_INVALIDO), result.Value.Status);
        }

        [Fact]
        public void Status_Pedido_Aprovado_Result_UT()
        {
            //Arrange
            StatusPedidoRequest request = new StatusPedidoRequest
            {
                ItensAprovados = 3,
                Pedido = "123456",
                Status = "APROVADO",
                ValorAprovado = 20
            };

            var pedidoRepoTest = new PedidoRepositoryTest();
            Task<IEnumerable<Core.Entities.Pedido.Pedido>> resultPedido = pedidoRepoTest.pedidoRepository.GetByCodigoAsync(request.Pedido);
            _pedidoRepository.Setup(x => x.GetByCodigoAsync(request.Pedido)).Returns(resultPedido);
            GetStatusPedidoQuery getStatusPedidoQuery = new GetStatusPedidoQuery(request);

            //Action
            var handler = new GetStatusPedidoQueryHandler(_pedidoRepository.Object,_mapper.Object);
            var result = handler.Handle(getStatusPedidoQuery, new CancellationToken()).Result;

            //Assert
            Assert.Contains(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO), result.Value.Status);
        }

        [Fact]
        public void Status_Pedido_Quantidade_Maior_Result_UT()
        {
            //Arrange
            StatusPedidoRequest request = new StatusPedidoRequest
            {
                ItensAprovados = 4,
                Pedido = "123456",
                Status = "APROVADO",
                ValorAprovado = 20
            };

            var pedidoRepoTest = new PedidoRepositoryTest();
            Task<IEnumerable<Core.Entities.Pedido.Pedido>> resultPedido = pedidoRepoTest.pedidoRepository.GetByCodigoAsync(request.Pedido);
            _pedidoRepository.Setup(x => x.GetByCodigoAsync(request.Pedido)).Returns(resultPedido);
            GetStatusPedidoQuery getStatusPedidoQuery = new GetStatusPedidoQuery(request);

            //Action
            var handler = new GetStatusPedidoQueryHandler(_pedidoRepository.Object, _mapper.Object);
            var result = handler.Handle(getStatusPedidoQuery, new CancellationToken()).Result;

            //Assert
            Assert.Contains(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO_QTD_A_MAIOR), result.Value.Status);
        }

        [Fact]
        public void Status_Pedido_Quantidade_Menor_Result_UT()
        {
            //Arrange
            StatusPedidoRequest request = new StatusPedidoRequest
            {
                ItensAprovados = 2,
                Pedido = "123456",
                Status = "APROVADO",
                ValorAprovado = 20
            };

            var pedidoRepoTest = new PedidoRepositoryTest();
            Task<IEnumerable<Core.Entities.Pedido.Pedido>> resultPedido = pedidoRepoTest.pedidoRepository.GetByCodigoAsync(request.Pedido);
            _pedidoRepository.Setup(x => x.GetByCodigoAsync(request.Pedido)).Returns(resultPedido);
            GetStatusPedidoQuery getStatusPedidoQuery = new GetStatusPedidoQuery(request);

            //Action
            var handler = new GetStatusPedidoQueryHandler(_pedidoRepository.Object, _mapper.Object);
            var result = handler.Handle(getStatusPedidoQuery, new CancellationToken()).Result;

            //Assert
            Assert.Contains(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO_QTD_A_MENOR), result.Value.Status);
        }

        [Fact]
        public void Status_Pedido_Valor_Menor_Result_UT()
        {
            //Arrange
            StatusPedidoRequest request = new StatusPedidoRequest
            {
                ItensAprovados = 3,
                Pedido = "123456",
                Status = "APROVADO",
                ValorAprovado = 15
            };

            var pedidoRepoTest = new PedidoRepositoryTest();
            Task<IEnumerable<Core.Entities.Pedido.Pedido>> resultPedido = pedidoRepoTest.pedidoRepository.GetByCodigoAsync(request.Pedido);
            _pedidoRepository.Setup(x => x.GetByCodigoAsync(request.Pedido)).Returns(resultPedido);
            GetStatusPedidoQuery getStatusPedidoQuery = new GetStatusPedidoQuery(request);

            //Action
            var handler = new GetStatusPedidoQueryHandler(_pedidoRepository.Object, _mapper.Object);
            var result = handler.Handle(getStatusPedidoQuery, new CancellationToken()).Result;

            //Assert
            Assert.Contains(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO_VALOR_A_MENOR), result.Value.Status);
        }

        [Fact]
        public void Status_Pedido_Valor_Maior_Result_UT()
        {
            //Arrange
            StatusPedidoRequest request = new StatusPedidoRequest
            {
                ItensAprovados = 3,
                Pedido = "123456",
                Status = "APROVADO",
                ValorAprovado = 21
            };

            var pedidoRepoTest = new PedidoRepositoryTest();
            Task<IEnumerable<Core.Entities.Pedido.Pedido>> resultPedido = pedidoRepoTest.pedidoRepository.GetByCodigoAsync(request.Pedido);
            _pedidoRepository.Setup(x => x.GetByCodigoAsync(request.Pedido)).Returns(resultPedido);
            GetStatusPedidoQuery getStatusPedidoQuery = new GetStatusPedidoQuery(request);

            //Action
            var handler = new GetStatusPedidoQueryHandler(_pedidoRepository.Object, _mapper.Object);
            var result = handler.Handle(getStatusPedidoQuery, new CancellationToken()).Result;

            //Assert
            Assert.Contains(EnumHelper.ObterDescricaoEnum(EnumStatusPedido.APROVADO_VALOR_A_MAIOR), result.Value.Status);
        }
        #endregion
    }
}
