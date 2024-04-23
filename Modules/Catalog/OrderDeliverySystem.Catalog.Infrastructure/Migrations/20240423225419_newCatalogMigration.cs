using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newCatalogMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Establishments_Users_CatalogItemId",
                schema: "catalog",
                table: "Establishments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_CatalogTypes_CatalogTypeId",
                schema: "users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "users",
                newName: "Catalog",
                newSchema: "catalog");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CatalogTypeId",
                schema: "catalog",
                table: "Catalog",
                newName: "IX_Catalog_CatalogTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog",
                schema: "catalog",
                table: "Catalog",
                column: "CatalogItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_CatalogTypes_CatalogTypeId",
                schema: "catalog",
                table: "Catalog",
                column: "CatalogTypeId",
                principalSchema: "catalog",
                principalTable: "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Establishments_Catalog_CatalogItemId",
                schema: "catalog",
                table: "Establishments",
                column: "CatalogItemId",
                principalSchema: "catalog",
                principalTable: "Catalog",
                principalColumn: "CatalogItemId",
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
                name: "FK_Establishments_Catalog_CatalogItemId",
                schema: "catalog",
                table: "Establishments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog",
                schema: "catalog",
                table: "Catalog");

            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.RenameTable(
                name: "Catalog",
                schema: "catalog",
                newName: "Users",
                newSchema: "users");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_CatalogTypeId",
                schema: "users",
                table: "Users",
                newName: "IX_Users_CatalogTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "users",
                table: "Users",
                column: "CatalogItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Establishments_Users_CatalogItemId",
                schema: "catalog",
                table: "Establishments",
                column: "CatalogItemId",
                principalSchema: "users",
                principalTable: "Users",
                principalColumn: "CatalogItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CatalogTypes_CatalogTypeId",
                schema: "users",
                table: "Users",
                column: "CatalogTypeId",
                principalSchema: "catalog",
                principalTable: "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
