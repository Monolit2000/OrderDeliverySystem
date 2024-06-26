﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Basket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newBAsskdfksgjsdfdfgdfdfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                schema: "Basket",
                table: "Basket");

            migrationBuilder.RenameTable(
                name: "Basket",
                schema: "Basket",
                newName: "Baskets",
                newSchema: "basket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets",
                column: "CustomerBasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.EnsureSchema(
                name: "Basket");

            migrationBuilder.RenameTable(
                name: "Baskets",
                schema: "basket",
                newName: "Basket",
                newSchema: "Basket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                schema: "Basket",
                table: "Basket",
                column: "CustomerBasketId");
        }
    }
}
