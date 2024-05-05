using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Catalog.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Infrastructure.Persistence
{
    public static class CatalogItemSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Начальная дата для `TimeToItemExist`
            var startDate = new DateTime(2024, 5, 5);

            // Используем счетчик для увеличения даты на один день для каждого элемента
            var dateIncrement = 0;

            modelBuilder.Entity<CatalogItem>().HasData(
                new CatalogItem(
                    Guid.NewGuid(), "Margherita Pizza", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Classic cheese pizza with tomato and basil.", 9.99m, "margherita.jpg", "/images/margherita.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Pepperoni Pizza", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Pizza with pepperoni slices.", 11.99m, "pepperoni.jpg", "/images/pepperoni.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Caesar Salad", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Traditional Caesar salad with croutons and parmesan.", 7.99m, "caesar.jpg", "/images/caesar.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Spaghetti Bolognese", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Spaghetti with a rich Bolognese sauce.", 12.99m, "spaghetti.jpg", "/images/spaghetti.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Chicken Wings", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Chicken wings with spicy sauce.", 8.99m, "wings.jpg", "/images/wings.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Cheeseburger", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Classic cheeseburger with fries.", 10.99m, "cheeseburger.jpg", "/images/cheeseburger.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Fish and Chips", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Fried fish with chips.", 13.99m, "fishchips.jpg", "/images/fishchips.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Tiramisu", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Traditional Italian dessert with mascarpone.", 6.99m, "tiramisu.jpg", "/images/tiramisu.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Chicken Alfredo", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Chicken with creamy Alfredo sauce.", 14.99m, "alfredo.jpg", "/images/alfredo.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Margarita", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Classic Margarita cocktail.", 5.99m, "margarita.jpg", "/images/margarita.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Mojito", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Refreshing Mojito with mint and lime.", 5.99m, "mojito.jpg", "/images/mojito.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Pina Colada", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Tropical cocktail with pineapple and coconut.", 6.99m, "pinacolada.jpg", "/images/pinacolada.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Cappuccino", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Coffee with steamed milk.", 4.99m, "cappuccino.jpg", "/images/cappuccino.jpg"),
                new CatalogItem(
                    Guid.NewGuid(), "Espresso", startDate.AddDays(dateIncrement++), Guid.NewGuid(), "Strong coffee shot.", 2.99m, "espresso.jpg", "/images/espresso.jpg")
            );
        }
    }
}
