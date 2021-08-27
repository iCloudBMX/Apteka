using Microsoft.EntityFrameworkCore.Migrations;

namespace Apteka.API.Migrations
{
    public partial class Firmalar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoriDoriFirma_DoriFirma_FirmalarId",
                table: "DoriDoriFirma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoriFirma",
                table: "DoriFirma");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661cdfdb-f5c9-4df2-b23d-63b120488a14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0a756a4-77c9-4a75-9a04-7ceaba0dbd7f");

            migrationBuilder.RenameTable(
                name: "DoriFirma",
                newName: "Firmalar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Firmalar",
                table: "Firmalar",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d96bfafe-6d58-42fa-9c5b-2744f238b621", "b85acc2c-7b80-46f5-93cb-f95680777556", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "384c3e21-6f53-42fe-a312-5bd816ecdaf5", "604ebcbd-00b3-4c5b-9b6f-e9086f2698c7", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_DoriDoriFirma_Firmalar_FirmalarId",
                table: "DoriDoriFirma",
                column: "FirmalarId",
                principalTable: "Firmalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoriDoriFirma_Firmalar_FirmalarId",
                table: "DoriDoriFirma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Firmalar",
                table: "Firmalar");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "384c3e21-6f53-42fe-a312-5bd816ecdaf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d96bfafe-6d58-42fa-9c5b-2744f238b621");

            migrationBuilder.RenameTable(
                name: "Firmalar",
                newName: "DoriFirma");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoriFirma",
                table: "DoriFirma",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0a756a4-77c9-4a75-9a04-7ceaba0dbd7f", "3e6b0c14-f6fb-4a07-bdce-9ab30dceea79", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "661cdfdb-f5c9-4df2-b23d-63b120488a14", "30285a90-6a16-4761-8549-21d80096f919", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_DoriDoriFirma_DoriFirma_FirmalarId",
                table: "DoriDoriFirma",
                column: "FirmalarId",
                principalTable: "DoriFirma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
