using System;
using System.Collections.Generic;
using ME.Pedido.Domain.ValueObjects;
using ME.Pedido.Domain;
using Xunit;

namespace ME.Pedido.Domain.Tests
{
    public class PedidoTests
    {
        [Fact]
        public void Pedido_Aprovar_QTDeValorIguais()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>(){ "APROVADO" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(3, 20);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Aprovar_ValorMenor()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_VALOR_A_MENOR" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(3, 10);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Aprovar_ValorMaior()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_VALOR_A_MAIOR" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(3, 21);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Aprovar_QTDeValorMaior()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MAIOR" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(4, 31);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Aprovar_QTDeValorMenor()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_VALOR_A_MENOR", "APROVADO_QTD_A_MENOR" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(2, 19);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Aprovar_QtdMenor()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_QTD_A_MENOR" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(2, 20);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Aprovar_QtdMaiorValorMenor()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_VALOR_A_MENOR", "APROVADO_QTD_A_MAIOR" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(5, 19);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Aprovar_QtdMenorValorMaior()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MENOR" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(1, 21);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Reprovado()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "REPROVADO" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(0, 0);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Invalido_SemItens()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, -1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            var resultadoEsperado = new StatusPedidoResponse()
            {
                pedido = "123456",
                status = new List<string>() { "REPROVADO" }
            };

            //Act
            var resultadoAtual = pedido.AvaliarPedido(0, 0);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoAtual);

        }

        [Fact]
        public void Pedido_Invalido_QtdNegativa()
        {
            //Arrange & Act
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, -1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            //Assert
            Assert.False(pedido.IsValid());

        }

        [Fact]
        public void Pedido_Invalido_ValorNegativo()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, -1),
                new PedidoItem("123456","Item B", -5, 2)
            });


            //Act

            //Assert
            Assert.False(pedido.IsValid());

        }

        [Fact]
        public void Pedido_Invalido_ItemSemPedidoID()
        {
            //Arrange
            var pedido = new Domain.Pedido("123456", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("","Item B", 5, 2)
            });

            //Act

            //Assert
            Assert.False(pedido.IsValid());

        }


        [Fact]
        public void Pedido_Invalido_PedidoSemPedidoID()
        {
            //Arrange
            var pedido = new Domain.Pedido("", new List<PedidoItem>()
            {
                new PedidoItem("123456","Item A", 10, 1),
                new PedidoItem("123456","Item B", 5, 2)
            });

            //Act

            //Assert
            Assert.False(pedido.IsValid());

        }

    }
}
