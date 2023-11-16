using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CansInnov.Persistence.Migrations
{
    public partial class AddAudit : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "T_EVENEMENT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "T_EVENEMENT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "T_EVENEMENT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "T_EVENEMENT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "T_ATELIER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "T_ATELIER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "T_ATELIER",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "T_ATELIER",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "T_EVENEMENT",
                columns: new[] { "ID_EVENEMENT", "CreatedBy", "CreatedDate", "DATE_DEBUT_EVENEMENT", "DATE_FIN_EVENEMENT", "DESCRIPTION_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "Titre", "VISUEL_EVENEMENT" },
                values: new object[] { new Guid("69105ac7-4c60-4c90-b143-eff304556c44"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 23, 12, 45, 757, DateTimeKind.Local).AddTicks(7126), new DateTime(2023, 10, 15, 23, 12, 45, 757, DateTimeKind.Local).AddTicks(7163), "DEscription", null, null, "Titre", null });

            migrationBuilder.InsertData(
                table: "T_ATELIER",
                columns: new[] { "ID_ATELIER", "CreatedBy", "CreatedDate", "DATE_DEBUT_ATELIER", "DATE_FIN_ATELIER", "DESCRIPTION_ATELIER", "ID_EVENEMENT", "LastModifiedBy", "LastModifiedDate", "LIEN_REUNION", "LIEU_ATELIER", "NOMBRE_PARTICIPANT_MAX", "NOM_INTERVENANT", "TITRE_ATELIER", "TYPE_ATELIER" },
                values: new object[] { new Guid("78e80c46-3322-4d34-b128-ecb325092241"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "DEscription", new Guid("69105ac7-4c60-4c90-b143-eff304556c44"), null, null, "lien", "lieu", 10, "Intervenant", "Titre", "Presentiel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ATELIER",
                keyColumn: "ID_ATELIER",
                keyValue: new Guid("78e80c46-3322-4d34-b128-ecb325092241"));

            migrationBuilder.DeleteData(
                table: "T_EVENEMENT",
                keyColumn: "ID_EVENEMENT",
                keyValue: new Guid("69105ac7-4c60-4c90-b143-eff304556c44"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "T_EVENEMENT");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "T_EVENEMENT");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "T_EVENEMENT");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "T_EVENEMENT");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "T_ATELIER");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "T_ATELIER");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "T_ATELIER");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "T_ATELIER");

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
