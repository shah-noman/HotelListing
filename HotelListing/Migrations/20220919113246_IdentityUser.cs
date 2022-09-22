using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Migrations
{
    public partial class IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74dae260-10e5-473c-93d4-0a9fc292bc53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "793d3a9a-9440-450b-bd95-89034eaaf0e7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2dbc172a-3428-4d63-87fe-c5cd3322e9fe", "57a0b21b-bdca-48c7-9c64-13783e864c5b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49ddfadb-048f-47ef-b47a-c9c920ac9d47", "83240340-04ce-495d-928c-8cbf65eb270f", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dbc172a-3428-4d63-87fe-c5cd3322e9fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49ddfadb-048f-47ef-b47a-c9c920ac9d47");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74dae260-10e5-473c-93d4-0a9fc292bc53", "63c1f583-62cd-4a57-b976-06e79fc1c5d3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "793d3a9a-9440-450b-bd95-89034eaaf0e7", "62aeffd6-1ef1-49f9-b49b-4f1a7e8f1999", "Administrator", "ADMINISTRATOR" });
        }
    }
}
