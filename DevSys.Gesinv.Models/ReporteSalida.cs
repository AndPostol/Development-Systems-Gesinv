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
        public string? Nombre { get; set; }
        public int MotivoId { get; set; }
        public DateTime IngresoFecha { get; set; }
        public DateTime SalidaFecha { get; set; }
        public int TipoProveedor { get; set; }
        public string? RazonSocial { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public double CostoSalida { get; set; }
    }
}
