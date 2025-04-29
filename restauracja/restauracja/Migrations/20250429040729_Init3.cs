using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restauracja.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_zam",
                table: "Zamowienia",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "nr_tel",
                table: "StaliKlienci",
                type: "varchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldMaxLength: 9)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "mail",
                table: "StaliKlienci",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    id_rez = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nazwisko = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_tel = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_rez = table.Column<DateTime>(type: "datetime", nullable: true),
                    data_koniec = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.id_rez);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stoliki",
                columns: table => new
                {
                    id_stolika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_lok = table.Column<int>(type: "int", nullable: false),
                    nr_stolika = table.Column<int>(type: "int", nullable: false),
                    liczba_miejsc = table.Column<short>(type: "smallint", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoliki", x => x.id_stolika);
                    table.ForeignKey(
                        name: "FK_Stoliki_Rezerwacje_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Rezerwacje",
                        principalColumn: "id_rez");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_id_rez",
                table: "Zamowienia",
                column: "id_rez");

            migrationBuilder.CreateIndex(
                name: "IX_Stoliki_ReservationId",
                table: "Stoliki",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Rezerwacje_id_rez",
                table: "Zamowienia",
                column: "id_rez",
                principalTable: "Rezerwacje",
                principalColumn: "id_rez");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Rezerwacje_id_rez",
                table: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Stoliki");

            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_id_rez",
                table: "Zamowienia");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_zam",
                table: "Zamowienia",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "StaliKlienci",
                keyColumn: "nr_tel",
                keyValue: null,
                column: "nr_tel",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "nr_tel",
                table: "StaliKlienci",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldMaxLength: 12,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "StaliKlienci",
                keyColumn: "mail",
                keyValue: null,
                column: "mail",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "mail",
                table: "StaliKlienci",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
