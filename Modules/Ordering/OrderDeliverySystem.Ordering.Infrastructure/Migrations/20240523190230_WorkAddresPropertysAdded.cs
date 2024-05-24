using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkAddresPropertysAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "ordering",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryCost",
                schema: "ordering",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDateTime",
                schema: "ordering",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeliveryMethod",
                schema: "ordering",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelfPickup",
                schema: "ordering",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WorkAddress",
                schema: "ordering",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeliveryCost",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeliveryDateTime",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeliveryMethod",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsSelfPickup",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "WorkAddress",
                schema: "ordering",
                table: "Buyers");
        }
    }
}
