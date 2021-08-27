using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apteka.API.Migrations
{
    public partial class ManyToManyRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a3df7e4-71c2-46ba-934c-a35be2c8f3d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83aeac4d-bf57-4298-b278-512b22bd7a47");

            migrationBuilder.CreateTable(
                name: "DoriFirma",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoriFirma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoriDoriFirma",
                columns: table => new
                {
                    DorilarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirmalarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoriDoriFirma", x => new { x.DorilarId, x.FirmalarId });
                    table.ForeignKey(
                        name: "FK_DoriDoriFirma_DoriFirma_FirmalarId",
                        column: x => x.FirmalarId,
                        principalTable: "DoriFirma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoriDoriFirma_Dorilar_DorilarId",
                        column: x => x.DorilarId,
                        principalTable: "Dorilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0a756a4-77c9-4a75-9a04-7ceaba0dbd7f", "3e6b0c14-f6fb-4a07-bdce-9ab30dceea79", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "661cdfdb-f5c9-4df2-b23d-63b120488a14", "30285a90-6a16-4761-8549-21d80096f919", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_DoriDoriFirma_FirmalarId",
                table: "DoriDoriFirma",
                column: "FirmalarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoriDoriFirma");

            migrationBuilder.DropTable(
                name: "DoriFirma");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661cdfdb-f5c9-4df2-b23d-63b120488a14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0a756a4-77c9-4a75-9a04-7ceaba0dbd7f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83aeac4d-bf57-4298-b278-512b22bd7a47", "4b2982b9-980c-4268-9040-c1dd710f6a84", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a3df7e4-71c2-46ba-934c-a35be2c8f3d1", "b9a8e664-ec3f-41a3-9d45-ac3f1b359483", "User", "USER" });
        }
    }
}
