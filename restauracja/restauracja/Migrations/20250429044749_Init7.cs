using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restauracja.Migrations
{
    /// <inheritdoc />
    public partial class Init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "login",
                table: "Uzytkownicy",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "haslo",
                table: "Uzytkownicy",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lokale",
                columns: table => new
                {
                    id_lok = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    adres = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    miasto = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    czy_otwarty = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokale", x => x.id_lok);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_id_u",
                table: "Zamowienia",
                column: "id_u");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_id_lok",
                table: "Uzytkownicy",
                column: "id_lok");

            migrationBuilder.CreateIndex(
                name: "IX_Stoliki_id_lok",
                table: "Stoliki",
                column: "id_lok");

            migrationBuilder.AddForeignKey(
                name: "FK_Stoliki_Lokale_id_lok",
                table: "Stoliki",
                column: "id_lok",
                principalTable: "Lokale",
                principalColumn: "id_lok",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Lokale_id_lok",
                table: "Uzytkownicy",
                column: "id_lok",
                principalTable: "Lokale",
                principalColumn: "id_lok");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_Uzytkownicy_id_u",
                table: "Zamowienia",
                column: "id_u",
                principalTable: "Uzytkownicy",
                principalColumn: "id_u",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stoliki_Lokale_id_lok",
                table: "Stoliki");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Lokale_id_lok",
                table: "Uzytkownicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_Uzytkownicy_id_u",
                table: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Lokale");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienia_id_u",
                table: "Zamowienia");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownicy_id_lok",
                table: "Uzytkownicy");

            migrationBuilder.DropIndex(
                name: "IX_Stoliki_id_lok",
                table: "Stoliki");

            migrationBuilder.UpdateData(
                table: "Uzytkownicy",
                keyColumn: "login",
                keyValue: null,
                column: "login",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "login",
                table: "Uzytkownicy",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Uzytkownicy",
                keyColumn: "haslo",
                keyValue: null,
                column: "haslo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "haslo",
                table: "Uzytkownicy",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
