using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CansInnov.Persistence.Migrations
{
    public partial class AddAudit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("d0e73c7d-84b7-4177-83f1-d77401d2dbc3"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("3e14a0a4-85f7-4798-9db2-e461aead50c4"));

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "CreatedBy", "CreatedDate", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("5f3899b9-ebe7-4479-b6f4-921858a50fc3"), "cmuller", new DateTime(2023, 11, 15, 23, 20, 2, 312, DateTimeKind.Local).AddTicks(8751), new DateTime(2023, 11, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", null, null, "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "CreatedBy", "CreatedDate", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("8116ce46-ee6c-44fc-bf82-327e2d533319"), "cmuller", new DateTime(2023, 11, 15, 23, 20, 2, 312, DateTimeKind.Local).AddTicks(8887), new DateTime(2023, 11, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("5f3899b9-ebe7-4479-b6f4-921858a50fc3"), null, null, null, "lieu", 10, "Intervenant", "Atelier 1", "Presentiel" });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "CreatedBy", "CreatedDate", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("a1f76469-79fe-455d-8ce2-952938561e38"), "cmuller", new DateTime(2023, 11, 15, 23, 20, 2, 312, DateTimeKind.Local).AddTicks(8900), new DateTime(2023, 11, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("5f3899b9-ebe7-4479-b6f4-921858a50fc3"), null, null, null, "lieu", 10, "Intervenant", "Atelier 2", "Presentiel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("8116ce46-ee6c-44fc-bf82-327e2d533319"));

            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("a1f76469-79fe-455d-8ce2-952938561e38"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("5f3899b9-ebe7-4479-b6f4-921858a50fc3"));

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "CreatedBy", "CreatedDate", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("3e14a0a4-85f7-4798-9db2-e461aead50c4"), "cmuller", new DateTime(2023, 11, 15, 23, 15, 17, 217, DateTimeKind.Local).AddTicks(307), new DateTime(2023, 9, 15, 23, 15, 17, 217, DateTimeKind.Local).AddTicks(258), new DateTime(2023, 10, 15, 23, 15, 17, 217, DateTimeKind.Local).AddTicks(304), "DEscription", null, null, "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "CreatedBy", "CreatedDate", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("d0e73c7d-84b7-4177-83f1-d77401d2dbc3"), "cmuller", new DateTime(2023, 11, 15, 23, 15, 17, 217, DateTimeKind.Local).AddTicks(458), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("3e14a0a4-85f7-4798-9db2-e461aead50c4"), null, null, "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });
        }
    }
}
