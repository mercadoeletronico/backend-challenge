using MercadoEletronicoApi.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;
using System.Collections.Generic;

namespace MercadoEletronicoApi.Tests
{
    public class OrderUnitTest
    {
        [Fact]
        public void CreateOrder_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Order(-1, "1234");
            
            action.Should()
                .Throw< Domain.Exceptions.OrderException>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateOrder_NullOrderCodeValue_DomainExceptionInvalidOrderCode()
        {
            Action action = () => new Order(1, "");
            
            action.Should()
                .Throw<Domain.Exceptions.OrderException>()
                .WithMessage("Order code is required.");
        }

        [Fact]
        public void CalculateTotalItemsInOrderWithoutItems_OrderExceptionNoItems()
        {
            Order pedido = new Order(1, "12345");
            
            Action action = () => pedido.GetTotalOrderItems();
            
            action.Should()
                .Throw<Domain.Exceptions.OrderException>()
                .WithMessage("Order without items.");
        }

        [Fact]
        public void CalculateTotalValueInOrderWithoutItems_OrderExceptionNoItems() 
        {
            Order pedido = new Order(1, "12345");
            pedido.Items = new List<Item>();

            Action action = () => pedido.GetTotalOrderAmount();

            action.Should()
                .Throw<Domain.Exceptions.OrderException>()
                .WithMessage("Unable to calculate total amount: order without items.");
        }

    }
}
