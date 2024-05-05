﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newBAsskdfksgjsdfdfgdfdfgdsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                column: "CustomerBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Baskets_CustomerBasketId",
                schema: "basket",
                table: "BasketItems",
                column: "CustomerBasketId",
                principalSchema: "basket",
                principalTable: "Baskets",
                principalColumn: "CustomerBasketId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Baskets_CustomerBasketId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_CustomerBasketId",
                schema: "basket",
                table: "BasketItems");
        }
    }
}
