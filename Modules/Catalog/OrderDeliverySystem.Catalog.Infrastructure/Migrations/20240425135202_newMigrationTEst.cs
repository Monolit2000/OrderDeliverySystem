using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newMigrationTEst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                schema: "catalog",
                table: "Catalog",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_EstablishmentId",
                schema: "catalog",
                table: "Catalog",
                column: "EstablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_CatalogTypes_CatalogTypeId",
                schema: "catalog",
                table: "Catalog",
                column: "CatalogTypeId",
                principalSchema: "catalog",
                principalTable: "CatalogTypes",
                principalColumn: "CatalogTypeId",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_CatalogTypes_CatalogTypeId",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_Establishments_EstablishmentId",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_CatalogTypeId",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_EstablishmentId",
                schema: "catalog",
                table: "Catalog");
        }
    }
}
