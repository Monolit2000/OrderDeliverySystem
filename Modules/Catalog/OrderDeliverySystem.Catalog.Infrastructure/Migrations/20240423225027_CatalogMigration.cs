using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderDeliverySystem.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CatalogMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "CatalogTypes",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "users",
                columns: table => new
                {
                    CatalogItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CatalogItemId);
                    table.ForeignKey(
                        name: "FK_Users_CatalogTypes_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalSchema: "catalog",
                        principalTable: "CatalogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Establishments",
                schema: "catalog",
                columns: table => new
                {
                    EstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatalogItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishments", x => x.EstablishmentId);
                    table.ForeignKey(
                        name: "FK_Establishments_Users_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalSchema: "users",
                        principalTable: "Users",
                        principalColumn: "CatalogItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establishments_CatalogItemId",
                schema: "catalog",
                table: "Establishments",
                column: "CatalogItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CatalogTypeId",
                schema: "users",
                table: "Users",
                column: "CatalogTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Establishments",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "users");

            migrationBuilder.DropTable(
                name: "CatalogTypes",
                schema: "catalog");
        }
    }
}
