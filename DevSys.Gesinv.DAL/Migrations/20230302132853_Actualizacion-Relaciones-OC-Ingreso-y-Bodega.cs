using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class ActualizacionRelacionesOCIngresoyBodega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompra_CondicionPago_CondicionPagoId",
                table: "OrdenCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompra_Proveedor_ProveedorId",
                table: "OrdenCompra");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "OrdenCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CondicionPagoId",
                table: "OrdenCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BodegaId",
                table: "OrdenCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrdenCompraId",
                table: "Ingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompra_BodegaId",
                table: "OrdenCompra",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_OrdenCompraId",
                table: "Ingreso",
                column: "OrdenCompraId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingreso_OrdenCompra_OrdenCompraId",
                table: "Ingreso",
                column: "OrdenCompraId",
                principalTable: "OrdenCompra",
                principalColumn: "OrdenCompraId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompra_Bodega_BodegaId",
                table: "OrdenCompra",
                column: "BodegaId",
                principalTable: "Bodega",
                principalColumn: "BodegaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompra_CondicionPago_CondicionPagoId",
                table: "OrdenCompra",
                column: "CondicionPagoId",
                principalTable: "CondicionPago",
                principalColumn: "CondicionPagoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompra_Proveedor_ProveedorId",
                table: "OrdenCompra",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_OrdenCompra_OrdenCompraId",
                table: "Ingreso");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompra_Bodega_BodegaId",
                table: "OrdenCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompra_CondicionPago_CondicionPagoId",
                table: "OrdenCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompra_Proveedor_ProveedorId",
                table: "OrdenCompra");

            migrationBuilder.DropIndex(
                name: "IX_OrdenCompra_BodegaId",
                table: "OrdenCompra");

            migrationBuilder.DropIndex(
                name: "IX_Ingreso_OrdenCompraId",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "BodegaId",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OrdenCompraId",
                table: "Ingreso");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "OrdenCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CondicionPagoId",
                table: "OrdenCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompra_CondicionPago_CondicionPagoId",
                table: "OrdenCompra",
                column: "CondicionPagoId",
                principalTable: "CondicionPago",
                principalColumn: "CondicionPagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompra_Proveedor_ProveedorId",
                table: "OrdenCompra",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "ProveedorId");
        }
    }
}
