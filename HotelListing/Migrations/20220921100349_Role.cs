using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Migrations
{
    public partial class Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2983d4f3-3ea6-419e-bebc-c208b0ef07c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca0bf1b-3f5f-4be5-81c7-d6cf1d5678fb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01195ca5-9d08-4586-9e6e-e85acc5f23bf", "e79b9188-a190-4500-b06d-6e30fff8305c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a47ab751-5486-4baa-b882-6504252dbc30", "d0d4252e-63b3-4393-a317-c9ff6816eac8", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01195ca5-9d08-4586-9e6e-e85acc5f23bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a47ab751-5486-4baa-b882-6504252dbc30");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2983d4f3-3ea6-419e-bebc-c208b0ef07c8", "6318aa34-303e-45b7-8739-d98d249980bd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ca0bf1b-3f5f-4be5-81c7-d6cf1d5678fb", "e5dc51d6-ebb8-46c6-b309-74734584b6b2", "User", "USER" });
        }
    }
}
