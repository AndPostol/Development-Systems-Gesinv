using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class CorreccionProductoMarcaMedida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marca_Producto_ProductoId",
                table: "Marca");

            migrationBuilder.DropForeignKey(
                name: "FK_Medida_Producto_ProductoId",
                table: "Medida");

            migrationBuilder.DropIndex(
                name: "IX_Medida_ProductoId",
                table: "Medida");

            migrationBuilder.DropIndex(
                name: "IX_Marca_ProductoId",
                table: "Marca");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Medida");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Marca");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Producto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedidaId",
                table: "Producto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaId",
                table: "Producto",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MedidaId",
                table: "Producto",
                column: "MedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Marca_MarcaId",
                table: "Producto",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Medida_MedidaId",
                table: "Producto",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "MedidaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Marca_MarcaId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Medida_MedidaId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_MarcaId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_MedidaId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "MedidaId",
                table: "Producto");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Medida",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Marca",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medida_ProductoId",
                table: "Medida",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Marca_ProductoId",
                table: "Marca",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marca_Producto_ProductoId",
                table: "Marca",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medida_Producto_ProductoId",
                table: "Medida",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId");
        }
    }
}
