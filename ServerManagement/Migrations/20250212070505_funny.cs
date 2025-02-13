using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerManagement.Migrations
{
    /// <inheritdoc />
    public partial class funny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsOnline",
                value: false);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsOnline",
                value: false);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsOnline",
                value: false);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsOnline",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsOnline",
                value: true);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsOnline",
                value: true);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsOnline",
                value: true);

            migrationBuilder.UpdateData(
                table: "Servers",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsOnline",
                value: true);
        }
    }
}
