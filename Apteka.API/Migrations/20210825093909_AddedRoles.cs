using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apteka.API.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dorilar",
                keyColumn: "Id",
                keyValue: new Guid("0773858a-188a-4103-974d-fa2e34269840"));

            migrationBuilder.DeleteData(
                table: "Dorilar",
                keyColumn: "Id",
                keyValue: new Guid("1ed75b07-bf1b-43f7-829b-1abbfbff4c7c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83aeac4d-bf57-4298-b278-512b22bd7a47", "4b2982b9-980c-4268-9040-c1dd710f6a84", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a3df7e4-71c2-46ba-934c-a35be2c8f3d1", "b9a8e664-ec3f-41a3-9d45-ac3f1b359483", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a3df7e4-71c2-46ba-934c-a35be2c8f3d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83aeac4d-bf57-4298-b278-512b22bd7a47");

            migrationBuilder.InsertData(
                table: "Dorilar",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("1ed75b07-bf1b-43f7-829b-1abbfbff4c7c"), "Sitromon", 1000m, 100 });

            migrationBuilder.InsertData(
                table: "Dorilar",
                columns: new[] { "Id", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("0773858a-188a-4103-974d-fa2e34269840"), "Paratsetomol", 500m, 50 });
        }
    }
}
