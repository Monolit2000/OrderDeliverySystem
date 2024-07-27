using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newBuyerAddedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("9b3ae29f-da00-467b-9d36-f3133c4ef913"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("9fa6fa03-ac70-4ec9-a055-5b31f87ab2c7"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b7468d36-b0f7-410a-a65d-9a81f7cef5a0"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f72a366c-32ba-4039-912b-093d856bf2d2"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "ordering",
                table: "Orders",
                columns: new[] { "Id", "Address", "BuyerId", "Description", "OrderDate", "PaymentId" },
                values: new object[,]
                {
                    { new Guid("9b3ae29f-da00-467b-9d36-f3133c4ef913"), "123 Main St, Cityville", new Guid("df3e4b3a-6704-4691-9b24-469588833b16"), "The order was submitted", new DateTime(2024, 7, 27, 0, 44, 14, 669, DateTimeKind.Utc).AddTicks(4100), null },
                    { new Guid("9fa6fa03-ac70-4ec9-a055-5b31f87ab2c7"), "456 Elm St, Townsville", new Guid("df3e4b3a-6704-4691-9b24-469588833b16"), "The order was submitted", new DateTime(2024, 7, 27, 0, 44, 14, 669, DateTimeKind.Utc).AddTicks(4144), null },
                    { new Guid("b7468d36-b0f7-410a-a65d-9a81f7cef5a0"), "789 Oak St, Villagetown", new Guid("df3e4b3a-6704-4691-9b24-469588833b16"), "The order was submitted", new DateTime(2024, 7, 27, 0, 44, 14, 669, DateTimeKind.Utc).AddTicks(4166), null },
                    { new Guid("f72a366c-32ba-4039-912b-093d856bf2d2"), "321 Maple St, Hamletville", new Guid("df3e4b3a-6704-4691-9b24-469588833b16"), "The order was submitted", new DateTime(2024, 7, 27, 0, 44, 14, 669, DateTimeKind.Utc).AddTicks(4169), null }
                });
        }
    }
}
