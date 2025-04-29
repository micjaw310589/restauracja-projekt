using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restauracja.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id_d = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cena = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    dostepny = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cz_staly = table.Column<TimeSpan>(type: "time", nullable: true),
                    cz_obliczony = table.Column<TimeSpan>(type: "time", nullable: true),
                    danie_dnia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    wyklucz_flag = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id_d);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id_stat = table.Column<sbyte>(type: "tinyint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nazwa = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id_stat);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Znizki",
                columns: table => new
                {
                    id_znizki = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nazwa_poziomu = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    znizka = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    prog_zamowien = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Znizki", x => x.id_znizki);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaliKlienci",
                columns: table => new
                {
                    id_k = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    imie = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nazwisko = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_tel = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mail = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_znizki = table.Column<int>(type: "int", nullable: true),
                    czy_aktywny = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaliKlienci", x => x.id_k);
                    table.ForeignKey(
                        name: "FK_StaliKlienci_Znizki_id_znizki",
                        column: x => x.id_znizki,
                        principalTable: "Znizki",
                        principalColumn: "id_znizki");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    id_zam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_u = table.Column<int>(type: "int", nullable: false),
                    id_rez = table.Column<int>(type: "int", nullable: true),
                    id_k = table.Column<int>(type: "int", nullable: true),
                    id_s = table.Column<int>(type: "int", nullable: false),
                    data_zam = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_wyd = table.Column<DateTime>(type: "datetime", nullable: true),
                    nr_wydania = table.Column<sbyte>(type: "tinyint", nullable: true),
                    id_status = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.id_zam);
                    table.ForeignKey(
                        name: "FK_Zamowienia_StaliKlienci_id_k",
                        column: x => x.id_k,
                        principalTable: "StaliKlienci",
                        principalColumn: "id_k");
                    table.ForeignKey(
                        name: "FK_Zamowienia_Status_id_status",
                        column: x => x.id_status,
                        principalTable: "Status",
                        principalColumn: "id_stat",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu_Zamowienia",
                columns: table => new
                {
                    id_d_zam = table.Column<int>(type: "int", nullable: false),
                    id_d_men = table.Column<int>(type: "int", nullable: false),
                    cena_zakupu = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    czy_do_znizki = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Zamowienia", x => new { x.id_d_zam, x.id_d_men });
                    table.ForeignKey(
                        name: "FK_Menu_Zamowienia_Menu_id_d_men",
                        column: x => x.id_d_men,
                        principalTable: "Menu",
                        principalColumn: "id_d",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_Zamowienia_Zamowienia_id_d_zam",
                        column: x => x.id_d_zam,
                        principalTable: "Zamowienia",
                        principalColumn: "id_zam",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Zamowienia_id_d_men",
                table: "Menu_Zamowienia",
                column: "id_d_men");

            migrationBuilder.CreateIndex(
                name: "IX_StaliKlienci_id_znizki",
                table: "StaliKlienci",
                column: "id_znizki");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_id_k",
                table: "Zamowienia",
                column: "id_k");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_id_status",
                table: "Zamowienia",
                column: "id_status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu_Zamowienia");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "StaliKlienci");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Znizki");
        }
    }
}
