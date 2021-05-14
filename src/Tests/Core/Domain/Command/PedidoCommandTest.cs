using System.Collections.Generic;
using Api.Models.Request;
using Domain.Commands;
using Domain.Entities;
using Xunit;

namespace Tests.Core.Domain.Command
{
    public class PedidoCommandTest
    {

        [Fact]
        public void AcordoValidoTest()
        {
            var itensPedido = new List<PedidoItens>{
                new PedidoItens{
                    Descricao = "12",
                    PrecoUnitario = 2,
                    Quantidade =2
                }
            };

            var command = new PedidoCommand("12122", itensPedido);
            command.Validate();
            Assert.False(command.HasNotifications);
        }

        [Fact]
        public void AcordoNotificationTest()
        {
            var itensPedido = new List<PedidoItens>{
                new PedidoItens{
                    Descricao = "",
                    PrecoUnitario = 2,
                    Quantidade =2
                }
            };

            var command = new PedidoCommand("", itensPedido);
            command.Validate();
            Assert.True(command.HasNotifications);
        }
    }
}