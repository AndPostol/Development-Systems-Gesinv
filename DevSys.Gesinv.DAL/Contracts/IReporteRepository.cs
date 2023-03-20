using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.DAL.Contracts
{
    public interface IReporteRepository
    {
        Task<List<ReporteProveedor>> obtenerReporteProveedores(
            string? fechaInicio,
            string? fechaFin,
            string? ruc,
            int? codigo,
            string? razonSocial,
            int? productoId);
        Task<List<ReporteIngreso>> obtenerReporteIngreso(
            int? motivo,
            string? fechaInicio,
            string? fechaFin,
            int? bodega,
            int? proveedor,
            int? tipoProducto
            );
        Task<List<ReporteSalida>> obtenerReporteSalida(
            string? fechaInicio,
            string? fechaFin,
            int? bodega,
            int? proveedor,
            int? tipoProducto
            );
    }
}
