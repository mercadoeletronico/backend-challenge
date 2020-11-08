using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace MercadoEletronico.UnityTests
{
    public class TestePedido
    {
        [Fact(DisplayName = "Criar Pedido sem código")]
        public void Pedido_Sem_Codigo_Nao_Pode_Ser_Valido()
        {
            var pedido = new Pedido("", null);
            Assert.False(pedido.IsValid);
            Assert.Equal("'Codigo' deve ser informado.", pedido.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Criar Pedido com itens nulo")]
        public void Pedido_Com_Itens_Nulo_Nao_Pode_Ser_Valido()
        {
            var pedido = new Pedido("ABC", null);
            Assert.False(pedido.IsValid);
            Assert.Equal("'Itens' não pode ser nulo.", pedido.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Criar Pedido sem itens na lista")]
        public void Pedido_Com_Itens_Vazio_Nao_Pode_Ser_Valido()
        {
            var pedido = new Pedido("ABC", new List<ItemPedido>());
            Assert.False(pedido.IsValid);
            Assert.Equal("O pedido deve conter pelo menos um item de pedido.", pedido.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Criar Pedido válido")]
        public void Pedido_Valido()
        {
            var pedido = new Pedido("123-A", new List<ItemPedido>() { new ItemPedido("Teste", 1, 1) });
            Assert.True(pedido.IsValid);
            Assert.True(pedido.ValidationResult.Errors.Count == 0);
        }
    }
}
