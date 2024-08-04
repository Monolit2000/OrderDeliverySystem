using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderItemStatusChangeIdFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemStatusChangs",
                schema: "ordering",
                table: "OrderItemStatusChangs");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                schema: "ordering",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "ordering",
                table: "OrderItemStatusChangs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemStatusChangs",
                schema: "ordering",
                table: "OrderItemStatusChangs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemStatusChangs_ItemId",
                schema: "ordering",
                table: "OrderItemStatusChangs",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItemStatusChangs",
                schema: "ordering",
                table: "OrderItemStatusChangs");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemStatusChangs_ItemId",
                schema: "ordering",
                table: "OrderItemStatusChangs");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "ordering",
                table: "OrderItemStatusChangs");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                schema: "ordering",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItemStatusChangs",
                schema: "ordering",
                table: "OrderItemStatusChangs",
                column: "ItemId");
        }
    }
}
