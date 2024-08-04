using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableOrderItemStatusChengedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "ordering",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItemStatusChangs",
                schema: "ordering",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemStatusChangs", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_OrderItemStatusChangs_OrderItems_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "ordering",
                        principalTable: "OrderItems",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemStatusChangs_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalSchema: "ordering",
                        principalTable: "OrderItems",
                        principalColumn: "OrderItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemStatusChangs_OrderItemId",
                schema: "ordering",
                table: "OrderItemStatusChangs",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "ordering",
                table: "OrderItems",
                column: "OrderId",
                principalSchema: "ordering",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderItemStatusChangs",
                schema: "ordering");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "ordering",
                table: "OrderItems",
                column: "OrderId",
                principalSchema: "ordering",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
