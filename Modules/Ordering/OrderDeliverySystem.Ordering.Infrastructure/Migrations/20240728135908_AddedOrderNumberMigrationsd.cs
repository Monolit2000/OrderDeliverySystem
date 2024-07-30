using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderNumberMigrationsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("2ae33652-5986-4334-b2c8-ecc4d9037620"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7677affc-0f06-45a1-9282-5b253a65a25d"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("99aa8267-c4dc-45a3-b820-9e4052465150"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("c5d97d85-f837-4bce-a36b-b8b35fd3e1af"));

            migrationBuilder.InsertData(
                schema: "ordering",
                table: "Orders",
                columns: new[] { "Id", "Address", "BuyerId", "Description", "OrderDate", "PaymentId" },
                values: new object[,]
                {
                    { new Guid("1698be4c-0fc6-4eb0-a341-377c6ca9ed5e"), "789 Oak St, Villagetown", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 13, 59, 8, 238, DateTimeKind.Utc).AddTicks(6574), null },
                    { new Guid("459efc43-e928-412f-a000-d5639ac52826"), "456 Elm St, Townsville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 13, 59, 8, 238, DateTimeKind.Utc).AddTicks(6570), null },
                    { new Guid("708a0b4d-8add-45f9-a87c-a3f87c2b9800"), "321 Maple St, Hamletville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 13, 59, 8, 238, DateTimeKind.Utc).AddTicks(6577), null },
                    { new Guid("95cf8c3e-990e-4567-9ff6-f74e90cc23ad"), "123 Main St, Cityville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 13, 59, 8, 238, DateTimeKind.Utc).AddTicks(6560), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("1698be4c-0fc6-4eb0-a341-377c6ca9ed5e"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("459efc43-e928-412f-a000-d5639ac52826"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("708a0b4d-8add-45f9-a87c-a3f87c2b9800"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("95cf8c3e-990e-4567-9ff6-f74e90cc23ad"));

            migrationBuilder.InsertData(
                schema: "ordering",
                table: "Orders",
                columns: new[] { "Id", "Address", "BuyerId", "Description", "OrderDate", "PaymentId" },
                values: new object[,]
                {
                    { new Guid("2ae33652-5986-4334-b2c8-ecc4d9037620"), "321 Maple St, Hamletville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 27, 19, 8, 12, 656, DateTimeKind.Utc).AddTicks(6960), null },
                    { new Guid("7677affc-0f06-45a1-9282-5b253a65a25d"), "123 Main St, Cityville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 27, 19, 8, 12, 656, DateTimeKind.Utc).AddTicks(6931), null },
                    { new Guid("99aa8267-c4dc-45a3-b820-9e4052465150"), "789 Oak St, Villagetown", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 27, 19, 8, 12, 656, DateTimeKind.Utc).AddTicks(6957), null },
                    { new Guid("c5d97d85-f837-4bce-a36b-b8b35fd3e1af"), "456 Elm St, Townsville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 27, 19, 8, 12, 656, DateTimeKind.Utc).AddTicks(6954), null }
                });
        }
    }
}
