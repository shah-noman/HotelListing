using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88fab6fb-b77a-48ae-a8c9-a40a340e3e0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f477c93b-2c42-48e9-9320-8a698c682ace");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74dae260-10e5-473c-93d4-0a9fc292bc53", "63c1f583-62cd-4a57-b976-06e79fc1c5d3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "793d3a9a-9440-450b-bd95-89034eaaf0e7", "62aeffd6-1ef1-49f9-b49b-4f1a7e8f1999", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "88fab6fb-b77a-48ae-a8c9-a40a340e3e0e", "d1607928-69d2-4c9e-93e4-0da28bf51658", "Administrator", "ADMNISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f477c93b-2c42-48e9-9320-8a698c682ace", "2753f052-aed3-426c-8bb1-d18e61333b40", "User", "USER" });
        }
    }
}
