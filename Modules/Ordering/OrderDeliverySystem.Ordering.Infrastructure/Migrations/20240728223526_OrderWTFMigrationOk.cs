using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderWTFMigrationOk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Deadline",
                schema: "ordering",
                table: "OrderItems",
                newName: "DeliveryDateTime");

            migrationBuilder.InsertData(
                schema: "ordering",
                table: "Orders",
                columns: new[] { "Id", "Address", "BuyerId", "Description", "OrderDate", "PaymentId" },
                values: new object[,]
                {
                    { new Guid("13f46e83-b887-4ed8-814c-822c17dd9d12"), "789 Oak St, Villagetown", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 22, 35, 25, 312, DateTimeKind.Utc).AddTicks(4380), null },
                    { new Guid("3e4d205a-bbbf-4a47-9a65-628d2db57c39"), "456 Elm St, Townsville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 22, 35, 25, 312, DateTimeKind.Utc).AddTicks(4375), null },
                    { new Guid("8a311fc5-8e39-4a8b-bde4-aa37585281ae"), "123 Main St, Cityville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 22, 35, 25, 312, DateTimeKind.Utc).AddTicks(4358), null },
                    { new Guid("e76ab7c3-abf0-4fbc-af7d-3b70e81ec247"), "321 Maple St, Hamletville", new Guid("4c024333-a4d1-42c3-a537-0df0dd9946ac"), "The order was submitted", new DateTime(2024, 7, 28, 22, 35, 25, 312, DateTimeKind.Utc).AddTicks(4385), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("13f46e83-b887-4ed8-814c-822c17dd9d12"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3e4d205a-bbbf-4a47-9a65-628d2db57c39"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("8a311fc5-8e39-4a8b-bde4-aa37585281ae"));

            migrationBuilder.DeleteData(
                schema: "ordering",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e76ab7c3-abf0-4fbc-af7d-3b70e81ec247"));

            migrationBuilder.RenameColumn(
                name: "DeliveryDateTime",
                schema: "ordering",
                table: "OrderItems",
                newName: "Deadline");

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
    }
}
