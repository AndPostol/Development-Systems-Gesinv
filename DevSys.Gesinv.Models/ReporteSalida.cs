using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Models
{
    public class ReporteSalida
    {
        public int ProductoId { get; set; }
        public string? Nombre { get; set; } = "No asignado";
        public int MotivoId { get; set; } = 0;
        public DateTime IngresoFecha { get; set; }
        public DateTime SalidaFecha { get; set; }
        public int TipoProveedor { get; set; } = 0;
        public string? RazonSocial { get; set; } = "No asignado";
        public int Cantidad { get; set; } = 0;
        public int Stock { get; set; } = 0;
        public double CostoSalida { get; set; } = 0;
    }
}
