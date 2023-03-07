using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Models
{
    public class ReporteIngreso
    {
        public int ProveedorId { get; set; }
        public string RazonSocial { get; set; }
        public int OrdenCompraId { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

        public double Precio { get; set; }
    }
}
