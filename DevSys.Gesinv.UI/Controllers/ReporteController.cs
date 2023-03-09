using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevSys.Gesinv.UI.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IReporteRepository _service;

        public ReporteController(IReporteRepository service)
        {
            _service = service;
        }



        // GET: ReporteController
        // Reporte/Ingreso
        //[HttpGet("Ingreso")]
        public async Task<IActionResult> Ingreso(
            int? motivo = null, 
            string? fechaInicio = null, 
            string? fechaFin = null, 
            int? bodega = null, 
            int? proveedor = null, 
            int? tipoProducto = null
            )
        {
            List<ReporteIngreso> list = await _service.obtenerReporteIngreso(motivo,fechaInicio,fechaFin,bodega,proveedor,tipoProducto);
            ViewBag.data = list;
            return View();
        }
        //[HttpGet("Salida")]
        public async Task<IActionResult> Salida(
            string? fechaInicio = null,
            string? fechaFin = null,
            int? bodega = null,
            int? proveedor = null,
            int? tipoProducto = null
            )
        {
            List<ReporteSalida> list = await _service.obtenerReporteSalida(fechaInicio, fechaFin, bodega, proveedor, tipoProducto);
            ViewBag.data = list;
            return View();
        }

        //[HttpGet("Proveedor")]
        public async Task<IActionResult> Proveedor(
            string? fechaInicio = null,
            string? fechaFin = null,
            string? ruc = null,
            int? codigo = null,
            string? razonSocial = null,
            int? producto = null
        )

        {
            List<ReporteProveedor> list = await _service.obtenerReporteProveedores(fechaInicio, fechaFin, ruc, codigo, razonSocial, producto);
            ViewBag.data = list;

            return View();
        }
    }
}
 