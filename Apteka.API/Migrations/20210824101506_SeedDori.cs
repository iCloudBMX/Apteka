using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apteka.API.Migrations
{
    public partial class SeedDori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dorilar",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "Dorilar",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("ccb00df2-8538-46af-83de-ad2aacb873cf"), "Sitromon", 1000m, 100 });

            migrationBuilder.InsertData(
                table: "Dorilar",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("c1edc814-b6c5-440a-a52b-1a9bb8b655a3"), "Paratsetomol", 500m, 50 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dorilar",
                keyColumn: "Id",
                keyValue: new Guid("c1edc814-b6c5-440a-a52b-1a9bb8b655a3"));

            migrationBuilder.DeleteData(
                table: "Dorilar",
                keyColumn: "Id",
                keyValue: new Guid("ccb00df2-8538-46af-83de-ad2aacb873cf"));

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Dorilar",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
