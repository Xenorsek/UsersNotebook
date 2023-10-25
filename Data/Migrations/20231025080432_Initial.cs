using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UsersNotebook.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DodatkoweParametry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DataUrodzenia", "DodatkoweParametry", "Imie", "Nazwisko", "Plec" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Key\":\"Numer Telefonu\",\"Value\":\"123-456-789\"},{\"Key\":\"Stanowisko\",\"Value\":\"Programista\"}]", "Jan", "Kowalski", "Mężczyzna" },
                    { 2, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "[{\"Key\":\"Numer Telefonu\",\"Value\":\"123-456-789\"},{\"Key\":\"Stanowisko\",\"Value\":\"Analityk\"}]", "Anna", "Nowak", "Kobieta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
