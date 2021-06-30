using System;
using System.Collections.Generic;
using BackendChallenge.Core.Entities;

namespace BackendChallenge.Tests.Helpers
{
    public static class OrdersGeneration
    {
        /// <summary>
        /// Generate new orders
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="itemsQuantity"></param>
        /// <returns>List of orders</returns>
        public static List<Order> Generate(int quantity = 3, int itemsQuantity = 3)
        {
            List<Order> orders = new List<Order>();
            Random random = new Random();

            for (int i = 1; i <= quantity; i++)
            {
                Order order = new Order();
                order.Id = i;
                order.Items = new List<Item>();

                for (int y = 1; y <= itemsQuantity; y++)
                {
                    Item item = new Item
                    {
                        Id = y,
                        Description = $"Item #{y} description",
                        Quantity = random.Next(1, 100),
                        Price = random.Next(1, 100),
                        OrderId = i
                    };

                    order.Items.Add(item);
                }

                orders.Add(order);
            }

            return orders;
        }
    }
}
