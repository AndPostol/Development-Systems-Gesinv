using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository _repository;
        public ReporteService(IReporteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ReporteIngreso>> obtenerReporteIngreso(int? motivo, string? fechaInicio, string? fechaFin, int? bodega, int? proveedor, int? tipoProducto)
        {
            List<ReporteIngreso> result = await _repository.obtenerReporteIngreso(motivo,fechaInicio,fechaFin,bodega,proveedor,tipoProducto);
            return result;
        }

        public async Task<List<ReporteProveedor>> obtenerReporteProveedores(string? fechaInicio, string? fechaFin, string? ruc, int? codigo, string? razonSocial, int? productoId)
        {
            List<ReporteProveedor> result = await _repository.obtenerReporteProveedores(fechaInicio,fechaFin,ruc,codigo,razonSocial,productoId);
            return result;
        }

        public async Task<List<ReporteSalida>> obtenerReporteSalida(string? fechaInicio, string? fechaFin, int? bodega, int? proveedor, int? tipoProducto)
        {
            List<ReporteSalida> result = await _repository.obtenerReporteSalida( fechaInicio, fechaFin, bodega, proveedor, tipoProducto);
            return result;
        }
    }
}
