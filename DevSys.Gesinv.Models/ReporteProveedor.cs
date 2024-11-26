using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Models
{
    public class ReporteProveedor
    {
        public int ProveedorId { get; set; }
        public string RazonSocial { get; set; } = "No asignado";
        public int OrdenCompraId { get; set; } = 0;
        public int ProductoId { get; set; } = 0;
        public string Nombre { get; set; } = "No asignado";
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; } = 0;

        public double Precio { get; set; } = 0;
    }
}
