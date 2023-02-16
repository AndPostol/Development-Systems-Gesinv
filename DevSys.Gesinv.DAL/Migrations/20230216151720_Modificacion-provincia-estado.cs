using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class Modificacionprovinciaestado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Provincia1",
                table: "Provincia",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Estado1",
                table: "Estado",
                newName: "Nombre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Provincia",
                newName: "Provincia1");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Estado",
                newName: "Estado1");
        }
    }
}
