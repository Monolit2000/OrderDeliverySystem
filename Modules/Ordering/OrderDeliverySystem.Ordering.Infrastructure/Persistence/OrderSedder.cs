using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Ordering.Domain.Orders;
using System;

namespace OrderDeliverySystem.Ordering.Infrastructure.Persistence
{
    public static class OrderSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Начальная дата для `OrderDate`
            var startDate = new DateTime(2024, 6, 1);

            // Используем счетчик для увеличения даты на один день для каждого заказа
            var dateIncrement = 0;

            var buyerIdString = Guid.Parse("4c024333-a4d1-42c3-a537-0df0dd9946ac");

            // Создание заказов с использованием метода CreateNew
            var orders = new[]
            {
                Order.CreateNew(
                    buyerId: buyerIdString,
                    address: "123 Main St, Cityville"
                ),
                Order.CreateNew(
                    buyerId: buyerIdString,
                    address: "456 Elm St, Townsville"
                ),
                Order.CreateNew(
                    buyerId: buyerIdString,
                    address: "789 Oak St, Villagetown"
                ),
                Order.CreateNew(
                    buyerId: buyerIdString,
                    address: "321 Maple St, Hamletville"
                )
            };

            // Добавление заказов в ModelBuilder
            modelBuilder.Entity<Order>().HasData(
                orders.Select(o => new
                {
                    o.Id,
                    o.BuyerId,
                    o.OrderDate,
                    o.Address,
                    o.Description,
                    o.OrderStatus
                }).ToArray()
            );
        }
    }
}