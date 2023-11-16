using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CansInnov.Persistence.Migrations
{
    public partial class AddParticipant2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantAtelier_T_ATELIER_AtelierId",
                table: "ParticipantAtelier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantAtelier",
                table: "ParticipantAtelier");

            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("7ff10674-cc5a-400a-a824-9d1fb1c1cfab"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("edd6a8a1-27bd-4e68-a0a9-1e3311373e02"));

            migrationBuilder.RenameTable(
                name: "ParticipantAtelier",
                newName: "T_PARTICIPANT_ATELIER");

            migrationBuilder.RenameColumn(
                name: "Matricule",
                table: "T_PARTICIPANT_ATELIER",
                newName: "MATRICULE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "T_PARTICIPANT_ATELIER",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AtelierId",
                table: "T_PARTICIPANT_ATELIER",
                newName: "ID_ATELIER");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantAtelier_AtelierId",
                table: "T_PARTICIPANT_ATELIER",
                newName: "IX_T_PARTICIPANT_ATELIER_ID_ATELIER");

            migrationBuilder.AlterColumn<string>(
                name: "MATRICULE",
                table: "T_PARTICIPANT_ATELIER",
                type: "CHAR(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_PARTICIPANT_ATELIER",
                table: "T_PARTICIPANT_ATELIER",
                column: "ID");

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("6d8faf40-3165-4a50-ba4a-fa0fb50312eb"), new DateTime(2023, 9, 16, 14, 47, 25, 261, DateTimeKind.Local).AddTicks(2891), new DateTime(2023, 10, 16, 14, 47, 25, 261, DateTimeKind.Local).AddTicks(2938), "DEscription", "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("054144c8-5744-4441-a685-6e19313b996e"), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("6d8faf40-3165-4a50-ba4a-fa0fb50312eb"), "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });

            migrationBuilder.AddForeignKey(
                name: "FK_T_PARTICIPANT_ATELIER_T_ATELIER_ID_ATELIER",
                table: "T_PARTICIPANT_ATELIER",
                column: "ID_ATELIER",
                principalTable: "T_ATELIER",
                principalColumn: "ID_ATELIER",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_PARTICIPANT_ATELIER_T_ATELIER_ID_ATELIER",
                table: "T_PARTICIPANT_ATELIER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_PARTICIPANT_ATELIER",
                table: "T_PARTICIPANT_ATELIER");

            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("054144c8-5744-4441-a685-6e19313b996e"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("6d8faf40-3165-4a50-ba4a-fa0fb50312eb"));

            migrationBuilder.RenameTable(
                name: "T_PARTICIPANT_ATELIER",
                newName: "ParticipantAtelier");

            migrationBuilder.RenameColumn(
                name: "MATRICULE",
                table: "ParticipantAtelier",
                newName: "Matricule");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ParticipantAtelier",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID_ATELIER",
                table: "ParticipantAtelier",
                newName: "AtelierId");

            migrationBuilder.RenameIndex(
                name: "IX_T_PARTICIPANT_ATELIER_ID_ATELIER",
                table: "ParticipantAtelier",
                newName: "IX_ParticipantAtelier_AtelierId");

            migrationBuilder.AlterColumn<string>(
                name: "Matricule",
                table: "ParticipantAtelier",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(7)",
                oldMaxLength: 7);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantAtelier",
                table: "ParticipantAtelier",
                column: "Id");

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("edd6a8a1-27bd-4e68-a0a9-1e3311373e02"), new DateTime(2023, 9, 16, 14, 46, 19, 712, DateTimeKind.Local).AddTicks(5738), new DateTime(2023, 10, 16, 14, 46, 19, 712, DateTimeKind.Local).AddTicks(5786), "DEscription", "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("7ff10674-cc5a-400a-a824-9d1fb1c1cfab"), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("edd6a8a1-27bd-4e68-a0a9-1e3311373e02"), "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantAtelier_T_ATELIER_AtelierId",
                table: "ParticipantAtelier",
                column: "AtelierId",
                principalTable: "T_ATELIER",
                principalColumn: "ID_ATELIER",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
