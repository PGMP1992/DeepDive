using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "City", "IsOnline", "Name" },
                values: new object[,]
                {
                    { 1, "Toronto", false, "Server1" },
                    { 2, "Toronto", false, "Server2" },
                    { 3, "Toronto", true, "Server3" },
                    { 4, "Toronto", false, "Server4" },
                    { 5, "Montreal", false, "Server5" },
                    { 6, "Montreal", true, "Server6" },
                    { 7, "Montreal", false, "Server7" },
                    { 8, "Ottawa", false, "Server8" },
                    { 9, "Ottawa", false, "Server9" },
                    { 10, "Calgary", false, "Server10" },
                    { 11, "Calgary", false, "Server11" },
                    { 12, "Halifax", true, "Server12" },
                    { 13, "Halifax", true, "Server13" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
