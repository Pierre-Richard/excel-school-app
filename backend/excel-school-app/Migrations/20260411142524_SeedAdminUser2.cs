using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace excel_school_app.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "Role" },
                values: new object[] { 2, new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), "mayer_alexandre@yahoo.fr", "Pierre", "Mayer", "$2a$11$kbyrwUIt/zQBYxL./q5sResUMegZ.Bet2Ug4vbzHYcmRJp.J8GCa", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "Role" },
                values: new object[] { 1, new DateTime(2026, 4, 11, 13, 38, 36, 213, DateTimeKind.Utc).AddTicks(5820), "mayer_mexandre@yahoo.fr", "Pierre", "Mayer", "$2a$11$17qbly8BJQOCRnZET.ISyeVWvd.bLAZilNqJLJVKf0F34sOC09Okq", 3 });
        }
    }
}
