using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Challenge.Web.Migrations
{
    public partial class BancoFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Produto_Tbl_Inventario_InventarioId",
                table: "Tbl_Produto");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Produto_InventarioId",
                table: "Tbl_Produto");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "Tbl_Produto");

            migrationBuilder.CreateTable(
                name: "Tbl_Item_Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    InventarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Item_Produto", x => new { x.ProdutoId, x.InventarioId });
                    table.ForeignKey(
                        name: "FK_Tbl_Item_Produto_Tbl_Inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Tbl_Inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Item_Produto_Tbl_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Tbl_Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Item_Produto_InventarioId",
                table: "Tbl_Item_Produto",
                column: "InventarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Item_Produto");

            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
                table: "Tbl_Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Produto_InventarioId",
                table: "Tbl_Produto",
                column: "InventarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Produto_Tbl_Inventario_InventarioId",
                table: "Tbl_Produto",
                column: "InventarioId",
                principalTable: "Tbl_Inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
