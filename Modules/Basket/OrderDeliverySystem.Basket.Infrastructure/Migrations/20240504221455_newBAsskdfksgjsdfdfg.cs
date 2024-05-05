using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newBAsskdfksgjsdfdfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Basket_CustomerBasketId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_CustomerBasketId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "CustomerBasketId",
                schema: "basket",
                table: "BasketItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                column: "CustomerBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Basket_CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                column: "CustomerBasketId",
                principalSchema: "Basket",
                principalTable: "Basket",
                principalColumn: "CustomerBasketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
