using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemMonitorowaniaWydatkowDomowych.Migrations
{
    /// <inheritdoc />
    public partial class UtworzenieTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodyPlatnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodyPlatnosci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wydatki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kwota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false),
                    MetodaPlatnosciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydatki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wydatki_Kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wydatki_MetodyPlatnosci_MetodaPlatnosciId",
                        column: x => x.MetodaPlatnosciId,
                        principalTable: "MetodyPlatnosci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wydatki_KategoriaId",
                table: "Wydatki",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wydatki_MetodaPlatnosciId",
                table: "Wydatki",
                column: "MetodaPlatnosciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wydatki");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "MetodyPlatnosci");
        }
    }
}





