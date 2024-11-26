using Castle.Core.Internal;
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

        public async Task<List<ReporteIngreso>> obtenerReporteIngreso(int? motivo = null, string? fechaInicio = null, string? fechaFin = null, int? bodega = null, int? proveedor = null, int? tipoProducto = null)
        {
            List<ReporteIngreso> lstReporteIngreso = new List<ReporteIngreso>();
            using (var connection = new SqlConnection(_connection.SQLConnection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_InformeIngreso", connection);
                cmd.Parameters.AddWithValue("motivo", motivo);
                cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("bodega", bodega);
                cmd.Parameters.AddWithValue("proveedor", proveedor);
                cmd.Parameters.AddWithValue("tipoProducto", tipoProducto);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        Console.WriteLine(dr["MotivoId"]);
                        lstReporteIngreso.Add(new ReporteIngreso()
                        {
                            ProductoId = Convert.ToInt32(dr["ProductoId"]),
                            Nombre = dr["Nombre"].ToString(),
                            MotivoId = Convert.ToInt32(String.IsNullOrEmpty(dr["MotivoId"].ToString()) ? 0 : dr["MotivoId"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioBruto = Convert.ToDouble(dr["PrecioBruto"])
                        });
                    }
                }
                return lstReporteIngreso;
            }
        }

        public async Task<List<ReporteProveedor>> obtenerReporteProveedores(
            string? fechaInicio = null,
            string? fechaFin = null,
            string? ruc = null,
            int? codigo = null,
            string? razonSocial = null,
            int? productoId = null)
        {
            List<ReporteProveedor> lstReporteProveedor = new List<ReporteProveedor>();
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
                        lstReporteProveedor.Add(new ReporteProveedor
                        {
                            ProveedorId = Convert.ToInt32(dr["ProveedorId"]),
                            RazonSocial = dr["RazonSocial"].ToString() ?? "No asignado",
                            OrdenCompraId = Convert.ToInt32(dr["OrdenCompraId"]),
                            ProductoId = Convert.ToInt32(dr["ProductoId"]),
                            Nombre = dr["Nombre"].ToString() ?? "No asignado",
                            Fecha = Convert.ToDateTime(dr["Fecha"] ?? DateTime.Now),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Precio = Convert.ToDouble(dr["Precio"])
                        });

                    }
                }
            }
            return lstReporteProveedor;
        }

        public async Task<List<ReporteSalida>> obtenerReporteSalida(string? fechaInicio = null, string? fechaFin = null, int? bodega = null, int? proveedor = null, int? tipoProducto = null)
        {
            List<ReporteSalida> lstReporteSalida = new List<ReporteSalida>();
            using (var connection = new SqlConnection(_connection.SQLConnection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("sp_InformeSalida", connection);
                cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("bodega", bodega);
                cmd.Parameters.AddWithValue("proveedor", proveedor);
                cmd.Parameters.AddWithValue("tipoProducto", tipoProducto);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lstReporteSalida.Add(new ReporteSalida()
                        {
                            ProductoId = Convert.ToInt32(dr["ProductoId"]),
                            Nombre = dr["Nombre"].ToString(),
                            MotivoId = Convert.ToInt32(dr["MotivoId"]),
                            IngresoFecha = Convert.ToDateTime(dr["Ingreso"]),
                            SalidaFecha = Convert.ToDateTime(dr["Salida"]),
                            TipoProveedor = Convert.ToInt32(dr["TipoProveedor"]),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Stock = Convert.ToInt32(dr["Stock"]),
                            CostoSalida = Convert.ToDouble(dr["CostoSalida"])
                        });
                    }
                }
                return lstReporteSalida;
            }
        }
    }
}