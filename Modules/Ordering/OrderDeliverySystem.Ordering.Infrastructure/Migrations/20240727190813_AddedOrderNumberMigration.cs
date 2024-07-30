using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderNumberMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("380123b4-fa5f-49e6-a57d-dade94949d40"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("57ce6d9f-5bd0-4894-a4e2-e8748adf7cb3"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e88c7c1a-fe51-4bd2-9dd9-17f1b8fb7a8a"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e95ad8d7-11f6-4940-a841-a8b6f9ca26e1"));

            migrationBuilder.AddColumn<long>(
                name: "OrderNumber",
                schema: "ordering",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.InsertData(
                schema: "ordering",
                table: "Orders",
                columns: new[] { "Id", "Address", "BuyerId", "Description", "OrderDate", "PaymentId" },
                values: new object[,]
                {
                    { new Guid("380123b4-fa5f-49e6-a57d-dade94949d40"), "321 Maple St, Hamletville", new Guid("df3e4b3a-6704-4691-9b24-469588833b16"), "The order was submitted", new DateTime(2024, 7, 27, 0, 57, 0, 602, DateTimeKind.Utc).AddTicks(5108), null },
                    { new Guid("57ce6d9f-5bd0-4894-a4e2-e8748adf7cb3"), "123 Main St, Cityville", new Guid("df3e4b3a-6704-4691-9b24-469588833b16"), "The order was submitted", new DateTime(2024, 7, 27, 0, 57, 0, 602, DateTimeKind.Utc).AddTicks(5088), null },
                    { new Guid("e88c7c1a-fe51-4bd2-9dd9-17f1b8fb7a8a"), "456 Elm St, Townsville", new Guid("df3e4b3a-6704-4691-9b24-469588833b16"), "The order was submitted", new DateTime(2024, 7, 27, 0, 57, 0, 602, DateTimeKind.Utc).AddTicks(5102), null },
                    { new Guid("e95ad8d7-11f6-4940-a841-a8b6f9ca26e1"), "789 Oak St, Villagetown", new Guid("df3e4b3a-6704-4691-9b24-469588833b16"), "The order was submitted", new DateTime(2024, 7, 27, 0, 57, 0, 602, DateTimeKind.Utc).AddTicks(5105), null }
                });
        }
    }
}
