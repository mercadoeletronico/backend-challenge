using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MercadoEletronico.UnityTests
{
    
    public class TesteItemPedido
    {
        [Fact(DisplayName = "Item de Pedido deve conter uma descrição")]
        public void Item_Pedido_Sem_Descricao()
        {
            var itemPedido = new ItemPedido(descricao: "", precoUnitario: 0, quantidade: 0);
            Assert.False(itemPedido.IsValid);
            Assert.Equal("'Descricao' deve ser informado.", itemPedido.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Descrição não pode ser muito curta")]
        public void Item_Pedido_Com_Descricao_Curta()
        {
            var itemPedido = new ItemPedido(descricao: "ab", precoUnitario: 0, quantidade: 0);
            Assert.False(itemPedido.IsValid);
            Assert.Contains("'Descricao' deve ser maior ou igual a 3 caracteres.", itemPedido.ValidationResult.Errors[0].ErrorMessage);
        }
    }
}
