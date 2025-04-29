using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restauracja.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zamowienia_Stoliki",
                columns: table => new
                {
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false),
                    TablesTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia_Stoliki", x => new { x.OrdersOrderId, x.TablesTableId });
                    table.ForeignKey(
                        name: "FK_Zamowienia_Stoliki_Stoliki_TablesTableId",
                        column: x => x.TablesTableId,
                        principalTable: "Stoliki",
                        principalColumn: "id_stolika",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Stoliki_Zamowienia_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Zamowienia",
                        principalColumn: "id_zam",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_Stoliki_TablesTableId",
                table: "Zamowienia_Stoliki",
                column: "TablesTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienia_Stoliki");
        }
    }
}
