using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class Eliminacionencascada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaSalida_Salida_SalidaId",
                table: "LineaSalida");

            migrationBuilder.AlterColumn<int>(
                name: "SalidaId",
                table: "LineaSalida",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaSalida_Salida_SalidaId",
                table: "LineaSalida",
                column: "SalidaId",
                principalTable: "Salida",
                principalColumn: "SalidaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaSalida_Salida_SalidaId",
                table: "LineaSalida");

            migrationBuilder.AlterColumn<int>(
                name: "SalidaId",
                table: "LineaSalida",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaSalida_Salida_SalidaId",
                table: "LineaSalida",
                column: "SalidaId",
                principalTable: "Salida",
                principalColumn: "SalidaId");
        }
    }
}
