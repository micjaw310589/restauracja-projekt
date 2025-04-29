using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restauracja.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stoliki_Rezerwacje_ReservationId",
                table: "Stoliki");

            migrationBuilder.DropIndex(
                name: "IX_Stoliki_ReservationId",
                table: "Stoliki");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Stoliki");

            migrationBuilder.CreateTable(
                name: "Rezerwacje_Stoliki",
                columns: table => new
                {
                    ReservationsReservationId = table.Column<int>(type: "int", nullable: false),
                    TablesTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje_Stoliki", x => new { x.ReservationsReservationId, x.TablesTableId });
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Stoliki_Rezerwacje_ReservationsReservationId",
                        column: x => x.ReservationsReservationId,
                        principalTable: "Rezerwacje",
                        principalColumn: "id_rez",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Stoliki_Stoliki_TablesTableId",
                        column: x => x.TablesTableId,
                        principalTable: "Stoliki",
                        principalColumn: "id_stolika",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_Stoliki_TablesTableId",
                table: "Rezerwacje_Stoliki",
                column: "TablesTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezerwacje_Stoliki");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Stoliki",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stoliki_ReservationId",
                table: "Stoliki",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stoliki_Rezerwacje_ReservationId",
                table: "Stoliki",
                column: "ReservationId",
                principalTable: "Rezerwacje",
                principalColumn: "id_rez");
        }
    }
}
