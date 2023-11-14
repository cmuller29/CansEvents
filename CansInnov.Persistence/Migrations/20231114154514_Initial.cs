using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CansInnov.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_EVENEMENT",
                columns: table => new
                {
                    ID_EVENEMENT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DESCRIPTION_EVENEMENT = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: "DEscription de base"),
                    VISUEL_EVENEMENT = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATE_DEBUT_EVENEMENT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATE_FIN_EVENEMENT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EVENEMENT", x => x.ID_EVENEMENT);
                });

            migrationBuilder.CreateTable(
                name: "T_ATELIER",
                columns: table => new
                {
                    ID_ATELIER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_EVENEMENT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TITRE_ATELIER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DESCRIPTION_ATELIER = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TYPE_ATELIER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NOM_INTERVENANT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LIEU_ATELIER = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LIEN_REUNION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOMBRE_PARTICIPANT_MAX = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DATE_DEBUT_ATELIER = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATE_FIN_ATELIER = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ATELIER", x => x.ID_ATELIER);
                    table.ForeignKey(
                        name: "FK_CUSTOM_ATELIER_EVENT",
                        column: x => x.ID_EVENEMENT,
                        principalTable: "T_EVENEMENT",
                        principalColumn: "ID_EVENEMENT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("8c76e726-dbe9-412e-930c-9d8bc0231b42"), new DateTime(2023, 9, 14, 16, 45, 14, 689, DateTimeKind.Local).AddTicks(9696), new DateTime(2023, 10, 14, 16, 45, 14, 689, DateTimeKind.Local).AddTicks(9741), "DEscription", "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("74f05612-024b-4bb9-88b0-fd8a67dddd74"), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("8c76e726-dbe9-412e-930c-9d8bc0231b42"), "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });

            migrationBuilder.CreateIndex(
                name: "IX_T_ATELIER_ID_EVENEMENT",
                table: "T_ATELIER",
                column: "ID_EVENEMENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ATELIER");

            migrationBuilder.DropTable(
                name: "T_EVENEMENT");
        }
    }
}
