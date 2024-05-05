using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "catalog",
                table: "Catalog",
                columns: new[] { "CatalogItemId", "Description", "Name", "PictureFileName", "PictureUri", "Price", "ProductId", "TimeToItemExist" },
                values: new object[,]
                {
                    { new Guid("05eed828-315b-4208-8c64-630206254c9f"), "Coffee with steamed milk.", "Cappuccino", "cappuccino.jpg", "/images/cappuccino.jpg", 4.99m, new Guid("f1955656-ed0e-4656-a6b4-3d46973ece92"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("117d1453-54c5-4f10-a14d-8ae33cfc96fc"), "Strong coffee shot.", "Espresso", "espresso.jpg", "/images/espresso.jpg", 2.99m, new Guid("aaf82609-e484-411a-8bd1-05fffbae7095"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("1280a737-63f6-4466-8112-e70063620bde"), "Chicken with creamy Alfredo sauce.", "Chicken Alfredo", "alfredo.jpg", "/images/alfredo.jpg", 14.99m, new Guid("c58a4bae-34ba-4aa6-b057-3c52e5097f6d"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("4c92cc44-f54b-4418-9fd1-a5406352e224"), "Tropical cocktail with pineapple and coconut.", "Pina Colada", "pinacolada.jpg", "/images/pinacolada.jpg", 6.99m, new Guid("7d6556dc-134a-4501-8e47-ad6861675fd1"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("4e37cf76-a39d-48aa-a050-1fbb096d71ff"), "Traditional Caesar salad with croutons and parmesan.", "Caesar Salad", "caesar.jpg", "/images/caesar.jpg", 7.99m, new Guid("678d8c39-461d-4f38-87d5-c137b7f62ba1"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("5dc70ff4-6cff-4b4a-831e-10a9ad98b91d"), "Traditional Italian dessert with mascarpone.", "Tiramisu", "tiramisu.jpg", "/images/tiramisu.jpg", 6.99m, new Guid("08b36226-7e2e-461b-8c0b-db89f21ab751"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("6d47e656-e393-4a72-8385-21917bcf1d31"), "Classic cheese pizza with tomato and basil.", "Margherita Pizza", "margherita.jpg", "/images/margherita.jpg", 9.99m, new Guid("8496cfd3-0937-44b6-9e8d-05e0a2ac41a7"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("75e1ae4d-92ab-48f8-b1fa-cbd0ded2d36c"), "Classic Margarita cocktail.", "Margarita", "margarita.jpg", "/images/margarita.jpg", 5.99m, new Guid("5e30dd83-b66f-4da4-9cc9-17d4d3f4d268"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("82bc630c-1268-4820-8019-7e2bc9e3d61f"), "Chicken wings with spicy sauce.", "Chicken Wings", "wings.jpg", "/images/wings.jpg", 8.99m, new Guid("0328fbd1-3174-40b8-9af0-099ca7daee44"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("abbd36bd-ff32-4809-b234-77923d10fd4b"), "Spaghetti with a rich Bolognese sauce.", "Spaghetti Bolognese", "spaghetti.jpg", "/images/spaghetti.jpg", 12.99m, new Guid("678c30ce-682b-4902-aa35-33060cfe125b"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("b07925b2-71b7-46f3-a944-5c2c4de6bde1"), "Refreshing Mojito with mint and lime.", "Mojito", "mojito.jpg", "/images/mojito.jpg", 5.99m, new Guid("331c5e26-bc27-496f-88c6-e25a7fa30556"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("c1e17ead-2736-429e-921e-ff4171d4d4a8"), "Classic cheeseburger with fries.", "Cheeseburger", "cheeseburger.jpg", "/images/cheeseburger.jpg", 10.99m, new Guid("de4d0cca-5c1e-4bde-90b5-a7637978aa5a"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("c36276a9-7367-4aa3-9398-3415e32e90cd"), "Fried fish with chips.", "Fish and Chips", "fishchips.jpg", "/images/fishchips.jpg", 13.99m, new Guid("4aafa4e8-be63-42d2-bbf2-144af36ca4f6"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) },
                    { new Guid("d29d1efc-a9b9-442d-a582-251658d0bd92"), "Pizza with pepperoni slices.", "Pepperoni Pizza", "pepperoni.jpg", "/images/pepperoni.jpg", 11.99m, new Guid("44d7968c-eeaa-489e-803d-5074fae0b302"), new DateTime(2024, 5, 5, 3, 6, 26, 751, DateTimeKind.Local).AddTicks(6649) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("05eed828-315b-4208-8c64-630206254c9f"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("117d1453-54c5-4f10-a14d-8ae33cfc96fc"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("1280a737-63f6-4466-8112-e70063620bde"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("4c92cc44-f54b-4418-9fd1-a5406352e224"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("4e37cf76-a39d-48aa-a050-1fbb096d71ff"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("5dc70ff4-6cff-4b4a-831e-10a9ad98b91d"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("6d47e656-e393-4a72-8385-21917bcf1d31"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("75e1ae4d-92ab-48f8-b1fa-cbd0ded2d36c"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("82bc630c-1268-4820-8019-7e2bc9e3d61f"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("abbd36bd-ff32-4809-b234-77923d10fd4b"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("b07925b2-71b7-46f3-a944-5c2c4de6bde1"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("c1e17ead-2736-429e-921e-ff4171d4d4a8"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("c36276a9-7367-4aa3-9398-3415e32e90cd"));

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "Catalog",
                keyColumn: "CatalogItemId",
                keyValue: new Guid("d29d1efc-a9b9-442d-a582-251658d0bd92"));
        }
    }
}
