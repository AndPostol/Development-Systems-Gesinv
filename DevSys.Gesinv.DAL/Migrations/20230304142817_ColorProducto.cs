using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class ColorProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Producto_ProductoId",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_ProductoId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Color");

            migrationBuilder.CreateTable(
                name: "ColorProducto",
                columns: table => new
                {
                    ColorProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorProducto", x => x.ColorProductoId);
                    table.ForeignKey(
                        name: "FK_ColorProducto_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorProducto_ColorId",
                table: "ColorProducto",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorProducto_ProductoId",
                table: "ColorProducto",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorProducto");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Color",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_ProductoId",
                table: "Color",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Producto_ProductoId",
                table: "Color",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId");
        }
    }
}
