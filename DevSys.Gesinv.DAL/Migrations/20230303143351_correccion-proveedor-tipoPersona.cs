using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class correccionproveedortipoPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_TipoPersona_TipoPersonaNavigationTipoPersonaId",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "TipoPersona",
                table: "Proveedor");

            migrationBuilder.RenameColumn(
                name: "TipoPersonaNavigationTipoPersonaId",
                table: "Proveedor",
                newName: "TipoPersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Proveedor_TipoPersonaNavigationTipoPersonaId",
                table: "Proveedor",
                newName: "IX_Proveedor_TipoPersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_TipoPersona_TipoPersonaId",
                table: "Proveedor",
                column: "TipoPersonaId",
                principalTable: "TipoPersona",
                principalColumn: "TipoPersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_TipoPersona_TipoPersonaId",
                table: "Proveedor");

            migrationBuilder.RenameColumn(
                name: "TipoPersonaId",
                table: "Proveedor",
                newName: "TipoPersonaNavigationTipoPersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Proveedor_TipoPersonaId",
                table: "Proveedor",
                newName: "IX_Proveedor_TipoPersonaNavigationTipoPersonaId");

            migrationBuilder.AddColumn<int>(
                name: "TipoPersona",
                table: "Proveedor",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_TipoPersona_TipoPersonaNavigationTipoPersonaId",
                table: "Proveedor",
                column: "TipoPersonaNavigationTipoPersonaId",
                principalTable: "TipoPersona",
                principalColumn: "TipoPersonaId");
        }
    }
}
