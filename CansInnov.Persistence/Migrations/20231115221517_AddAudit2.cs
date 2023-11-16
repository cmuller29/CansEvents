using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CansInnov.Persistence.Migrations
{
    public partial class AddAudit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("78e80c46-3322-4d34-b128-ecb325092241"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("69105ac7-4c60-4c90-b143-eff304556c44"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "T_EVENEMENT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "T_ATELIER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "CreatedBy", "CreatedDate", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("3e14a0a4-85f7-4798-9db2-e461aead50c4"), "cmuller", new DateTime(2023, 11, 15, 23, 15, 17, 217, DateTimeKind.Local).AddTicks(307), new DateTime(2023, 9, 15, 23, 15, 17, 217, DateTimeKind.Local).AddTicks(258), new DateTime(2023, 10, 15, 23, 15, 17, 217, DateTimeKind.Local).AddTicks(304), "DEscription", null, null, "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "CreatedBy", "CreatedDate", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("d0e73c7d-84b7-4177-83f1-d77401d2dbc3"), "cmuller", new DateTime(2023, 11, 15, 23, 15, 17, 217, DateTimeKind.Local).AddTicks(458), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("3e14a0a4-85f7-4798-9db2-e461aead50c4"), null, null, "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("d0e73c7d-84b7-4177-83f1-d77401d2dbc3"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("3e14a0a4-85f7-4798-9db2-e461aead50c4"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "T_EVENEMENT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "T_ATELIER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "CreatedBy", "CreatedDate", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("69105ac7-4c60-4c90-b143-eff304556c44"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 23, 12, 45, 757, DateTimeKind.Local).AddTicks(7126), new DateTime(2023, 10, 15, 23, 12, 45, 757, DateTimeKind.Local).AddTicks(7163), "DEscription", null, null, "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "CreatedBy", "CreatedDate", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("78e80c46-3322-4d34-b128-ecb325092241"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("69105ac7-4c60-4c90-b143-eff304556c44"), null, null, "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });
        }
    }
}
