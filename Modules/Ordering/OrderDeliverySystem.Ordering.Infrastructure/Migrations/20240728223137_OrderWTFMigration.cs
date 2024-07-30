using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderWTFMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("1109ed6e-374b-4036-80d9-8a484406942e"), "123 Main St, Cityville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 22, 31, 37, 293, DateTimeKind.Utc).AddTicks(4199), null },
                    { new Guid("1cbe91d9-e72c-4ca2-b734-b0a5ea5e681b"), "456 Elm St, Townsville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 22, 31, 37, 293, DateTimeKind.Utc).AddTicks(4213), null },
                    { new Guid("212d2eff-4b13-4bb9-9d9a-7ddb43709496"), "321 Maple St, Hamletville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 22, 31, 37, 293, DateTimeKind.Utc).AddTicks(4224), null },
                    { new Guid("f25a8a09-11e2-4e2f-bc73-6b2a562a032a"), "789 Oak St, Villagetown", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 22, 31, 37, 293, DateTimeKind.Utc).AddTicks(4219), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("1109ed6e-374b-4036-80d9-8a484406942e"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("1cbe91d9-e72c-4ca2-b734-b0a5ea5e681b"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("212d2eff-4b13-4bb9-9d9a-7ddb43709496"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f25a8a09-11e2-4e2f-bc73-6b2a562a032a"));

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
    }
}
