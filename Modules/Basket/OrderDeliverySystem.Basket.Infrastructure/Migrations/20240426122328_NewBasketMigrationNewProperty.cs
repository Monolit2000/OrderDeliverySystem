using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewBasketMigrationNewProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BuyerChatId",
                schema: "basket",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "DeliveryOptions",
                schema: "basket",
                columns: table => new
                {
                    DeliveryOptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOptions", x => x.DeliveryOptionsId);
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                schema: "basket",
                columns: table => new
                {
                    BasketItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OldUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryOptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerBasketBasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.BasketItemId);
                    table.ForeignKey(
                        name: "FK_BasketItem_Baskets_CustomerBasketBasketId",
                        column: x => x.CustomerBasketBasketId,
                        principalSchema: "basket",
                        principalTable: "Baskets",
                        principalColumn: "BasketId");
                    table.ForeignKey(
                        name: "FK_BasketItem_DeliveryOptions_DeliveryOptionsId",
                        column: x => x.DeliveryOptionsId,
                        principalSchema: "basket",
                        principalTable: "DeliveryOptions",
                        principalColumn: "DeliveryOptionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_CustomerBasketBasketId",
                schema: "basket",
                table: "BasketItem",
                column: "CustomerBasketBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_DeliveryOptionsId",
                schema: "basket",
                table: "BasketItem",
                column: "DeliveryOptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItem",
                schema: "basket");

            migrationBuilder.DropTable(
                name: "DeliveryOptions",
                schema: "basket");

            migrationBuilder.DropColumn(
                name: "BuyerChatId",
                schema: "basket",
                table: "Baskets");
        }
    }
}
