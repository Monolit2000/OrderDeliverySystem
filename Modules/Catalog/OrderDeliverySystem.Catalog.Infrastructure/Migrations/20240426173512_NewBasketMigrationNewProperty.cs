using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewBasketMigrationNewProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_CatalogTypes_CatalogTypeId",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_CatalogTypeId",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "CatalogTypeId",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeToItemExist",
                schema: "catalog",
                table: "Catalog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeToItemExist",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.AddColumn<Guid>(
                name: "CatalogTypeId",
                schema: "catalog",
                table: "Catalog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                schema: "catalog",
                table: "Catalog",
                column: "CatalogTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_CatalogTypes_CatalogTypeId",
                schema: "catalog",
                table: "Catalog",
                column: "CatalogTypeId",
                principalSchema: "catalog",
                principalTable: "CatalogTypes",
                principalColumn: "CatalogTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
