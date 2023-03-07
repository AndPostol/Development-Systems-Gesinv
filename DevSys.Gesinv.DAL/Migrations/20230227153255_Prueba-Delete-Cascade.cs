using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class PruebaDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaCompra_Departamento_DepartamentoId",
                table: "LineaCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaCompra_OrdenCompra_OrdenCompraId",
                table: "LineaCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaCompra_Producto_ProductoId",
                table: "LineaCompra");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "LineaCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrdenCompraId",
                table: "LineaCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "LineaCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaCompra_Departamento_DepartamentoId",
                table: "LineaCompra",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaCompra_OrdenCompra_OrdenCompraId",
                table: "LineaCompra",
                column: "OrdenCompraId",
                principalTable: "OrdenCompra",
                principalColumn: "OrdenCompraId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaCompra_Producto_ProductoId",
                table: "LineaCompra",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaCompra_Departamento_DepartamentoId",
                table: "LineaCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaCompra_OrdenCompra_OrdenCompraId",
                table: "LineaCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaCompra_Producto_ProductoId",
                table: "LineaCompra");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "LineaCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenCompraId",
                table: "LineaCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "LineaCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaCompra_Departamento_DepartamentoId",
                table: "LineaCompra",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaCompra_OrdenCompra_OrdenCompraId",
                table: "LineaCompra",
                column: "OrdenCompraId",
                principalTable: "OrdenCompra",
                principalColumn: "OrdenCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaCompra_Producto_ProductoId",
                table: "LineaCompra",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId");
        }
    }
}
