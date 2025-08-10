using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kometha.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6a7f1c92-f224-4b23-a6db-28e556f054db"), "Medium" },
                    { new Guid("7674c000-85d1-469b-8460-5043b6fc5575"), "Easy" },
                    { new Guid("871fa652-2c1c-48f8-aedd-a6708089d5a7"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3e23d63a-1df4-4303-87a2-baa4653f846c"), "SPS", "SAN PEDRO SULA", null },
                    { new Guid("52636623-dd18-4067-b6a0-03cea9aaf7c2"), "TGU", "TEGUCIGALPA", "https://allasfileserver.s3.amazonaws.com/productos_fotos/thumbnails/01-200104-0410M_2_2.png" },
                    { new Guid("7674c000-85d1-469b-8460-5043b6fc5575"), "AKL", "AuckLand", "https://allasfileserver.s3.amazonaws.com/productos_fotos/thumbnails/01-200104-0410M_1_1.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6a7f1c92-f224-4b23-a6db-28e556f054db"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7674c000-85d1-469b-8460-5043b6fc5575"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("871fa652-2c1c-48f8-aedd-a6708089d5a7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3e23d63a-1df4-4303-87a2-baa4653f846c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("52636623-dd18-4067-b6a0-03cea9aaf7c2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7674c000-85d1-469b-8460-5043b6fc5575"));
        }
    }
}
