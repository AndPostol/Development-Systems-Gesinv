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
        public ReporteRepository(IOptions<ConfigurationConnection> connection) 
        {
            _connection = connection.Value;
        }

        public async Task<List<ReporteIngreso>> obtenerReporteProveedores(
            string? fechaInicio = null,
            string? fechaFin = null,
            string? ruc = null,
            int? codigo = null,
            string? razonSocial = null,
            int? productoId = null)
        {
            List<ReporteIngreso> lst = new List<ReporteIngreso>();
            using (var connection = new SqlConnection(_connection.SQLConnection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_InformeProveedor", connection);
                cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("ruc", ruc);
                cmd.Parameters.AddWithValue("codigo", codigo);
                cmd.Parameters.AddWithValue("razonSocial", razonSocial);
                cmd.Parameters.AddWithValue("producto", productoId);

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
