using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Challenge.Web.Migrations
{
    public partial class Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventarioId",
                table: "Tbl_Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tbl_Inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Inventario", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Produto_Tbl_Inventario_InventarioId",
                table: "Tbl_Produto");

            migrationBuilder.DropTable(
                name: "Tbl_Inventario");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Produto_InventarioId",
                table: "Tbl_Produto");

            migrationBuilder.DropColumn(
                name: "InventarioId",
                table: "Tbl_Produto");
        }
    }
}
