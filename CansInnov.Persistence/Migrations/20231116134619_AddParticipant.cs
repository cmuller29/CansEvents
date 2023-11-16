using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CansInnov.Persistence.Migrations
{
    public partial class AddParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("74f05612-024b-4bb9-88b0-fd8a67dddd74"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("8c76e726-dbe9-412e-930c-9d8bc0231b42"));

            migrationBuilder.CreateTable(
                name: "ParticipantAtelier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtelierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantAtelier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantAtelier_T_ATELIER_AtelierId",
                        column: x => x.AtelierId,
                        principalTable: "T_ATELIER",
                        principalColumn: "ID_ATELIER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("edd6a8a1-27bd-4e68-a0a9-1e3311373e02"), new DateTime(2023, 9, 16, 14, 46, 19, 712, DateTimeKind.Local).AddTicks(5738), new DateTime(2023, 10, 16, 14, 46, 19, 712, DateTimeKind.Local).AddTicks(5786), "DEscription", "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("7ff10674-cc5a-400a-a824-9d1fb1c1cfab"), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("edd6a8a1-27bd-4e68-a0a9-1e3311373e02"), "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantAtelier_AtelierId",
                table: "ParticipantAtelier",
                column: "AtelierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantAtelier");

            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("7ff10674-cc5a-400a-a824-9d1fb1c1cfab"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("edd6a8a1-27bd-4e68-a0a9-1e3311373e02"));

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("8c76e726-dbe9-412e-930c-9d8bc0231b42"), new DateTime(2023, 9, 14, 16, 45, 14, 689, DateTimeKind.Local).AddTicks(9696), new DateTime(2023, 10, 14, 16, 45, 14, 689, DateTimeKind.Local).AddTicks(9741), "DEscription", "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("74f05612-024b-4bb9-88b0-fd8a67dddd74"), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("8c76e726-dbe9-412e-930c-9d8bc0231b42"), "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });
        }
    }
}
