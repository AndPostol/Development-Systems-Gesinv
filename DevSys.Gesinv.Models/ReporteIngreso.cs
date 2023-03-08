using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Models
{
    public class ReporteIngreso
    {
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public int MotivoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public double PrecioBruto { get; set; }
    }
}
