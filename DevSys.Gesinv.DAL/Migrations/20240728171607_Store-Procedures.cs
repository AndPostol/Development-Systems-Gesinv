using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSys.Gesinv.DAL.Migrations
{
    public partial class StoreProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string path = "StoreProcedure/";

            string pathInformeProveedor = path + "sp_InformeProveedor.sql";
            migrationBuilder.Sql(File.ReadAllText(pathInformeProveedor));

            string pathInformeSalida = path + "sp_InformeSalida.sql";
            migrationBuilder.Sql(File.ReadAllText(pathInformeSalida));

            string pathReporteIngreso = path + "sp_ReporteIngreso.sql";
            migrationBuilder.Sql(File.ReadAllText(pathReporteIngreso));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE sp_InformeProveedor");
            migrationBuilder.Sql("DROP PROCEDURE sp_InformeSalida");
            migrationBuilder.Sql("DROP PROCEDURE sp_InformeIngreso");
        }
    }
}
