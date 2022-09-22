using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c7cf7d7-eb6d-42f4-a986-2630f7c64045");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c486c154-49a2-4a57-8084-16fb9aad275f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45b35334-43d9-445b-9ae2-01f0ef52731a", "2cdbd0d9-068c-4777-9016-a3fd3c321078", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98cb4f97-0e80-4bbc-bdd0-a8c7f3158c08", "d5c5b2ad-d0ea-4e97-b091-0be7cf889a6f", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45b35334-43d9-445b-9ae2-01f0ef52731a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98cb4f97-0e80-4bbc-bdd0-a8c7f3158c08");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c7cf7d7-eb6d-42f4-a986-2630f7c64045", "86f46c9c-f4df-4293-9694-b4607d67a9a1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c486c154-49a2-4a57-8084-16fb9aad275f", "ed5443aa-1267-4353-a54b-6f5f4dfa41a2", "Administrator", "ADMINISTRATOR" });
        }
    }
}
