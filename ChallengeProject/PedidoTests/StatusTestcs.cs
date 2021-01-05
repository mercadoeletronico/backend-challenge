using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pedido.Domain.Repositories;
using Pedido.Domain.Services;
using Pedido.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidoTests
{
    [TestClass]
    public class StatusTests
    {
        
    }

    [TestClass]
    public class PedidoTests
    {

        [TestMethod]
        public void InserirPedido()
        {
            //arrange  
           
            var pedido = new Pedido.Domain.Models.Pedido() { NumeroPedido = "123456" };
            pedido.ItemPedidos.Add(new Pedido.Domain.Models.ItemPedido() { Descricao = "TV", PrecoUnitario = 1830 });
            var mockPedidoService = new Mock<IPedidoService>();

            //act
            var mockPedido = new Mock<IPedidoService>();
            mockPedido.Setup(x => x.AddAsync(pedido)).Returns(true);

            IPedidoService pedidoService = mockPedidoService.Object;
            bool success = pedidoService.AddAsync(pedido);

            //assert
            Assert.AreEqual(success, true);
        }

    }
}
