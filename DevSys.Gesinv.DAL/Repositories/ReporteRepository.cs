using DevSys.Gesinv.DAL.Configuration;
using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.DAL.DataContext;
using DevSys.Gesinv.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly ConfigurationConnection _connection;
        private readonly string _conn = "Data Source=localhost;Initial Catalog=DbInventario;Integrated Security=True;Trust Server Certificate=True;";
        public ReporteRepository(IOptions<ConfigurationConnection> connection) 
        {
            _connection = connection.Value;
        }

        public async Task<List<ReporteIngreso>> obtenerReporteProveedores()
        {
            List<ReporteIngreso> lst = new List<ReporteIngreso>();
            using (var connection = new SqlConnection(_conn))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_InformeProveedor", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lst.Add(new ReporteIngreso
                        {
                            ProveedorId = Convert.ToInt32(dr["ProveedorId"]),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            OrdenCompraId = Convert.ToInt32(dr["OrdenCompraId"]),
                            ProductoId = Convert.ToInt32(dr["ProductoId"]),
                            Nombre = dr["Nombre"].ToString(),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Precio = Convert.ToDouble(dr["Precio"])
                        });

                    }
                }
            }
            return lst;
        }
    }
}
