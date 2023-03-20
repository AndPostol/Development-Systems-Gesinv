using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class EliminacionRequisicionyAtributoCodigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salida_Requisicion_RequisicionId",
                table: "Salida");

            migrationBuilder.DropTable(
                name: "Requisicion");

            migrationBuilder.DropIndex(
                name: "IX_Salida_RequisicionId",
                table: "Salida");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Salida");

            migrationBuilder.DropColumn(
                name: "RequisicionId",
                table: "Salida");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "CodigoIngreso",
                table: "Ingreso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Salida",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RequisicionId",
                table: "Salida",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Proveedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodigoIngreso",
                table: "Ingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Requisicion",
                columns: table => new
                {
                    RequisicionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenCompraId = table.Column<int>(type: "int", nullable: true),
                    CodigoRequisicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicion", x => x.RequisicionId);
                    table.ForeignKey(
                        name: "FK_Requisicion_Departamento_OrdenCompraId",
                        column: x => x.OrdenCompraId,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salida_RequisicionId",
                table: "Salida",
                column: "RequisicionId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicion_OrdenCompraId",
                table: "Requisicion",
                column: "OrdenCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salida_Requisicion_RequisicionId",
                table: "Salida",
                column: "RequisicionId",
                principalTable: "Requisicion",
                principalColumn: "RequisicionId");
        }
    }
}
