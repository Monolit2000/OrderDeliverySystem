using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewBasketMigrationNewUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Establishments_EstablishmentId",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_EstablishmentId",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "EstablishmentId",
                schema: "catalog",
                table: "Catalog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstablishmentId",
                schema: "catalog",
                table: "Catalog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_EstablishmentId",
                schema: "catalog",
                table: "Catalog",
                column: "EstablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_Establishments_EstablishmentId",
                schema: "catalog",
                table: "Catalog",
                column: "EstablishmentId",
                principalSchema: "catalog",
                principalTable: "Establishments",
                principalColumn: "EstablishmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
